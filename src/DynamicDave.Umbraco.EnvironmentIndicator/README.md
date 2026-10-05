# DynamicDave.Umbraco.EnvironmentIndicator

Shows a thin coloured environment bar at the top and a header badge (LOCAL, ACCEPTANCE/STAGING, PRODUCTION, plus the host name) in the Umbraco backoffice, so editors always know which environment they are working in.

## Install

    dotnet add package DynamicDave.Umbraco.EnvironmentIndicator

Supported Umbraco version: **17.x** (net10.0). The backoffice UI is available in English, Dutch, German, French and Danish.

## Configuration

The environment is taken from `ASPNETCORE_ENVIRONMENT`. Built-in defaults: `Development` (green, DEVELOPMENT), `Local` (green, LOCAL), `Staging`/`Acceptance` (amber, ACCEPTANCE/STAGING), `Production` (red, PRODUCTION). Any other name gets its upper-cased name in neutral grey. Override or extend them in `appsettings.json`:

```json
{
  "DynamicDave": {
    "EnvironmentIndicator": {
      "ShowHost": true,
      "Environments": {
        "Staging": { "Label": "ACCEPTANCE", "Color": "#e0a800" },
        "Test": { "Label": "TEST", "Color": "#1565c0" }
      }
    }
  }
}
```

- `ShowHost` (default `true`): show the host name in the header badge.
- `Environments`: per environment name (case-insensitive) a `Label` and a `Color`.

Note: a configured entry replaces the built-in default entirely. If you set only `Label`, `Color` falls back to the neutral grey `#607d8b`, so always set both.

## License

MIT
