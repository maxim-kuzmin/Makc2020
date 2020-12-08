const hostPort = 4201;

export const environment = {
  apiServerLangParamName: 'lang',
  apiServerUrl: `http://localhost:5002`,
  authTypeOidcIsEnabled: false,
  identityServerUrl: `http://localhost:6002`,
  hostIsFirstLoginParamName: 'core--is-first-login',
  hostIsFirstLoginParamValue: 'true',
  hostLangParamName: 'core--lang',
  hostLangSessionName: 'Lang',
  hostPort,
  hostUrl: `http://localhost:${hostPort}`,
  production: true
};
