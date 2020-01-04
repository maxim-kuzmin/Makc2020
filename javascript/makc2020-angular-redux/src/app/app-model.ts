// //Author Maxim Kuzmin//makc//
import {Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreAuthTypeOidcJobStartService} from '@app/core/auth/types/oidc/jobs/start/core-auth-type-oidc-job-start.service';
import {AppCoreAuthTypeOidcService} from '@app/core/auth/types/oidc/core-auth-type-oidc.service';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreCommonTitlable} from '@app/core/common/core-common-titlable';
import {AppCoreLocalizationService} from './core/localization/core-localization.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppCoreTitleService} from './core/title/core-title.service';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppHostPartMenuDataService} from './host/parts/menu/data/host-part-menu-data.service';
import {AppHostPartRouteData} from '@app/host/parts/route/host-part-route-data';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyMainPageIndexService} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index.service';
import {AppModDummyMainPageItemService} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item.service';
import {AppModDummyMainPageListService} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list.service';
import {AppModAuthPageRedirectService} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect.service';
import {AppRootPageAdministrationService} from '@app/root/pages/administration/root-page-administration.service';
import {AppRootPageIndexService} from '@app/root/pages/index/root-page-index.service';
import {AppResources} from './app-resources';
import {AppService} from './app.service';
import {AppCoreAuthTypeOidcJobStartInput} from '@app/core/auth/types/oidc/jobs/start/core-auth-type-oidc-job-start-input';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';

/** Приложение. Модель. */
export class AppModel extends AppCoreCommonTitlable {

  /** @type {Subject<boolean>} */
  private isAdminModeEnabledChanged$ = new Subject<boolean>();

  /**
   * Ресурсы.
   * @type {AppResources}
   */
  resources: AppResources;

  /**
   * Конструктор.
   * @param {AppService} app Приложение.
   * @param {AppCoreAuthTypeOidcService} appAuthTypeOidc Аутентификация типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobStartService} appAuthTypeOidcJobStart Задание на запуск аутентификации типа OIDC.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppHostPartMenuDataService} appMenuData Данные меню.
   * @param {AppModAuthPageRedirectService} appModAuthPageRedirect Страница "ModAuthPageRedirect".
   * @param {AppModDummyMainPageIndexService} appModDummyMainPageIndex Страница "ModDummyMainPageIndex".
   * @param {AppModDummyMainPageItemService} appModDummyMainPageItem Страница "ModDummyMainPageItem".
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {AppRootPageIndexService} appRootPageIndex Страница "RootPageIndex".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param appRootPageAdministration {AppRootPageAdministrationService} Страница "RootPageAdministration".
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  constructor(
    private app: AppService,
    private appAuthTypeOidc: AppCoreAuthTypeOidcService,
    private appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    private appAuthTypeOidcJobStart: AppCoreAuthTypeOidcJobStartService,
    private appAuthStore: AppHostPartAuthStore,
    private appLocalizer: AppCoreLocalizationService,
    private appLogger: AppCoreLoggingService,
    private appMenuData: AppHostPartMenuDataService,
    private appModAuthPageRedirect: AppModAuthPageRedirectService,
    private appModDummyMainPageIndex: AppModDummyMainPageIndexService,
    private appModDummyMainPageItem: AppModDummyMainPageItemService,
    private appModDummyMainPageList: AppModDummyMainPageListService,
    private appNavigation: AppCoreNavigationService,
    private appRootPageIndex: AppRootPageIndexService,
    private appRoute: AppHostPartRouteService,
    private appRootPageAdministration: AppRootPageAdministrationService,
    appTitle: AppCoreTitleService
  ) {
    super(
      appTitle
    );

    this.onAuthTypeOidcJobStart = this.onAuthTypeOidcJobStart.bind(this);
    this.onGetRouteData = this.onGetRouteData.bind(this);

    this.resources = new AppResources(
      this.appLocalizer,
      this.app.settings,
      this.unsubscribe$
    );
  }

  getIsAdminModeEnabled$(): Observable<boolean> {
    return this.isAdminModeEnabledChanged$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  /** Обработчик события инициализации. */
  onInit() {
    this.appAuthStore.runActionRedirectUrlSet(this.appRootPageIndex.settings.path);

    if (this.appAuthTypeOidc.isEnabled) {
      const input = new AppCoreAuthTypeOidcJobStartInput(
        this.appNavigation.createAbsoluteUrlOfHost(this.appModAuthPageRedirect.settings.path)
      );

      this.appAuthTypeOidcJobStart.execute$(
        this.appLogger,
        input
      ).subscribe(
        this.onAuthTypeOidcJobStart
      );
    }

    this.appRoute.getData$(this.unsubscribe$).subscribe(this.onGetRouteData);

    this.appLocalizer.onApplicationStart();

    this.appMenuData.onApplicationStart(
      this.appLocalizer,
      this.appNavigation,
      this.unsubscribe$
    );

    this.executeTitleActionItemAdd();
  }

  private executeTitleActionItemAdd() {
    this.appTitle.executeActionItemAdd(
      this.app.settings.titleResourceKey,
      this.resources.titleTranslated$,
      this.unsubscribe$
    );

    this.titleItemsCount = 1;
  }

  /** @param {AppCoreExecutionResult} result */
  private onAuthTypeOidcJobStart(result: AppCoreExecutionResult) {
    this.appAuthTypeOidcStore.runActionIsInitializedSet(result.isOk);
  }

  private onGetRouteData(routeData: AppHostPartRouteData) {
    const {
      page
    } = routeData;

    let isAdminModeEnabled = false;

    if (page) {
      switch (page.key) {
        case this.appModDummyMainPageIndex.settings.key:
        case this.appModDummyMainPageItem.settings.key:
        case this.appModDummyMainPageItem.settings.keys.keyCreate:
        case this.appModDummyMainPageItem.settings.keys.keyEdit:
        case this.appModDummyMainPageItem.settings.keys.keyView:
        case this.appModDummyMainPageList.settings.key:
        case this.appRootPageAdministration.settings.key:
          isAdminModeEnabled = true;
          break;
      }
    }

    this.isAdminModeEnabledChanged$.next(isAdminModeEnabled);
  }
}
