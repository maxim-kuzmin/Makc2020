// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {NgModule, Optional, SkipSelf} from '@angular/core';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppSkinModAuthModule} from '@app-skin/mods/auth/mod-auth.module';
import {AppModAuthRoutingModule} from './mod-auth-routing.module';
import {AppModAuthPageIndexStoreEffects} from './pages/index/store/mod-auth-page-index-store.effects';
import {AppModAuthPageLogonStoreEffects} from './pages/logon/store/mod-auth-page-logon-store.effects';
import {AppModAuthPageRedirectStoreEffects} from './pages/redirect/store/mod-auth-page-redirect-store.effects';
import {AppModAuthPageRegisterStoreEffects} from './pages/register/store/mod-auth-page-register-store.effects';
import {appModAuthStoreReducers} from './store/mod-auth-store.reducers';
import {appModAuthStoreConfigFeatureName} from './store/mod-auth-store-config';

/** Мод "Auth". Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppModAuthRoutingModule,
    AppSkinModAuthModule,
    StoreModule.forFeature(appModAuthStoreConfigFeatureName, appModAuthStoreReducers),
    EffectsModule.forFeature([
      AppModAuthPageIndexStoreEffects,
      AppModAuthPageLogonStoreEffects,
      AppModAuthPageRedirectStoreEffects,
      AppModAuthPageRegisterStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppModAuthModule.name},
    AppCoreLoggingService
  ]
})
export class AppModAuthModule {

  /**
   * Конструктор.
   * @param {AppModAuthModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppModAuthModule
  ) {
    if (parentModule) {
      throw new Error(`${AppModAuthModule.name} is already loaded.`);
    }
  }
}

