// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinBaseModule} from '../base/base.module';
import {AppSkinCoreModule} from '../core/core.module';
import {AppSkinHostLayoutMenuComponent} from './layout/menu/host-layout-menu.component';

/** Хост. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule
  ],
  exports: [
    AppSkinHostLayoutMenuComponent
  ],
  declarations: [
    AppSkinHostLayoutMenuComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinHostModule {
  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppSkinHostModule,
      providers: []
    };
  }
}
