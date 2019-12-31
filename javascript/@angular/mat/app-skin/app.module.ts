// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinComponent} from './app.component';
import {AppSkinBaseModule} from './base/base.module';
import {AppSkinCoreModule} from './core/core.module';
import {AppSkinHostModule} from './host/host.module';

/** Приложение. Оболочка. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule.forRoot(),
    AppSkinCoreModule.forRoot(),
    AppSkinHostModule.forRoot()
  ],
  exports: [
    AppSkinComponent
  ],
  declarations: [
    AppSkinComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModule {
}
