// //Author Maxim Kuzmin//makc//

import {Validators} from '@angular/forms';
import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppModDummyMainJobListGetInput} from '../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainJobListGetOutput} from '../../jobs/list/get/mod-dummy-main-job-list-get-output';
import {AppModDummyMainPageListDataItem} from './data/mod-dummy-main-page-list-data-item';
import {AppModDummyMainPageListEnumActions} from './enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListModel} from './mod-dummy-main-page-list-model';
import {AppModDummyMainPageListResources} from './mod-dummy-main-page-list-resources';
import {AppModDummyMainPageListState} from './mod-dummy-main-page-list-state';
import {AppModDummyMainPageListView} from './mod-dummy-main-page-list-view';

/** Мод "DummyMain". Страницы. Список. Представитель. */
export class AppModDummyMainPageListPresenter extends AppCoreCommonPagePresenter<AppModDummyMainPageListModel> {

  /** @type {boolean} */
  private isFilterApplied = false;

  /** @type {boolean} */
  private isSortCanceled = false;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionParametersSetAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageListResources}
   */
  get resources(): AppModDummyMainPageListResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListModel} model Модель.
   * @param {AppModDummyMainPageListView} view Вид.
   */
  constructor(
    model: AppModDummyMainPageListModel,
    private view: AppModDummyMainPageListView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onActionParametersSet = this.onActionParametersSet.bind(this);
    this.onActionParametersSetAsync = new AppCoreExecutableAsync(this.onActionParametersSet);

    this.onDataLoaded = this.onDataLoaded.bind(this);
    this.onFilterCancel = this.onFilterCancel.bind(this);
    this.onFilterChange = this.onFilterChange.bind(this);
    this.onFilteredToggle = this.onFilteredToggle.bind(this);
    this.onGetIsDataRefreshed = this.onGetIsDataRefreshed.bind(this);
    this.onGetIsItemDeleteStarted = this.onGetIsItemDeleteStarted.bind(this);
    this.onGetIsItemsDeleteStarted = this.onGetIsItemsDeleteStarted.bind(this);
    this.onGetState = this.onGetState.bind(this);
    this.onHeaderCheckboxToggle = this.onHeaderCheckboxToggle.bind(this);
    this.onRowSelect = this.onRowSelect.bind(this);
    this.onRowUnselect = this.onRowUnselect.bind(this);
    this.onSortChange = this.onSortChange.bind(this);
    this.onSortOrPageChange = this.onSortOrPageChange.bind(this);

    this.buildView();
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.subscribeOnHeaderCheckboxToggle(this.onHeaderCheckboxToggle);
    this.view.subscribeOnRowSelect(this.onRowSelect);
    this.view.subscribeOnRowUnselect(this.onRowUnselect);
    this.view.subscribeOnSortChange(this.onSortChange);
    this.view.subscribeOnSortOrPageChange(this.onSortOrPageChange);

    this.view.initLoadingSpinner(this.onDataLoaded);
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);
    // this.model.subscribeToEventDelayedDistinct(this.view.fieldName.valueChanges, this.onFilterChange);
    // this.model.subscribeToEventDelayedDistinct(this.view.fieldObjectDummyMainType.valueChanges, this.onFilterChange);

    super.onAfterViewInit();
  }

  /** Обработчик события отмены фильтрации. */
  onFilterCancel() {
    this.clearFields();

    if (this.isFilterApplied) {
      this.onFilterChange();
    }
  }

  /** Обработчик события изменения фильтрации. */
  onFilterChange() {
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }

    this.model.onReceiveEnsureLoadDataRequest();

    this.clearSelectedItems();

    this.refresh();
  }

  /** @inheritDoc */
  onInit() {
    this.model.getIsDataRefreshed$().subscribe(this.onGetIsDataRefreshed);
    this.model.getIsItemDeleteStarted$().subscribe(this.onGetIsItemDeleteStarted);
    this.model.getIsItemsDeleteStarted$().subscribe(this.onGetIsItemsDeleteStarted);

    const {
      fieldFiltered
    } = this.view;

    this.model.subscribeToEvent(fieldFiltered.valueChanges, this.onFilteredToggle);

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

    this.model.executeActionItemDelete(id);
  }

  /** Обработчик события удаления элементов. */
  onItemsDelete() {
    if (this.view.isItemsDeleteStarted) {
      return;
    }

    let isOk = false;

    if (this.view.fieldFiltered.value === true) {
      this.model.executeActionItemsDeleteFiltered();

      isOk = true;
    } else {
      const items = this.view.getSelectedItems();

      if (items.length > 0) {
        const ids: number[] = [];
        const names: string[] = [];

        for (const item of items) {
          ids.push(item.id);
          names.push(item.name);
        }

        this.model.executeActionItemsDeleteList(ids, names);

        isOk = true;
      }
    }

    if (!isOk) {
      this.view.isItemsDeleteStarted = false;
    }
  }

  /**
   * Обработчик события нажатия на кнопку редактирования.
   * @param {number} id Идентификатор.
   */
  onItemEdit(id: number) {
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
    this.model.executeActionItemView(id);
  }

  /** Обработчик события освежения. */
  onRefresh() {
    const {
      jobListGetInput
    } = this.model.getState();

    if (jobListGetInput) {
      this.loadFilterFromJobListGetInput(jobListGetInput);
    }

    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  /** Обработчик события отмены сортировки. */
  onSortCancel() {
    this.isSortCanceled = true;

    this.onRefresh();
  }

  /**
   * @inheritDoc
   * @param {string} message
   * @param {any} error
   */
  protected onException(message: string, error: any) {
    this.hideSpinners();

    super.onException(message, error);

    this.view.isActionStarted = false;

    this.refreshFields();
  }

  private buildView() {
    const {
      extFormBuilder
    } = this.model;

    const {
      fieldName,
      fieldObjectDummyOneToMany
    } = this.model.getSettingFields();

    const formGroup = extFormBuilder.group({
      [fieldName.name]: [{value: '', disabled: true}, Validators.nullValidator],
      [fieldObjectDummyOneToMany.name]: [{value: '', disabled: true}, Validators.nullValidator],
    });

    this.view.build(formGroup);
  }

  private clearFields() {
    const {
      fieldName,
      fieldObjectDummyOneToMany
    } = this.view;

    fieldName.setValue('', {emitEvent: false});
    fieldObjectDummyOneToMany.setValue(0, {emitEvent: false});

    this.clearFormGroupState();
  }

  private clearFormGroupState() {
    const {
      formGroup
    } = this.view;

    formGroup.markAsPristine();
    formGroup.markAsUntouched();
  }

  private clearSelectedItems() {
    if (this.view.getSelectedItems().length > 0) {
      this.view.setSelectedItemIds([]);
    }
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

  /** @param {AppModDummyMainJobListGetOutput} data */
  private loadData(data: AppModDummyMainJobListGetOutput) {
    const {
      jobListGetInput
    } = this.model.getState();

    this.view.pageSize = jobListGetInput
      ? this.model.getRealPageSize(jobListGetInput.pageSize)
      : this.model.getRealPageSize();

    let totalCount = 0;
    let items: AppModDummyMainPageListDataItem[];

    const {
      isDataLoaded,
      isDataRefreshed
    } = this.view;

    if ((!isDataLoaded || !isDataRefreshed) && jobListGetInput) {
      this.loadFilterFromJobListGetInput(jobListGetInput);
    }

    if (data) {
      totalCount = data.totalCount;

      items = data.items.map(
        x => new AppModDummyMainPageListDataItem(
          x.objectDummyMain.id,
          x.objectDummyMain.name,
          x.objectDummyOneToMany.name
        )
      );
    }

    if (!items) {
      items = [];
    }

    this.view.totalCount = totalCount;

    this.view.loadData(items, this.model.getParameters());
  }

  private loadFilterFromJobListGetInput(jobListGetInput: AppModDummyMainJobListGetInput) {
    const {
      dataName,
      dataObjectDummyOneToManyId
    } = jobListGetInput;

    const {
      fieldName,
      fieldObjectDummyOneToMany
    } = this.view;

    fieldName.setValue(dataName ?? '', {emitEvent: false});
    fieldObjectDummyOneToMany.setValue(dataObjectDummyOneToManyId > 0 ? dataObjectDummyOneToManyId : 0, {emitEvent: false});
  }

  private onActionParametersSet() {
    const {
      parameters
    } = this.model.getState();

    const {
      value: currentItemId
    } = parameters.paramsPageItem.paramId;

    this.view.currentItemId = currentItemId > 0 ? currentItemId : 0;

    const {
      paramName,
      paramObjectDummyOneToManyId,
      paramSelectedItemIdsString,
      paramSortDirection,
      paramSortField
    } = parameters.paramsPageList;

    const {
      paramSortDirection: paramSortDirectionDefault,
      paramSortField: paramSortFieldDefault
    } = this.model.createParameters();

    this.isFilterApplied = !!paramName.value
      || !!paramObjectDummyOneToManyId.value;

    this.view.isSortApplied = paramSortDirection.value !== paramSortDirectionDefault.value
      || paramSortField.value !== paramSortFieldDefault.value;

    const {
      fieldFiltered
    } = this.view;

    fieldFiltered.setValue(paramSelectedItemIdsString.value === '*', {emitEvent: false});

    this.view.paramNameValue = paramName.value ?? '';
    this.view.paramObjectDummyOneToManyIdValue = paramObjectDummyOneToManyId.value ?? 0;
  }

  private onActionsDataChanging() {
    this.view.isActionStarted = true;

    this.refreshFields();

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
      case AppModDummyMainPageListEnumActions.ItemDeleteSuccess:
        isCompleted = this.onDataChangedByDeleteSuccess();
        break;
      case AppModDummyMainPageListEnumActions.FilteredDeleteSuccess:
        isCompleted = this.onDataChangedByDeleteListSuccess();
        break;
      case AppModDummyMainPageListEnumActions.ListDeleteSuccess:
        isCompleted = this.onDataChangedByDeleteListSuccess();
        break;
      case AppModDummyMainPageListEnumActions.LoadSuccess:
        isCompleted = this.onDataChangedByLoadSuccess();
        break;
    }

    if (isCompleted) {
      this.view.isItemDeleteStarted = false;
      this.view.isItemsDeleteStarted = false;

      this.hideSpinners();

      this.view.isActionStarted = false;

      this.refreshFields();
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
          this.model.onReceiveEnsureLoadDataRequest();

          this.refresh();
        }
      }
    }

    return true;
  }

  /** @returns {boolean} */
  private onDataChangedByDeleteListSuccess(): boolean {
    const {
      jobListDeleteResult
    } = this.model.getState();
    if (jobListDeleteResult) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = jobListDeleteResult;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (isOk) {
        if (!this.model.onAfterActionItemsDeleteSuccess()) {
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
      jobListGetResult: result,
      jobOptionsDummyOneToManyGetResult: optionsDummyOneToMany,
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

    if (optionsDummyOneToMany) {
      const {
        data,
        errorMessages,
        successMessages
      } = optionsDummyOneToMany;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      this.view.loadOptionsDummyOneToMany(data);
    }

    return true;
  }

  private onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  private onFilteredToggle() {
    this.clearSelectedItems();

    this.refresh();
  }

  private onGetIsDataRefreshed(isDataRefreshed: boolean) {
    this.view.isDataRefreshed = isDataRefreshed;
  }

  private onGetIsItemDeleteStarted() {
    this.view.isItemDeleteStarted = true;
  }

  private onGetIsItemsDeleteStarted() {
    this.view.isItemsDeleteStarted = true;
  }

  /** @param {AppModDummyMainPageListState} state */
  private onGetState(state: AppModDummyMainPageListState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModDummyMainPageListEnumActions.ItemDelete:
        case AppModDummyMainPageListEnumActions.FilteredDelete:
        case AppModDummyMainPageListEnumActions.ListDelete:
        case AppModDummyMainPageListEnumActions.Load:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModDummyMainPageListEnumActions.ItemDeleteSuccess:
        case AppModDummyMainPageListEnumActions.FilteredDeleteSuccess:
        case AppModDummyMainPageListEnumActions.ListDeleteSuccess:
        case AppModDummyMainPageListEnumActions.LoadSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
        case AppModDummyMainPageListEnumActions.ParametersSet:
          this.onActionParametersSetAsync.execute();
          break;
      }
    }
  }

  private onHeaderCheckboxToggle() {
    this.refresh();
  }

  private onRowSelect() {
    this.refresh();
  }

  private onRowUnselect() {
    this.refresh();
  }

  private onSortChange() {
    if (this.view.getPageNumber() > 1) {
      this.view.setPageNumber(1);
    }
  }

  private onSortOrPageChange() {
    const {
      jobListGetInput
    } = this.model.getState();

    if (jobListGetInput) {
      this.loadFilterFromJobListGetInput(jobListGetInput);
    }

    this.model.onReceiveEnsureLoadDataRequest();

    this.clearSelectedItems();

    this.refresh();
  }

  private refresh() {
    const parameters = this.model.createParameters();

    const {
      paramIsDataRefreshed,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSelectedItemIdsString,
      paramSortDirection,
      paramSortField,
      paramName,
      paramObjectDummyOneToManyId
    } = parameters;

    paramIsDataRefreshed.value = true;

    paramPageNumber.value = this.view.getPageNumber();
    paramPageSize.value = this.view.getPageSize();
    paramSelectedItemId.value = this.view.getSelectedItem()?.id ?? 0;

    paramSelectedItemIdsString.value = this.view.fieldFiltered.value === true
      ? '*'
      : this.view.getSelectedItems().map(x => x.id).join(',');

    if (!this.isSortCanceled) {
      paramSortField.value = this.view.getSortField();
      paramSortDirection.value = this.view.getSortDirection();
    }

    this.isSortCanceled = false;

    paramName.value = this.view.fieldName.value;
    paramObjectDummyOneToManyId.value = +this.view.fieldObjectDummyOneToMany.value;

    this.model.executeActionRefresh(parameters);
  }

  private refreshFields() {
    const {
      fieldName,
      fieldObjectDummyOneToMany,
      isActionStarted
    } = this.view;

    if (isActionStarted) {
      fieldName.disable();
      fieldObjectDummyOneToMany.disable();
    } else {
      fieldName.enable();
      fieldObjectDummyOneToMany.enable();
    }
  }
}
