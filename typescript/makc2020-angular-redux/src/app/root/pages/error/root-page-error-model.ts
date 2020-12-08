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
import {AppRootPageErrorResources} from './root-page-error-resources';
import {AppRootPageErrorService} from './root-page-error.service';
import {AppRootPageErrorState} from './root-page-error-state';
import {AppRootPageErrorStore} from './root-page-error-store';

/** Корень. Страницы. Ошибка. Модель. */
@Injectable()
export class AppRootPageErrorModel extends AppCoreCommonPageModel {

  /**
   * Ресурсы.
   * @type {AppRootPageErrorResources}
   */
  resources: AppRootPageErrorResources;

  /**
   * Конструктор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppRootPageErrorService} appRootPageError Страница "RootPageError".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppRootPageErrorStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   */
  constructor(
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appRootPageError: AppRootPageErrorService,
    appRoute: AppHostPartRouteService,
    private appStore: AppRootPageErrorStore,
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

    this.resources = new AppRootPageErrorResources(
      appLocalizer,
      this.appRootPageError.settings,
      this.unsubscribe$
    );
  }

  /**
   * Получить состояние.
   * @returns {AppRootPageErrorState} Состояние.
   */
  getState(): AppRootPageErrorState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppRootPageErrorState>} Поток состояния.
   */
  getState$(): Observable<AppRootPageErrorState> {
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
      this.appRootPageError.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }
}
