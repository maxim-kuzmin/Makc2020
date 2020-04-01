// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {NgModule, Optional, SkipSelf} from '@angular/core';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppSkinModDummyTreeModule} from '@app-skin/mods/dummy-tree/mod-dummy-tree.module';
import {AppModDummyTreeRoutingModule} from './mod-dummy-tree-routing.module';
import {AppModDummyTreePageIndexStoreEffects} from './pages/index/store/mod-dummy-tree-page-index-store.effects';
import {AppModDummyTreePageItemStoreEffects} from './pages/item/store/mod-dummy-tree-page-item-store.effects';
import {AppModDummyTreePageListStoreEffects} from './pages/list/store/mod-dummy-tree-page-list-store.effects';
import {appModDummyTreeStoreReducers} from './store/mod-dummy-tree-store.reducers';
import {appModDummyTreeStoreConfigFeatureName} from './store/mod-dummy-tree-store-config';

/** Мод "DummyTree". Модуль. */
@NgModule({
  imports: [
    CommonModule,
    AppModDummyTreeRoutingModule,
    AppSkinModDummyTreeModule,
    StoreModule.forFeature(appModDummyTreeStoreConfigFeatureName, appModDummyTreeStoreReducers),
    EffectsModule.forFeature([
      AppModDummyTreePageIndexStoreEffects,
      AppModDummyTreePageItemStoreEffects,
      AppModDummyTreePageListStoreEffects
    ])
  ],
  declarations: [],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppModDummyTreeModule.name },
    AppCoreLoggingService
  ]
})
export class AppModDummyTreeModule {

  /**
   * Конструктор.
   * @param {AppModDummyTreeModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppModDummyTreeModule
  ) {
    if (parentModule) {
      throw new Error(`${AppModDummyTreeModule.name} is already loaded.`);
    }
  }
}

