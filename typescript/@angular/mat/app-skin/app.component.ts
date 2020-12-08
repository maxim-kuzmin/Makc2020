// //Author Maxim Kuzmin//makc//

import {BreakpointObserver} from '@angular/cdk/layout';
import {Component, OnDestroy, OnInit} from '@angular/core';
import {appComponentName} from '@app/app.component';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppSkinView} from './app-view';
import {AppPresenter} from '@app/app-presenter';
import {AppContext} from '@app/app-context';

/** Приложение. Оболочка. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appComponentName),
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinComponent.name},
    AppCoreLoggingService,
    AppContext
  ]
})
export class AppSkinComponent implements OnInit, OnDestroy {

  /**
   * Мой вид.
   * @type {AppSkinView}
   */
  myView: AppSkinView;

  /**
   * Мой представитель.
   * @type {AppPresenter}
   */
  myPresenter: AppPresenter;

  /**
   * Конструктор.
   * @param {AppContext} context Контекст.
   * @param {BreakpointObserver} breakpointObserver Утилита для проверки состояния соответствия запросов @media.
   */
  constructor(
    context: AppContext,
    breakpointObserver: BreakpointObserver
  ) {
    this.myView = new AppSkinView(
      breakpointObserver
    );

    this.myPresenter = new AppPresenter(
      context,
      this.myView
    );
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  /** @inheritdoc */
  ngOnInit() {
    this.myPresenter.onInit();
  }
}
