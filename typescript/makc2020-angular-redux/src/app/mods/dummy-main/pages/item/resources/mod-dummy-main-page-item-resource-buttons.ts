// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyMainPageItemSettingButtons} from '../settings/mod-dummy-main-page-item-setting-buttons';

/** Мод "DummyMain". Страницы. Элемент. Ресурсы. Кнопки. */
export class AppModDummyMainPageItemResourceButtons {

  /** Кнопка "Отправить". */
  buttonSubmit = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageItemSettingButtons} settingButtons Настройка кнопок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingButtons: AppModDummyMainPageItemSettingButtons,
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
