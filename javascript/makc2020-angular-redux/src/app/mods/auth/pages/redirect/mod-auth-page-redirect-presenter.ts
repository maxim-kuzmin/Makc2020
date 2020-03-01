// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPagePresenter} from '@app/core/common/page/core-common-page-presenter';
import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppModAuthPageRedirectEnumActions} from '@app/mods/auth/pages/redirect/enums/mod-auth-page-redirect-enum-actions';
import {AppModAuthPageRedirectModel} from './mod-auth-page-redirect-model';
import {AppModAuthPageRedirectResources} from './mod-auth-page-redirect-resources';
import {AppModAuthPageRedirectState} from './mod-auth-page-redirect-state';
import {AppModAuthPageRedirectView} from './mod-auth-page-redirect-view';

/** Мод "Auth". Страницы. Перенаправление. Представитель. */
export class AppModAuthPageRedirectPresenter extends AppCoreCommonPagePresenter<AppModAuthPageRedirectModel> {

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangedAsync: AppCoreExecutableAsync;

  /** @type {AppCoreExecutableAsync} */
  private onActionsDataChangingAsync: AppCoreExecutableAsync;

  /**
   * Ресурсы.
   * @type {AppModAuthPageRedirectResources}
   */
  get resources(): AppModAuthPageRedirectResources {
    return this.model.resources;
  }

  /**
   * Конструктор.
   * @param {AppModAuthPageRedirectModel} model Модель.
   * @param {AppModAuthPageRedirectView} view Вид.
   */
  constructor(
    model: AppModAuthPageRedirectModel,
    private view: AppModAuthPageRedirectView
  ) {
    super(model);

    this.onActionsDataChanged = this.onActionsDataChanged.bind(this);
    this.onActionsDataChangedAsync = new AppCoreExecutableAsync(this.onActionsDataChanged);

    this.onActionsDataChanging = this.onActionsDataChanging.bind(this);
    this.onActionsDataChangingAsync = new AppCoreExecutableAsync(this.onActionsDataChanging);

    this.onGetState = this.onGetState.bind(this);
    this.onDataLoaded = this.onDataLoaded.bind(this);
  }

  /** @inheritDoc */
  onAfterViewInit() {
    this.view.initLoadingSpinner(this.onDataLoaded);

    this.model.getState$().subscribe(this.onGetState);

    super.onAfterViewInit();
  }

  /**
   * @inheritDoc
   * @param {string[]} errorMessages
   * @param {any} errorData
   */
  protected onLogError(errorMessages: string[], errorData: any) {
    this.hideSpinners();

    super.onLogError(errorMessages, errorData);
  }

  private hideSpinners() {
    const {
      isDataLoaded
    } = this.view;

    if (!isDataLoaded) {
      this.view.hideLoadingSpinner();
    }
  }

  private onActionsDataChanging() {
    const {
      isDataLoaded
    } = this.view;

    if (!isDataLoaded) {
      this.view.showLoadingSpinner();
    }
  }

  private onActionsDataChanged() {
    const {
      action
    } = this.model.getState();

    if (action === AppModAuthPageRedirectEnumActions.LoadSuccess) {
      this.onDataChangedByLoadSuccess();
    }

    this.hideSpinners();
  }

  private onDataChangedByLoadSuccess() {
    const {
      jobCurrentUserGetResult: result,
      returnUrl
    } = this.model.getState();

    if (result) {
      const {
        errorMessages,
        successMessages
      } = result;

      this.view.responseErrorMessages = errorMessages;
      this.view.responseSuccessMessages = successMessages;

      if (returnUrl) {
        this.model.executeActionRedirect(returnUrl);
      }
    }
  }

  private onDataLoaded() {
    this.view.isDataLoaded = true;
  }

  /** @param {AppModAuthPageRedirectState} state */
  private onGetState(state: AppModAuthPageRedirectState) {
    if (state) {
      const {
        action
      } = state;

      switch (action) {
        case AppModAuthPageRedirectEnumActions.Load:
          this.onActionsDataChangingAsync.execute();
          break;
        case AppModAuthPageRedirectEnumActions.LoadSuccess:
          this.onActionsDataChangedAsync.execute();
          break;
      }
    }
  }
}
