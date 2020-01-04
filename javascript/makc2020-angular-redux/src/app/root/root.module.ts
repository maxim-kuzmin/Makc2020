// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule, Optional, SkipSelf} from '@angular/core';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppHostPartAuthService} from '@app/host/parts/auth/host-part-auth.service';
import {AppHostPartMenuDataService} from '@app/host/parts/menu/data/host-part-menu-data.service';
import {AppSkinRootModule} from '@app-skin/root/root.module';
import {AppRootPartMenuDataService} from './parts/menu/data/root-part-menu-data.service';
import {AppRootPartAuthService} from './parts/auth/root-part-auth.service';
import {AppRootRoutingModule} from './root-routing.module';
import {AppRootPageAdministrationStoreEffects} from './pages/administration/store/root-page-administration-store.effects';
import {AppRootPageContactsStoreEffects} from './pages/contacts/store/root-page-contacts-store.effects';
import {AppRootPageErrorStoreEffects} from './pages/error/store/root-page-error-store.effects';
import {AppRootPageIndexStoreEffects} from './pages/index/store/root-page-index-store.effects';
import {AppRootPageSiteStoreEffects} from './pages/site/store/root-page-site-store.effects';
import {appRootStoreReducers} from './store/root-store.reducers';
import {appRootStoreConfigFeatureName} from './store/root-store-config';

/** Корень. Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppRootRoutingModule,
    AppSkinRootModule,
    StoreModule.forFeature(appRootStoreConfigFeatureName, appRootStoreReducers),
    EffectsModule.forFeature([
      AppRootPageAdministrationStoreEffects,
      AppRootPageContactsStoreEffects,
      AppRootPageErrorStoreEffects,
      AppRootPageIndexStoreEffects,
      AppRootPageSiteStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppRootModule.name},
    AppCoreLoggingService
  ]
})
export class AppRootModule {

  /**
   * Конструктор.
   * @param {AppRootModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppRootModule
  ) {
    if (parentModule) {
      throw new Error(`${AppRootModule.name} is already loaded.`);
    }
  }

  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppRootModule,
      providers: [
        {provide: AppHostPartAuthService, useClass: AppRootPartAuthService},
        {provide: AppHostPartMenuDataService, useClass: AppRootPartMenuDataService}
      ]
    };
  }
}
