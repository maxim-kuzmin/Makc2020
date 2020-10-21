// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppModDummyTreePageListSettingActions} from '../settings/mod-dummy-tree-page-list-setting-actions';

/** Мод "DummyTree". Страницы. Список. Ресурсы. Действия. */
export class AppModDummyTreePageListResourceActions {

  /** Действие "Добавить". */
  actionAdd = {
    title: ''
  };

  /** Действие "Удалить". */
  actionDelete = {
    confirm: '',
    title: ''
  };

  /** Действие "Удалить отфильтрованное". */
  actionDeleteFiltered = {
    confirm: '',
    title: ''
  };

  /** Действие "Удалить список". */
  actionDeleteList = {
    confirm: '',
    title: ''
  };

  /** Действие "Изменить". */
  actionEdit = {
    title: ''
  };

  /** Действие "Фильтровать". */
  actionFilter = {
    title: ''
  };

  /** Действие "Отменить фильтрацию". */
  actionFilterCancel = {
    title: ''
  };

  /** Действие "Освежить". */
  actionRefresh = {
    title: ''
  };

  /** Действие "Выбрать всё на всех страницах". */
  actionSelectAllOnAllPages = {
    title: ''
  };

  /** Действие "Выбрать всё на этой странице". */
  actionSelectAllOnThisPage = {
    title: ''
  };

  /** Действие "Отменить сортировку". */
  actionSortCancel = {
    title: ''
  };

  /** Действие "Просмотреть". */
  actionView = {
    title: ''
  };

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppModDummyTreePageListSettingActions} settingActions Настройка действий.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingActions: AppModDummyTreePageListSettingActions,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      actionAdd,
      actionDelete,
      actionDeleteFiltered,
      actionDeleteList,
      actionEdit,
      actionFilter,
      actionFilterCancel,
      actionRefresh,
      actionSelectAllOnAllPages,
      actionSelectAllOnThisPage,
      actionSortCancel,
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
      actionDeleteFiltered.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDeleteFiltered.confirm = s;
    });

    appLocalizer.createTranslator(
      actionDeleteList.confirmResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDeleteList.confirm = s;
    });

    appLocalizer.createTranslator(
      actionDeleteList.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionDeleteList.title = s;
    });

    appLocalizer.createTranslator(
      actionEdit.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionEdit.title = s;
    });

    appLocalizer.createTranslator(
      actionFilter.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionFilter.title = s;
    });

    appLocalizer.createTranslator(
      actionFilterCancel.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionFilterCancel.title = s;
    });

    appLocalizer.createTranslator(
      actionRefresh.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionRefresh.title = s;
    });

    appLocalizer.createTranslator(
      actionSelectAllOnAllPages.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionSelectAllOnAllPages.title = s;
    });

    appLocalizer.createTranslator(
      actionSelectAllOnThisPage.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionSelectAllOnThisPage.title = s;
    });

    appLocalizer.createTranslator(
      actionSortCancel.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionSortCancel.title = s;
    });

    appLocalizer.createTranslator(
      actionView.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.actionView.title = s;
    });
  }
}
