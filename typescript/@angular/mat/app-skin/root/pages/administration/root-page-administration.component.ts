// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appRootPageAdministrationComponentName} from '@app/root/pages/administration/root-page-administration.component';
import {AppRootPageAdministrationPresenter} from '@app/root/pages/administration/root-page-administration-presenter';
import {AppRootPageAdministrationContext} from '@app/root/pages/administration/root-page-administration-context';
import {AppRootPageAdministrationView} from '@app/root/pages/administration/root-page-administration-view';

/** Корень. Страницы. Администрирование. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appRootPageAdministrationComponentName),
  templateUrl: './root-page-administration.component.html',
  styleUrls: ['./root-page-administration.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageAdministrationComponent.name },
    AppCoreLoggingService,
    AppRootPageAdministrationContext
  ]
})
export class AppSkinRootPageAdministrationComponent implements AfterViewInit, OnDestroy {

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

  /** @inheritdoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
