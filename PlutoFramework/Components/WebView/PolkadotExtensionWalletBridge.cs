using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using Plutonication;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlutoFramework.Components.WebView;

public record EnablePayload
{
    [JsonPropertyName("origin")]
    public string Origin { get; set; } = string.Empty;

    [JsonPropertyName("tabId")]
    public uint TabId { get; set; }
}

public record DAppInfo
{
    [JsonPropertyName("icon")]
    public required ImageSource Icon { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}

public class PolkadotExtensionWalletBridge
{
    public static TaskCompletionSource<byte[]> SignatureTask = new();

    internal const string ProviderName = "polkadot-js";

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<string> HandleAsync(string requestJson)
    {
        WalletBridgeRequest request;

        try
        {
            request = System.Text.Json.JsonSerializer.Deserialize<WalletBridgeRequest>(requestJson, SerializerOptions)
                ?? throw new InvalidOperationException("Unable to parse wallet bridge request.");
        }
        catch (Exception ex)
        {
            return SerializeResponse(new WalletBridgeResponse
            {
                Id = null,
                Error = ex.Message
            });
        }

        object? result = null;
        string? error = null;

        try
        {
            switch (request.Method)
            {
                case "enable":
                    result = await HandleEnableAsync(request.Payload);
                    break;
                case "accounts.get":
                    result = HandleAccounts();
                    break;
                case "signRaw":
                    result = await HandleSignRawAsync(request).ConfigureAwait(false);
                    break;
                case "signPayload":
                    result = await HandleSignPayloadAsync(request).ConfigureAwait(false);
                    break;
                default:
                    throw new NotSupportedException($"Method '{request.Method}' is not supported by Pluto wallet bridge.");
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }

        return SerializeResponse(new WalletBridgeResponse
        {
            Id = request.Id,
            Result = result,
            Error = error
        });
    }

    private static async Task<object> HandleEnableAsync(JsonElement? payload)
    {
        var allowedOrigins = (string[])Application.Current.Resources["AllowedOrigins"];

        if (payload == null)
        {
            return new { approved = false, provider = ProviderName };
        }

        EnablePayload enablePayload = payload!.Value.Deserialize<EnablePayload>(SerializerOptions)!;

        var dAppInfo = ExtensionWebViewModel.TabInfos[enablePayload.TabId];


        if (allowedOrigins.Any(dAppInfo.Url.Contains))
        {
            return new { approved = true, provider = ProviderName };
        }

        var uri = new Uri(dAppInfo.Url);

        if (ExtensionWebViewModel.ApprovedUrls.TryGetValue(uri.Host, out var cachedApproved) && cachedApproved)
        {
            return new { approved = cachedApproved, provider = ProviderName };
        }

        var popupViewModel = DependencyService.Get<DAppWebViewConnectionRequestPopupViewModel>();
        var approved = await popupViewModel.ShowAsync(dAppInfo);

        ExtensionWebViewModel.ApprovedUrls[uri.Host] = approved;

        return new { approved, provider = ProviderName };
    }

    private static IEnumerable<InjectedAccount> HandleAccounts()
    {
        if (!KeysModel.HasSubstrateKey())
        {
            return [];
        }

        var address = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(KeysModel.GetSubstrateKey()), 0);
        var appName = "Account";

        return [
            new InjectedAccount
            {
                Address = address,
                Meta = new InjectedAccountMeta
                {
                    Name = appName,
                    Source = ProviderName
                }
            }
        ];
    }

    private static async Task<SignerResultPayload> HandleSignRawAsync(WalletBridgeRequest request)
    {
        Console.WriteLine("Sign raw called");

        SignatureTask = new TaskCompletionSource<byte[]>();

        if (!request.Payload.HasValue)
        {
            throw new InvalidOperationException("Missing payload for signRaw request.");
        }

        var signRawPayload = request.Payload.Value.Deserialize<SignRawPayload>(SerializerOptions)
            ?? throw new InvalidOperationException("Unable to parse signRaw payload.");

        Console.WriteLine(signRawPayload);

        if (!KeysModel.HasSubstrateKey())
        {
            throw new InvalidOperationException("No Substrate account is available.");
        }

        var expectedAddress = KeysModel.GetSubstrateKey();
        if (!string.Equals(expectedAddress, signRawPayload.Address, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Requested account does not match the active wallet address.");
        }

        try
        {
            if (signRawPayload.Type != "bytes")
            {
                throw new Exception("Message signing is supported only for bytes format");
            }

            var messageSignRequest = DependencyService.Get<WebSignRawPopupViewModel>();

            messageSignRequest.SignatureTask = SignatureTask;

            messageSignRequest.Message = new RawMessage
            {
                type = signRawPayload.Type,
                data = signRawPayload.Data,
                address = signRawPayload.Address,
            };

            messageSignRequest.IsVisible = true;
        }
        catch (Exception ex)
        {
            var messagePopup = DependencyService.Get<MessagePopupViewModel>();

            messagePopup.Title = "ConnectionRequestView Error";
            messagePopup.Text = ex.Message;

            messagePopup.IsVisible = true;
        }

        var signature = await SignatureTask.Task.ConfigureAwait(false);

        return new SignerResultPayload
        {
            Id = signRawPayload.Id ?? request.Id ?? Guid.NewGuid().ToString("N"),
            Signature = Utils.Bytes2HexString(signature).ToLowerInvariant()
        };
    }

    private static async Task<SignerResultPayload> HandleSignPayloadAsync(WalletBridgeRequest request)
    {
        Console.WriteLine("Sign payload called");

        if (!request.Payload.HasValue)
        {
            throw new InvalidOperationException("Missing payload for signPayload request.");
        }

        var payload = request.Payload.Value.Deserialize<SignerPayloadJson>(SerializerOptions)
            ?? throw new InvalidOperationException("Unable to parse signPayload payload.");

        if (!KeysModel.HasSubstrateKey())
        {
            throw new InvalidOperationException("No Substrate account is available inside Pluto wallet.");
        }

        SignatureTask = new TaskCompletionSource<byte[]>();

        var (unCheckedExtrinsic, runtime) = ToUnCheckedExtrinsic(payload);

        var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

        var substratePayload = unCheckedExtrinsic.GetPayload(runtime);

        if (Endpoints.HashToKey.ContainsKey(payload.GenesisHash))
        {
            Console.WriteLine("Genesis hash found");
            EndpointEnum key = Endpoints.HashToKey[payload.GenesisHash];

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(key, CancellationToken.None);

            await transactionAnalyzerConfirmationViewModel.LoadAsync(
                client,
                unCheckedExtrinsic.ToTempUnCheckedExtrinsic(
                    substratePayload,
                    client.Endpoint.AddressVersion,
                    client.CheckMetadata
                ),
                true,
                onConfirm: OnConfirmClickedAsync,
                runtimeVersion: runtime
            );
        }
        else
        {
            transactionAnalyzerConfirmationViewModel.LoadUnknown(
                unCheckedExtrinsic.ToTempUnCheckedExtrinsic(substratePayload, 2u, true),
                runtime,
                onConfirm: OnConfirmClickedAsync
            );
        }

        var signature = await SignatureTask.Task.ConfigureAwait(false);

        return new SignerResultPayload
        {
            Id = payload.Id ?? request.Id ?? Guid.NewGuid().ToString("N"),
            Signature = Utils.Bytes2HexString(signature).ToLowerInvariant()
        };
    }

    public static async Task OnConfirmClickedAsync()
    {
        try
        {
            var viewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

            var account = await Model.KeysModel.GetAccountAsync();

            if (account is null)
            {
                return;
            }

            byte[] signature = account.Sign(viewModel.Payload.Encode());

            SignatureTask.SetResult(signature);

            // Hide this layout
            viewModel.IsVisible = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            // Handle potential errors
        }
    }

    private static (UnCheckedExtrinsic, RuntimeVersion) ToUnCheckedExtrinsic(SignerPayloadJson payload)
    {
        if (payload.Tip is null || payload.SpecVersion is null ||
                    payload.TransactionVersion is null || payload.Nonce is null)
        {
            throw new WrongMessageReceivedException();
        }

        byte[] methodBytes = Utils.HexToByteArray(payload.Method);

        List<byte> methodParameters = new List<byte>();

        for (int i = 2; i < methodBytes.Length; i++)
        {
            methodParameters.Add(methodBytes[i]);
        }

        Method method = new Method(methodBytes[0], methodBytes[1], methodParameters.ToArray());

        Hash eraHash = new Hash();
        eraHash.Create(Utils.HexToByteArray(payload.Era));

        Hash blockHash = new Hash();
        blockHash.Create(payload.BlockHash);

        Hash genesisHash = new Hash();
        genesisHash.Create(Utils.HexToByteArray(payload.GenesisHash));

        RuntimeVersion runtime = new RuntimeVersion
        {
            ImplVersion = payload.Version,
            SpecVersion = HexStringToUint(payload.SpecVersion),
            TransactionVersion = HexStringToUint(payload.TransactionVersion),
        };

        ChargeType charge;

        if (payload.Tip.Length == 34)
        {
            charge = new ChargeTransactionPayment(HexStringToUint(payload.Tip));
        }
        else
        {
            int _p = 0;

            charge = new ChargeAssetTxPayment(0, new());
            charge.Decode(Utils.HexToByteArray(payload.Tip), ref _p);
        }

        var account = new Substrate.NetApi.Model.Types.Account();
        account.Create(KeyType.Sr25519, Utils.GetPublicKeyFrom(payload.Address));

        return (
            new UnCheckedExtrinsic(true, account, method, Era.Decode(Utils.HexToByteArray(payload.Era)),
                HexStringToUint(payload.Nonce), charge, genesisHash, blockHash),
            runtime
        );
    }

    private static string SerializeResponse(WalletBridgeResponse response)
        => System.Text.Json.JsonSerializer.Serialize(response, SerializerOptions);

    private sealed class WalletBridgeRequest
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("payload")]
        public JsonElement? Payload { get; set; }
    }

    private sealed class WalletBridgeResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("result")]
        public object? Result { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }

    private sealed record SignRawPayload
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public string Data { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    private sealed class SignerPayloadJson
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; } = string.Empty;

        [JsonPropertyName("blockNumber")]
        public string BlockNumber { get; set; } = string.Empty;

        [JsonPropertyName("era")]
        public string Era { get; set; } = string.Empty;

        [JsonPropertyName("genesisHash")]
        public string GenesisHash { get; set; } = string.Empty;

        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = string.Empty;

        [JsonPropertyName("specVersion")]
        public string SpecVersion { get; set; } = string.Empty;

        [JsonPropertyName("tip")]
        public string Tip { get; set; } = string.Empty;

        [JsonPropertyName("transactionVersion")]
        public string TransactionVersion { get; set; } = string.Empty;

        [JsonPropertyName("signedExtensions")]
        public string[] SignedExtensions { get; set; } = Array.Empty<string>();

        // Optional: a pre-encoded SCALE payload (hex) that we will sign.
        // Your JS shim should populate this.
        [JsonPropertyName("data")]
        public string? Data { get; set; }

        // Optional: if your JS assigns a per-request id here
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("version")]
        public uint Version { get; set; }
    }


    private sealed class SignerResultPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("signature")]
        public string Signature { get; set; } = string.Empty;
    }

    private sealed class InjectedAccount
    {
        [JsonPropertyName("address")]
        public required string Address { get; set; }

        [JsonPropertyName("meta")]
        public required InjectedAccountMeta Meta { get; set; }
    }

    private sealed class InjectedAccountMeta
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("source")]
        public required string Source { get; set; }
    }

    /// <summary>
    /// Helper method that translates hex string to uint
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    private static uint HexStringToUint(string hex)
    {
        hex = hex.Replace("0x", ""); // remove the 0x if it's there
        if (uint.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint result))
        {
            return result;
        }
        else
        {
            throw new FormatException("The provided string is not a valid hexadecimal number");
        }
    }
}
