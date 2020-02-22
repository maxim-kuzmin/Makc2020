// //Author Maxim Kuzmin//makc//

import {FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';
import {Observable, Subscription} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreLocalizationStore} from '@app/core/localization/core-localization-store';
import {AppHostPartAuthService} from '@app/host/parts/auth/host-part-auth.service';
import {AppHostPartAuthState} from '@app/host/parts/auth/host-part-auth-state';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppRootPageIndexService} from '@app/root/pages/index/root-page-index.service';
import {AppHostLayoutHeaderResources} from './host-layout-header-resources';
import {AppHostLayoutHeaderSettings} from './host-layout-header-settings';
import { Injectable } from '@angular/core';

/** Хост. Разметка. Шапка. Модель. */
@Injectable()
export class AppHostLayoutHeaderModel extends AppCoreCommonUnsubscribable {

  /**
   * Ресурсы.
   * @type {AppHostLayoutHeaderResources}
   */
  resources: AppHostLayoutHeaderResources;

  /**
   * Настройки.
   * @type {AppHostLayoutHeaderSettings}
   */
  settings = new AppHostLayoutHeaderSettings();

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLocalizationStore} appLocalizerStore Хранилище состояния локализатора.
   * @param {AppRootPageIndexService} appRootPageIndex Страница "RootPageIndex".
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appLocalizer: AppCoreLocalizationService,
    private appLocalizerStore: AppCoreLocalizationStore,
    private appRootPageIndex: AppRootPageIndexService,
    public extFormBuilder: FormBuilder,
    private extRouter: Router
  ) {
    super();

    this.resources = new AppHostLayoutHeaderResources(
      this.appLocalizer,
      this.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу "RootPageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToRootPageIndexCreate(): any[] {
    return [this.appRootPageIndex.settings.path];
  }

  /**
   * Выполнить действие "Язык. Установить".
   * @type {string} Ключ языка.
   */
  executeActionLanguageSet(languageKey: string) {
    this.appLocalizer.executeActionLanguageSet(languageKey);
  }

  /**
   * Получить ключ языка.
   * @type {string}
   */
  getLanguageKey(): string {
    return this.appLocalizerStore.getState().languageKey;
  }

  /**
   * Подписаться на событие.
   * @param {Observable<T>} event$ Событие.
   * @param {(T) => void} eventHandler Обработчик события.
   */
  subscribeToEvent<T>(event$: Observable<T>, eventHandler: (T) => void): Subscription {
    return event$.pipe(
      takeUntil(this.unsubscribe$)
    ).subscribe(
      eventHandler
    );
  }
}
