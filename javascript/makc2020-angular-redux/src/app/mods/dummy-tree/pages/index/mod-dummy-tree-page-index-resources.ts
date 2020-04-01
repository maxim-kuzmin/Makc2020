// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyTreePageIndexSettings} from './mod-dummy-tree-page-index-settings';

/** Мод "DummyTree". Страницы. Начало. Ресурсы. */
export class AppModDummyTreePageIndexResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Заголовок страницы "ModDummyTreePageItemCreate".
   * @type {string}
   */
  titleOfModDummyTreePageItemCreate = '';

  /**
   * Заголовок страницы "ModDummyTreePageItemEdit".
   * @type {string}
   */
  titleOfModDummyTreePageItemEdit = '';

  /**
   * Заголовок страницы "ModDummyTreePageItemView".
   * @type {string}
   */
  titleOfModDummyTreePageItemView = '';

  /**
   * Заголовок страницы "ModDummyTreePageList".
   * @type {string}
   */
  titleOfModDummyTreePageList = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageIndexSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyTreePageIndexSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModDummyTreePageItemCreateResourceKey,
      titleOfModDummyTreePageItemEditResourceKey,
      titleOfModDummyTreePageItemViewResourceKey,
      titleOfModDummyTreePageListResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageItemCreateResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageItemCreate = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageItemEdit = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageItemView = s;
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageListResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageList = s;
    });
  }
}
