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
import {AppModAuthPageIndexService} from '@app/mods/auth/pages/index/mod-auth-page-index.service';
import {AppRootPageContactsService} from '@app/root/pages/contacts/root-page-contacts.service';
import {AppRootPageSiteResources} from './root-page-site-resources';
import {AppRootPageSiteService} from './root-page-site.service';
import {AppRootPageSiteState} from './root-page-site-state';
import {AppRootPageSiteStore} from './root-page-site-store';

/** Корень. Страницы. Сайт. Модель. */
@Injectable()
export class AppRootPageSiteModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageSiteResources}
   */
  resources: AppRootPageSiteResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModAuthPageIndexService} appModAuthPageIndex Страница "ModAuthPageIndex".
   * @param {AppRootPageContactsService} appRootPageContacts Страница "RootPageContacts".
   * @param {AppRootPageSiteService} appRootPageSite Страница "RootPageSite".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageSiteStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appExceptionStore: AppCoreExceptionStore,
    private appMenu: AppHostPartMenuService,
    private appModAuthPageIndex: AppModAuthPageIndexService,
    private appRootPageContacts: AppRootPageContactsService,
    private appRootPageSite: AppRootPageSiteService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageSiteStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appExceptionStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppRootPageSiteResources(
      appLocalizer,
      this.appRootPageSite.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу "ModAuthPageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToModAuthPageIndex(): any[] {
    return [this.appModAuthPageIndex.settings.path];
  }

  /**
   * Создать ссылку маршрутизатора на страницу "RootPageContacts".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToRootPageContacts(): any[] {
    return [this.appRootPageContacts.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageSiteState} Состояние.
   */
  getState(): AppRootPageSiteState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageSiteState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageSiteState> {
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
    this.appTitle.executeActionItemAdd(
      this.appRootPageSite.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
