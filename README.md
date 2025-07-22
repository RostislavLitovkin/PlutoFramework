# PlutoFramework

All in one framework for creating web3 mobile applications.

Have you ever dreamed of having your own mobile application with web3 functionalities, while all other competitors are stuck on clunky websites? But you do not have so many developers to create you the UI for both Android and iOS? Then PlutoFramework might be the perfect choice for you!

Learn more in the official developer documentation: https://plutolabs.gitbook.io/plutoframework

## Supported platforms

- Android & WearOS
- iOS & ipadOS
- MacCatalyst
- Windows

## PlutoFramework functionalities

- [✅] Create a new seed-phrase based hot wallet right in the app (Easy on-boarding)
- [✅] Export the account to be used in other applications and wallets (seed-phrase and json export)
- [✅] Import an existing seed-phrase based or json account
- [🕔] Web2 based login and account creation
- [🕔] Account-abstraction login and account creation
- [✅] Create a new Kilt DID
- [✅] Export your Kilt DID
- [✅] Import existing Kilt DID
- [✅] Complete KYC powered by SumSub
- [✅] Display any website right in the application
- [✅] Connect to any Substrate-based blockchain
- [✅] Interact with EVM-based smart contracts
- [🟩] Interact with ink!-based smart contracts
- [✅] Track submitted transaction status in real-time
- [✅] fetching asset balance from **Balances**, **Assets** and **Tokens** pallet
- [✅] transfer of assets from **Balances**, **Assets** and **Tokens** pallet
- [✅] Hold tokens and see the actual balance
- [✅] Transfer tokens to other accounts
- [🕔] Token swaps powered by Hydration
- [✅] View your liquidity positions in Hydration omnipool
- [✅] View your DCA positions on Hydration
- [▶️] Token on-ramp
- [🕔] Token off-ramp
- [✅] View all nft information (nfts pallet, uniques pallet) powered by UniqueryPlus
- [✅] Buy and sell nfts (nfts pallet, uniques pallet) powered by UniqueryPlus
- [✅] Use any GraphQL indexer (Subsquid, Subquery, ...)
- [✅] AZERO.ID ink! contracts
- [✅] View opengov referenda
- [🕔] Opengov voting
- [✅] View your opengov delegations
- [✅] View your vDOT liquid staking amount powered by Bifrost
- [✅] Ensure that the user knows what they are signing thanks to [TransactionAnalyzer](https://plutolabs.gitbook.io/plutoframework/make-your-application/transaction-analyzer).
- [✅] NftMarketplace pallet developed by Xcavate
- [▶️] Messaging system powered by Kilt
- [🟩] Connect to web app that uses [Polkadot.js/extension](https://github.com/polkadot-js/extension) via Plutonication
- [✅] Custom app splash screen and app icon
- [🕔] If you do not see something you would like to use, just contact us, we can add custom features uppon request.

✅ = Already implemented, 🟩 = Implemented but untested, ▶️ = in development, 🕔 = planned to be added later-on

# Build, Debug and Deploy

## Supported platforms
- Android
- iOS & ipadOS

## Installation

I recommend using Visual Studio 2022: https://visualstudio.microsoft.com/vs/community/

Install .net MAUI: https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation?tabs=vswin

## Steps before running the code

You need to setup the environment variables. Follow this documentation: https://plutolabs.gitbook.io/plutoframework/make-your-application/environment-variables.

## Run the code

Detailed description on how to run the app using Android simulator: https://docs.microsoft.com/en-us/dotnet/maui/get-started/first-app?tabs=vswin&pivots=devices-android

## Deploying the code

Follow the PlutoFramework documentation:

- Android: https://plutolabs.gitbook.io/plutoframework/publish-to-android
- iOS: https://plutolabs.gitbook.io/plutoframework/publish-to-ios

# Security

### 1) Private key generation

- Private key is generated with [RandomNumberGenerator](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator?view=net-7.0) which creates cryptographically strong random values. This entropy is then passed to `Mnemonic.MnemonicFromEntropy(<entropyBytes>, BIP39Wordlist.English);` to generate the mnemonics.

### 2) Secure storage

- Private key / Mnemonics are saved in the Secure storage according to these docs: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage.

# Tech Stack

Tech stack used can be found here: https://plutolabs.gitbook.io/plutoframework/about-plutoframework/tech-stack

# Apps built with PlutoFramework

PlutoFramework is meant to be used and it is!

Here is the list of apps benefiting by this amazing piece of tech.

## realXmarket

A custom made mobile application for Xcavate built with custom design, extra features that were built specifically for this app. A great showcase of what is possible to make with PlutoFramework.

github repo: https://github.com/XcavateBlockchain/realXmarketMobileApp

![realXmarket built with PlutoFramework](https://github.com/user-attachments/assets/1b69433e-d6c6-4eab-b3f4-6f18bbd8c261)

## PlutoWallet

All in 1 application that has all PlutoFramework features and functions.

github repo: https://github.com/RostislavLitovkin/PlutoFramework/tree/PlutoWallet

<img width="1019" alt="Screenshot 2023-11-09 at 23 21 17" src="https://github.com/RostislavLitovkin/PlutoFramework/assets/77352013/e1928376-6c63-46b2-9c35-4e00ec6a9070">

## Wagoi

Expressed an interest to build a mobile application with PlutoFramework.

Learn more from the Polkadot Treasury proposal: https://polkadot.polkassembly.io/referenda/1593
