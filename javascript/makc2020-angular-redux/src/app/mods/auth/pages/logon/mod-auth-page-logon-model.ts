// //Author Maxim Kuzmin//makc//

import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartAuthService} from '@app/host/parts/auth/host-part-auth.service';
import {AppHostPartAuthState} from '@app/host/parts/auth/host-part-auth-state';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppHostPartAuthCommonJobLoginInput} from '@app/host/parts/auth/common/jobs/login/host-part-auth-common-job-login-input';
import {AppModAuthPageRedirectService} from '../redirect/mod-auth-page-redirect.service';
import {AppModAuthPageLogonResources} from './mod-auth-page-logon-resources';
import {AppModAuthPageLogonService} from './mod-auth-page-logon.service';
import {AppModAuthPageLogonState} from './mod-auth-page-logon-state';
import {AppModAuthPageLogonStore} from './mod-auth-page-logon-store';
import {AppModAuthPageLogonSettingFields} from './settings/mod-auth-page-logon-setting-fields';
import {AppModAuthPageLogonSettingErrors} from './settings/mod-auth-page-logon-setting-errors';
import { Injectable } from "@angular/core";

/** Мод "Auth". Страницы. Вход в систему. Модель. */
@Injectable()
export class AppModAuthPageLogonModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModAuthPageLogonResources}
   */
  resources: AppModAuthPageLogonResources;

  /**
   * Конструктор.
   * @param {AppHostPartAuthService} appAuth Аутентификация.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageLogonService} appModAuthPageLogon Страница "ModAuthPageLogon".
   * @param {AppModAuthPageRedirectService} appModAuthPageRedirect Страница "ModAuthPageRedirect".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModAuthPageLogonStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appAuth: AppHostPartAuthService,
    private appAuthStore: AppHostPartAuthStore,
    appLocalizer: AppCoreLocalizationService,
    private appLogger: AppCoreLoggingService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageLogon: AppModAuthPageLogonService,
    private appModAuthPageRedirect: AppModAuthPageRedirectService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModAuthPageLogonStore,
    appTitle: AppCoreTitleService,
    public extFormBuilder: FormBuilder,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppModAuthPageLogonResources(
      appLocalizer,
      this.appModAuthPageLogon.settings,
      this.unsubscribe$
    );
  }

  /**
   * Получить состояние аутентификации.
   * @returns {AppModAuthPageLogonState} Состояние аутентификации.
   */
  getAuthState(): AppHostPartAuthState {
    return this.appAuthStore.getState();
  }

  /**
   * Получить поток состояния аутентификации.
   * @returns {Observable<AppHostPartAuthState>} Поток состояния аутентификации.
   */
  getAuthState$(): Observable<AppHostPartAuthState> {
    return this.appAuthStore.getState$(this.unsubscribe$);
  }

  /**
   * Получить настройку ошибок.
   * @returns {AppModAuthPageLogonSettingErrors} Настройка ошибок.
   */
  getSettingErrors(): AppModAuthPageLogonSettingErrors {
    return this.appModAuthPageLogon.settings.errors;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModAuthPageLogonSettingFields} Настройка полей.
   */
  getSettingFields(): AppModAuthPageLogonSettingFields {
    return this.appModAuthPageLogon.settings.fields;
  }

  /**
   * Получить состояние.
   * @returns {AppModAuthPageLogonState} Состояние.
   */
  getState(): AppModAuthPageLogonState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModAuthPageLogonState>} Поток состояния.
   */
  getState$(): Observable<AppModAuthPageLogonState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /**
   * Выполнить действие "Вход в систему".
   * @param {AppHostPartAuthCommonJobLoginInput} input
   */
  executeActionLogin(input: AppHostPartAuthCommonJobLoginInput) {
    this.appStore.runActionLogin(input);
  }

  /** Выполнить действие "Выход из системы". */
  executeActionLogout() {
    this.appAuth.logout(this.appLogger);

    const {
      currentUser,
      isLoggedIn
    } = this.appAuthStore.getState();

    this.appStore.runActionLogout(currentUser, isLoggedIn);
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

    const {
      key: keyRedirect
    } = this.appModAuthPageRedirect.settings;

    const lookupOptionByMenuNodeKey = {
      [keyRedirect]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      }
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();

    const {
      currentUser,
      isLoggedIn
    } = this.appAuthStore.getState();

    this.appStore.runActionLoad(currentUser, isLoggedIn);
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModAuthPageLogon.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
