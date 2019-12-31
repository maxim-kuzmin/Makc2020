// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModAuthPageRegisterComponentName} from '@app/mods/auth/pages/register/mod-auth-page-register.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModAuthPageRegisterView} from './mod-auth-page-register-view';
import {AppModAuthPageRegisterPresenter} from '@app/mods/auth/pages/register/mod-auth-page-register-presenter';
import {AppModAuthPageRegisterContext} from '@app/mods/auth/pages/register/mod-auth-page-register-context';

/** Мод "Auth". Страницы. Регистрация. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModAuthPageRegisterComponentName),
  templateUrl: './mod-auth-page-register.component.html',
  styleUrls: ['./mod-auth-page-register.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageRegisterComponent.name },
    AppCoreLoggingService,
    AppModAuthPageRegisterContext
  ]
})
export class AppSkinModAuthPageRegisterComponent implements AfterViewInit, OnDestroy {

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', { static: true }) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', { static: true }) private ctrlForm: NgForm;

  /**
   * Мой вид.
   * @type {AppModAuthPageRegisterPresenter}
   */
  myPresenter: AppModAuthPageRegisterPresenter;

  /**
   * Мой вид.
   * @type {AppSkinModAuthPageRegisterView}
   */
  myView: AppSkinModAuthPageRegisterView;

  /**
   * Конструктор.
   * @param {AppModAuthPageRegisterContext} context Контекст.
   */
  constructor(
    context: AppModAuthPageRegisterContext
  ) {
    const {
      appPage
    } = context;

    this.myView = new AppSkinModAuthPageRegisterView(
      appPage.settings.errors,
      appPage.settings.fields
    );

    this.myPresenter = new AppModAuthPageRegisterPresenter(
      context,
      this.myView
    );
  }

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myView.init(
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
