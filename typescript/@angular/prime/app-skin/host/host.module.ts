// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinBaseModule} from '../base/base.module';
import {AppSkinCoreModule} from '../core/core.module';
import {AppSkinHostCalendarStore} from './calendar/host-calendar-store';
import {AppSkinHostControlValidationMessageComponent} from './controls/validation/message/host-control-validation-message.component';
import {AppSkinHostLayoutHeaderComponent} from './layout/header/host-layout-header.component';
import {AppSkinHostLayoutMenuComponent} from './layout/menu/host-layout-menu.component';
import {AppSkinHostLayoutCommonDialogAlertComponent} from './layout/common/dialogs/alert/host-layout-common-dialog-alert.component';
import {AppSkinHostLayoutCommonDialogConfirmComponent} from './layout/common/dialogs/confirm/host-layout-common-dialog-confirm.component';
import {AppSkinHostLayoutCommonMessageComponent} from './layout/common/message/host-layout-common-message.component';

/** Хост. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    FormsModule
  ],
  exports: [
    AppSkinHostControlValidationMessageComponent,
    AppSkinHostLayoutCommonDialogAlertComponent,
    AppSkinHostLayoutCommonDialogConfirmComponent,
    AppSkinHostLayoutCommonMessageComponent,
    AppSkinHostLayoutHeaderComponent,
    AppSkinHostLayoutMenuComponent
  ],
  declarations: [
    AppSkinHostControlValidationMessageComponent,
    AppSkinHostLayoutCommonDialogAlertComponent,
    AppSkinHostLayoutCommonDialogConfirmComponent,
    AppSkinHostLayoutCommonMessageComponent,
    AppSkinHostLayoutHeaderComponent,
    AppSkinHostLayoutMenuComponent
  ],
  entryComponents: [
    AppSkinHostLayoutCommonDialogAlertComponent,
    AppSkinHostLayoutCommonDialogConfirmComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinHostModule.name},
    AppCoreLoggingService,
    AppSkinHostCalendarStore
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
