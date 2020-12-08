// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '../../../localization/core-localization.service';
import {AppCoreDialogAlertSettingButtons} from '../settings/core-dialog-alert-setting-buttons';

/** Ядро. Диалог. Предупреждение. Ресурсы. Кнопки. */
export class AppCoreDialogAlertResourceButtons {

  /** Кнопка "Принять". */
    buttonAccept = {
      title: ''
    };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreDialogAlertSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppCoreDialogAlertSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonAccept
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonAccept.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonAccept.title = s;
    });
  }
}
