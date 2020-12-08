// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppModAuthPageRedirectPresenter} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-presenter';
import {AppModAuthPageRedirectModel} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-model';
import {AppModAuthPageRedirectView} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-view';
import {AppModAuthPageRedirectStore} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-store';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinModDummyMainPageListView} from '@app-skin/mods/dummy-main/pages/list/mod-dummy-main-page-list-view';
import {AppSkinModAuthPageRedirectView} from '@app-skin/mods/auth/pages/redirect/mod-auth-page-redirect-view';

/** Мод "Auth". Страницы. Перенаправление. Компонент. */
@Component({
  templateUrl: './mod-auth-page-redirect.component.html',
  styleUrls: ['./mod-auth-page-redirect.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageRedirectComponent.name},
    AppCoreLoggingService,
    AppModAuthPageRedirectModel,
    AppModAuthPageRedirectStore
  ]
})
export class AppSkinModAuthPageRedirectComponent implements AfterViewInit, OnDestroy, OnInit {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  @ViewChild('ctrlLoading') private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /**
   * Мой представитель.
   * @type {AppModAuthPageRedirectPresenter}
   */
  myPresenter: AppModAuthPageRedirectPresenter;

  /**
   * Мой вид.
   * @type {AppModAuthPageRedirectView}
   */
  myView: AppSkinModAuthPageRedirectView;

  /**
   * Конструктор.
   * @param {AppModAuthPageRedirectModel} model Модель.
   */
  constructor(
    model: AppModAuthPageRedirectModel
  ) {
    this.myView = new AppSkinModAuthPageRedirectView();

    this.myPresenter = new AppModAuthPageRedirectPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myView.init(
      this.ctrlLoading
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
