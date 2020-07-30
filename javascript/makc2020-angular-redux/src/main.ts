// //Author Maxim Kuzmin//makc//

import {enableProdMode} from '@angular/core';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {environment} from './environments/environment';
import {AppCoreAuthTypeJwtDefault} from '@app/core/auth/types/jwt/core-auth-type-jwt-default';
import {AppCoreDialogDefault} from '@app/core/dialog/core-dialog-default';
import {AppCoreNavigationDefault} from '@app/core/navigation/core-navigation-default';
import {AppCoreLoggingDefault} from '@app/core/logging/core-logging-default';
import {appCoreSettings, AppCoreSettings} from '@app/core/core-settings';
import {AppCoreStorageDefault} from '@app/core/storage/core-storage-default';
import {AppBaseAuthTypeJwtDefault} from '@app/base/auth/types/jwt/base-auth-type-jwt-default';
import {AppBaseDialogDefault} from '@app/base/dialog/base-dialog-default';
import {AppBaseLoggingDefault} from '@app/base/logging/base-logging-default';
import {AppBaseNavigationDefault} from '@app/base/navigation/base-navigation-default';
import {AppBaseStorageDefault} from '@app/base/storage/base-storage-default';
import {
  appBaseDiTokenConsole,
  appBaseDiTokenDocument,
  appBaseDiTokenLocalStorage,
  appBaseDiTokenSessionStorage,
  appBaseDiTokenWindow
} from '@app/base/base-di';
import {AppModule} from '@app/app.module';

const providers = [
  {provide: appBaseDiTokenLocalStorage, useValue: window.localStorage},
  {provide: appBaseDiTokenSessionStorage, useValue: window.sessionStorage},
  {provide: appBaseDiTokenConsole, useValue: console},
  {provide: appBaseDiTokenDocument, useValue: document},
  {provide: appBaseDiTokenWindow, useValue: window},
  {provide: AppCoreAuthTypeJwtDefault, useClass: AppBaseAuthTypeJwtDefault, deps: [appBaseDiTokenSessionStorage]},
  {provide: AppCoreDialogDefault, useClass: AppBaseDialogDefault, deps: [appBaseDiTokenWindow]},
  {provide: AppCoreLoggingDefault, useClass: AppBaseLoggingDefault, deps: [appBaseDiTokenConsole]},
  {provide: AppCoreNavigationDefault, useClass: AppBaseNavigationDefault, deps: [AppCoreSettings, appBaseDiTokenDocument]},
  {provide: AppCoreSettings, useValue: appCoreSettings},
  {provide: AppCoreStorageDefault, useClass: AppBaseStorageDefault, deps: [appBaseDiTokenLocalStorage, appBaseDiTokenSessionStorage]}
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
