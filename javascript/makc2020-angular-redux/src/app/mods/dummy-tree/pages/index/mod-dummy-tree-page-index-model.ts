// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Observable} from 'rxjs';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyTreePageItemService} from '../item/mod-dummy-tree-page-item.service';
import {AppModDummyTreePageListService} from '../list/mod-dummy-tree-page-list.service';
import {AppModDummyTreePageIndexResources} from './mod-dummy-tree-page-index-resources';
import {AppModDummyTreePageIndexService} from './mod-dummy-tree-page-index.service';
import {AppModDummyTreePageIndexState} from './mod-dummy-tree-page-index-state';
import {AppModDummyTreePageIndexStore} from './mod-dummy-tree-page-index-store';

/** Мод "DummyTree". Страницы. Начало. Модель. */
@Injectable()
export class AppModDummyTreePageIndexModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageIndexResources}
   */
  resources: AppModDummyTreePageIndexResources;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyTreePageIndexService} appModDummyTreePageIndex Страница "ModDummyTreePageIndex".
   * @param {AppModDummyTreePageItemService} appModDummyTreePageItem Страница "ModDummyTreePageItem".
   * @param {AppModDummyTreePageListService} appModDummyTreePageList Страница "ModDummyTreePageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyTreePageIndexStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    appExceptionStore: AppCoreExceptionStore,
    private appMenu: AppHostPartMenuService,
    private appModDummyTreePageIndex: AppModDummyTreePageIndexService,
    private appModDummyTreePageItem: AppModDummyTreePageItemService,
    private appModDummyTreePageList: AppModDummyTreePageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyTreePageIndexStore,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute
  ) {
    super(
      appExceptionStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.resources = new AppModDummyTreePageIndexResources(
      appLocalizer,
      this.appModDummyTreePageIndex.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу создания элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemCreate(): any[] {
    return [this.appModDummyTreePageItem.settings.paths.pathCreate];
  }

  /**
   * Создать ссылку маршрутизатора на страницу редактирования элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemEdit(): any[] {
    return [this.appModDummyTreePageItem.settings.paths.pathEdit, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу просмотра элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemView(): any[] {
    return [this.appModDummyTreePageItem.settings.paths.pathView, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу списка.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageList(): any[] {
    return [this.appModDummyTreePageList.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyTreePageIndexState} Состояние.
   */
  getState(): AppModDummyTreePageIndexState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyTreePageIndexState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyTreePageIndexState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    const {
      keyEdit,
      keyView
    } = this.appModDummyTreePageItem.settings.keys;

    const lookupOptionByMenuNodeKey = {
      [keyEdit]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      },
      [keyView]: <AppHostPartMenuOption>{
        isNeededToRemove: true
      }
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.appModDummyTreePageIndex.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}