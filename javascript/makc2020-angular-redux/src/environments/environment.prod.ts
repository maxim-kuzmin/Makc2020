const hostPort = 4201;

export const environment = {
  apiServerUrl: `http://localhost:5002`,
  authTypeOidcIsEnabled: false,
  identityServerUrl: `http://localhost:6002`,
  hostPort: hostPort,
  hostUrl: `http://localhost:${hostPort}`,
  production: true
};
