// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyTreePageItemSettingButtons} from '../settings/mod-dummy-tree-page-item-setting-buttons';

/** Мод "DummyTree". Страницы. Элемент. Ресурсы. Кнопки. */
export class AppModDummyTreePageItemResourceButtons {

  /** Кнопка "Отправить". */
  buttonSubmit = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageItemSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppModDummyTreePageItemSettingButtons,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      buttonSubmit
    } = settingButtons;

    appLocalizer.createTranslator(
      buttonSubmit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.buttonSubmit.title = s;
    });
  }
}
