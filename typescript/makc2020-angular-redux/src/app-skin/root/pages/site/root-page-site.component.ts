// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppRootPageSiteModel} from '@app/root/pages/site/root-page-site-model';
import {AppRootPageSitePresenter} from '@app/root/pages/site/root-page-site-presenter';
import {AppRootPageSiteStore} from '@app/root/pages/site/root-page-site-store';
import {AppRootPageSiteView} from '@app/root/pages/site/root-page-site-view';

/** Корень. Страницы. Сайт. Компонент. */
@Component({
  templateUrl: './root-page-site.component.html',
  styleUrls: ['./root-page-site.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageSiteComponent.name},
    AppCoreLoggingService,
    AppRootPageSiteModel,
    AppRootPageSiteStore
  ]
})
export class AppSkinRootPageSiteComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppRootPageSitePresenter}
   */
  myPresenter: AppRootPageSitePresenter;

  /**
   * Вид.
   * @type {AppRootPageSiteView}
   */
  myView: AppRootPageSiteView;

  /**
   * Конструктор.
   * @param {AppRootPageSiteModel} model Модель.
   */
  constructor(
    model: AppRootPageSiteModel
  ) {
    this.myView = new AppRootPageSiteView();

    this.myPresenter = new AppRootPageSitePresenter(
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
