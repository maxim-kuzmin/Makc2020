// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppModAuthPageIndexPresenter} from '@app/mods/auth/pages/index/mod-auth-page-index-presenter';
import {AppModAuthPageIndexContext} from '@app/mods/auth/pages/index/mod-auth-page-index-context';
import {AppModAuthPageIndexView} from '@app/mods/auth/pages/index/mod-auth-page-index-view';
import {AppModAuthPageIndexStore} from '@app/mods/auth/pages/index/mod-auth-page-index-store';

/** Мод "Auth". Страницы. Начало. Компонент. */
@Component({
  templateUrl: './mod-auth-page-index.component.html',
  styleUrls: ['./mod-auth-page-index.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageIndexComponent.name},
    AppCoreLoggingService,
    AppModAuthPageIndexContext,
    AppModAuthPageIndexStore
  ]
})
export class AppSkinModAuthPageIndexComponent implements AfterViewInit, OnDestroy, OnInit {

  /**
   * Мой представитель.
   * @type {AppModAuthPageIndexPresenter}
   */
  myPresenter: AppModAuthPageIndexPresenter;

  /**
   * Мой вид.
   * @type {AppModAuthPageIndexView}
   */
  myView: AppModAuthPageIndexView;

  /**
   * Конструктор.
   * @param {AppModAuthPageIndexContext} context Контекст.
   */
  constructor(
    context: AppModAuthPageIndexContext
  ) {
    this.myView = new AppModAuthPageIndexView();

    this.myPresenter = new AppModAuthPageIndexPresenter(
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
