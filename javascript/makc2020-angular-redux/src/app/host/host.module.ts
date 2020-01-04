// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule, Optional, SkipSelf} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '../core/logging/core-logging-di';
import {AppCoreLoggingService} from '../core/logging/core-logging.service';
import {StoreModule} from '@ngrx/store';
import {EffectsModule} from '@ngrx/effects';
import {AppHostLayoutFooterStoreEffects} from './layout/footer/store/host-layout-footer-store.effects';
import {AppHostLayoutMenuStoreEffects} from './layout/menu/store/host-layout-menu-store.effects';
import {appHostStoreConfigFeatureName} from './store/host-store-config';
import {appHostStoreReducers} from './store/host-store.reducers';
import {AppHostPartAuthStore} from './parts/auth/host-part-auth-store';
import {AppHostPartMenuStore} from './parts/menu/host-part-menu-store';
import {AppSkinHostModule} from '@app-skin/host/host.module';

/** Хост. Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppSkinHostModule,
    StoreModule.forFeature(appHostStoreConfigFeatureName, appHostStoreReducers),
    EffectsModule.forFeature([
      AppHostLayoutFooterStoreEffects,
      AppHostLayoutMenuStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppHostModule.name},
    AppCoreLoggingService
  ]
})
export class AppHostModule {

  /**
   * Конструктор.
   * @param {AppHostModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppHostModule
  ) {
    if (parentModule) {
      throw new Error(`${AppHostModule.name} is already loaded.`);
    }
  }

  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppHostModule,
      providers: [
        AppHostPartAuthStore,
        AppHostPartMenuStore
      ]
    };
  }
}
