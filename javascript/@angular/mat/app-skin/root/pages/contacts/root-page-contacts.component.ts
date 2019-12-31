// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy} from '@angular/core';
import {appCoreConfigSkinSelectorGet} from '@app/core/core-config';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appRootPageContactsComponentName} from '@app/root/pages/contacts/root-page-contacts.component';
import {AppRootPageContactsPresenter} from '@app/root/pages/contacts/root-page-contacts-presenter';
import {AppRootPageContactsContext} from '@app/root/pages/contacts/root-page-contacts-context';
import {AppRootPageContactsView} from '@app/root/pages/contacts/root-page-contacts-view';

/** Корень. Страницы. Контакты. Компонент. */
@Component({
  selector: appCoreConfigSkinSelectorGet(appRootPageContactsComponentName),
  templateUrl: './root-page-contacts.component.html',
  styleUrls: ['./root-page-contacts.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageContactsComponent.name },
    AppCoreLoggingService,
    AppRootPageContactsContext
  ]
})
export class AppSkinRootPageContactsComponent implements AfterViewInit, OnDestroy {

  /**
   * Мой представитель.
   * @type {AppRootPageContactsPresenter}
   */
  myPresenter: AppRootPageContactsPresenter;

  /**
   * Вид.
   * @type {AppRootPageContactsView}
   */
  myView: AppRootPageContactsView;

  /**
   * Конструктор.
   * @param {AppRootPageContactsContext} context Контекст.
   */
  constructor(
    context: AppRootPageContactsContext
  ) {
    this.myView = new AppRootPageContactsView();

    this.myPresenter = new AppRootPageContactsPresenter(
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
