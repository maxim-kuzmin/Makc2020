// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageListResourceColumns} from './resources/mod-dummy-main-page-list-resource-columns';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {AppModDummyMainPageListSettings} from './mod-dummy-main-page-list-settings';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyMainPageListResourceActions} from './resources/mod-dummy-main-page-list-resource-actions';

/** Мод "DummyMain". Страницы. Список. Ресурсы. */
export class AppModDummyMainPageListResources {

  /**
   * Действия.
   * @type {AppModDummyMainPageListResourceActions}
   */
  actions: AppModDummyMainPageListResourceActions;

  /**
   * Столбцы.
   * @type {AppModDummyMainPageListResourceColumns}
   */
  columns: AppModDummyMainPageListResourceColumns;

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
   * @param {AppModDummyMainPageListSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyMainPageListSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    this.actions = new AppModDummyMainPageListResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.columns = new AppModDummyMainPageListResourceColumns(
      appLocalizer,
      settings.columns,
      unsubscribe$
    );
  }
}
