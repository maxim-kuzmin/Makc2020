// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppHostControlValidationMessageResourceTexts} from './resources/host-control-validation-message-resource-texts';
import {AppHostControlValidationMessageSettings} from './host-control-validation-message-settings';

/** Хост. Элементы управления. Валидация. Сообщение. Ресурсы. */
export class AppHostControlValidationMessageResources {

  /**
   * Тексты.
   * @type {AppHostControlValidationMessageResourceTexts}
   */
  texts: AppHostControlValidationMessageResourceTexts;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostControlValidationMessageSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppHostControlValidationMessageSettings,
    unsubscribe$: Subject<boolean>
  ) {
    this.texts = new AppHostControlValidationMessageResourceTexts(
      appLocalizer,
      settings.texts,
      unsubscribe$
    );
  }
}
