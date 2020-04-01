// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinModDummyTreeComponent} from './mod-dummy-tree.component';
import {AppSkinModDummyTreePageIndexComponent} from './pages/index/mod-dummy-tree-page-index.component';
import {AppSkinModDummyTreePageItemComponent} from './pages/item/mod-dummy-tree-page-item.component';
import {AppSkinModDummyTreePageListComponent} from './pages/list/mod-dummy-tree-page-list.component';
import {AppSkinBaseModule} from '../../base/base.module';
import {AppSkinCoreModule} from '../../core/core.module';
import {AppSkinHostModule} from '../../host/host.module';

/** Мод "DummyTree". Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    AppSkinHostModule
  ],
  exports: [
    AppSkinModDummyTreeComponent,
    AppSkinModDummyTreePageIndexComponent,
    AppSkinModDummyTreePageItemComponent,
    AppSkinModDummyTreePageListComponent
  ],
  declarations: [
    AppSkinModDummyTreeComponent,
    AppSkinModDummyTreePageIndexComponent,
    AppSkinModDummyTreePageItemComponent,
    AppSkinModDummyTreePageListComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyTreeModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModDummyTreeModule {
}
