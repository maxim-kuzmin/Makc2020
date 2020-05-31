const hostPort = 4201;

export const environment = {
  apiServerLangParamName: 'lang',
  apiServerUrl: `http://localhost:5002`,
  authTypeOidcIsEnabled: true,
  identityServerUrl: `http://localhost:6002`,
  hostLangParamName: 'lang',
  hostPort: hostPort,
  hostUrl: `http://localhost:${hostPort}`,
  production: true
};
