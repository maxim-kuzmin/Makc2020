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
import {AppModDummyMainPageIndexService} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index.service';
import {AppModDummyTreePageIndexService} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index.service';
import {AppRootPageAdministrationResources} from './root-page-administration-resources';
import {AppRootPageAdministrationService} from './root-page-administration.service';
import {AppRootPageAdministrationState} from './root-page-administration-state';
import {AppRootPageAdministrationStore} from './root-page-administration-store';

/** Корень. Страницы. Администрирование. Модель. */
@Injectable()
export class AppRootPageAdministrationModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageAdministrationResources}
   */
  resources: AppRootPageAdministrationResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageIndexService} appModDummyMainPageIndex Страница "ModDummyMainPageIndex".
   * @param {AppModDummyTreePageIndexService} appModDummyTreePageIndex Страница "ModDummyTreePageIndex".
   * @param {AppRootPageAdministrationService} appRootPageAdministration Страница "RootPageAdministration".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageAdministrationStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appModDummyMainPageIndex: AppModDummyMainPageIndexService,
    private appModDummyTreePageIndex: AppModDummyTreePageIndexService,
    private appRootPageAdministration: AppRootPageAdministrationService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageAdministrationStore,
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

    this.resources = new AppRootPageAdministrationResources(
      appLocalizer,
      this.appRootPageAdministration.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу "ModDummyMainPageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToModDummyMainPageIndex(): any[] {
    return [this.appModDummyMainPageIndex.settings.path];
  }

  /**
   * Создать ссылку маршрутизатора на страницу "ModDummyTreePageIndex".
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToModDummyTreePageIndex(): any[] {
    return [this.appModDummyTreePageIndex.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageAdministrationState} Состояние.
   */
  getState(): AppRootPageAdministrationState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageAdministrationState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageAdministrationState> {
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
      this.appRootPageAdministration.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
