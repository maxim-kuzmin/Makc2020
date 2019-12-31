// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModAuthPageRegisterSettingErrors} from '../settings/mod-auth-page-register-setting-errors';

/** Мод "Auth". Страницы. Регистрация. Ресурсы. Ошибки. */
export class AppModAuthPageRegisterResourceErrors {

  /** Ошибка "E-mail". */
  errorEmail = {
    message: ''
  };

  /** Ошибка "Подтверждение пароля". */
  errorPasswordConfirm = {
    message: ''
  };

  /** Ошибка "Обязательно". */
  errorRequired = {
    message: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageRegisterSettingErrors} settingErrors Настройка ошибок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingErrors: AppModAuthPageRegisterSettingErrors,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      errorEmail,
      errorPasswordConfirm,
      errorRequired
    } = settingErrors;

    appLocalizer.createTranslator(
      errorEmail.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorEmail.message = s;
    });

    appLocalizer.createTranslator(
      errorPasswordConfirm.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorPasswordConfirm.message = s;
    });

    appLocalizer.createTranslator(
      errorRequired.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorRequired.message = s;
    });
  }
}
