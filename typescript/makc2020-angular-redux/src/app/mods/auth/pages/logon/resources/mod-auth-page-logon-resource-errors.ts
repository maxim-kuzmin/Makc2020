// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModAuthPageLogonSettingErrors} from '../settings/mod-auth-page-logon-setting-errors';

/** Мод "Auth". Страницы. Вход в систему. Ресурсы. Ошибки. */
export class AppModAuthPageLogonResourceErrors {

  /** Обязательное поле. */
  errorRequired = {
    message: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageLogonSettingErrors} settingErrors Настройка ошибок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingErrors: AppModAuthPageLogonSettingErrors,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      errorRequired
    } = settingErrors;

    appLocalizer.createTranslator(
      errorRequired.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorRequired.message = s;
    });
  }
}
