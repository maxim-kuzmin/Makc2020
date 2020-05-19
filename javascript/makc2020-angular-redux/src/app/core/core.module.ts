// //Author Maxim Kuzmin//makc//

import {CommonModule} from '@angular/common';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {ModuleWithProviders, NgModule, Optional, SkipSelf} from '@angular/core';
import {AppCoreAuthInterceptor} from './auth/core-auth-interceptor';
import {AppCoreEmptyComponent} from './empty/core-empty.component';
import {AppCoreHttpInterceptor} from './http/core-http-interceptor';
import {appCoreLoggingDiTokenLoggerName} from './logging/core-logging-di';
import {AppCoreLoggingService} from './logging/core-logging.service';
import {AppCoreViewHostDirective} from './view/core-view-host.directive';
import {AppCoreViewComponent} from './view/core-view.component';

/** Ядро. Модуль. */
@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    AppCoreViewComponent
  ],
  declarations: [
    AppCoreEmptyComponent,
    AppCoreViewComponent,
    AppCoreViewHostDirective
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppCoreModule.name},
    AppCoreLoggingService
  ]
})
export class AppCoreModule {

  /**
   * Конструктор.
   * @param {AppCoreModule} parentModule Модуль, внедрённый родительским инжектором.
   */
  constructor(
    @Optional() @SkipSelf() parentModule: AppCoreModule
  ) {
    if (parentModule) {
      throw new Error(`${AppCoreModule.name} is already loaded.`);
    }
  }

  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders<AppCoreModule> {
    return {
      ngModule: AppCoreModule,
      providers: [
        {provide: HTTP_INTERCEPTORS, useClass: AppCoreAuthInterceptor, multi: true},
        {provide: HTTP_INTERCEPTORS, useClass: AppCoreHttpInterceptor, multi: true}
      ]
    };
  }
}
