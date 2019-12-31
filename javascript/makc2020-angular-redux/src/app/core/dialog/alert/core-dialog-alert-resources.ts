// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '../../localization/core-localization.service';
import {AppCoreDialogAlertSettings} from './core-dialog-alert-settings';
import {AppCoreDialogAlertResourceButtons} from './resources/core-dialog-alert-resource-buttons';

/** Ядро. Диалог. Предупреждение. Ресурсы. */
export class AppCoreDialogAlertResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Кнопки.
   * @type {AppCoreDialogAlertResourceButtons}
   */
  buttons: AppCoreDialogAlertResourceButtons;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogAlertSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppCoreDialogAlertSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      title
    } = settings;

    appLocalizer.createTranslator(
      title
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
    });

    this.buttons = new AppCoreDialogAlertResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );
  }
}
