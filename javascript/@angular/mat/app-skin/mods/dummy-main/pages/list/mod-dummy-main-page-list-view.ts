// //Author Maxim Kuzmin//makc//

import {MatPaginator, MatSort} from '@angular/material';
import {merge} from 'rxjs';
import {AppModDummyMainPageListDataItem} from '@app/mods/dummy-main/pages/list/data/mod-dummy-main-page-list-data-item';
import {AppModDummyMainPageListSettings} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-settings';
import {AppModDummyMainPageListSettingColumns} from '@app/mods/dummy-main/pages/list/settings/mod-dummy-main-page-list-setting-columns';
import {AppModDummyMainPageListView} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-view';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppSkinModDummyMainPageListDataSource} from './data/mod-dummy-main-page-list-data-source';

/** Мод "DummyMain". Страницы. Список. Вид. */
export class AppSkinModDummyMainPageListView extends AppModDummyMainPageListView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {MatPaginator} */
  private ctrlPaginator: MatPaginator;

  /** @type {MatSort} */
  private ctrlSort: MatSort;

  /**
   * Источник данных.
   * @type {AppSkinModDummyMainPageListDataSource}
   */
  dataSource = new AppSkinModDummyMainPageListDataSource();

  /**
   * Отображаемые столбцы.
   * @type {string[]}
   */
  displayedColumns: string[];

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListSettings} settingColumns Настройка столбцов.
   * @param {number[]} pageSizeOptions Опции размера страницы.
   */
  constructor(
    settingColumns: AppModDummyMainPageListSettingColumns,
    public pageSizeOptions: number[]
  ) {
    super();

    const {
      columnAction,
      columnId,
      columnName
    } = settingColumns;

    this.displayedColumns = [
      columnAction.name,
      columnId.name,
      columnName.name
    ];
  }

  /**
   * @inheritdoc
   * @returns {number}
   */
  getPageNumber(): number {
    return this.ctrlPaginator.pageIndex + 1;
  }

  /**
   * @inheritdoc
   * @returns {number}
   */
  getPageSize(): number {
    return this.ctrlPaginator.pageSize;
  }

  /**
   * @inheritdoc
   * @returns {string}
   */
  getSortDirection(): string {
    return this.ctrlSort.direction;
  }

  /**
   * @inheritdoc
   * @returns {string}
   */
  getSortField(): string {
    return this.ctrlSort.active;
  }

  /** @inheritdoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritdoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {MatPaginator} ctrlPaginator Элемент управления "Пагинатор".
   * @param {MatSort} ctrlSort Элемент управления "Сортировщик".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent,
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlPaginator: MatPaginator,
    ctrlSort: MatSort
  ) {
    this.ctrlLoading = ctrlLoading;
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlPaginator = ctrlPaginator;
    this.ctrlSort = ctrlSort;
  }

  /**
   * @inheritdoc
   * @param {() => void} callback
   */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritdoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /**
   * @inheritdoc
   * @param {AppModDummyMainPageListDataItem[]} data
   */
  loadData(data: AppModDummyMainPageListDataItem[]) {
    this.dataSource.loadData(data);
  }

  /**
   * @inheritdoc
   * @param {number} value
   */
  setPageNumber(value: number) {
    this.ctrlPaginator.pageIndex = value - 1;
  }

  /** @inheritdoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritdoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }

  /**
   * @inheritdoc
   * @param {() => void} callback
   */
  subscribeOnSortChange(callback: () => void) {
    this.ctrlSort.sortChange.subscribe(
      callback
    );
  }

  /**
   * @inheritdoc
   * @param {() => void} callback
   */
  subscribeOnSortOrPageChange(callback: () => void) {
    merge(
      this.ctrlSort.sortChange,
      this.ctrlPaginator.page
    ).subscribe(
      callback
    );
  }
}
