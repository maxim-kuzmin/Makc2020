// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyMainPageItemResourceButtons} from './resources/mod-dummy-main-page-item-resource-buttons';
import {AppModDummyMainPageItemResourceErrors} from './resources/mod-dummy-main-page-item-resource-errors';
import {AppModDummyMainPageItemResourceFields} from './resources/mod-dummy-main-page-item-resource-fields';
import {AppModDummyMainPageItemSettings} from './mod-dummy-main-page-item-settings';
import {AppModDummyMainPageItemResourceActions} from './resources/mod-dummy-main-page-item-resource-actions';

/** Мод "DummyMain". Страницы. Список. Ресурсы. */
export class AppModDummyMainPageItemResources {

  /**
   * Действия.
   * @type {AppModDummyMainPageItemResourceActions}
   */
  actions: AppModDummyMainPageItemResourceActions;

  /**
   * Кнопки.
   * @type {AppModDummyMainPageItemResourceButtons}
   */
  buttons: AppModDummyMainPageItemResourceButtons;

  /**
   * Ошибки.
   * @type {AppModDummyMainPageItemResourceErrors}
   */
  errors: AppModDummyMainPageItemResourceErrors;

  /**
   * Поля.
   * @type {AppModDummyMainPageItemResourceFields}
   */
  fields: AppModDummyMainPageItemResourceFields;

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';
  /**
   * Заголовок страницы "ModDummyMainPageItemCreate".
   * @type {string}
   */
  titleOfModDummyMainPageItemCreate = '';

  /**
   * Заголовок страницы "ModDummyMainPageItemEdit".
   * @type {string}
   */
  titleOfModDummyMainPageItemEdit = '';

  /**
   * Заголовок страницы "ModDummyMainPageItemView".
   * @type {string}
   */
  titleOfModDummyMainPageItemView = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {Subject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyMainPageItemCreate".
   * @type {Subject<string>}
   */
  titleOfModDummyMainPageItemCreateTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyMainPageItemEdit".
   * @type {Subject<string>}
   */
  titleOfModDummyMainPageItemEditTranslated$ = new BehaviorSubject<string>('');

  /**
   * Событие, возникающее после перевода заголовка страницы "ModDummyMainPageItemView".
   * @type {Subject<string>}
   */
  titleOfModDummyMainPageItemViewTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageItemSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppModDummyMainPageItemSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey,
      titleOfModDummyMainPageItemCreateResourceKey,
      titleOfModDummyMainPageItemEditResourceKey,
      titleOfModDummyMainPageItemViewResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemCreateResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemCreate = s;
      this.titleOfModDummyMainPageItemCreateTranslated$.next(this.titleOfModDummyMainPageItemCreate);
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemEditResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemEdit = s;
      this.titleOfModDummyMainPageItemEditTranslated$.next(this.titleOfModDummyMainPageItemEdit);
    });

    appLocalizer.createTranslator(
      titleOfModDummyMainPageItemViewResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.titleOfModDummyMainPageItemView = s;
      this.titleOfModDummyMainPageItemViewTranslated$.next(this.titleOfModDummyMainPageItemView);
    });

    this.actions = new AppModDummyMainPageItemResourceActions(
      appLocalizer,
      settings.actions,
      unsubscribe$
    );

    this.buttons = new AppModDummyMainPageItemResourceButtons(
      appLocalizer,
      settings.buttons,
      unsubscribe$
    );

    this.errors = new AppModDummyMainPageItemResourceErrors(
      appLocalizer,
      settings.errors,
      unsubscribe$
    );

    this.fields = new AppModDummyMainPageItemResourceFields(
      appLocalizer,
      settings.fields,
      unsubscribe$
    );
  }
}
