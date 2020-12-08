// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyMainPageIndexContext} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-context';
import {AppModDummyMainPageIndexPresenter} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-presenter';
import {AppModDummyMainPageIndexStore} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-store';
import {AppModDummyMainPageIndexView} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-view';

/** Мод "DummyMain". Страницы. Начало. Компонент. */
@Component({
  templateUrl: './mod-dummy-main-page-index.component.html',
  styleUrls: ['./mod-dummy-main-page-index.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageIndexComponent.name},
    AppCoreLoggingService,
    AppModDummyMainPageIndexContext,
    AppModDummyMainPageIndexStore
  ]
})
export class AppSkinModDummyMainPageIndexComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppModDummyMainPageIndexPresenter}
   */
  myPresenter: AppModDummyMainPageIndexPresenter;

  /**
   * Мой вид.
   * @type {AppModDummyMainPageIndexView}
   */
  myView: AppModDummyMainPageIndexView;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageIndexContext} context Контекст.
   */
  constructor(
    context: AppModDummyMainPageIndexContext
  ) {
    this.myView = new AppModDummyMainPageIndexView();

    this.myPresenter = new AppModDummyMainPageIndexPresenter(
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
