// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppModDummyTreeJobListGetOutput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-output';
import {AppModDummyTreePageListDataItem} from './data/mod-dummy-tree-page-list-data-item';
import {AppModDummyTreePageListEnumActions} from './enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListModel} from './mod-dummy-tree-page-list-model';
import {AppModDummyTreePageListResources} from './mod-dummy-tree-page-list-resources';
import {AppModDummyTreePageListState} from './mod-dummy-tree-page-list-state';
import {AppModDummyTreePageListView} from './mod-dummy-tree-page-list-view';

/** Мод "DummyTree". Страницы. Список. Представитель. */
export class AppModDummyTreePageListPresenter extends AppCoreCommonPagePresenter<AppModDummyTreePageListModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageListResources}
   */
  get resources(): AppModDummyTreePageListResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListModel} model Модель.
   * @param {AppModDummyTreePageListView} view Вид.
   */
  constructor(
    model: AppModDummyTreePageListModel,
    private view: AppModDummyTreePageListView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onDataLoaded = this.onDataLoaded.bind(this);
    this.onFilterChange = this.onFilterChange.bind(this);
    this.onGetIsDataRefreshed = this.onGetIsDataRefreshed.bind(this);
    this.onGetIsItemDeleteStarted = this.onGetIsItemDeleteStarted.bind(this);
    this.onGetState = this.onGetState.bind(this);
    this.onRowSelect = this.onRowSelect.bind(this);
    this.onSortChange = this.onSortChange.bind(this);
    this.onSortOrPageChange = this.onSortOrPageChange.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.subscribeOnRowSelect(this.onRowSelect);
    this.view.subscribeOnSortChange(this.onSortChange);
    this.view.subscribeOnSortOrPageChange(this.onSortOrPageChange);

    this.view.initLoadingSpinner(this.onDataLoaded);
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);
    this.model.subscribeToEventDelayedDistinct(this.view.fieldName.valueChanges, this.onFilterChange);

    super.onAfterViewInit();
  }

  /**
   * @inheritDoc
   * @param {string} message
   * @param {any} error
   */
  protected onException(message: string, error: any) {
    this.hideSpinners();

    super.onException(message, error);
  }

  /** @inheritDoc */
  onInit() {
    this.model.getIsDataRefreshed$().subscribe(this.onGetIsDataRefreshed);
    this.model.getIsItemDeleteStarted$().subscribe(this.onGetIsItemDeleteStarted);

    super.onInit();
  }

  /**
   * Обработчик события удаления элемента.
   * @param {number} id Идентификатор.
   */
  onItemDelete(id: number) {
    if (this.view.isItemDeleteStarted) {
      return;
    }

    this.view.setSelectedItemId(id);

    this.model.executeActionItemDelete(id);
  }

  /**
   * Обработчик события нажатия на кнопку редактирования.
   * @param {number} id Идентификатор.
   */
  onItemEdit(id: number) {
    this.view.setSelectedItemId(id);

    this.model.executeActionItemEdit(id);
  }

  /** Обработчик события вставки элемента. */
  onItemInsert() {
    this.model.executeActionItemInsert();
  }

  /**
   * Обработчик события нажатия на кнопку просмотра.
   * @param {number} id Идентификатор.
   */
  onItemView(id: number) {
    this.view.setSelectedItemId(id);

    this.model.executeActionItemView(id);
  }

  private hideSpinners() {
    const {
      isDataLoaded
    } = this.view;

    if (isDataLoaded) {
      this.view.hideRefreshSpinner();
    } else {
      this.view.hideLoadingSpinner();
    }
  }

  /** @param {AppModDummyTreeJobListGetOutput} data */
  private loadData(data: AppModDummyTreeJobListGetOutput) {
    const {
      jobListGetInput
    } = this.model.getState();

    this.view.pageSize = jobListGetInput
      ? this.model.getRealPageSize(jobListGetInput.pageSize)
      : this.model.getRealPageSize();

    let totalCount = 0;
    let items: AppModDummyTreePageListDataItem[];

    const {
      isDataLoaded,
      isDataRefreshed
    } = this.view;

    if ((!isDataLoaded || !isDataRefreshed) && jobListGetInput) {
      this.view.fieldName.setValue(jobListGetInput.dataName, {emitEvent: false});
    }

    if (data) {
      totalCount = data.totalCount;

      items = data.items.map(
        x => new AppModDummyTreePageListDataItem(
          x.objectDummyTree.id,
          x.objectDummyTree.name
        )
      );
    }

    if (!items) {
      items = [];
    }

    this.view.totalCount = totalCount;

    this.view.loadData(items, this.model.getParameters());
  }

  private onActionsDataChanging() {
    const {
      isDataLoaded
    } = this.view;

    if (isDataLoaded) {
      this.view.showRefreshSpinner();
    } else {
      this.view.showLoadingSpinner();
    }
  }

  private onActionsDataChanged() {
    const {
      action
    } = this.model.getState();

    let isCompleted = false;

    switch (action) {
      case AppModDummyTreePageListEnumActions.DeleteSuccess:
        isCompleted = this.onDataChangedByDeleteSuccess();
        break;
      case AppModDummyTreePageListEnumActions.LoadSuccess:
        isCompleted = this.onDataChangedByLoadSuccess();
        break;
    }

    if (isCompleted) {
      this.view.isItemDeleteStarted = false;

      this.hideSpinners();
    }
  }

  /** @returns {boolean} */
  private onDataChangedByDeleteSuccess(): boolean {
    const {
      jobItemDeleteResult
    } = this.model.getState();

    if (jobItemDeleteResult) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = jobItemDeleteResult;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (isOk) {
        if (!this.model.onAfterActionItemDeleteSuccess()) {
          this.view.setSelectedItemId(0);

          this.model.onReceiveEnsureLoadDataRequest();

          this.refresh();
        }
      }
    }

    return true;
  }

  /** @returns {boolean} */
  private onDataChangedByLoadSuccess(): boolean {
    const {
      jobListGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      this.loadData(data);
    }

    return true;
  }

  private onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  private onFilterChange() {
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }

    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  private onGetIsDataRefreshed(isDataRefreshed: boolean) {
    this.view.isDataRefreshed = isDataRefreshed;
  }

  private onGetIsItemDeleteStarted() {
    this.view.isItemDeleteStarted = true;
  }

  /** @param {AppModDummyTreePageListState} state */
  private onGetState(state: AppModDummyTreePageListState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModDummyTreePageListEnumActions.Delete:
        case AppModDummyTreePageListEnumActions.Load:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModDummyTreePageListEnumActions.DeleteSuccess:
        case AppModDummyTreePageListEnumActions.LoadSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private onRowSelect() {
    this.refresh();
  }

  private onSortChange() {
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }
  }

  private onSortOrPageChange() {
    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  private refresh() {
    const parameters = this.model.createParameters();

    const {
      paramIsDataRefreshed,
      paramName,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField
    } = parameters;

    paramIsDataRefreshed.value = true;
    paramName.value = this.view.fieldName.value;
    paramPageNumber.value = this.view.getPageNumber();
    paramPageSize.value = this.view.getPageSize();
    paramSelectedItemId.value = this.view.getSelectedItemId();
    paramSortField.value = this.view.getSortField();
    paramSortDirection.value = this.view.getSortDirection();

    this.model.executeActionRefresh(parameters);
  }
}
