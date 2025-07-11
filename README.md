# realXmarket

Mobile version of [realXmarket application](https://realxmarket.xcavate.io/marketplace) powered by Xcavate and secured by Polkadot.

The app is currently under development and is available only for internal testing as of time of writing.

Built using [PlutoFramework](https://plutolabs.gitbook.io/plutoframework) by Pluto Labs.

![realXmarket (1)](https://github.com/user-attachments/assets/26491fc7-4c09-4b91-8eb5-71dd2c4e12f0)

## App functionalities

- [✅] Create a new seed-phrase based hot wallet right in the app (Easy on-boarding)
- [✅] Export the account to be used in other applications and wallets (seed-phrase and json export)
- [✅] Import an existing seed-phrase based or json account
- [🕔] Web2 based login and account creation
- [🕔] Account-abstraction login and account creation
- [✅] Create a new Kilt DID
- [✅] Export your Kilt DID
- [✅] Import existing Kilt DID
- [✅] Complete KYC powered by SumSub
- [▶️] a questionaire to figure out if realXmarket is a right application for the user
- [✅] Hold tokens and see the actual balance
- [✅] Transfer tokens to other accounts
- [▶️] Token on-ramp
- [🕔] Token off-ramp
- [✅] Ensure that the user knows what they are signing thanks to [TransactionAnalyzer](https://plutolabs.gitbook.io/plutoframework/make-your-application/transaction-analyzer) and the custom implemented checks for realXmarket use-cases.
- [✅] Browse real-estate properties in the marketplace tab
- [▶️] Filter the properties by location, price ...
- [✅] View the detailed page of the real-estate property
- [✅] Buy listed property tokens
- [✅] View all owned/bought property tokens
- [🟩] Relist tokens
- [▶️] View relisted tokens
- [▶️] Buy relisted tokens
- [▶️] Messaging system powered by Kilt
- [🟩] Connect to a web version of realXmarket via Plutonication
- [✅] View information about Xcavate
- [✅] Custom app splash screen and app icon

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

# Tech Stack

Tech stack used can be found here: https://plutolabs.gitbook.io/plutoframework/about-plutoframework/tech-stack
