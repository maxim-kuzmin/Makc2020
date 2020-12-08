// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppModDummyMainPresenter} from '@app/mods/dummy-main/mod-dummy-main-presenter';
import {AppModDummyMainContext} from '@app/mods/dummy-main/mod-dummy-main-context';

/** Мод "DummyMain". Компонент. */
@Component({
  templateUrl: './mod-dummy-main.component.html',
  styleUrls: ['./mod-dummy-main.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModDummyMainComponent.name},
    AppCoreLoggingService,
    AppModDummyMainContext
  ]
})
export class AppSkinModDummyMainComponent implements AfterViewInit, OnDestroy {

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

  /** @inheritDoc */
  ngAfterViewInit() {
    this.myPresenter.onAfterViewInit();
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
