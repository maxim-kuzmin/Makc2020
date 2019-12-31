// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModAuthPageLogonView} from './mod-auth-page-logon-view';
import {AppModAuthPageLogonPresenter} from '@app/mods/auth/pages/logon/mod-auth-page-logon-presenter';
import {AppModAuthPageLogonModel} from '@app/mods/auth/pages/logon/mod-auth-page-logon-model';
import {AppModAuthPageLogonStore} from '@app/mods/auth/pages/logon/mod-auth-page-logon-store';

/** Мод "Auth". Страницы. Вход в систему. Компонент. */
@Component({
  templateUrl: './mod-auth-page-logon.component.html',
  styleUrls: ['./mod-auth-page-logon.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageLogonComponent.name},
    AppCoreLoggingService,
    AppModAuthPageLogonModel,
    AppModAuthPageLogonStore
  ]
})
export class AppSkinModAuthPageLogonComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  @ViewChild('ctrlRefresh', {static: true}) private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {NgForm} */
  @ViewChild('ctrlForm', {static: true}) private ctrlForm: NgForm;

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
   * @param {AppModAuthPageLogonModel} model Модель.
   */
  constructor(
    model: AppModAuthPageLogonModel
  ) {
    this.myView = new AppSkinModAuthPageLogonView(
      model.getSettingErrors(),
      model.getSettingFields()
    );

    this.myPresenter = new AppModAuthPageLogonPresenter(
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
