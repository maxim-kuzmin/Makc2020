// //Author Maxim Kuzmin//makc//

import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {appCoreLoggingDiTokenLoggerName} from '@app/core/logging/core-logging-di';
import {AppRootPageContactsModel} from '@app/root/pages/contacts/root-page-contacts-model';
import {AppRootPageContactsPresenter} from '@app/root/pages/contacts/root-page-contacts-presenter';
import {AppRootPageContactsStore} from '@app/root/pages/contacts/root-page-contacts-store';
import {AppRootPageContactsView} from '@app/root/pages/contacts/root-page-contacts-view';

/** Корень. Страницы. Контакты. Компонент. */
@Component({
  templateUrl: './root-page-contacts.component.html',
  styleUrls: ['./root-page-contacts.component.css'],
  providers: [
    { provide: appCoreLoggingDiTokenLoggerName, useValue: AppSkinRootPageContactsComponent.name },
    AppCoreLoggingService,
    AppRootPageContactsModel,
    AppRootPageContactsStore
  ]
})
export class AppSkinRootPageContactsComponent implements AfterViewInit, OnDestroy, OnInit {

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
   * @param {AppRootPageContactsModel} model Модель.
   */
  constructor(
    model: AppRootPageContactsModel
  ) {
    this.myView = new AppRootPageContactsView();

    this.myPresenter = new AppRootPageContactsPresenter(
      model,
      this.myView
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

  /** @inheritDoc */
  ngOnInit() {
    this.myPresenter.onInit();
  }
}
