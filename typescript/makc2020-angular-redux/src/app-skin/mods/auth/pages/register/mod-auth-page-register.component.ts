// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModAuthPageRegisterView} from './mod-auth-page-register-view';
import {AppModAuthPageRegisterPresenter} from '@app/mods/auth/pages/register/mod-auth-page-register-presenter';
import {AppModAuthPageRegisterModel} from '@app/mods/auth/pages/register/mod-auth-page-register-model';
import {AppModAuthPageRegisterStore} from '@app/mods/auth/pages/register/mod-auth-page-register-store';

/** Мод "Auth". Страницы. Регистрация. Компонент. */
@Component({
  templateUrl: './mod-auth-page-register.component.html',
  styleUrls: ['./mod-auth-page-register.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageRegisterComponent.name},
    AppCoreLoggingService,
    AppModAuthPageRegisterModel,
    AppModAuthPageRegisterStore
  ]
})
export class AppSkinModAuthPageRegisterComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', {static: true}) private ctrlForm: NgForm;

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
   * @param {AppModAuthPageRegisterModel} model Модель.
   */
  constructor(
    model: AppModAuthPageRegisterModel
  ) {
    this.myView = new AppSkinModAuthPageRegisterView(
      model.getSettingErrors(),
      model.getSettingFields()
    );

    this.myPresenter = new AppModAuthPageRegisterPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlRefresh,
      this.ctrlForm
    );

    this.myPresenter.onAfterViewInit();
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  /** @inheritDoc */
  ngOnInit() {
    this.myPresenter.onInit();
  }
}
