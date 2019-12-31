// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {Message, MessageService} from 'primeng/api';
import {AppCoreNotificationPresenter} from '@app/core/notification/core-notification-presenter';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreNotificationInfoSettings} from '@app/core/notification/info/core-notification-info-settings';
import {AppCoreNotificationErrorSettings} from '@app/core/notification/error/core-notification-error-settings';
import {AppCoreNotificationSuccessSettings} from '@app/core/notification/success/core-notification-success-settings';
import {AppCoreNotificationWarnSettings} from '@app/core/notification/warn/core-notification-warn-settings';
import {AppSkinCoreNotificationRef} from './core-notification-ref';

/** Ядро. Извещение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreNotificationService extends AppCoreNotificationService {

  /** @type {AppCoreNotificationPresenter} */
  errorPresenter: AppCoreNotificationPresenter;

  /** @type {AppCoreNotificationPresenter} */
  infoPresenter: AppCoreNotificationPresenter;

  /** @type {AppCoreNotificationPresenter} */
  successPresenter: AppCoreNotificationPresenter;

  /** @type {AppCoreNotificationPresenter} */
  warnPresenter: AppCoreNotificationPresenter;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {MessageService} extMessage Сообщение.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    private extMessage: MessageService
  ) {
    super();

    this.errorPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationErrorSettings(),
      null
    );

    this.infoPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationInfoSettings(),
      null
    );

    this.successPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationSuccessSettings(),
      null
    );

    this.warnPresenter = new AppCoreNotificationPresenter(
      appLocalizer,
      new AppCoreNotificationWarnSettings(),
      null
    );
  }

  /**
   * @inheritDoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showError(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef('error', messages);
  }

  /**
   * @inheritDoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showInfo(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef('info', messages);
  }

  /**
   * @inheritDoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showSuccess(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef('success', messages);
  }

  /**
   * @inheritDoc
   * @param {string[]} messages
   * @returns {AppCoreCommonDisposable}
   */
  showWarn(messages: string[]): AppCoreCommonDisposable {
    return this.createNotificationRef('warn', messages);
  }

  private createNotificationRef(
    severity: 'error' | 'info' | 'warn' | 'success' | 'warn',
    messages: string[]
  ): AppSkinCoreNotificationRef {
    let summary: string;

    switch (severity) {
      case 'error':
        summary = this.errorPresenter.resources.title;
        break;
      case 'info':
        summary = this.infoPresenter.resources.title;
        break;
      case 'success':
        summary = this.successPresenter.resources.title;
        break;
      case 'warn':
        summary = this.warnPresenter.resources.title;
        break;
    }

    this.extMessage.addAll(
      messages.map(
        (message) => <Message>{
          severity: severity,
          detail: message,
          summary: summary
        }
      )
    );

    return new AppSkinCoreNotificationRef(this.extMessage);
  }
}
