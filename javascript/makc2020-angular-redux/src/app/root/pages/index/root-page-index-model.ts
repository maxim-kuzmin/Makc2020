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
import {AppRootPageAdministrationService} from '../administration/root-page-administration.service';
import {AppRootPageSiteService} from '../site/root-page-site.service';
import {AppRootPageIndexResources} from './root-page-index-resources';
import {AppRootPageIndexService} from './root-page-index.service';
import {AppRootPageIndexState} from './root-page-index-state';
import {AppRootPageIndexStore} from './root-page-index-store';

/** Корень. Страницы. Начало. Модель. */
@Injectable()
export class AppRootPageIndexModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageIndexResources}
   */
  resources: AppRootPageIndexResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppRootPageAdministrationService} appRootPageAdministration
   * @param {AppRootPageIndexService} appRootPageIndex Страница "RootPageIndex".
   * @param {AppRootPageSiteService} appRootPageSite
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageIndexStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appRootPageAdministration: AppRootPageAdministrationService,
    private appRootPageIndex: AppRootPageIndexService,
    private appRootPageSite: AppRootPageSiteService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageIndexStore,
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

    this.resources = new AppRootPageIndexResources(
      appLocalizer,
      this.appRootPageIndex.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу "RootPageAdministration".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToRootPageAdministration(): any[] {
    return [this.appRootPageAdministration.settings.path];
  }

  /**
   * Создать ссылку маршрутизатора на страницу "RootPageSite".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToRootPageSite(): any[] {
    return [this.appRootPageSite.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageIndexState} Состояние.
   */
  getState(): AppRootPageIndexState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageIndexState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageIndexState> {
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
      this.appRootPageIndex.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
