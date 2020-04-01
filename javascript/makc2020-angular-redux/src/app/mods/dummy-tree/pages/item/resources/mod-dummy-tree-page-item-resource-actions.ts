// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyTreePageItemSettingActions} from '../settings/mod-dummy-tree-page-item-setting-actions';

/** Мод "DummyTree". Страницы. Элемнет. Ресурсы. Действия. */
export class AppModDummyTreePageItemResourceActions {

  /** Действие "Деактивировать". */
  actionDeactivate = {
    confirm: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageListSettingColumns} settingColumns Настройка столбцов.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingColumns: AppModDummyTreePageItemSettingActions,
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
