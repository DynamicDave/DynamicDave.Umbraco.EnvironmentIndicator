# Environment Indicator

Never edit production by accident again. Environment Indicator shows a coloured bar and a header badge in the Umbraco backoffice, so editors always know which environment they are working in.

## Features

- Badge with the environment (LOCAL, ACCEPTANCE/STAGING, PRODUCTION, …) and the host name
- Colours per environment: green for development, amber for acceptance/staging, red for production
- Follows `ASPNETCORE_ENVIRONMENT`, works without configuration
- Labels and colours per environment can be changed in `appsettings.json`

## Compatibility

- Umbraco **17 and 18** (.NET 10)
- Backoffice UI in English, Dutch, German, French and Danish
- Free and open source (MIT)

## Getting started

```
dotnet add package DynamicDave.Umbraco.EnvironmentIndicator
```

Full documentation and configuration: [README on GitHub](https://github.com/DynamicDave/DynamicDave.Umbraco.EnvironmentIndicator/blob/main/src/DynamicDave.Umbraco.EnvironmentIndicator/README.md).
