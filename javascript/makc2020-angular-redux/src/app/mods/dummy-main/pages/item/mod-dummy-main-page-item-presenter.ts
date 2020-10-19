// //Author Maxim Kuzmin//makc//

import {Validators} from '@angular/forms';
import {Observable, of} from 'rxjs';
import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {appDataObjectDummyMainCreate} from '@app/data/objects/data-object-dummy-main';
import {
  AppModDummyMainJobItemGetOutput,
  appModDummyMainJobItemGetOutputCreate
} from '../../jobs/item/get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainPageItemEnumActions} from './enums/mod-dummy-main-page-item-enum-actions';
import {AppModDummyMainPageItemModel} from './mod-dummy-main-page-item-model';
import {AppModDummyMainPageItemResources} from './mod-dummy-main-page-item-resources';
import {AppModDummyMainPageItemState} from './mod-dummy-main-page-item-state';
import {AppModDummyMainPageItemView} from './mod-dummy-main-page-item-view';
import {map} from 'rxjs/operators';

/** Мод "DummyMain". Страницы. Элемент. Представитель. */
export class AppModDummyMainPageItemPresenter extends AppCoreCommonPagePresenter<AppModDummyMainPageItemModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageItemResources}
   */
  get resources(): AppModDummyMainPageItemResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModDummyMainPageItemModel} model Модель.
   * @param {AppModDummyMainPageItemView} view Вид.
   */
  constructor(
    model: AppModDummyMainPageItemModel,
    private view: AppModDummyMainPageItemView
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

    const {
      formGroup
    } = this.view;

    if (formGroup.dirty) {
      return appDialog.confirm$(
        actionDeactivate.confirm
      ).pipe(
        map(isOk => {
          if (isOk) {
            this.restore();
          }

          return isOk;
        })
      );
    } else {
      return of(true);
    }
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

    this.view.isActionStarted = false;

    this.refreshFields();
  }

  /** @inheritDoc */
  onInit() {
    this.model.getIsDataChangeAllowed$().subscribe(this.onGetIsDataChangeAllowed);

    super.onInit();
  }

  /** Обработчик события освежения. */
  onRefresh() {
    this.model.onReceiveEnsureLoadDataRequest();

    this.refresh();
  }

  /** Обработчик события отправки. */
  onSubmit() {
    if (!this.view.formGroup.valid) {
      return;
    }

    const input = appModDummyMainJobItemGetOutputCreate();

    let {
      data
    } = this.view;

    const {
      fieldName,
      fieldObjectDummyOneToMany
    } = this.view;

    if (!data) {
      data = appModDummyMainJobItemGetOutputCreate();
    }

    input.objectDummyMain = data.objectDummyMain ?? appDataObjectDummyMainCreate();

    const {
      objectDummyMain
    } = input;

    objectDummyMain.name = fieldName.value;
    objectDummyMain.objectDummyOneToManyId = +fieldObjectDummyOneToMany.value;

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

  private clearFields() {
    const {
      fieldId,
      fieldName,
      fieldObjectDummyOneToMany
    } = this.view;

    fieldId.setValue('', {emitEvent: false});
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

  /** @param {AppModDummyMainJobItemGetOutput} data */
  private loadData(data: AppModDummyMainJobItemGetOutput) {
    if (data) {
      this.view.data = data;

      const {
        objectDummyMain
      } = this.view.data;

      const {
        fieldId,
        fieldName,
        fieldObjectDummyOneToMany
      } = this.view;

      if (objectDummyMain) {
        fieldId.setValue(objectDummyMain.id, {emitEvent: false});
        fieldName.setValue(objectDummyMain.name, {emitEvent: false});
        fieldObjectDummyOneToMany.setValue(objectDummyMain.objectDummyOneToManyId, {emitEvent: false});
      }
    } else {
      this.view.data = appModDummyMainJobItemGetOutputCreate();
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

  private loadJobOptionsDummyManyToManyGetResult() {
    const {
      jobOptionsDummyManyToManyGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      this.view.loadOptionsDummyManyToMany(data);
    }
  }

  private loadJobOptionsDummyOneToManyGetResult() {
    const {
      jobOptionsDummyOneToManyGetResult: result
    } = this.model.getState();

    if (result) {
      const {
        data,
        errorMessages,
        successMessages
      } = result;

      this.view.loadResponseErrorMessages(errorMessages);
      this.view.loadResponseSuccessMessages(successMessages);

      this.view.loadOptionsDummyOneToMany(data);
    }
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

    switch (action) {
      case AppModDummyMainPageItemEnumActions.LoadSuccess:
        this.onDataChangedByLoadSuccess();
        break;
      case AppModDummyMainPageItemEnumActions.SaveSuccess:
        this.onDataChangedBySaveSuccess();
        break;
    }

    this.hideSpinners();

    this.view.isActionStarted = false;

    this.refreshFields();
  }

  private onDataChangedByLoadSuccess() {
    this.loadJobItemGetResult();
    this.loadJobOptionsDummyManyToManyGetResult();
    this.loadJobOptionsDummyOneToManyGetResult();
  }

  private onDataChangedBySaveSuccess() {
    if (this.loadJobItemGetResult()) {
      const {
        jobItemGetInput: input
      } = this.model.getState();

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
      this.refreshFields();
    }
  }

  /** @param {AppModDummyMainPageItemState} state */
  private onGetState(state: AppModDummyMainPageItemState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModDummyMainPageItemEnumActions.Load:
        case AppModDummyMainPageItemEnumActions.Save:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModDummyMainPageItemEnumActions.LoadSuccess:
        case AppModDummyMainPageItemEnumActions.SaveSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private refresh() {
    this.model.executeActionRefresh();
  }

  private refreshFields() {
    const {
      fieldName,
      fieldObjectDummyOneToMany,
      isActionStarted,
      isDataChangeAllowed
    } = this.view;

    if (isActionStarted) {
      fieldName.disable();
      fieldObjectDummyOneToMany.disable();
    } else if (isDataChangeAllowed) {
      fieldName.enable();
      fieldObjectDummyOneToMany.enable();
    }
  }

  private resetForm() {
    this.view.resetForm();
    this.view.formGroup.reset();
  }

  private restore() {
    const {
      jobItemGetResult
    } = this.model.getState();

    if (!!jobItemGetResult) {
      this.loadData(jobItemGetResult.data);
    } else {
      this.clearFields();
    }
  }
}
