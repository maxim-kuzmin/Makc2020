// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModAuthPageLogonService} from '@app/mods/auth/pages/logon/mod-auth-page-logon.service';
import {AppModAuthPageRegisterService} from '@app/mods/auth/pages/register/mod-auth-page-register.service';
import {AppModAuthPageIndexResources} from './mod-auth-page-index-resources';
import {AppModAuthPageIndexService} from './mod-auth-page-index.service';
import {AppModAuthPageIndexState} from './mod-auth-page-index-state';
import {AppModAuthPageIndexStore} from './mod-auth-page-index-store';

/** Мод "Auth". Страницы. Начало. Модель. */
@Injectable()
export class AppModAuthPageIndexModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModAuthPageIndexResources}
   */
  resources: AppModAuthPageIndexResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageIndexService} appModAuthPageIndex Страница "ModAuthPageIndex".
   * @param {AppModAuthPageLogonService} appModAuthPageLogon Страница "ModAuthPageLogon".
   * @param {AppModAuthPageRegisterService} appModAuthPageRegister Страница "ModAuthPageRegister".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModAuthPageIndexStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageIndex: AppModAuthPageIndexService,
    private appModAuthPageLogon: AppModAuthPageLogonService,
    private appModAuthPageRegister: AppModAuthPageRegisterService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModAuthPageIndexStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appExceptionStore,
      appLocalizer,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppModAuthPageIndexResources(
      appLocalizer,
      this.appModAuthPageIndex.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу входа в систему.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageLogon(): any[] {
    return [this.appModAuthPageLogon.settings.path];
  }

  /**
   * Создать ссылку маршрутизатора на страницу регистрации.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageRegister(): any[] {
    return [this.appModAuthPageRegister.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppModAuthPageIndexState} Состояние.
   */
  getState(): AppModAuthPageIndexState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModAuthPageIndexState>} Поток состояния.
   */
  getState$(): Observable<AppModAuthPageIndexState> {
    return this.appStore.getState$(this.unsubscribe$);
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

    this.appMenu.executeActionSet(this.pageKey);

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      const {
        titleResourceKey
      } = this.appModAuthPageIndex.settings;

      if (!!titleResourceKey) {
        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount++;
      }
    }
  }
}
