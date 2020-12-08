// //Author Maxim Kuzmin//makc//

import {Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appModAuthPageIndexComponentName} from '@app/mods/auth/pages/index/mod-auth-page-index.component';
import {AppModAuthPageIndexPresenter} from '@app/mods/auth/pages/index/mod-auth-page-index-presenter';
import {AppModAuthPageIndexContext} from '@app/mods/auth/pages/index/mod-auth-page-index-context';

/** Мод "Auth". Страницы. Начало. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appModAuthPageIndexComponentName),
  templateUrl: './mod-auth-page-index.component.html',
  styleUrls: ['./mod-auth-page-index.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinModAuthPageIndexComponent.name },
    AppCoreLoggingService,
    AppModAuthPageIndexContext
  ]
})
export class AppSkinModAuthPageIndexComponent implements OnDestroy {

  /**
   * Мой представитель.
   * @type {AppModAuthPageIndexPresenter}
   */
  myPresenter: AppModAuthPageIndexPresenter;

  /**
   * Конструктор.
   * @param {AppModAuthPageIndexContext} context Контекст.
   */
  constructor(
    private context: AppModAuthPageIndexContext
  ) {
    this.myPresenter = new AppModAuthPageIndexPresenter(
      context
    );
  }

  /** @inheritdoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }
}
