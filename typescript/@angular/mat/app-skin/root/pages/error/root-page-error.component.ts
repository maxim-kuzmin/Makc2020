// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appRootPageErrorComponentName} from '@app/root/pages/error/root-page-error.component';
import {AppRootPageErrorPresenter} from '@app/root/pages/error/root-page-error-presenter';
import {AppRootPageErrorContext} from '@app/root/pages/error/root-page-error-context';
import {AppRootPageErrorView} from '@app/root/pages/error/root-page-error-view';

/** Корень. Страницы. Ошибка. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appRootPageErrorComponentName),
  templateUrl: './root-page-error.component.html',
  styleUrls: ['./root-page-error.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageErrorComponent.name },
    AppCoreLoggingService,
    AppRootPageErrorContext
  ]
})
export class AppSkinRootPageErrorComponent implements AfterViewInit, OnDestroy {

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
   * @param {AppRootPageErrorContext} context Контекст.
   */
  constructor(
    context: AppRootPageErrorContext
  ) {
    this.myView = new AppRootPageErrorView();

    this.myPresenter = new AppRootPageErrorPresenter(
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
