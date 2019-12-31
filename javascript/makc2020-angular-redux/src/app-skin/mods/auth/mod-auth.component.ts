// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppModAuthPresenter} from '@app/mods/auth/mod-auth-presenter';
import {AppModAuthModel} from '@app/mods/auth/mod-auth-model';

/** Мод "Auth". Компонент. */
@Component({
  templateUrl: './mod-auth.component.html',
  styleUrls: ['./mod-auth.component.css'],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthComponent.name},
    AppCoreLoggingService,
    AppModAuthModel
  ]
})
export class AppSkinModAuthComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModAuthPresenter}
   */
  myPresenter: AppModAuthPresenter;

  /**
   * Конструктор.
   * @param {AppModAuthModel} model Модель.
   */
  constructor(
    private model: AppModAuthModel
  ) {
    this.myPresenter = new AppModAuthPresenter(
      model
    );
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
