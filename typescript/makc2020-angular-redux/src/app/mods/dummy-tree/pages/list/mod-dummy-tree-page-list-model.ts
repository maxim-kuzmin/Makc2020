// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {merge, Observable, of, Subject, Subscription} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonEnumTreeItemAxis} from '@app/core/common/enums/tree/item/core-common-enum-tree-item-axis';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreDeactivatingService} from '@app/core/deactivating/core-deactivating.service';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyTreeJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-tree-job-item-delete-input';
import {AppModDummyTreeJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-tree-job-list-delete-input';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';
import {AppModDummyTreePageItemLocation} from '../item/mod-dummy-tree-page-item-location';
import {AppModDummyTreePageItemService} from '../item/mod-dummy-tree-page-item.service';
import {AppModDummyTreePageListParameters} from './mod-dummy-tree-page-list-parameters';
import {AppModDummyTreePageListResources} from './mod-dummy-tree-page-list-resources';
import {AppModDummyTreePageListService} from './mod-dummy-tree-page-list.service';
import {AppModDummyTreePageListSettingColumns} from './settings/mod-dummy-tree-page-list-setting-columns';
import {AppModDummyTreePageListState} from './mod-dummy-tree-page-list-state';
import {AppModDummyTreePageListStore} from './mod-dummy-tree-page-list-store';
import {AppModDummyTreePageListSettingFields} from './settings/mod-dummy-tree-page-list-setting-fields';
import {AppModDummyTreePageListStateParameters} from './state/mod-dummy-tree-page-list-state-parameters';

/** Мод "DummyTree". Страницы. Список. Модель. */
@Injectable()
export class AppModDummyTreePageListModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataRefreshed$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemDeleteStarted$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemsDeleteStarted$ = new Subject<boolean>();

  /** @type {AppModDummyTreeJobListGetInput} */
  private jobListGetInput: AppModDummyTreeJobListGetInput;

  /** @type {AppModDummyTreePageListParameters} */
  private parameters: AppModDummyTreePageListParameters;

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageListResources}
   */
  resources: AppModDummyTreePageListResources;

  /**
   * Конструктор.
   * @param {AppCoreDeactivatingService} appDeactivating Деактивация.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyTreePageItemService} appModDummyTreePageItem Страница "ModDummyTreePageItem".
   * @param {AppModDummyTreePageListService} appModDummyTreePageList Страница "ModDummyTreePageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyTreePageListStore} appStore Хранилище состояния.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appDeactivating: AppCoreDeactivatingService,
    private appDialog: AppCoreDialogService,
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appModDummyTreePageItem: AppModDummyTreePageItemService,
    private appModDummyTreePageList: AppModDummyTreePageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyTreePageListStore,
    private appSettings: AppCoreSettings,
    appTitle: AppCoreTitleService,
    public extFormBuilder: FormBuilder,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appExceptionStore,
      appLocalizer,
      appRoute,
      appTitle,
      extRoute
    );

    this.onReceiveEnsureLoadDataRequest = this.onReceiveEnsureLoadDataRequest.bind(this);
    this.onGetJobListGetInput = this.onGetJobListGetInput.bind(this);
    this.onItemLocationFilter = this.onItemLocationFilter.bind(this);
    this.onRouteParamMapSwitchMapToJobListGetInput = this.onRouteParamMapSwitchMapToJobListGetInput.bind(this);

    this.resources = new AppModDummyTreePageListResources(
      appLocalizer,
      appModDummyTreePageList.settings,
      this.unsubscribe$
    );

    this.appModDummyTreePageList.receiveEnsureLoadDataRequest$(
      this.unsubscribe$
    ).subscribe(
      this.onReceiveEnsureLoadDataRequest
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModDummyTreePageListParameters} Параметры.
   */
  createParameters(): AppModDummyTreePageListParameters {
    return this.appModDummyTreePageList.createParameters();
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

        this.appStore.runActionItemDelete(new AppModDummyTreeJobItemDeleteInput(id));
      }
    });
  }

  /** Выполнить действие "Элементы. Удаление отфильтрованного". */
  executeActionItemsDeleteFiltered() {
    this.appDialog.confirm$(
      this.resources.actions.actionDeleteFiltered.confirm
    ).subscribe(isOk => {
      if (isOk) {
        this.isItemsDeleteStarted$.next();

        const {
          jobListGetInput
        } = this.getState();

        if (jobListGetInput) {
          this.appStore.runActionFilteredDelete(jobListGetInput);
        }
      }
    });
  }

  /**
   * Выполнить действие "Элементы. Удаление списка".
   * @param {number[]} ids Идентификаторы.
   * @param {string[]} names Наименования.
   */
  executeActionItemsDeleteList(ids: number[], names: string[]) {
    this.appDialog.confirm$(
      this.resources.actions.actionDeleteList.confirm
    ).subscribe(isOk => {
      if (isOk) {
        this.isItemsDeleteStarted$.next();

        this.appStore.runActionListDelete(new AppModDummyTreeJobListDeleteInput(ids, names));
      }
    });
  }

  /**
   * Выполнить действие "Элемент. Редактирование".
   * @param {number} id Идентификатор.
   */
  executeActionItemEdit(id: number) {
    const {
      pathEdit
    } = this.appModDummyTreePageItem.settings.paths;

    const parameters = this.appModDummyTreePageItem.createParameters();

    parameters.paramAxis.value = AppCoreCommonEnumTreeItemAxis.Self;
    parameters.paramRootId.value = id;

    const commands = this.appModDummyTreePageItem.createRouterLink(pathEdit, parameters);

    this.appModDummyTreePageItem.sendEnsureLoadDataRequest();

    this.appDeactivating.isEnabled = true;

    this.extRouter.navigate(commands).catch();
  }

  /** Выполнить действие "Элемент. Вставка". */
  executeActionItemInsert() {
    const {
      pathCreate
    } = this.appModDummyTreePageItem.settings.paths;

    const commands = this.appModDummyTreePageItem.createRouterLink(pathCreate);

    this.appModDummyTreePageItem.sendEnsureLoadDataRequest();

    this.appDeactivating.isEnabled = true;

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Элемент. Просмотр".
   * @param {number} id Идентификатор.
   */
  executeActionItemView(id: number) {
    const {
      pathView
    } = this.appModDummyTreePageItem.settings.paths;

    const parameters = this.appModDummyTreePageItem.createParameters();

    parameters.paramAxis.value = AppCoreCommonEnumTreeItemAxis.Self;
    parameters.paramRootId.value = id;

    const commands = this.appModDummyTreePageItem.createRouterLink(pathView, parameters);

    this.appModDummyTreePageItem.sendEnsureLoadDataRequest();

    this.appDeactivating.isEnabled = true;

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModDummyTreePageListParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModDummyTreePageListParameters) {
    if (parameters) {
      const location = this.appModDummyTreePageList.getLocation();

      location.parameters = parameters;

      this.appModDummyTreePageList.setLocation(location);
    }

    let commands: any[];

    switch (this.pageKey) {
      case this.appModDummyTreePageItem.settings.key: {
        const itemLocation = this.appModDummyTreePageItem.getLocation();

        itemLocation.pageKey = this.pageKey;

        this.appModDummyTreePageItem.setLocation(itemLocation);

        commands = this.appModDummyTreePageItem.createRouterLink();
      }
        break;
      case this.appModDummyTreePageList.settings.key:
        commands = this.appModDummyTreePageList.createRouterLink(parameters);
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

  getIsItemsDeleteStarted$(): Observable<boolean> {
    return this.isItemsDeleteStarted$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getParameters(): AppModDummyTreePageListParameters {
    return this.appModDummyTreePageList.getLocation().parameters;
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
   * @returns {AppModDummyTreePageListSettingColumns} Настройка колонок.
   */
  getSettingColumns(): AppModDummyTreePageListSettingColumns {
    return this.appModDummyTreePageList.settings.columns;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModDummyTreePageListSettingFields} Настройка полей.
   */
  getSettingFields(): AppModDummyTreePageListSettingFields {
    return this.appModDummyTreePageList.settings.fields;
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
   * @returns {AppModDummyTreePageListState} Состояние.
   */
  getState(): AppModDummyTreePageListState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyTreePageListState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyTreePageListState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  setSelectedItemId(selectedItemId: number) {
    const location = this.appModDummyTreePageList.getLocation();

    const {
      paramSelectedItemId
    } = location.parameters;

    paramSelectedItemId.value = selectedItemId;

    this.appModDummyTreePageList.setLocation(location);
  }

  /**
   * Обработчик события после действия "Элемент. Удаление. Успех".
   * @returns {boolean} Результат обработки.
   */
  onAfterActionItemDeleteSuccess(): boolean {
    if (this.pageKey === this.appModDummyTreePageItem.settings.key) {
      this.onReceiveEnsureLoadDataRequest();

      this.executeActionItemInsert();

      return true;
    }

    return false;
  }

  /**
   * Обработчик события после действия "Элемент. Удаление. Успех".
   * @returns {boolean} Результат обработки.
   */
  onAfterActionItemsDeleteSuccess(): boolean {
    if (this.pageKey === this.appModDummyTreePageItem.settings.key) {
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

    this.parameters = this.createParameters();
  }

  /** @param {string} pageKey */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    merge(
      this.extRoute.paramMap.pipe(
        takeUntil(this.unsubscribe$),
        switchMap(this.onRouteParamMapSwitchMapToJobListGetInput)
      ),
      this.appModDummyTreePageItem.getLocation$(this.unsubscribe$).pipe(
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
      const {
        titleResourceKey
      } = this.appModDummyTreePageList.settings;

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

  private getItemParametersFromRouteParamMap(paramMap: ParamMap) {
    const parameters = this.appModDummyTreePageItem.createParameters();

    const {
      paramAxis,
      paramRootId
    } = parameters;

    paramAxis.value = +paramMap.get(paramAxis.name) as AppCoreCommonEnumTreeItemAxis;
    paramRootId.value = +paramMap.get(paramRootId.name);

    return parameters;
  }

  private getParametersFromRouteParamMap(paramMap: ParamMap) {
    const parameters = this.createParameters();

    const {
      paramIsDataRefreshed,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSelectedItemIdsString,
      paramSortDirection,
      paramSortField,
      paramIdsString,
      paramName
    } = parameters;

    this.isDataRefreshed$.next(paramMap.get(paramIsDataRefreshed.name) === 'true');

    paramPageNumber.value = this.getRealPageNumber(+paramMap.get(paramPageNumber.name));
    paramPageSize.value = this.getRealPageSize(+paramMap.get(paramPageSize.name));
    paramSelectedItemId.value = this.getRealSelectedItemId(+paramMap.get(paramSelectedItemId.name));
    paramSelectedItemIdsString.value = paramMap.get(paramSelectedItemIdsString.name);
    paramSortField.value = this.getRealSortField(paramMap.get(paramSortField.name));
    paramSortDirection.value = this.getRealSortDirection(paramMap.get(paramSortDirection.name));

    paramIdsString.value = paramMap.get(paramIdsString.name);
    paramName.value = paramMap.get(paramName.name);

    return parameters;
  }

  /** @param {AppModDummyTreeJobListGetInput} input */
  private onGetJobListGetInput(input: AppModDummyTreeJobListGetInput) {
    if (this.pageKey === this.appModDummyTreePageList.settings.key) {
      const {
        keyCreate,
        keyEdit,
        keyView
      } = this.appModDummyTreePageItem.settings.keys;

      const {
        pathCreate
      } = this.appModDummyTreePageItem.settings.paths;

      const lookupOptionByMenuNodeKey = {
        [keyCreate]: {
          routerLink: this.appModDummyTreePageItem.createRouterLink(pathCreate)
        } as AppHostPartMenuOption,
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

    this.appStore.runActionLoad(input);
  }

  /**
   * @param {AppModDummyTreePageItemLocation} location
   * @returns {boolean}
   */
  private onItemLocationFilter(location: AppModDummyTreePageItemLocation): boolean {
    const {
      key
    } = this.appModDummyTreePageItem.settings;

    return this.pageKey === key && this.pageKey !== location.pageKey && !!location.paramMap;
  }

  private onRouteParamMapSwitchMapToJobListGetInput(paramMap: ParamMap): Observable<AppModDummyTreeJobListGetInput> {
    const paramsPageItem = this.getItemParametersFromRouteParamMap(paramMap);
    const paramsPageList = this.getParametersFromRouteParamMap(paramMap);

    const parameters = new AppModDummyTreePageListStateParameters(paramsPageItem, paramsPageList);

    this.appStore.runActionParametersSet(parameters);

    const location = this.appModDummyTreePageList.getLocation();

    location.path = this.appModDummyTreePageList.settings.path;
    location.parameters = paramsPageList;
    location.paramMap = paramMap;
    location.pageKey = this.pageKey;

    this.appModDummyTreePageList.setLocation(location);

    let input = paramsPageList.createJobListGetInput();

    if (input.equals(this.jobListGetInput)) {
      input = null;
    } else {
      this.jobListGetInput = input;
    }

    return of(input);
  }
}
