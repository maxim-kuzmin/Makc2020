// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppCoreSpinnerService} from '@app/core/spinner/core-spinner.service';
import {AppSkinHostDialogService} from '../host/dialog/host-dialog.service';
import {AppSkinHostLayoutCommonMessageService} from './notification/core-notification.service';
import {AppSkinCoreProgressSpinnerComponent} from './progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from './progress/spinner/core-progress-spinner.directive';
import {AppSkinCoreSpinnerComponent} from './spinner/core-spinner.component';
import {AppSkinCoreSpinnerService} from './spinner/core-spinner.service';
import {AppSkinBaseModule} from '../base/base.module';

/** Ядро. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule
  ],
  exports: [
    AppSkinCoreProgressSpinnerComponent,
    AppSkinCoreProgressSpinnerDirective,
    AppSkinCoreSpinnerComponent
  ],
  declarations: [
    AppSkinCoreProgressSpinnerComponent,
    AppSkinCoreProgressSpinnerDirective,
    AppSkinCoreSpinnerComponent
  ],
  entryComponents: [
    AppSkinCoreSpinnerComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinCoreModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinCoreModule {

  /**
   * Получить модуль с провайдерами для корня приложения.
   * @returns {ModuleWithProviders} Модуль с провайдерами.
   */
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AppSkinCoreModule,
      providers: [
        {provide: AppCoreDialogService, useClass: AppSkinHostDialogService},
        {provide: AppCoreNotificationService, useClass: AppSkinHostLayoutCommonMessageService},
        {provide: AppCoreSpinnerService, useClass: AppSkinCoreSpinnerService}
      ]
    };
  }
}
