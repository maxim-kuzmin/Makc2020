// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '../../localization/core-localization.service';
import {AppCoreDialogConfirmSettings} from './core-dialog-confirm-settings';
import {AppCoreDialogConfirmResourceButtons} from './resources/core-dialog-confirm-resource-buttons';

/** Ядро. Диалог. Подтверждение. Ресурсы. */
export class AppCoreDialogConfirmResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Кнопки.
   * @type {AppCoreDialogConfirmResourceButtons}
   */
  buttons: AppCoreDialogConfirmResourceButtons;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogConfirmSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppCoreDialogConfirmSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
    });

    this.buttons = new AppCoreDialogConfirmResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );
  }
}
