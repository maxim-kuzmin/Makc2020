// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppContext} from '@app/app-context';
import {AppPresenter} from '@app/app-presenter';
import {AppSkinView} from './app-view';

/** Приложение. Компонент. */
@Component({
  selector: 'app-root',
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
   * Мой представитель.
   * @type {AppPresenter}
   */
  myPresenter: AppPresenter;

  /**
   * Мой вид.
   * @type {AppSkinView}
   */
  myView: AppSkinView;

  /**
   * Конструктор.
   * @param {AppContext} context Контекст.
   */
  constructor(
    context: AppContext
  ) {
    this.myView = new AppSkinView();

    this.myPresenter = new AppPresenter(
      context
    );
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  /** @inheritDoc */
  ngOnInit() {
    this.myPresenter.onInit();

    this.myView.cssClass = {
      'skin--css--way--back': false,
      'skin--css--way--front': true
    };
  }
}
