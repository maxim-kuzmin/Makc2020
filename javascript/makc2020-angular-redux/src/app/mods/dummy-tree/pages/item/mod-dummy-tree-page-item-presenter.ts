// //Author Maxim Kuzmin//makc//

import {Validators} from '@angular/forms';
import {Observable, of} from 'rxjs';
import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {appDataObjectDummyTreeCreate} from '@app/data/objects/data-object-dummy-tree';
import {
  AppModDummyTreeJobItemGetOutput,
  appModDummyTreeJobItemGetOutputCreate
} from '../../jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreePageItemEnumActions} from './enums/mod-dummy-tree-page-item-enum-actions';
import {AppModDummyTreePageItemModel} from './mod-dummy-tree-page-item-model';
import {AppModDummyTreePageItemResources} from './mod-dummy-tree-page-item-resources';
import {AppModDummyTreePageItemState} from './mod-dummy-tree-page-item-state';
import {AppModDummyTreePageItemView} from './mod-dummy-tree-page-item-view';

/** Мод "DummyTree". Страницы. Элемент. Представитель. */
export class AppModDummyTreePageItemPresenter extends AppCoreCommonPagePresenter<AppModDummyTreePageItemModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageItemResources}
   */
  get resources(): AppModDummyTreePageItemResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyTreePageItemModel} model Модель.
   * @param {AppModDummyTreePageItemView} view Вид.
   */
  constructor(
    model: AppModDummyTreePageItemModel,
    private view: AppModDummyTreePageItemView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onDataLoaded = this.onDataLoaded.bind(this);
    this.onGetIsDataChangeAllowed = this.onGetIsDataChangeAllowed.bind(this);
    this.onGetState = this.onGetState.bind(this);

    this.buildView();
  }

  /**
   * Получение разрешения на деактивацию.
   * @returns {Observable<boolean>} True - если деактивация разрешена, False - в противном случае.
   */
  canDeactivate(): Observable<boolean> {
    const {
      appDialog
    } = this.model;

    const {
      actionDeactivate
    } = this.resources.actions;

    return this.view.formGroup.dirty ? appDialog.confirm$(actionDeactivate.confirm) : of(true);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.initLoadingSpinner(this.onDataLoaded);
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);

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
    this.model.getIsDataChangeAllowed$().subscribe(this.onGetIsDataChangeAllowed);

    super.onInit();
  }

  /** Обработчик события отправки. */
  onSubmit() {
    if (!this.view.formGroup.valid) {
      return;
    }

    const input = appModDummyTreeJobItemGetOutputCreate();

    let {
      data
    } = this.view;

    const {
      fieldName
    } = this.view;

    if (!data) {
      data = appModDummyTreeJobItemGetOutputCreate();
    }

    input.objectDummyTree = data.objectDummyTree
      ? data.objectDummyTree
      : appDataObjectDummyTreeCreate();

    const {
      objectDummyTree
    } = input;

    objectDummyTree.name = fieldName.value;

    this.model.executeActionSave(input);
  }

  /** Обработчик события окончания загрузки данных. */
  protected onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  private buildView() {
    const {
      extFormBuilder
    } = this.model;

    const {
      fieldId,
      fieldName,
      fieldObjectDummyOneToMany
    } = this.model.getSettingFields();

    const formGroup = extFormBuilder.group({
      [fieldId.name]: [{value: '', disabled: true}, Validators.required],
      [fieldName.name]: [{value: '', disabled: true}, Validators.required],
      [fieldObjectDummyOneToMany.name]: [{value: '', disabled: true}, Validators.required]
    });

    this.view.build(formGroup);
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

  /** @param {AppModDummyTreeJobItemGetOutput} data */
  private loadData(data: AppModDummyTreeJobItemGetOutput) {
    if (data) {
      this.view.data = data;

      const {
        objectDummyTree
      } = this.view.data;

      const {
        fieldId,
        fieldName
      } = this.view;

      if (objectDummyTree) {
        fieldId.setValue(objectDummyTree.id, {emitEvent: false});
        fieldName.setValue(objectDummyTree.name, {emitEvent: false});
      }
    } else {
      this.view.data = appModDummyTreeJobItemGetOutputCreate();
    }

    this.view.formGroup.markAsPristine();
  }

  /** @returns {boolean} */
  private loadJobItemGetResult(): boolean {
    const {
      jobItemGetInput: input,
      jobItemGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      if (isOk) {
        let {
          data
        } = result;

        if (!input.isForUpdate) {
          data = null;
        }

        this.loadData(data);
      }

      return isOk;
    }

    return false;
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


    switch (action) {
      case AppModDummyTreePageItemEnumActions.LoadSuccess:
        this.onDataChangedByLoadSuccess();
        break;
      case AppModDummyTreePageItemEnumActions.SaveSuccess:
        this.onDataChangedBySaveSuccess();
        break;
    }

    this.hideSpinners();
  }

  private onDataChangedByLoadSuccess() {
    this.loadJobItemGetResult();
  }

  private onDataChangedBySaveSuccess() {
    if (this.loadJobItemGetResult()) {
      const {
        jobItemGetInput: input
      } = this.model.getState();

      const {
        formGroup
      } = this.view;

      if (!input.isForUpdate) {
        this.resetForm();
      }

      this.refresh();
    }
  }

  /** @param {boolean} isDataChangeAllowed */
  private onGetIsDataChangeAllowed(isDataChangeAllowed: boolean) {
    this.view.isDataChangeAllowed = isDataChangeAllowed;

    if (this.view.isDataChangeAllowed) {
      this.view.fieldName.enable();
    }
  }

  /** @param {AppModDummyTreePageItemState} state */
  private onGetState(state: AppModDummyTreePageItemState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModDummyTreePageItemEnumActions.Load:
        case AppModDummyTreePageItemEnumActions.Save:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModDummyTreePageItemEnumActions.LoadSuccess:
        case AppModDummyTreePageItemEnumActions.SaveSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private refresh() {
    const parameters = this.model.createParameters();

    const {
      paramId
    } = parameters;

    paramId.value = this.view.fieldId.value;

    this.model.executeActionRefresh(parameters);
  }

  private resetForm() {
    this.view.resetForm();
    this.view.formGroup.reset();
  }
}
