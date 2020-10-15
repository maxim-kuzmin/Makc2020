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
import {AppModDummyMainPageItemService} from '../item/mod-dummy-main-page-item.service';
import {AppModDummyMainPageListService} from '../list/mod-dummy-main-page-list.service';
import {AppModDummyMainPageIndexResources} from './mod-dummy-main-page-index-resources';
import {AppModDummyMainPageIndexService} from './mod-dummy-main-page-index.service';
import {AppModDummyMainPageIndexState} from './mod-dummy-main-page-index-state';
import {AppModDummyMainPageIndexStore} from './mod-dummy-main-page-index-store';

/** Мод "DummyMain". Страницы. Начало. Модель. */
@Injectable()
export class AppModDummyMainPageIndexModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageIndexResources}
   */
  resources: AppModDummyMainPageIndexResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageIndexService} appModDummyMainPageIndex Страница "ModDummyMainPageIndex".
   * @param {AppModDummyMainPageItemService} appModDummyMainPageItem Страница "ModDummyMainPageItem".
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyMainPageIndexStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appModDummyMainPageIndex: AppModDummyMainPageIndexService,
    private appModDummyMainPageItem: AppModDummyMainPageItemService,
    private appModDummyMainPageList: AppModDummyMainPageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyMainPageIndexStore,
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

    this.resources = new AppModDummyMainPageIndexResources(
      appLocalizer,
      this.appModDummyMainPageIndex.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать ссылку маршрутизатора на страницу создания элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemCreate(): any[] {
    return [this.appModDummyMainPageItem.settings.paths.pathCreate];
  }

  /**
   * Создать ссылку маршрутизатора на страницу редактирования элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemEdit(): any[] {
    return [this.appModDummyMainPageItem.settings.paths.pathEdit, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу просмотра элемента.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageItemView(): any[] {
    return [this.appModDummyMainPageItem.settings.paths.pathView, 1];
  }

  /**
   * Создать ссылку маршрутизатора на страницу списка.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLinkToPageList(): any[] {
    return [this.appModDummyMainPageList.settings.path];
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyMainPageIndexState} Состояние.
   */
  getState(): AppModDummyMainPageIndexState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyMainPageIndexState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyMainPageIndexState> {
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
    } = this.appModDummyMainPageItem.settings.keys;

    const lookupOptionByMenuNodeKey = {
      [keyEdit]: {
        isNeededToRemove: true
      } as AppHostPartMenuOption,
      [keyView]: {
        isNeededToRemove: true
      } as AppHostPartMenuOption
    };

    this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      const {
        titleResourceKey
      } = this.appModDummyMainPageIndex.settings;

      if (titleResourceKey) {
        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount = 1;
      }
    }
  }
}
