// //Author Maxim Kuzmin//makc//

import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModAuthPageLogonService} from '@app/mods/auth/pages/logon/mod-auth-page-logon.service';
import {AppModAuthPageRegisterService} from '@app/mods/auth/pages/register/mod-auth-page-register.service';
import {AppRootPageIndexService} from '@app/root/pages/index/root-page-index.service';
import {AppModAuthPageRedirectResources} from './mod-auth-page-redirect-resources';
import {AppModAuthPageRedirectService} from './mod-auth-page-redirect.service';
import {AppModAuthPageRedirectState} from './mod-auth-page-redirect-state';
import {AppModAuthPageRedirectStore} from './mod-auth-page-redirect-store';
import { Injectable } from "@angular/core";

/** Мод "Auth". Страницы. Перенаправление. Модель. */
@Injectable()
export class AppModAuthPageRedirectModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModAuthPageRedirectResources}
   */
  resources: AppModAuthPageRedirectResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageRedirectService} appModAuthPageRedirect Страница "ModAuthPageRedirect".
   * @param {AppModAuthPageLogonService} appModAuthPageLogon Страница "ModAuthPageLogon".
   * @param {AppModAuthPageRegisterService} appModAuthPageRegister Страница "ModAuthPageRegister".
   * @param {AppRootPageIndexService} appRootPageIndex Страница "RootPageIndex".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModAuthPageRedirectStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appAuthStore: AppHostPartAuthStore,
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageRedirect: AppModAuthPageRedirectService,
    private appModAuthPageLogon: AppModAuthPageLogonService,
    private appModAuthPageRegister: AppModAuthPageRegisterService,
    private appRootPageIndex: AppRootPageIndexService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModAuthPageRedirectStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onAuthTypeOidcGetState = this.onAuthTypeOidcGetState.bind(this);

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

  /** Выполнить действие "Перенаправление на стартовую страницу". */
  executeActionRedirectToRootPageIndex() {
    this.executeActionRedirect(this.appRootPageIndex.settings.path);
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
      [pageKey]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      }
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();

    if (this.appAuthTypeOidc.isEnabled) {
      const {
        returnUrl
      } = this.appAuthTypeOidc;

      if (returnUrl) {
        this.appAuthStore.runActionReturnUrlSet(returnUrl);
      }

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
      this.appStore.runActionLoad();
    }
  }
}
