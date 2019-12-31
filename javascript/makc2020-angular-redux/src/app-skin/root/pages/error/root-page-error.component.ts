// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppRootPageErrorModel} from '@app/root/pages/error/root-page-error-model';
import {AppRootPageErrorPresenter} from '@app/root/pages/error/root-page-error-presenter';
import {AppRootPageErrorStore} from '@app/root/pages/error/root-page-error-store';
import {AppRootPageErrorView} from '@app/root/pages/error/root-page-error-view';

/** Корень. Страницы. Ошибка. Компонент. */
@Component({
  templateUrl: './root-page-error.component.html',
  styleUrls: ['./root-page-error.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageErrorComponent.name},
    AppCoreLoggingService,
    AppRootPageErrorModel,
    AppRootPageErrorStore
  ]
})
export class AppSkinRootPageErrorComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppRootPageErrorPresenter}
   */
  myPresenter: AppRootPageErrorPresenter;

  /**
   * Вид.
   * @type {AppRootPageErrorView}
   */
  myView: AppRootPageErrorView;

  /**
   * Конструктор.
   * @param {AppRootPageErrorModel} model Модель.
   */
  constructor(
    model: AppRootPageErrorModel
  ) {
    this.myView = new AppRootPageErrorView();

    this.myPresenter = new AppRootPageErrorPresenter(
      model,
      this.myView
    );
  }

  /** @inheritDoc */
  ngAfterViewInit() {
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
