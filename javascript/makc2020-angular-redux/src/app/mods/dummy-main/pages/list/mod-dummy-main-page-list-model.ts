// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {merge, Observable, of, Subject, Subscription} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyMainJobItemGetInput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobListGetInput} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainPageItemLocation} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-location';
import {AppModDummyMainPageItemService} from '../item/mod-dummy-main-page-item.service';
import {AppModDummyMainPageListParameters} from './mod-dummy-main-page-list-parameters';
import {AppModDummyMainPageListResources} from './mod-dummy-main-page-list-resources';
import {AppModDummyMainPageListService} from './mod-dummy-main-page-list.service';
import {AppModDummyMainPageListSettingColumns} from './settings/mod-dummy-main-page-list-setting-columns';
import {AppModDummyMainPageListState} from './mod-dummy-main-page-list-state';
import {AppModDummyMainPageListStore} from './mod-dummy-main-page-list-store';

/** Мод "DummyMain". Страницы. Список. Модель. */
@Injectable()
export class AppModDummyMainPageListModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataRefreshed$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemDeleteStarted$ = new Subject<boolean>();

  /** @type {AppModDummyMainJobListGetInput} */
  private jobListGetInput: AppModDummyMainJobListGetInput;

  /** @type {AppModDummyMainPageListParameters} */
  private parameters: AppModDummyMainPageListParameters;

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageListResources}
   */
  resources: AppModDummyMainPageListResources;

  /**
   * Конструктор.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageItemService} appModDummyMainPageItem Страница "ModDummyMainPageItem".
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyMainPageListStore} appStore Хранилище состояния.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appDialog: AppCoreDialogService,
    appLocalizer: AppCoreLocalizationService,
    appExceptionStore: AppCoreExceptionStore,
    private appMenu: AppHostPartMenuService,
    private appModDummyMainPageItem: AppModDummyMainPageItemService,
    private appModDummyMainPageList: AppModDummyMainPageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyMainPageListStore,
    private appSettings: AppCoreSettings,
    appTitle: AppCoreTitleService,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appExceptionStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onReceiveEnsureLoadDataRequest = this.onReceiveEnsureLoadDataRequest.bind(this);
    this.onGetJobListGetInput = this.onGetJobListGetInput.bind(this);
    this.onItemLocationFilter = this.onItemLocationFilter.bind(this);
    this.onRouteParamMapSwitchMapToJobListGetInput = this.onRouteParamMapSwitchMapToJobListGetInput.bind(this);

    this.resources = new AppModDummyMainPageListResources(
      appLocalizer,
      appModDummyMainPageList.settings,
      this.unsubscribe$
    );

    this.appModDummyMainPageList.receiveEnsureLoadDataRequest$(
      this.unsubscribe$
    ).subscribe(
      this.onReceiveEnsureLoadDataRequest
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModDummyMainPageListParameters} Параметры.
   */
  createParameters(): AppModDummyMainPageListParameters {
    return this.appModDummyMainPageList.createParameters(this.parameters.index);
  }

    /**
   * Выполнить действие "Элемент. Удаление".
   * @param {number} id Идентификатор.
   */
  executeActionItemDelete(id: number) {
    this.appDialog.confirm$(
      this.resources.actions.actionDelete.confirm
    ).subscribe(isOk => {
      if (isOk) {
        this.isItemDeleteStarted$.next();

        this.appStore.runActionDelete(new AppModDummyMainJobItemGetInput(id));
      }
    });
  }

  /**
   * Выполнить действие "Элемент. Редактирование".
   * @param {number} id Идентификатор.
   */
  executeActionItemEdit(id: number) {
    this.setSelectedItemId(id);

    const {
      pathEdit
    } = this.appModDummyMainPageItem.settings.paths;

    const parameters = this.appModDummyMainPageItem.createParameters(this.parameters.index);

    parameters.paramId.value = id;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathEdit, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /** Выполнить действие "Элемент. Вставка". */
  executeActionItemInsert() {
    const {
      pathCreate
    } = this.appModDummyMainPageItem.settings.paths;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathCreate);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Элемент. Просмотр".
   * @param {number} id Идентификатор.
   */
  executeActionItemView(id: number) {
    this.setSelectedItemId(id);

    const {
      pathView
    } = this.appModDummyMainPageItem.settings.paths;

    const parameters = this.appModDummyMainPageItem.createParameters(this.parameters.index);

    parameters.paramId.value = id;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathView, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModDummyMainPageListParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModDummyMainPageListParameters) {
    if (parameters) {
      const location = this.appModDummyMainPageList.getLocation();

      location.parameters = parameters;

      this.appModDummyMainPageList.setLocation(location);
    }

    let commands: any[];

    switch (this.pageKey) {
      case this.appModDummyMainPageItem.settings.key: {
        const itemLocation = this.appModDummyMainPageItem.getLocation();

        itemLocation.pageKey = this.pageKey;

        this.appModDummyMainPageItem.setLocation(itemLocation);

        commands = this.appModDummyMainPageItem.createRouterLink();
      }
        break;
      case this.appModDummyMainPageList.settings.key:
        commands = this.appModDummyMainPageList.createRouterLink(parameters);
        break;
    }

    if (commands) {
      this.extRouter.navigate(commands).catch();
    }
  }

  getIsDataRefreshed$(): Observable<boolean> {
    return this.isDataRefreshed$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getIsItemDeleteStarted$(): Observable<boolean> {
    return this.isItemDeleteStarted$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getParameters(): AppModDummyMainPageListParameters {
    return this.appModDummyMainPageList.getLocation().parameters;
  }

  /**
   * Получить действительный номер страницы.
   * @param {?number} value Значение.
   * @returns {number} Номер страницы.
   */
  getRealPageNumber(value?: number): number {
    return value > 0 ? value : this.parameters.paramPageNumber.value;
  }

  /**
   * Получить действительный размер страницы.
   * @param {?number} value Значение.
   * @returns {number} Размер страницы.
   */
  getRealPageSize(value?: number): number {
    return value > 0 ? value : this.parameters.paramPageSize.value;
  }

  /**
   * Получить действительный идентификатор выбранного элемента.
   * @param {?number} value Значение.
   * @returns {number} Идентификатор выбранного элемента.
   */
  getRealSelectedItemId(value?: number): number {
    return value > 0 ? value : this.parameters.paramSelectedItemId.value;
  }

  /**
   * Получить действительное направление сортировки.
   * @param {?number} value Значение.
   * @returns {number} Направление сортировки.
   */
  getRealSortDirection(value?: string): string {
    return value ? value : this.parameters.paramSortDirection.value;
  }

  /**
   * Получить действительное поле сортировки.
   * @param {?number} value Значение.
   * @returns {number} Поле сортировки.
   */
  getRealSortField(value?: string): string {
    return value ? value : this.parameters.paramSortField.value;
  }

  /**
   * Получить настройку колонок.
   * @returns {AppModDummyMainPageListSettingColumns} Настройка колонок.
   */
  getSettingColumns(): AppModDummyMainPageListSettingColumns {
    return this.appModDummyMainPageList.settings.columns;
  }

  /**
   * Получить настройку вариантов размеров страницы.
   * @returns {number[]} Настройка вариантов размеров страницы.
   */
  getSettingPageSizeOptions(): number[] {
    return this.appSettings.pageSizeOptions;
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyMainPageListState} Состояние.
   */
  getState(): AppModDummyMainPageListState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyMainPageListState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyMainPageListState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  setSelectedItemId(selectedItemId: number) {
    const location = this.appModDummyMainPageList.getLocation();

    const {
      paramSelectedItemId
    } = location.parameters;

    paramSelectedItemId.value = selectedItemId;

    this.appModDummyMainPageList.setLocation(location);
  }

  /**
   * Обработчик события после действия "Элемент. Удаление. Успех".
   * @returns {boolean} Результат обработки.
   */
  onAfterActionItemDeleteSuccess(): boolean {
    if (this.pageKey === this.appModDummyMainPageItem.settings.key) {
      this.setSelectedItemId(0);

      this.onReceiveEnsureLoadDataRequest();

      this.executeActionItemInsert();

      return true;
    }

    return false;
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** Обработчик события получения запроса на загрузку данных. */
  onReceiveEnsureLoadDataRequest() {
    this.jobListGetInput = null;
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

  /**
   * Подписаться на событие, возникшее после задержки со значением, отличающемся от предыдущего.
   * @param {Observable<T>} event$ Событие.
   * @param {(T) => void} eventHandler Обработчик события.
   */
  subscribeToEventDelayedDistinct<T>(
    event$: Observable<T>,
    eventHandler: (T) => void
  ): Subscription {
    const {
      searchDelayMilliseconds
    } = this.appSettings;

    return this.subscribeToEvent(
      event$.pipe(
        debounceTime(searchDelayMilliseconds),
        distinctUntilChanged()
      ),
      eventHandler
    );
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverInit(pageKey: string) {
    super.onGetPageKeyOverInit(pageKey);

    const {
      index
    } = this.appModDummyMainPageList.settings;

    this.parameters = this.appModDummyMainPageList.createParameters(index);
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    merge(
      this.extRoute.paramMap.pipe(
        takeUntil(this.unsubscribe$),
        switchMap(this.onRouteParamMapSwitchMapToJobListGetInput)
      ),
      this.appModDummyMainPageItem.getLocation$(this.unsubscribe$).pipe(
        filter(this.onItemLocationFilter),
        switchMap(location => of(location.paramMap)),
        switchMap(this.onRouteParamMapSwitchMapToJobListGetInput)
      )
    ).pipe(
      filter(input => !!input)
    ).subscribe(
      this.onGetJobListGetInput
    );
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      this.appTitle.executeActionItemAdd(
        this.appModDummyMainPageList.settings.titleResourceKey,
        this.resources.titleTranslated$,
        this.unsubscribe$
      );

      this.titleItemsCount = 1;
    }
  }

  /** @param {AppModDummyMainJobListGetInput} input */
  private onGetJobListGetInput(input: AppModDummyMainJobListGetInput) {
    if (this.pageKey === this.appModDummyMainPageList.settings.key) {
      const {
        keyCreate,
        keyEdit,
        keyView
      } = this.appModDummyMainPageItem.settings.keys;

      const {
        pathCreate
      } = this.appModDummyMainPageItem.settings.paths;

      const lookupOptionByMenuNodeKey = {
        [keyCreate]: <AppHostPartMenuOption>{
          routerLink: this.appModDummyMainPageItem.createRouterLink(pathCreate)
        },
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

    this.appStore.runActionLoad(input);
  }

  /**
   * @param {AppModDummyMainPageItemLocation} location
   * @returns {boolean}
   */
  private onItemLocationFilter(location: AppModDummyMainPageItemLocation): boolean {
    const {
      key
    } = this.appModDummyMainPageItem.settings;

    return this.pageKey === key && this.pageKey !== location.pageKey && !!location.paramMap;
  }

  private onRouteParamMapSwitchMapToJobListGetInput(paramMap: ParamMap): Observable<AppModDummyMainJobListGetInput> {
    const parameters = this.createParameters();

    const {
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField,
      paramObjectDummyOneToManyName,
      paramObjectDummyOneToManyId,
      paramObjectDummyOneToManyIdsString,
      paramName,
      paramIdsString,
      paramIsDataRefreshed
    } = parameters;

    paramIdsString.value = paramMap.get(paramIdsString.name);
    paramName.value = paramMap.get(paramName.name);
    paramPageNumber.value = this.getRealPageNumber(+paramMap.get(paramPageNumber.name));
    paramPageSize.value = this.getRealPageSize(+paramMap.get(paramPageSize.name));
    paramSelectedItemId.value = this.getRealSelectedItemId(+paramMap.get(paramSelectedItemId.name));
    paramSortField.value = this.getRealSortField(paramMap.get(paramSortField.name));
    paramSortDirection.value = this.getRealSortDirection(paramMap.get(paramSortDirection.name));
    paramObjectDummyOneToManyName.value = paramMap.get(paramObjectDummyOneToManyName.name);
    paramObjectDummyOneToManyId.value = +paramMap.get(paramObjectDummyOneToManyId.name);
    paramObjectDummyOneToManyIdsString.value = paramMap.get(paramObjectDummyOneToManyIdsString.name);

    this.isDataRefreshed$.next(paramMap.get(paramIsDataRefreshed.name) === 'true');

    const location = this.appModDummyMainPageList.getLocation();

    location.path = this.appModDummyMainPageList.settings.path;
    location.parameters = parameters;
    location.paramMap = paramMap;
    location.pageKey = this.pageKey;

    this.appModDummyMainPageList.setLocation(location);

    let input = parameters.createJobListGetInput();

    if (input.equals(this.jobListGetInput)) {
      input = null;
    } else {
      this.jobListGetInput = input;
    }

    return of(input);
  }
}
