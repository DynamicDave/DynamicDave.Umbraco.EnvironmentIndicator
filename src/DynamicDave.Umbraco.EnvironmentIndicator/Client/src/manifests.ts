export const manifests: Array<UmbExtensionManifest> = [
  {
    type: 'headerApp',
    alias: 'DynamicDave.EnvironmentIndicator.HeaderApp',
    name: 'Environment Indicator Header App',
    element: () => import('./environment-badge.element.js'),
    weight: 1000,
  },
  {
    type: 'localization',
    alias: 'DynamicDave.EnvironmentIndicator.Localization.En',
    name: 'Environment Indicator English',
    weight: -100,
    meta: { culture: 'en' },
    js: () => import('./localization/en.js'),
  },
  {
    type: 'localization',
    alias: 'DynamicDave.EnvironmentIndicator.Localization.Nl',
    name: 'Environment Indicator Dutch',
    weight: -100,
    meta: { culture: 'nl' },
    js: () => import('./localization/nl.js'),
  },
];
