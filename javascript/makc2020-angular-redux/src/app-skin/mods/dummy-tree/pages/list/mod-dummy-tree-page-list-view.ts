// //Author Maxim Kuzmin//makc//

import {Paginator, SelectItem, Table} from 'primeng';
import {merge} from 'rxjs';
import {AppModDummyTreePageListSettings} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-settings';
import {AppModDummyTreePageListView} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-view';
import {AppModDummyTreePageListSettingColumns} from '@app/mods/dummy-tree/pages/list/settings/mod-dummy-tree-page-list-setting-columns';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyTreePageListDataItem} from '@app/mods/dummy-tree/pages/list/data/mod-dummy-tree-page-list-data-item';
import {AppModDummyTreePageListParameters} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-parameters';
import {AppModDummyTreePageListResourceColumns} from '@app/mods/dummy-tree/pages/list/resources/mod-dummy-tree-page-list-resource-columns';
import {AppModDummyTreePageListSettingFields} from '@app/mods/dummy-tree/pages/list/settings/mod-dummy-tree-page-list-setting-fields';

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
   * Вырианты выбора "DummyOneToMany".
   * @type {SelectItem[]}
   */
  selectItemsDummyOneToMany: SelectItem[] = [];

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
   * Выбранные элементы.
   * @type {AppModDummyTreePageListDataItem[]}
   */
  selectedItems: AppModDummyTreePageListDataItem[];

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListResourceColumns} resourceColumns Ресурс столбцов.
   * @param {AppModDummyTreePageListSettings} settingColumns Настройка столбцов.
   * @param {AppModDummyTreePageListSettingFields} settingFields Настройка полей.
   * @param {number[]} pageSizeOptions Опции размера страницы.
   */
  constructor(
    resourceColumns: AppModDummyTreePageListResourceColumns,
    public settingColumns: AppModDummyTreePageListSettingColumns,
    settingFields: AppModDummyTreePageListSettingFields,
    public pageSizeOptions: number[]
  ) {
    super(settingFields);

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

  /**
   * @inheritDoc
   * @returns {AppModDummyTreePageListDataItem[]}
   */
  getData(): AppModDummyTreePageListDataItem[] {
    return this.ctrlTable.value;
  }

  /**
   * @inheritDoc
   * @returns {boolean}
   */
  getItemsDeleteButtonIsDisabled(): boolean {
    return super.getItemsDeleteButtonIsDisabled()
      || (
        !this.selectedItems
        || !this.selectedItems.length
      )
      && this.fieldFiltered.value === false;
  }

  /** @inheritDoc */
  getPageNumber(): number {
    return this.ctrlPaginator.getPage() + 1;
  }

  /** @inheritDoc */
  getPageSize(): number {
    return 10;
  }

  /**
   * Получить CSS-класс строки.
   * @param {AppModDummyTreePageListDataItem} row Строка.
   */
  getRowCssClass(row: AppModDummyTreePageListDataItem) {
    return {
      'ui-state-highlight': this.currentItemId === row.id
    };
  }

  /**
   * @inheritDoc
   * @returns {AppModDummyTreePageListDataItem}
   */
  getSelectedItem(): AppModDummyTreePageListDataItem {
    return this.selectedItem;
  }

  /**
   * @inheritDoc
   * @returns {AppModDummyTreePageListDataItem[]}
   */
  getSelectedItems(): AppModDummyTreePageListDataItem[] {
    return this.selectedItems ?? [];
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
      paramSelectedItemIdsString,
      paramSortDirection,
      paramSortField
    } = parameters;

    this.setPageNumber(paramPageNumber.value);
    this.setSelectedItemId(paramSelectedItemId.value);

    let selectedItemIds: number[] = [];

    if (paramSelectedItemIdsString.value && paramSelectedItemIdsString.value.length > 0) {
      selectedItemIds = paramSelectedItemIdsString.value.split(',').map(x => +x);
    }

    this.setSelectedItemIds(selectedItemIds);

    this.ctrlTable.sortField = paramSortField.value;
    this.ctrlTable.sortOrder = paramSortDirection.value === 'asc' ? 1 : -1;

    this.ctrlTable.sortSingle();

    this.isDataLoading = false;
  }

  /**
   * @inheritDoc
   * @param {number} value
   */
  setPageNumber(value: number) {
    this.ctrlPaginator.first = (value - 1) * this.pageSize;
    this.ctrlPaginator.updatePageLinks();
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

  /**
   * @inheritDoc
   * @param {number[]} value
   */
  setSelectedItemIds(value: number[]) {
    const selectedItems = [];

    if (value && value.length > 0) {
      for (const item of this.ctrlTable.value) {
        for (const id of value) {
          if (item.id === id) {
            selectedItems.push(item);
          }
        }
      }
    }

    this.selectedItems = selectedItems;
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
  subscribeOnHeaderCheckboxToggle(callback: () => void) {
    this.ctrlTable.onHeaderCheckboxToggle.subscribe(event => {
      if (!this.isDataLoading) {
        callback();
      }
    });
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
  subscribeOnRowUnselect(callback: () => void) {
    this.ctrlTable.onRowUnselect.subscribe(event => {
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
