// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyTreePageItemSettingFields} from '../settings/mod-dummy-tree-page-item-setting-fields';

/** Мод "DummyTree". Страницы. Элемент. Ресурсы. Поля. */
export class AppModDummyTreePageItemResourceFields {

  /** Поле "Идентификатор". */
  fieldId = {
    label: ''
  };

  /** Поле "Имя". */
  fieldName = {
    label: '',
    placeholder: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageItemSettingFields} settingFields Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingFields: AppModDummyTreePageItemSettingFields,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      fieldId,
      fieldName
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
  }
}
