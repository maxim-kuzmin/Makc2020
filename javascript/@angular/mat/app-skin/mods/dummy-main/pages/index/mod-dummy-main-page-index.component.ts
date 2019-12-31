// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModDummyMainPageIndexComponentName} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index.component';
import {AppModDummyMainPageIndexPresenter} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-presenter';
import {AppModDummyMainPageIndexContext} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-context';

/** Мод "DummyMain". Страницы. Начало. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModDummyMainPageIndexComponentName),
  templateUrl: './mod-dummy-main-page-index.component.html',
  styleUrls: ['./mod-dummy-main-page-index.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainPageIndexComponent.name },
    AppCoreLoggingService,
    AppModDummyMainPageIndexContext
  ]
})
export class AppSkinModDummyMainPageIndexComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModDummyMainPageIndexPresenter}
   */
  myPresenter: AppModDummyMainPageIndexPresenter;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageIndexContext} context Контекст.
   */
  constructor(
    private context: AppModDummyMainPageIndexContext
  ) {
    this.myPresenter = new AppModDummyMainPageIndexPresenter(
      context
    );
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
