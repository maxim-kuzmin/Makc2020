// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModAuthComponentName} from '@app/mods/auth/mod-auth.component';
import {AppModAuthPresenter} from '@app/mods/auth/mod-auth-presenter';
import {AppModAuthContext} from '@app/mods/auth/mod-auth-context';

/** Мод "Auth". Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModAuthComponentName),
  templateUrl: './mod-auth.component.html',
  styleUrls: ['./mod-auth.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthComponent.name },
    AppCoreLoggingService,
    AppModAuthContext
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
   * @param {AppModAuthContext} context Контекст.
   */
  constructor(
    private context: AppModAuthContext
  ) {
    this.myPresenter = new AppModAuthPresenter(
      context
    );
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
