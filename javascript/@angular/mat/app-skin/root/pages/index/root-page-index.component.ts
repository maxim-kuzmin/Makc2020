// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appRootPageIndexComponentName} from '@app/root/pages/index/root-page-index.component';
import {AppRootPageIndexPresenter} from '@app/root/pages/index/root-page-index-presenter';
import {AppRootPageIndexContext} from '@app/root/pages/index/root-page-index-context';
import {AppRootPageIndexView} from '@app/root/pages/index/root-page-index-view';

/** Корень. Страницы. Начало. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appRootPageIndexComponentName),
  templateUrl: './root-page-index.component.html',
  styleUrls: ['./root-page-index.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageIndexComponent.name },
    AppCoreLoggingService,
    AppRootPageIndexContext
  ]
})
export class AppSkinRootPageIndexComponent implements AfterViewInit, OnDestroy {

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

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
