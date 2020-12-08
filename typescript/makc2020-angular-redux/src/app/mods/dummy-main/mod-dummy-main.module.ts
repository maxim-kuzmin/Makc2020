// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {NgModule, Optional, SkipSelf} from '@angular/core';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppSkinModDummyMainModule} from '@app-skin/mods/dummy-main/mod-dummy-main.module';
import {AppModDummyMainRoutingModule} from './mod-dummy-main-routing.module';
import {AppModDummyMainPageIndexStoreEffects} from './pages/index/store/mod-dummy-main-page-index-store.effects';
import {AppModDummyMainPageItemStoreEffects} from './pages/item/store/mod-dummy-main-page-item-store.effects';
import {AppModDummyMainPageListStoreEffects} from './pages/list/store/mod-dummy-main-page-list-store.effects';
import {appModDummyMainStoreReducers} from './store/mod-dummy-main-store.reducers';
import {appModDummyMainStoreConfigFeatureName} from './store/mod-dummy-main-store-config';

/** Мод "DummyMain". Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppModDummyMainRoutingModule,
    AppSkinModDummyMainModule,
    StoreModule.forFeature(appModDummyMainStoreConfigFeatureName, appModDummyMainStoreReducers),
    EffectsModule.forFeature([
      AppModDummyMainPageIndexStoreEffects,
      AppModDummyMainPageItemStoreEffects,
      AppModDummyMainPageListStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppModDummyMainModule.name },
    AppCoreLoggingService
  ]
})
export class AppModDummyMainModule {

  /**
   * Конструктор.
   * @param {AppModDummyMainModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppModDummyMainModule
  ) {
    if (parentModule) {
      throw new Error(`${AppModDummyMainModule.name} is already loaded.`);
    }
  }
}

