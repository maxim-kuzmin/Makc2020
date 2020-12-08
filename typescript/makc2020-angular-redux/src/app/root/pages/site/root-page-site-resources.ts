// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppRootPageSiteSettings} from './root-page-site-settings';

/** Корень. Страницы. Сайт. Ресурсы. */
export class AppRootPageSiteResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "ModAuthPageIndex".
   * @type {string}
   */
  titleOfModAuthPageIndex = '';

  /**
   * Заголовок страницы "RootPageContacts".
   * @type {string}
   */
  titleOfRootPageContacts = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppRootPageSiteSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppRootPageSiteSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModAuthPageIndexResourceKey,
      titleOfRootPageContactsResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModAuthPageIndexResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModAuthPageIndex = s;
    });

    appLocalizer.createTranslator(
      titleOfRootPageContactsResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfRootPageContacts = s;
    });
  }
}
