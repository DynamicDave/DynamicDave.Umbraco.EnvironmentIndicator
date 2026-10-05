export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Dynamic Dave Umbraco Environment Indicator Entrypoint",
    alias: "DynamicDave.Umbraco.EnvironmentIndicator.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint.js"),
  },
];
