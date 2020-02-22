// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinRootPageAdministrationComponent} from './pages/administration/root-page-administration.component';
import {AppSkinRootPageContactsComponent} from './pages/contacts/root-page-contacts.component';
import {AppSkinRootPageErrorComponent} from './pages/error/root-page-error.component';
import {AppSkinRootPageIndexComponent} from './pages/index/root-page-index.component';
import {AppSkinRootPageSiteComponent} from './pages/site/root-page-site.component';
import {AppSkinBaseModule} from '../base/base.module';
import {AppSkinCoreModule} from '../core/core.module';
import {AppSkinHostModule} from '../host/host.module';

/** Корень. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    AppSkinHostModule
  ],
  exports: [
    AppSkinRootPageAdministrationComponent,
    AppSkinRootPageContactsComponent,
    AppSkinRootPageErrorComponent,
    AppSkinRootPageIndexComponent,
    AppSkinRootPageSiteComponent
  ],
  declarations: [
    AppSkinRootPageAdministrationComponent,
    AppSkinRootPageContactsComponent,
    AppSkinRootPageErrorComponent,
    AppSkinRootPageIndexComponent,
    AppSkinRootPageSiteComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinRootModule {
  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders<AppSkinRootModule> {
    return {
      ngModule: AppSkinRootModule,
      providers: []
    };
  }
}
