// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModAuthPageLogonSettingFields} from '../settings/mod-auth-page-logon-setting-fields';

/** Мод "Auth". Страницы. Вход в систему. Ресурсы. Поля. */
export class AppModAuthPageLogonResourceFields {

  /** Поле "Пароль". */
  fieldPassword = {
    label: '',
    placeholder: '',
  };

  /** Поле "Имя пользователя". */
  fieldUserName = {
    label: '',
    placeholder: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageLogonSettingFields} settingFields Настройка полей.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingFields: AppModAuthPageLogonSettingFields,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      fieldPassword,
      fieldUserName
    } = settingFields;

    appLocalizer.createTranslator(
      fieldPassword.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPassword.label = s;
    });

    appLocalizer.createTranslator(
      fieldPassword.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPassword.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldUserName.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldUserName.label = s;
    });

    appLocalizer.createTranslator(
      fieldUserName.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldUserName.placeholder = s;
    });
  }
}
