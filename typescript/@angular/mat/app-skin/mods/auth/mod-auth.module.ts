// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinModAuthComponent} from './mod-auth.component';
import {AppSkinModAuthPageIndexComponent} from './pages/index/mod-auth-page-index.component';
import {AppSkinModAuthPageLogonComponent} from './pages/logon/mod-auth-page-logon.component';
import {AppSkinModAuthPageRegisterComponent} from './pages/register/mod-auth-page-register.component';
import {AppSkinBaseModule} from '../../base/base.module';
import {AppSkinCoreModule} from '../../core/core.module';

/** Приложение. Оболочка. Модуль. */
@NgModule({
  imports: [
    AppSkinBaseModule,
    AppSkinCoreModule
  ],
  exports: [
    AppSkinModAuthComponent,
    AppSkinModAuthPageIndexComponent,
    AppSkinModAuthPageLogonComponent,
    AppSkinModAuthPageRegisterComponent
  ],
  declarations: [
    AppSkinModAuthComponent,
    AppSkinModAuthPageIndexComponent,
    AppSkinModAuthPageLogonComponent,
    AppSkinModAuthPageRegisterComponent
  ],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthModule.name},
    AppCoreLoggingService
  ]
})
export class AppSkinModAuthModule {
}
