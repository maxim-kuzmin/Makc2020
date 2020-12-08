// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyMainPageItemSettingFields} from '../settings/mod-dummy-main-page-item-setting-fields';

/** Мод "DummyMain". Страницы. Элемент. Ресурсы. Поля. */
export class AppModDummyMainPageItemResourceFields {

  /** Поле "Идентификатор". */
  fieldId = {
    label: ''
  };

  /** Поле "Имя". */
  fieldName = {
    label: '',
    placeholder: ''
  };

  /** Поле объект сущности "DummyManyToMany". */
  fieldObjectDummyManyToMany = {
    label: '',
    placeholder: ''
  };

  /** Поле объект сущности "DummyOneToMany". */
  fieldObjectDummyOneToMany = {
    label: '',
    placeholder: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageItemSettingFields} settingFields Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingFields: AppModDummyMainPageItemSettingFields,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      fieldId,
      fieldName,
      fieldObjectDummyManyToMany,
      fieldObjectDummyOneToMany
    } = settingFields;

    appLocalizer.createTranslator(
      fieldId.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldId.label = s;
    });

    appLocalizer.createTranslator(
      fieldName.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldName.label = s;
    });

    appLocalizer.createTranslator(
      fieldName.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldName.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldObjectDummyManyToMany.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectDummyManyToMany.label = s;
    });

    appLocalizer.createTranslator(
      fieldObjectDummyManyToMany.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectDummyManyToMany.placeholder = s;
    });

    appLocalizer.createTranslator(
      fieldObjectDummyOneToMany.labelResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectDummyOneToMany.label = s;
    });

    appLocalizer.createTranslator(
      fieldObjectDummyOneToMany.placeholderResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.fieldObjectDummyOneToMany.placeholder = s;
    });
  }
}
