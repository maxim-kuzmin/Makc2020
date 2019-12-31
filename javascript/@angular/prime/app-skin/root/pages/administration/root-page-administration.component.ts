// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppRootPageAdministrationContext} from '@app/root/pages/administration/root-page-administration-context';
import {AppRootPageAdministrationPresenter} from '@app/root/pages/administration/root-page-administration-presenter';
import {AppRootPageAdministrationStore} from '@app/root/pages/administration/root-page-administration-store';
import {AppRootPageAdministrationView} from '@app/root/pages/administration/root-page-administration-view';

/** Корень. Страницы. Администрирование. Компонент. */
@Component({
  templateUrl: './root-page-administration.component.html',
  styleUrls: ['./root-page-administration.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageAdministrationComponent.name},
    AppCoreLoggingService,
    AppRootPageAdministrationContext,
    AppRootPageAdministrationStore
  ]
})
export class AppSkinRootPageAdministrationComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppRootPageAdministrationPresenter}
   */
  myPresenter: AppRootPageAdministrationPresenter;

  /**
   * Вид.
   * @type {AppRootPageAdministrationView}
   */
  myView: AppRootPageAdministrationView;

  /**
   * Конструктор.
   * @param {AppRootPageAdministrationContext} context Контекст.
   */
  constructor(
    context: AppRootPageAdministrationContext
  ) {
    this.myView = new AppRootPageAdministrationView();

    this.myPresenter = new AppRootPageAdministrationPresenter(
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
