// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyTreePageListSettings} from './mod-dummy-tree-page-list-settings';
import {AppModDummyTreePageListResourceActions} from './resources/mod-dummy-tree-page-list-resource-actions';
import {AppModDummyTreePageListResourceColumns} from './resources/mod-dummy-tree-page-list-resource-columns';
import {AppModDummyTreePageListResourceFields} from './resources/mod-dummy-tree-page-list-resource-fields';

/** Мод "DummyTree". Страницы. Список. Ресурсы. */
export class AppModDummyTreePageListResources {

  /**
   * Действия.
   * @type {AppModDummyTreePageListResourceActions}
   */
  actions: AppModDummyTreePageListResourceActions;

  /**
   * Столбцы.
   * @type {AppModDummyTreePageListResourceColumns}
   */
  columns: AppModDummyTreePageListResourceColumns;

  /**
   * Поля.
   * @type {AppModDummyTreePageListResourceFields}
   */
  fields: AppModDummyTreePageListResourceFields;

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
   * @param {AppModDummyTreePageListSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyTreePageListSettings,
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

    this.actions = new AppModDummyTreePageListResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.columns = new AppModDummyTreePageListResourceColumns(
      appLocalizer,
      settings.columns,
      unsubscribe$
    );
  }
}
