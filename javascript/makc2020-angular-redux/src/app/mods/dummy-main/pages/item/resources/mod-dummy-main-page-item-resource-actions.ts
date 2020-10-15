// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyMainPageItemSettingActions} from '../settings/mod-dummy-main-page-item-setting-actions';

/** Мод "DummyMain". Страницы. Элемент. Ресурсы. Действия. */
export class AppModDummyMainPageItemResourceActions {

  /** Действие "Деактивировать". */
  actionDeactivate = {
    confirm: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageListSettingColumns} settingColumns Настройка столбцов.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingColumns: AppModDummyMainPageItemSettingActions,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      actionDeactivate
    } = settingColumns;

    appLocalizer.createTranslator(
      actionDeactivate.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDeactivate.confirm = s;
    });
  }
}
