// //Author Maxim Kuzmin//makc//

import {Paginator, Table} from 'primeng';
import {merge} from 'rxjs';
import {AppModDummyTreePageListSettings} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-settings';
import {AppModDummyTreePageListView} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-view';
import {AppModDummyTreePageListSettingColumns} from '@app/mods/dummy-tree/pages/list/settings/mod-dummy-tree-page-list-setting-columns';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyTreePageListDataItem} from '@app/mods/dummy-tree/pages/list/data/mod-dummy-tree-page-list-data-item';
import {AppModDummyTreePageListResourceColumns} from '@app/mods/dummy-tree/pages/list/resources/mod-dummy-tree-page-list-resource-columns';
import {AppModDummyTreePageListParameters} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-parameters';

/** Мод "DummyTree". Страницы. Список. Вид. */
export class AppSkinModDummyTreePageListView extends AppModDummyTreePageListView {

  /** @type {AppSkinCoreProgressSpinnerComponent} */
  private ctrlLoading: AppSkinCoreProgressSpinnerComponent;

  /** @type {Paginator} */
  private ctrlPaginator: Paginator;

  /** @type {AppSkinCoreProgressSpinnerDirective} */
  private ctrlRefresh: AppSkinCoreProgressSpinnerDirective;

  /** @type {Table} */
  private ctrlTable: Table;

  /** @type {boolean} */
  private isDataLoading = false;

  /**
   * Ключ данных.
   * @type {string}
   */
  dataKey: string;

  /**
   * Отображаемые столбцы.
   * @type {{ field: string, header: string }[]}
   */
  displayedColumns: { field: string, header: string }[];

  /**
   * Выбранный элемент.
   * @type {AppModDummyTreePageListDataItem}
   */
  selectedItem: AppModDummyTreePageListDataItem;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListResourceColumns} resourceColumns Ресурс столбцов.
   * @param {AppModDummyTreePageListSettings} settingColumns Настройка столбцов.
   * @param {number[]} pageSizeOptions Опции размера страницы.
   */
  constructor(
    resourceColumns: AppModDummyTreePageListResourceColumns,
    settingColumns: AppModDummyTreePageListSettingColumns,
    public pageSizeOptions: number[]
  ) {
    super();

    const {
      columnId: columnIdResource,
      columnName: columnNameResource
    } = resourceColumns;

    const {
      columnId: columnIdSetting,
      columnName: columnNameSetting
    } = settingColumns;

    this.dataKey = columnIdSetting.name;

    this.displayedColumns = [
      {
        field: columnIdSetting.name,
        get header(): string {
          return columnIdResource.label;
        }
      },
      {
        field: columnNameSetting.name,
        get header(): string {
          return columnNameResource.label;
        }
      }
    ];
  }

  /** @inheritDoc */
  getPageNumber(): number {
    return this.ctrlPaginator.getPage() + 1;
  }

  /** @inheritDoc */
  getPageSize(): number {
    return 10;
  }

  getSelectedItemId(): number {
    return this.selectedItem ? this.selectedItem.id : 0;
  }

  /** @inheritDoc */
  getSortDirection(): string {
    return this.ctrlTable.sortOrder > 0 ? 'asc' : 'desc';
  }

  /** @inheritDoc */
  getSortField(): string {
    return this.ctrlTable.sortField;
  }

  /** @inheritDoc */
  hideLoadingSpinner() {
    this.ctrlLoading.hide();
  }

  /** @inheritDoc */
  hideRefreshSpinner() {
    this.ctrlRefresh.hide();
  }

  /**
   * Инициализировать.
   * @param {AppSkinCoreProgressSpinnerComponent} ctrlLoading Элемент управления "Спиннер загрузки".
   * @param {AppSkinCoreProgressSpinnerDirective} ctrlRefresh Элемент управления "Спиннер обновления".
   * @param {Paginator} ctrlPaginator Элемент управления "Пагинатор".
   * @param {Table} ctrlTable Элемент управления "Таблица".
   */
  init(
    ctrlLoading: AppSkinCoreProgressSpinnerComponent,
    ctrlRefresh: AppSkinCoreProgressSpinnerDirective,
    ctrlPaginator: Paginator,
    ctrlTable: Table
  ) {
    this.ctrlLoading = ctrlLoading;
    this.ctrlRefresh = ctrlRefresh;
    this.ctrlPaginator = ctrlPaginator;
    this.ctrlTable = ctrlTable;

    this.ctrlTable.customSort = true;

    this.ctrlTable.sortFunction.subscribe(event => {
    });
  }

  /** @inheritDoc */
  initLoadingSpinner(callback: () => void) {
    this.ctrlLoading.init(callback);
  }

  /** @inheritDoc */
  initRefreshSpinner() {
    this.ctrlRefresh.init();
  }

  /**
   * @inheritDoc
   * @param {AppModDummyTreePageListDataItem[]} data
   * @param {AppModDummyTreePageListParameters} parameters
   */
  loadData(
    data: AppModDummyTreePageListDataItem[],
    parameters: AppModDummyTreePageListParameters
  ) {
    this.isDataLoading = true;

    this.ctrlTable.value = data;

    const {
      paramPageNumber,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField
    } = parameters;

    this.setPageNumber(paramPageNumber.value);
    this.setSelectedItemId(paramSelectedItemId.value);

    this.ctrlTable.sortField = paramSortField.value;
    this.ctrlTable.sortOrder = paramSortDirection.value === 'asc' ? 1 : -1;

    this.isDataLoading = false;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setPageNumber(value: number) {
    this.ctrlPaginator.first = (value - 1) * this.pageSize;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setSelectedItemId(value: number) {
    this.selectedItem = value > 0
      ? this.ctrlTable.value.find(item => item.id === value)
      : null;
  }

  /** @inheritDoc */
  showLoadingSpinner() {
    this.ctrlLoading.show();
  }

  /** @inheritDoc */
  showRefreshSpinner() {
    this.ctrlRefresh.show();
  }

  /** @inheritDoc */
  subscribeOnRowSelect(callback: () => void) {
    this.ctrlTable.onRowSelect.subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }

  /** @inheritDoc */
  subscribeOnSortChange(callback: () => void) {
    this.ctrlTable.onSort.subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }

  /** @inheritDoc */
  subscribeOnSortOrPageChange(callback: () => void) {
    merge(
      this.ctrlTable.onSort,
      this.ctrlPaginator.onPageChange
    ).subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
  }
}
