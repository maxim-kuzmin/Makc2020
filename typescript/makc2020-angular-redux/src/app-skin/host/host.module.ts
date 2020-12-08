// //Author Maxim Kuzmin//makc//

import {ModuleWithProviders, NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinBaseModule} from '../base/base.module';
import {AppSkinCoreModule} from '../core/core.module';
import {AppSkinHostControlValidationMessageComponent} from './controls/validation/message/host-control-validation-message.component';
import {AppSkinHostLayoutFooterComponent} from './layout/footer/host-layout-footer.component';
import {AppSkinHostLayoutHeaderComponent} from './layout/header/host-layout-header.component';
import {AppSkinHostLayoutMenuComponent} from './layout/menu/host-layout-menu.component';

/** Хост. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule,
    FormsModule
  ],
  exports: [
    AppSkinHostControlValidationMessageComponent,
    AppSkinHostLayoutFooterComponent,
    AppSkinHostLayoutHeaderComponent,
    AppSkinHostLayoutMenuComponent
  ],
  declarations: [
    AppSkinHostControlValidationMessageComponent,
    AppSkinHostLayoutFooterComponent,
    AppSkinHostLayoutHeaderComponent,
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
  static forRoot(): ModuleWithProviders<AppSkinHostModule> {
    return {
      ngModule: AppSkinHostModule,
      providers: []
    };
  }
}
