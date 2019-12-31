// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModAuthPageIndexSettings} from './mod-auth-page-index-settings';

/** Мод "Auth". Страницы. Начало. Ресурсы. */
export class AppModAuthPageIndexResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "ModAuthPageLogon".
   * @type {string}
   */
  titleOfModAuthPageLogon = '';

  /**
   * Заголовок страницы "ModAuthPageRegister".
   * @type {string}
   */
  titleOfModAuthPageRegister = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModAuthPageIndexSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModAuthPageIndexSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModAuthPageLogonResourceKey,
      titleOfModAuthPageRegisterResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModAuthPageLogonResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModAuthPageLogon = s;
    });

    appLocalizer.createTranslator(
      titleOfModAuthPageRegisterResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModAuthPageRegister = s;
    });
  }
}
