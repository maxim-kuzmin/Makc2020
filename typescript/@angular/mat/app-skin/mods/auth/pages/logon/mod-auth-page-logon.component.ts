// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModAuthPageLogonComponentName} from '@app/mods/auth/pages/logon/mod-auth-page-logon.component';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModAuthPageLogonView} from './mod-auth-page-logon-view';
import {AppModAuthPageLogonPresenter} from '@app/mods/auth/pages/logon/mod-auth-page-logon-presenter';
import {AppModAuthPageLogonContext} from '@app/mods/auth/pages/logon/mod-auth-page-logon-context';
import {AppModAuthPageLogonStore} from '@app/mods/auth/pages/logon/mod-auth-page-logon-store';

/** Мод "Auth". Страницы. Вход в систему. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModAuthPageLogonComponentName),
  templateUrl: './mod-auth-page-logon.component.html',
  styleUrls: ['./mod-auth-page-logon.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageLogonComponent.name },
    AppCoreLoggingService,
    AppModAuthPageLogonContext,
    AppModAuthPageLogonStore
  ]
})
export class AppSkinModAuthPageLogonComponent implements AfterViewInit, OnDestroy {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading', { static: false }) private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', { static: true }) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', { static: true }) private ctrlForm: NgForm;

  /**
   * Мой представитель.
   * @type {AppModAuthPageLogonPresenter}
   */
  myPresenter: AppModAuthPageLogonPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModAuthPageLogonView}
   */
  myView: AppSkinModAuthPageLogonView;

  /**
   * Конструктор.
   * @param {AppModAuthPageLogonContext} context Контекст.
   */
  constructor(
    context: AppModAuthPageLogonContext
  ) {
    this.myView = new AppSkinModAuthPageLogonView(
      context.getSettingErrors(),
      context.getSettingFields()
    );

    this.myPresenter = new AppModAuthPageLogonPresenter(
      context,
      this.myView
    );
  }

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading,
      this.ctrlRefresh,
      this.ctrlForm
    );

    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
