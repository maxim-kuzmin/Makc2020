// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyTreePageItemSettingErrors} from '../settings/mod-dummy-tree-page-item-setting-errors';

/** Мод "DummyTree". Страницы. Элемент. Ресурсы. Ошибки. */
export class AppModDummyTreePageItemResourceErrors {

  /** Ошибка "Обязательно". */
  errorRequired = {
    message: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingErrors: AppModDummyTreePageItemSettingErrors,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      errorRequired
    } = settingErrors;

    appLocalizer.createTranslator(
      errorRequired.messageResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.errorRequired.message = s;
    });
  }
}
