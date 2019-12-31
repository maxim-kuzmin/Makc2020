// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '../../../localization/core-localization.service';
import {AppCoreDialogConfirmSettingButtons} from '../settings/core-dialog-confirm-setting-buttons';

/** Ядро. Диалог. Подтверждение. Ресурсы. Кнопки. */
export class AppCoreDialogConfirmResourceButtons {

  /** Кнопка "Нет". */
    buttonNo = {
      title: ''
    };

  /** Кнопка "Да". */
  buttonYes = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogConfirmSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppCoreDialogConfirmSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonNo,
      buttonYes
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonNo.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonNo.title = s;
    });

    appLocalizer.createTranslator(
      buttonYes.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonYes.title = s;
    });
  }
}
