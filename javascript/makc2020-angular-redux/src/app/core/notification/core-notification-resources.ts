// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '../localization/core-localization.service';
import {AppCoreNotificationSettings} from './core-notification-settings';

/** Ядро. Извещение. Ресурсы. */
export class AppCoreNotificationResources {

  /**
   * Кнопка "Закрыть".
   * @type {string}
   */
  buttonClose = {
    title: ''
  };

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreNotificationSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppCoreNotificationSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonClose,
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      buttonClose.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonClose.title = s;
    });

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
    });
  }
}
