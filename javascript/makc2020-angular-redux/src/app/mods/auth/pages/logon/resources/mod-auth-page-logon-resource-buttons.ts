// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModAuthPageLogonSettingButtons} from '../settings/mod-auth-page-logon-setting-buttons';

/** Мод "Auth". Страницы. Вход в систему. Ресурсы. Кнопки. */
export class AppModAuthPageLogonResourceButtons {

  /** Кнопка "Войти". */
  buttonLogin = {
    title: ''
  };

  /** Кнопка "Выйти". */
  buttonLogout = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageLogonSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppModAuthPageLogonSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonLogin,
      buttonLogout
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonLogin.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonLogin.title = s;
    });

    appLocalizer.createTranslator(
      buttonLogout.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonLogout.title = s;
    });
  }
}
