// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinModDummyMainComponent} from './mod-dummy-main.component';
import {AppSkinModDummyMainPageIndexComponent} from './pages/index/mod-dummy-main-page-index.component';
import {AppSkinModDummyMainPageItemComponent} from './pages/item/mod-dummy-main-page-item.component';
import {AppSkinModDummyMainPageListComponent} from './pages/list/mod-dummy-main-page-list.component';
import {AppSkinBaseModule} from '../../base/base.module';
import {AppSkinCoreModule} from '../../core/core.module';
import {AppSkinHostModule} from '../../host/host.module';

/** Мод "DummyMain". Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    AppSkinHostModule
  ],
  exports: [
    AppSkinModDummyMainComponent,
    AppSkinModDummyMainPageIndexComponent,
    AppSkinModDummyMainPageItemComponent,
    AppSkinModDummyMainPageListComponent
  ],
  declarations: [
    AppSkinModDummyMainComponent,
    AppSkinModDummyMainPageIndexComponent,
    AppSkinModDummyMainPageItemComponent,
    AppSkinModDummyMainPageListComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModDummyMainModule {
}
