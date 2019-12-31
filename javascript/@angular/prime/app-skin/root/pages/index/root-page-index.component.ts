// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppRootPageIndexContext} from '@app/root/pages/index/root-page-index-context';
import {AppRootPageIndexPresenter} from '@app/root/pages/index/root-page-index-presenter';
import {AppRootPageIndexStore} from '@app/root/pages/index/root-page-index-store';
import {AppRootPageIndexView} from '@app/root/pages/index/root-page-index-view';

/** Корень. Страницы. Начало. Компонент. */
@Component({
  templateUrl: './root-page-index.component.html',
  styleUrls: ['./root-page-index.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageIndexComponent.name},
    AppCoreLoggingService,
    AppRootPageIndexContext,
    AppRootPageIndexStore
  ]
})
export class AppSkinRootPageIndexComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppRootPageIndexPresenter}
   */
  myPresenter: AppRootPageIndexPresenter;

  /**
   * Вид.
   * @type {AppRootPageIndexView}
   */
  myView: AppRootPageIndexView;

  /**
   * Конструктор.
   * @param {AppRootPageIndexContext} context Контекст.
   */
  constructor(
    context: AppRootPageIndexContext
  ) {
    this.myView = new AppRootPageIndexView();

    this.myPresenter = new AppRootPageIndexPresenter(
      context,
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
