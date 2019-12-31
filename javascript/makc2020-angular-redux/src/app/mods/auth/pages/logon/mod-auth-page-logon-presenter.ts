// //Author Maxim Kuzmin//makc//

import {isDevMode} from '@angular/core';
import {Validators} from '@angular/forms';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppHostAuthCommonJobLoginInput} from '@app/host/auth/common/jobs/login/host-auth-common-job-login-input';
import {AppHostAuthState} from '@app/host/auth/host-auth-state';
import {AppHostAuthEnumActions} from '@app/host/auth/enums/host-auth-enum-actions';
import {AppModAuthPageLogonEnumActions} from './enums/mod-auth-page-logon-enum-actions';
import {AppModAuthPageLogonView} from './mod-auth-page-logon-view';
import {AppModAuthPageLogonResources} from './mod-auth-page-logon-resources';
import {AppModAuthPageLogonState} from './mod-auth-page-logon-state';
import {AppModAuthPageLogonModel} from './mod-auth-page-logon-model';

/** Мод "Auth". Страницы. Вход в систему. Представитель. */
export class AppModAuthPageLogonPresenter {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModAuthPageLogonResources}
   */
  get resources(): AppModAuthPageLogonResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModAuthPageLogonModel} model Модель.
   * @param {AppModAuthPageLogonView} view Вид.
   */
  constructor(
    private model: AppModAuthPageLogonModel,
    private view: AppModAuthPageLogonView
  ) {
    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onGetState = this.onGetState.bind(this);
    this.onGetAuthState = this.onGetAuthState.bind(this);

    this.buildView();
  }

  /** Обработчик события после инициализации представления. */
  onAfterViewInit() {
    this.view.initRefreshSpinner();

    this.model.getAuthState$().subscribe(this.onGetAuthState);
    this.model.getState$().subscribe(this.onGetState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.model.onInit();
  }

  /** Обработчик события отправки. */
  onSubmit() {
    const {
      formGroup
    } = this.view;

    this.view.isPasswordHidden = true;

    if (this.view.isLoggedIn) {
      this.model.executeActionLogout();
    } else if (formGroup.valid) {
      const input = new AppHostAuthCommonJobLoginInput();

      const {
        fieldUserName,
        fieldPassword
      } = this.model.getSettingFields();

      input.dataUserName = formGroup.get(fieldUserName.name).value;
      input.dataPassword = formGroup.get(fieldPassword.name).value;

      this.model.executeActionLogin(input);
    }
  }

  private buildView() {
    const {
      extFormBuilder
    } = this.model;

    const {
      fieldUserName,
      fieldPassword
    } = this.model.getSettingFields();

    const formGroup = extFormBuilder.group({
      [fieldUserName.name]: ['', Validators.required],
      [fieldPassword.name]: ['', Validators.required]
    });

    this.view.build(
      formGroup,
      this.resources.buttons
    );

    this.initForm();
  }

  private initForm() {
    if (isDevMode()) {
      this.view.fieldUserName.setValue('admin', {emitEvent: false});
      this.view.fieldPassword.setValue('Admin(2019)', {emitEvent: false});
    }
  }

  private onActionAuthCurrentUserSet() {
    const {
      action
    } = this.model.getState();

    const {
      isLoggedIn
    } = this.model.getAuthState();

    if (action !== AppModAuthPageLogonEnumActions.Login) {
      this.resetForm();
      this.initForm();
    }

    this.view.isLoggedIn = isLoggedIn;
  }

  private onActionsDataChanging() {
    this.view.showRefreshSpinner();
  }

  private onActionsDataChanged() {
    this.onActionsDataChangedByLoadOrSubmit();

    const {
      action
    } = this.model.getState();

    if (action === AppModAuthPageLogonEnumActions.LoginSuccess) {
      this.onActionsDataChangedByLoginSuccess();
    }

    this.view.hideRefreshSpinner();
  }

  private onActionsDataChangedByLoadOrSubmit() {
    const {
      currentUser,
      isLoggedIn
    } = this.model.getState();

    this.view.userName = currentUser ? currentUser.userName : null;
    this.view.isLoggedIn = isLoggedIn;
  }

  private onActionsDataChangedByLoginSuccess() {
    const {
      isLoggedIn,
      jobLoginResult: result,
      redirectUrl
    } = this.model.getState();

    if (result) {
      const {
        errorMessages,
        successMessages
      } = result;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (isLoggedIn && redirectUrl) {
        this.model.executeActionRedirect(redirectUrl);
      }
    }
  }

  /** @param {AppHostAuthState} state  */
  private onGetAuthState(state: AppHostAuthState) {
    const {
      action
    } = state;

    if (action === AppHostAuthEnumActions.CurrentUserSet) {
      this.onActionAuthCurrentUserSet();
    }
  }

  /** @param {AppModAuthPageLogonState} state */
  private onGetState(state: AppModAuthPageLogonState) {
    if (state) {
      const {
        action
      } = state;

      this.view.responseErrorMessages = [];
      this.view.responseSuccessMessages = [];

      switch (action) {
        case AppModAuthPageLogonEnumActions.Login:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModAuthPageLogonEnumActions.Load:
        case AppModAuthPageLogonEnumActions.LoginSuccess:
        case AppModAuthPageLogonEnumActions.Logout:
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