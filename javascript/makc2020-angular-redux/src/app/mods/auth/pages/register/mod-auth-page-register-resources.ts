// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModAuthPageRegisterSettings} from './mod-auth-page-register-settings';
import {AppModAuthPageRegisterResourceButtons} from './resources/mod-auth-page-register-resource-buttons';
import {AppModAuthPageRegisterResourceErrors} from './resources/mod-auth-page-register-resource-errors';
import {AppModAuthPageRegisterResourceFields} from './resources/mod-auth-page-register-resource-fields';

/** Мод "Auth". Страницы. Регистрация. Ресурсы. */
export class AppModAuthPageRegisterResources {

  /**
   * Кнопки.
   * @type {AppModAuthPageRegisterResourceButtons}
   */
  buttons: AppModAuthPageRegisterResourceButtons;

  /**
   * Ошибки.
   * @type {AppModAuthPageRegisterResourceErrors}
   */
  errors: AppModAuthPageRegisterResourceErrors;

  /**
   * Поля.
   * @type {AppModAuthPageRegisterResourceFields}
   */
  fields: AppModAuthPageRegisterResourceFields;

  /** Сообщения. */
  messages = {
    passwordInfo: ''
  };

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageRegisterSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModAuthPageRegisterSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      messages
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    this.buttons = new AppModAuthPageRegisterResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );

    this.errors = new AppModAuthPageRegisterResourceErrors(
      appLocalizer,
      settings.errors,
      unsubscribe$
    );

    this.fields = new AppModAuthPageRegisterResourceFields(
      appLocalizer,
      settings.fields,
      unsubscribe$
    );

    appLocalizer.createTranslator(
      messages.passwordInfoResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.messages.passwordInfo = s;
    });
  }
}
