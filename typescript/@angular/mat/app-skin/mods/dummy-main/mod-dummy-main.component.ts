// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModDummyMainComponentName} from '@app/mods/dummy-main/mod-dummy-main.component';
import {AppModDummyMainPresenter} from '@app/mods/dummy-main/mod-dummy-main-presenter';
import {AppModDummyMainContext} from '@app/mods/dummy-main/mod-dummy-main-context';

/** Мод "DummyMain". Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModDummyMainComponentName),
  templateUrl: './mod-dummy-main.component.html',
  styleUrls: ['./mod-dummy-main.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainComponent.name },
    AppCoreLoggingService,
    AppModDummyMainContext
  ]
})
export class AppSkinModDummyMainComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModDummyMainPresenter}
   */
  myPresenter: AppModDummyMainPresenter;

  /**
   * Конструктор.
   * @param {AppModDummyMainContext} context Контекст.
   */
  constructor(
    private context: AppModDummyMainContext
  ) {
    this.myPresenter = new AppModDummyMainPresenter(
      context
    );
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
