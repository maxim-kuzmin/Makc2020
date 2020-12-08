// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyTreePageItemResourceButtons} from './resources/mod-dummy-tree-page-item-resource-buttons';
import {AppModDummyTreePageItemResourceErrors} from './resources/mod-dummy-tree-page-item-resource-errors';
import {AppModDummyTreePageItemResourceFields} from './resources/mod-dummy-tree-page-item-resource-fields';
import {AppModDummyTreePageItemSettings} from './mod-dummy-tree-page-item-settings';
import {AppModDummyTreePageItemResourceActions} from './resources/mod-dummy-tree-page-item-resource-actions';

/** Мод "DummyTree". Страницы. Список. Ресурсы. */
export class AppModDummyTreePageItemResources {

  /**
   * Действия.
   * @type {AppModDummyTreePageItemResourceActions}
   */
  actions: AppModDummyTreePageItemResourceActions;

  /**
   * Кнопки.
   * @type {AppModDummyTreePageItemResourceButtons}
   */
  buttons: AppModDummyTreePageItemResourceButtons;

  /**
   * Ошибки.
   * @type {AppModDummyTreePageItemResourceErrors}
   */
  errors: AppModDummyTreePageItemResourceErrors;

  /**
   * Поля.
   * @type {AppModDummyTreePageItemResourceFields}
   */
  fields: AppModDummyTreePageItemResourceFields;

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
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyTreePageItemCreate".
   * @type {Subject<string>}
   */
  titleOfModDummyTreePageItemCreateTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyTreePageItemEdit".
   * @type {Subject<string>}
   */
  titleOfModDummyTreePageItemEditTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyTreePageItemView".
   * @type {Subject<string>}
   */
  titleOfModDummyTreePageItemViewTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageItemSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyTreePageItemSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModDummyTreePageItemCreateResourceKey,
      titleOfModDummyTreePageItemEditResourceKey,
      titleOfModDummyTreePageItemViewResourceKey
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
      this.titleOfModDummyTreePageItemCreateTranslated$.next(this.titleOfModDummyTreePageItemCreate);
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageItemEdit = s;
      this.titleOfModDummyTreePageItemEditTranslated$.next(this.titleOfModDummyTreePageItemEdit);
    });

    appLocalizer.createTranslator(
      titleOfModDummyTreePageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyTreePageItemView = s;
      this.titleOfModDummyTreePageItemViewTranslated$.next(this.titleOfModDummyTreePageItemView);
    });

    this.actions = new AppModDummyTreePageItemResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.buttons = new AppModDummyTreePageItemResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );

    this.errors = new AppModDummyTreePageItemResourceErrors(
      appLocalizer,
      settings.errors,
      unsubscribe$
    );

    this.fields = new AppModDummyTreePageItemResourceFields(
      appLocalizer,
      settings.fields,
      unsubscribe$
    );
  }
}
