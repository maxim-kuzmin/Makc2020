// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModAuthPageRegisterSettingButtons} from '../settings/mod-auth-page-register-setting-buttons';

/** Мод "Auth". Страницы. Регистрация. Ресурсы. Кнопки. */
export class AppModAuthPageRegisterResourceButtons {

  /** Кнопка "Отправить". */
  buttonSubmit = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageRegisterSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppModAuthPageRegisterSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonSubmit
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonSubmit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonSubmit.title = s;
    });
  }
}
