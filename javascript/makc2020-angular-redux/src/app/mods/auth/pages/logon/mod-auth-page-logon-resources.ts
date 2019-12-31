// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModAuthPageLogonResourceButtons} from './resources/mod-auth-page-logon-resource-buttons';
import {AppModAuthPageLogonResourceFields} from './resources/mod-auth-page-logon-resource-fields';
import {AppModAuthPageLogonResourceErrors} from './resources/mod-auth-page-logon-resource-errors';
import {AppModAuthPageLogonSettings} from './mod-auth-page-logon-settings';

/** Мод "Auth". Страницы. Вход в систему. Ресурсы. */
export class AppModAuthPageLogonResources {

  /**
   * Кнопки.
   * @type {AppModAuthPageLogonResourceButtons}
   */
  buttons: AppModAuthPageLogonResourceButtons;

  /**
   * Ошибки.
   * @type {AppModAuthPageLogonResourceErrors}
   */
  errors: AppModAuthPageLogonResourceErrors;

  /**
   * Поля.
   * @type {AppModAuthPageLogonResourceFields}
   */
  fields: AppModAuthPageLogonResourceFields;

  /** Сообщения. */
  messages = {
    loggedIn: '',
    passwordInfo: ''
  };

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Событие, возникающее после перевода заголовка.
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageLogonSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModAuthPageLogonSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      messages,
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      messages.loggedInResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.messages.loggedIn = s;
    });

    appLocalizer.createTranslator(
      messages.passwordInfoResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.messages.passwordInfo = s;
    });

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    this.buttons = new AppModAuthPageLogonResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );

    this.errors = new AppModAuthPageLogonResourceErrors(
      appLocalizer,
      settings.errors,
      unsubscribe$
    );

    this.fields = new AppModAuthPageLogonResourceFields(
      appLocalizer,
      settings.fields,
      unsubscribe$
    );
  }
}
