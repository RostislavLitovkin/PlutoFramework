﻿using Newtonsoft.Json;
using System.Text.RegularExpressions;
using UniqueryPlus.Metadata;

namespace UniqueryPlus.Ipfs
{
    public static class IpfsModel
    {
        private static HttpClient httpClient = new HttpClient();
        public static async Task<ImageTypeEnum> GetImageTypeAsync(this string ipfsLink)
        {
            var response = await httpClient.GetAsync(ipfsLink, HttpCompletionOption.ResponseHeadersRead);

            foreach (var x in response.Headers)
            {
                Console.WriteLine(x.Key + ": ");
                foreach (string values in x.Value)
                {
                    Console.WriteLine("    " + values);
                }
            }

            var contentTypeReturned = response.Headers.TryGetValues("Content-Type", out var contentTypes);

            if (!contentTypeReturned)
            {
                Console.WriteLine("Type not found");
                return ImageTypeEnum.Unknown;
            }

            Console.WriteLine("Type found: " + contentTypes?.First());

            return contentTypes?.First() switch
            {
                "image/jpeg" => ImageTypeEnum.Image,
                _ => ImageTypeEnum.Unknown,
            };
        }
        public static async Task<T?> GetMetadataAsync<T>(string ipfsLink, CancellationToken token) where T : IMetadataImage
        {
            var metadataJson = await FetchIpfsAsync(ToIpfsLink(ipfsLink), token);

            var metadata = JsonConvert.DeserializeObject<T>(metadataJson);

            if (metadata is null)
            {
                return metadata;
            }

            metadata.Image = metadata.Image is null ? "" : ToIpfsLink(metadata.Image);
            return metadata;
        }
        public static string ToIpfsLink(string ipfsLink, string ipfsEndpoint = Constants.KODA_IPFS_ENDPOINT)
        {
            if (ipfsLink.Contains("ipfs//"))
            {
                return ipfsEndpoint + ipfsLink.Remove(0, "ipfs//".Length + ipfsLink.IndexOf("ipfs//"));
            }

            if (ipfsLink.Contains("ipfs/"))
            {
                return ipfsEndpoint + ipfsLink.Remove(0, "ipfs/".Length + ipfsLink.IndexOf("ipfs/"));
            }

            if (ipfsLink.Contains("ipfs://"))
            {
                return ipfsEndpoint + ipfsLink.Remove(0, "ipfs://".Length + ipfsLink.IndexOf("ipfs://"));
            }

            if (ipfsLink.Contains("http://") || ipfsLink.Contains("https://"))
            {

                return ipfsLink.Substring(ipfsLink.IndexOf("http"));
            }

            return ipfsEndpoint + RemoveNonHexadecimalCharacters(ipfsLink);
        }

        public static Task<string> FetchIpfsAsync(string ipfsLink, CancellationToken token) => httpClient.GetStringAsync(ToIpfsLink(ipfsLink), token);
        
        private static string RemoveNonHexadecimalCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            Regex regex = new Regex("[^0-9a-zA-Z]", RegexOptions.IgnoreCase);

            if (input.Contains("/"))
            {
                string[] inputSplit = input.Split("/", 2);

                return regex.Replace(inputSplit[0], "") + "/" + inputSplit[1];
            }
            else
            {
                return regex.Replace(input, "");
            }
        }
    }
}
