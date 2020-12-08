// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppRootPageIndexSettings} from './root-page-index-settings';

/** Корень. Страницы. Начало. Ресурсы. */
export class AppRootPageIndexResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "RootPageAdministration".
   * @type {string}
   */
  titleOfRootPageAdministration = '';

  /**
   * Заголовок страницы "RootPageSite".
   * @type {string}
   */
  titleOfRootPageSite = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppRootPageIndexSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppRootPageIndexSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleOfRootPageAdministrationResourceKey,
      titleOfRootPageSiteResourceKey,
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleOfRootPageAdministrationResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfRootPageAdministration = s;
    });

    appLocalizer.createTranslator(
      titleOfRootPageSiteResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfRootPageSite = s;
    });

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });
  }
}
