// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppCoreSpinnerService} from '@app/core/spinner/core-spinner.service';
import {AppSkinCoreDialogAlertComponent} from './dialog/alert/core-dialog-alert.component';
import {AppSkinCoreDialogConfirmComponent} from './dialog/confirm/core-dialog-confirm.component';
import {AppSkinCoreDialogService} from './dialog/core-dialog.service';
import {AppSkinCoreNotificationService} from './notification/core-notification.service';
import {AppSkinCoreNotificationErrorComponent} from './notification/error/core-notification-error.component';
import {AppSkinCoreNotificationInfoComponent} from './notification/info/core-notification-info.component';
import {AppSkinCoreNotificationSuccessComponent} from './notification/success/core-notification-succsess.component';
import {AppSkinCoreProgressSpinnerComponent} from './progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from './progress/spinner/core-progress-spinner.directive';
import {AppSkinCoreSpinnerComponent} from './spinner/core-spinner.component';
import {AppSkinCoreSpinnerService} from './spinner/core-spinner.service';
import {AppSkinBaseModule} from '../base/base.module';

/** Приложение. Оболочка. Ядро. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinBaseModule
  ],
  exports: [
    AppSkinCoreDialogAlertComponent,
    AppSkinCoreDialogConfirmComponent,
    AppSkinCoreNotificationErrorComponent,
    AppSkinCoreNotificationInfoComponent,
    AppSkinCoreNotificationSuccessComponent,
    AppSkinCoreProgressSpinnerComponent,
    AppSkinCoreProgressSpinnerDirective,
    AppSkinCoreSpinnerComponent
  ],
  declarations: [
    AppSkinCoreDialogAlertComponent,
    AppSkinCoreDialogConfirmComponent,
    AppSkinCoreNotificationErrorComponent,
    AppSkinCoreNotificationInfoComponent,
    AppSkinCoreNotificationSuccessComponent,
    AppSkinCoreProgressSpinnerComponent,
    AppSkinCoreProgressSpinnerDirective,
    AppSkinCoreSpinnerComponent
  ],
  entryComponents: [
    AppSkinCoreDialogAlertComponent,
    AppSkinCoreDialogConfirmComponent,
    AppSkinCoreNotificationErrorComponent,
    AppSkinCoreNotificationInfoComponent,
    AppSkinCoreNotificationSuccessComponent,
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
        {provide: AppCoreDialogService, useClass: AppSkinCoreDialogService},
        {provide: AppCoreNotificationService, useClass: AppSkinCoreNotificationService},
        {provide: AppCoreSpinnerService, useClass: AppSkinCoreSpinnerService}
      ]
    };
  }
}
