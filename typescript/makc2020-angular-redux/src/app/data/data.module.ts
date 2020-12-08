// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {ModuleWithProviders, NgModule, Optional, SkipSelf} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '../core/logging/core-logging-di';
import {AppCoreLoggingService} from '../core/logging/core-logging.service';

/** Данные. Модуль. */
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppDataModule.name },
    AppCoreLoggingService
  ]
})
export class AppDataModule {

  /**
   * Конструктор.
   * @param {AppDataModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppDataModule
  ) {
    if (parentModule) {
      throw new Error(`${AppDataModule.name} is already loaded.`);
    }
  }

  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders<AppDataModule> {
    return {
      ngModule: AppDataModule,
      providers: []
    };
  }
}
