// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {ServerModule} from '@angular/platform-server';
import {AppCoreAuthTypeJwtDefault} from './core/auth/types/jwt/core-auth-type-jwt-default';
import {AppCoreDialogDefault} from './core/dialog/core-dialog-default';
import {AppCoreLoggingDefault} from './core/logging/core-logging-default';
import {AppCoreNavigationDefault} from './core/navigation/core-navigation-default';
import {AppCoreStorageDefault} from './core/storage/core-storage-default';
import {AppBaseAuthTypeJwtDefault} from './base/auth/types/jwt/base-auth-type-jwt-default';
import {AppBaseDialogDefault} from './base/dialog/base-dialog-default';
import {AppBaseLoggingDefault} from './base/logging/base-logging-default';
import {AppBaseNavigationDefault} from './base/navigation/base-navigation-default';
import {AppBaseStorageDefault} from './base/storage/base-storage-default';
import {appBaseDiTokenLocalStorage, appBaseDiTokenSessionStorage, appBaseDiTokenWindow} from './base/base-di';
import {AppModule} from './app.module';
import {AppSkinComponent} from '@app-skin/app.component';

@NgModule({
  imports: [
    AppModule,
    ServerModule
  ],
  providers: [
    {provide: AppCoreAuthTypeJwtDefault, useClass: AppBaseAuthTypeJwtDefault, deps: [appBaseDiTokenSessionStorage]},
    {provide: AppCoreDialogDefault, useClass: AppBaseDialogDefault, deps: [appBaseDiTokenWindow]},
    {provide: AppCoreLoggingDefault, useClass: AppBaseLoggingDefault, deps: [appBaseDiTokenWindow]},
    {provide: AppCoreNavigationDefault, useClass: AppBaseNavigationDefault, deps: [appBaseDiTokenWindow]},
    {provide: AppCoreStorageDefault, useClass: AppBaseStorageDefault, deps: [appBaseDiTokenLocalStorage, appBaseDiTokenSessionStorage]}
  ],
  bootstrap: [AppSkinComponent],
})
export class AppServerModule {
}
