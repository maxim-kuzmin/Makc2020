// //Author Maxim Kuzmin//makc//

import {FormBuilder} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModAuthPageRedirectService} from '../redirect/mod-auth-page-redirect.service';
import {AppModAuthPageRegisterService} from './mod-auth-page-register.service';
import {AppModAuthPageRegisterResources} from './mod-auth-page-register-resources';
import {AppModAuthPageRegisterState} from './mod-auth-page-register-state';
import {AppModAuthPageRegisterStore} from './mod-auth-page-register-store';
import {AppModAuthPageRegisterSettingErrors} from './settings/mod-auth-page-register-setting-errors';
import {AppModAuthPageRegisterSettingFields} from './settings/mod-auth-page-register-setting-fields';
import { Injectable } from '@angular/core';

/** Мод "Auth". Страницы. Регистрация. Модель. */
@Injectable()
export class AppModAuthPageRegisterModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModAuthPageRegisterResources}
   */
  resources: AppModAuthPageRegisterResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingStore} appLoggerStore Хранилище состояния регистратора.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageRedirectService} appModAuthPageRedirect Страница "ModAuthPageRedirect".
   * @param {AppModAuthPageRegisterService} appModAuthPageRegister Страница "ModAuthPageRegister".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModAuthPageRegisterStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appLoggerStore: AppCoreLoggingStore,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageRedirect: AppModAuthPageRedirectService,
    private appModAuthPageRegister: AppModAuthPageRegisterService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModAuthPageRegisterStore,
    appTitle: AppCoreTitleService,
    public extFormBuilder: FormBuilder,
    extRoute: ActivatedRoute
  ) {
    super(
      appLoggerStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppModAuthPageRegisterResources(
      appLocalizer,
      this.appModAuthPageRegister.settings,
      this.unsubscribe$
    );
  }

  /**
   * Получить настройку ошибок.
   * @returns {AppModAuthPageRegisterSettingErrors} Настройка ошибок.
   */
  getSettingErrors(): AppModAuthPageRegisterSettingErrors {
    return this.appModAuthPageRegister.settings.errors;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModAuthPageRegisterSettingErrors} Настройка полей.
   */
  getSettingFields(): AppModAuthPageRegisterSettingFields {
    return this.appModAuthPageRegister.settings.fields;
  }

  /**
   * Получить состояние.
   * @returns {AppModAuthPageRegisterState} Состояние.
   */
  getState(): AppModAuthPageRegisterState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModAuthPageRegisterState>} Поток состояния.
   */
  getState$(): Observable<AppModAuthPageRegisterState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /**
   * Выполнить действие "Сохранение".
   * @param {AppHostPartAuthCommonJobRegisterInput} input Ввод.
   */
  executeActionSave(input: AppHostPartAuthCommonJobRegisterInput) {
    this.appStore.runActionSave(input);
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
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModAuthPageRegister.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
