// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyMainPageListSettingActions} from '../settings/mod-dummy-main-page-list-setting-actions';

/** Мод "DummyMain". Страницы. Список. Ресурсы. Действия. */
export class AppModDummyMainPageListResourceActions {

  /** Действие "Добавить". */
  actionAdd = {
    title: ''
  };

  /** Действие "Удалить". */
  actionDelete = {
    confirm: '',
    title: ''
  };

  /** Действие "Изменить". */
  actionEdit = {
    title: ''
  };

  /** Действие "Просмотреть". */
  actionView = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyMainPageListSettingActions} settingActions Настройка действий.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingActions: AppModDummyMainPageListSettingActions,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      actionAdd,
      actionDelete,
      actionEdit,
      actionView
    } = settingActions;

    appLocalizer.createTranslator(
      actionAdd.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionAdd.title = s;
    });

    appLocalizer.createTranslator(
      actionDelete.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDelete.confirm = s;
    });

    appLocalizer.createTranslator(
      actionDelete.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDelete.title = s;
    });

    appLocalizer.createTranslator(
      actionEdit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionEdit.title = s;
    });

    appLocalizer.createTranslator(
      actionView.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionView.title = s;
    });
  }
}
