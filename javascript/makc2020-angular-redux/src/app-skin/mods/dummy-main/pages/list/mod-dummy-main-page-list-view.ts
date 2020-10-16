// //Author Maxim Kuzmin//makc//

import {Paginator, SelectItem, Table} from 'primeng';
import {merge} from 'rxjs';
import {AppModDummyMainPageListSettings} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-settings';
import {AppModDummyMainPageListView} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-view';
import {AppModDummyMainPageListSettingColumns} from '@app/mods/dummy-main/pages/list/settings/mod-dummy-main-page-list-setting-columns';
import {AppSkinCoreProgressSpinnerComponent} from '@app-skin/core/progress/spinner/core-progress-spinner.component';
import {AppSkinCoreProgressSpinnerDirective} from '@app-skin/core/progress/spinner/core-progress-spinner.directive';
import {AppModDummyMainCommonJobOptionsGetOutputList} from '@app/mods/dummy-main/common/jobs/options/get/output/mod-dummy-main-common-job-options-get-output-list';
import {AppModDummyMainPageListDataItem} from '@app/mods/dummy-main/pages/list/data/mod-dummy-main-page-list-data-item';
import {AppModDummyMainPageListParameters} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-parameters';
import {AppModDummyMainPageListResourceColumns} from '@app/mods/dummy-main/pages/list/resources/mod-dummy-main-page-list-resource-columns';
import {AppModDummyMainPageListSettingFields} from '@app/mods/dummy-main/pages/list/settings/mod-dummy-main-page-list-setting-fields';

/** Мод "DummyMain". Страницы. Список. Вид. */
export class AppSkinModDummyMainPageListView extends AppModDummyMainPageListView {

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
   * @type {AppModDummyMainPageListDataItem}
   */
  selectedItem: AppModDummyMainPageListDataItem;

  /**
   * Выбранные элементы.
   * @type {AppModDummyMainPageListDataItem[]}
   */
  selectedItems: AppModDummyMainPageListDataItem[];

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListResourceColumns} resourceColumns Ресурс столбцов.
   * @param {AppModDummyMainPageListSettings} settingColumns Настройка столбцов.
   * @param {AppModDummyMainPageListSettingFields} settingFields Настройка полей.
   * @param {number[]} pageSizeOptions Опции размера страницы.
   */
  constructor(
    resourceColumns: AppModDummyMainPageListResourceColumns,
    settingColumns: AppModDummyMainPageListSettingColumns,
    settingFields: AppModDummyMainPageListSettingFields,
    public pageSizeOptions: number[]
  ) {
    super(settingFields);

    const {
      columnId: columnIdResource,
      columnName: columnNameResource,
      columnObjectDummyOneToMany: columnObjectDummyOneToManyResource
    } = resourceColumns;

    const {
      columnId: columnIdSetting,
      columnName: columnNameSetting,
      columnObjectDummyOneToMany: columnObjectDummyOneToManySetting
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
      },
      {
        field: columnObjectDummyOneToManySetting.name,
        get header(): string {
          return columnObjectDummyOneToManyResource.label;
        }
      },
    ];
  }

  /**
   * @inheritDoc
   * @returns {AppModDummyMainPageListDataItem[]}
   */
  getData(): AppModDummyMainPageListDataItem[] {
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
   * @param {AppModDummyMainPageListDataItem} row Строка.
   */
  getRowCssClass(row: AppModDummyMainPageListDataItem) {
    return {
      'ui-state-highlight': this.currentItemId === row.id
    };
  }

  /**
   * @inheritDoc
   * @returns {AppModDummyMainPageListDataItem}
   */
  getSelectedItem(): AppModDummyMainPageListDataItem {
    return this.selectedItem;
  }

  /**
   * @inheritDoc
   * @returns {AppModDummyMainPageListDataItem[]}
   */
  getSelectedItems(): AppModDummyMainPageListDataItem[] {
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
   * @param {AppModDummyMainPageListDataItem[]} data
   * @param {AppModDummyMainPageListParameters} parameters
   */
  loadData(
    data: AppModDummyMainPageListDataItem[],
    parameters: AppModDummyMainPageListParameters
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
   * @param {AppModDummyMainCommonJobOptionsGetOutputList} data
   */
  loadOptionsDummyOneToMany(data?: AppModDummyMainCommonJobOptionsGetOutputList) {
    super.loadOptionsDummyOneToMany(data);

    if (this.optionsDummyOneToMany) {
      this.selectItemsDummyOneToMany = this.optionsDummyOneToMany.items.map(option => ({
        label: option.name,
        title: option.name,
        value: option.value
      } as SelectItem));

      this.selectItemsDummyOneToMany.unshift({
        label: '',
        title: '',
        value: 0
      } as SelectItem);
    }
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
