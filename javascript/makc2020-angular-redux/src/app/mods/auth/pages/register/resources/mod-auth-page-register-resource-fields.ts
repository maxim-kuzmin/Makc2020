// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModAuthPageRegisterSettingFields} from '../settings/mod-auth-page-register-setting-fields';

/** Мод "Auth". Страницы. Регистрация. Ресурсы. Поля. */
export class AppModAuthPageRegisterResourceFields {

  /** Поле "E-mail". */
  fieldEmail = {
    label: 'E-mail',
    placeholder: 'Введите e-mail'
  };

  /** Поле "Полное имя". */
  fieldFullName = {
    label: 'Ф.И.О',
    placeholder: 'Введите Ф.И.О'
  };

  /** Поле "Пароль". */
  fieldPassword = {
    label: 'Пароль',
    placeholder: 'Введите пароль'
  };

  /** Поле "Подтверждение пароля". */
  fieldPasswordConfirm = {
    label: 'Подтверждение пароля',
    placeholder: 'Введите пароль ещё раз'
  };

  /** Поле "Имя пользователя". */
  fieldUserName = {
    label: 'Имя',
    placeholder: 'Введите имя'
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageRegisterRegisterFields} settingFields Настройка полей.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingFields: AppModAuthPageRegisterSettingFields,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      fieldEmail,
      fieldFullName,
      fieldPassword,
      fieldPasswordConfirm,
      fieldUserName
    } = settingFields;

    appLocalizer.createTranslator(
      fieldEmail.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldEmail.label = s;
    });

    appLocalizer.createTranslator(
      fieldEmail.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldEmail.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldFullName.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldFullName.label = s;
    });

    appLocalizer.createTranslator(
      fieldFullName.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldFullName.placeholder = s;
    });

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
      fieldPasswordConfirm.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPasswordConfirm.label = s;
    });

    appLocalizer.createTranslator(
      fieldPasswordConfirm.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldPasswordConfirm.placeholder = s;
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
