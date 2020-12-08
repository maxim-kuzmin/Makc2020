// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {filter} from 'rxjs/operators';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartAuthState} from '@app/host/parts/auth/host-part-auth-state';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppHostPartAuthEnumActions} from '@app/host/parts/auth/enums/host-part-auth-enum-actions';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModAuthPageLogonService} from '@app/mods/auth/pages/logon/mod-auth-page-logon.service';
import {AppModAuthPageRegisterService} from '@app/mods/auth/pages/register/mod-auth-page-register.service';
import {AppModAuthPageRedirectResources} from './mod-auth-page-redirect-resources';
import {AppModAuthPageRedirectService} from './mod-auth-page-redirect.service';
import {AppModAuthPageRedirectState} from './mod-auth-page-redirect-state';
import {AppModAuthPageRedirectStore} from './mod-auth-page-redirect-store';

/** Мод "Auth". Страницы. Перенаправление. Модель. */
@Injectable()
export class AppModAuthPageRedirectModel extends AppCoreCommonPageModel {

  private isLoaded = false;

  /**
   * Ресурсы.
   * @type {AppModAuthPageRedirectResources}
   */
  resources: AppModAuthPageRedirectResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageRedirectService} appModAuthPageRedirect Страница "ModAuthPageRedirect".
   * @param {AppModAuthPageLogonService} appModAuthPageLogon Страница "ModAuthPageLogon".
   * @param {AppModAuthPageRegisterService} appModAuthPageRegister Страница "ModAuthPageRegister".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModAuthPageRedirectStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appAuthStore: AppHostPartAuthStore,
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageRedirect: AppModAuthPageRedirectService,
    private appModAuthPageLogon: AppModAuthPageLogonService,
    private appModAuthPageRegister: AppModAuthPageRegisterService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModAuthPageRedirectStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appExceptionStore,
      appLocalizer,
      appRoute,
      appTitle,
      extRoute
    );

    this.onAuthTypeOidcGetState = this.onAuthTypeOidcGetState.bind(this);
    this.onAuthStoreGetState = this.onAuthStoreGetState.bind(this);

    this.resources = new AppModAuthPageRedirectResources(
      appLocalizer,
      this.appModAuthPageRedirect.settings,
      this.unsubscribe$
    );
  }

  /**
   * Получить состояние.
   * @returns {AppModAuthPageRedirectState} Состояние.
   */
  getState(): AppModAuthPageRedirectState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModAuthPageRedirectState>} Поток состояния.
   */
  getState$(): Observable<AppModAuthPageRedirectState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /**
   * Выполнить действие "Перенаправление".
   * @param {string} redirectUrl URL перенаправления.
   */
  executeActionRedirect(redirectUrl: string) {
    this.extRouter.navigateByUrl(redirectUrl).catch();
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /**
   * @inheritDoc
   * @param {string} pageKey
   */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    const lookupOptionByMenuNodeKey = {
      [pageKey]: {
        isNeededToRemove: true
      } as AppHostPartMenuOption
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();

    if (this.appAuthTypeOidc.isEnabled) {
      this.appAuthTypeOidcStore.getState$(
        this.unsubscribe$
      ).subscribe(
        this.onAuthTypeOidcGetState
      );
    }
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModAuthPageRedirect.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }

  private onAuthTypeOidcGetState(state: AppCoreAuthTypeOidcState) {
    const {
      isInitialized
    } = state;

    if (isInitialized) {
      this.appAuthStore.getState$(
        this.unsubscribe$
      ).pipe(
        filter(authState => authState.action === AppHostPartAuthEnumActions.ReturnUrlSet)
      ).subscribe(
        this.onAuthStoreGetState
      );
    }
  }

  private onAuthStoreGetState(state: AppHostPartAuthState) {
    if (!this.isLoaded) {
      this.isLoaded = true;
      this.appStore.runActionLoad();
    }
  }
}
