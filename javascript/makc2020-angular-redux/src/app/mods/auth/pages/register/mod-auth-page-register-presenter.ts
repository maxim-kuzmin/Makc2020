// //Author Maxim Kuzmin//makc//

import {Validators} from '@angular/forms';
import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppModAuthPageRegisterEnumActions} from './enums/mod-auth-page-register-enum-actions';
import {AppModAuthPageRegisterModel} from './mod-auth-page-register-model';
import {AppModAuthPageRegisterResources} from './mod-auth-page-register-resources';
import {AppModAuthPageRegisterState} from './mod-auth-page-register-state';
import {AppModAuthPageRegisterView} from './mod-auth-page-register-view';

/** Мод "Auth". Страницы. Регистрация. Представитель. */
export class AppModAuthPageRegisterPresenter extends AppCoreCommonPagePresenter<AppModAuthPageRegisterModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModAuthPageRegisterResources}
   */
  get resources(): AppModAuthPageRegisterResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModAuthPageRegisterModel} model Модель.
   * @param {AppModAuthPageRegisterView} view Вид.
   */
  constructor(
    model: AppModAuthPageRegisterModel,
    private view: AppModAuthPageRegisterView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onGetState = this.onGetState.bind(this);

    this.buildView();
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.initRefreshSpinner();

    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /**
   * @inheritDoc
   * @param {string} errorMessage Сообщение об ошибке.
   * @param {any} errorData Данные ошибки.
   */
  protected onError(errorMessage: string, errorData: any) {
    this.view.hideRefreshSpinner();

    super.onError(errorMessage, errorData);
  }

  /** Обработчик события отправки. */
  onSubmit() {
    const {
      formGroup
    } = this.view;

    if (!formGroup.valid) {
      return;
    }

    const input = new AppHostPartAuthCommonJobRegisterInput();

    const {
      errorPasswordConfirm
    } = this.model.getSettingErrors();

    const {
      fieldEmail,
      fieldFullName,
      fieldPassword,
      fieldUserName,
      fieldPasswordConfirm
    } = this.model.getSettingFields();

    input.dataEmail = formGroup.get(fieldEmail.name).value;
    input.dataFullName = formGroup.get(fieldFullName.name).value;
    input.dataPassword = formGroup.get(fieldPassword.name).value;
    input.dataUserName = formGroup.get(fieldUserName.name).value;

    const passwordConfirm = <string>formGroup.get(fieldPasswordConfirm.name).value;

    let isOk = true;

    if (input.dataPassword !== passwordConfirm) {
      isOk = false;

      this.view.requestErrorMessages = [errorPasswordConfirm.messageResourceKey];
    }

    if (isOk) {
      this.view.requestErrorMessages = [];
      this.view.isPasswordHidden = true;
      this.view.isPasswordConfirmHidden = true;

      this.model.executeActionSave(input);
    }
  }

  private buildView() {
    const {
      extFormBuilder
    } = this.model;

    const {
      fieldEmail,
      fieldFullName,
      fieldPassword,
      fieldPasswordConfirm,
      fieldUserName
    } = this.model.getSettingFields();

    const formGroup = extFormBuilder.group({
      [fieldEmail.name]: ['', Validators.compose([Validators.required, Validators.email])],
      [fieldFullName.name]: [''],
      [fieldPassword.name]: ['', Validators.required],
      [fieldPasswordConfirm.name]: ['', Validators.required],
      [fieldUserName.name]: ['', Validators.required]
    });

    this.view.build(formGroup);
  }

  private onActionsDataChanging() {
    this.view.showRefreshSpinner();
  }

  private onActionsDataChanged() {
    const {
      action
    } = this.model.getState();

    let isCompleted = false;

    if (action === AppModAuthPageRegisterEnumActions.SaveSuccess) {
        isCompleted = this.onDataChangedBySaveSuccess();
    }

    if (isCompleted) {
      this.view.hideRefreshSpinner();
    }
  }

  /** @returns {boolean} */
  private onDataChangedBySaveSuccess(): boolean {
    const {
      jobRegisterResult: result
    } = this.model.getState();

    if (result) {
      const {
        isOk,
        errorMessages,
        successMessages
      } = result;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (isOk) {
        this.resetForm();
      }
    }

    return true;
  }

  /** @param {AppModAuthPageRegisterState} state */
  private onGetState(state: AppModAuthPageRegisterState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModAuthPageRegisterEnumActions.Save:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModAuthPageRegisterEnumActions.SaveSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }

  private resetForm() {
    this.view.resetForm();
    this.view.formGroup.reset();
  }
}
