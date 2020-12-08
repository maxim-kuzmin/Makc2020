// //Author Maxim Kuzmin//makc//

import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyMainPageItemSettingErrors} from '../settings/mod-dummy-main-page-item-setting-errors';

/** Мод "DummyMain". Страницы. Элемент. Ресурсы. Ошибки. */
export class AppModDummyMainPageItemResourceErrors {

  /** Ошибка "Обязательно". */
  errorRequired = {
    message: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingErrors: AppModDummyMainPageItemSettingErrors,
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
