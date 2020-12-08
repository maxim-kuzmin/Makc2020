// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appRootPageSiteComponentName} from '@app/root/pages/site/root-page-site.component';
import {AppRootPageSitePresenter} from '@app/root/pages/site/root-page-site-presenter';
import {AppRootPageSiteContext} from '@app/root/pages/site/root-page-site-context';
import {AppRootPageSiteView} from '@app/root/pages/site/root-page-site-view';

/** Корень. Страницы. Сайт. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appRootPageSiteComponentName),
  templateUrl: './root-page-site.component.html',
  styleUrls: ['./root-page-site.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageSiteComponent.name },
    AppCoreLoggingService,
    AppRootPageSiteContext
  ]
})
export class AppSkinRootPageSiteComponent implements AfterViewInit, OnDestroy {

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
   * @param {AppRootPageSiteContext} context Контекст.
   */
  constructor(
    context: AppRootPageSiteContext
  ) {
    this.myView = new AppRootPageSiteView();

    this.myPresenter = new AppRootPageSitePresenter(
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
