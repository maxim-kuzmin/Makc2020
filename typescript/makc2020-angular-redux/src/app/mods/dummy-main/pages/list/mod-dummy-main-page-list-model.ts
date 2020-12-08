// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {merge, Observable, of, Subject, Subscription} from 'rxjs';
import {debounceTime, distinctUntilChanged, filter, switchMap, takeUntil} from 'rxjs/operators';
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
import {AppModDummyMainJobItemDeleteInput} from '../../jobs/item/delete/mod-dummy-main-job-item-delete-input';
import {AppModDummyMainJobListDeleteInput} from '../../jobs/list/delete/mod-dummy-main-job-list-delete-input';
import {AppModDummyMainJobListGetInput} from '../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainPageItemLocation} from '../item/mod-dummy-main-page-item-location';
import {AppModDummyMainPageItemService} from '../item/mod-dummy-main-page-item.service';
import {AppModDummyMainPageListParameters} from './mod-dummy-main-page-list-parameters';
import {AppModDummyMainPageListResources} from './mod-dummy-main-page-list-resources';
import {AppModDummyMainPageListService} from './mod-dummy-main-page-list.service';
import {AppModDummyMainPageListSettingColumns} from './settings/mod-dummy-main-page-list-setting-columns';
import {AppModDummyMainPageListState} from './mod-dummy-main-page-list-state';
import {AppModDummyMainPageListStore} from './mod-dummy-main-page-list-store';
import {AppModDummyMainPageListSettingFields} from './settings/mod-dummy-main-page-list-setting-fields';
import {AppModDummyMainPageListStateParameters} from './state/mod-dummy-main-page-list-state-parameters';

/** Мод "DummyMain". Страницы. Список. Модель. */
@Injectable()
export class AppModDummyMainPageListModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataRefreshed$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemDeleteStarted$ = new Subject<boolean>();

  /** @type {Subject<boolean>} */
  private isItemsDeleteStarted$ = new Subject<boolean>();

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
   * @param {AppCoreDeactivatingService} appDeactivating Деактивация.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageItemService} appModDummyMainPageItem Страница "ModDummyMainPageItem".
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyMainPageListStore} appStore Хранилище состояния.
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
    private appModDummyMainPageItem: AppModDummyMainPageItemService,
    private appModDummyMainPageList: AppModDummyMainPageListService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyMainPageListStore,
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
    return this.appModDummyMainPageList.createParameters();
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

        this.appStore.runActionItemDelete(new AppModDummyMainJobItemDeleteInput(id));
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

        this.appStore.runActionListDelete(new AppModDummyMainJobListDeleteInput(ids, names));
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
    } = this.appModDummyMainPageItem.settings.paths;

    const parameters = this.appModDummyMainPageItem.createParameters();

    parameters.paramId.value = id;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathEdit, parameters);

    this.appModDummyMainPageItem.sendEnsureLoadDataRequest();

    this.appDeactivating.isEnabled = true;

    this.extRouter.navigate(commands).catch();
  }

  /** Выполнить действие "Элемент. Вставка". */
  executeActionItemInsert() {
    const {
      pathCreate
    } = this.appModDummyMainPageItem.settings.paths;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathCreate);

    this.appModDummyMainPageItem.sendEnsureLoadDataRequest();

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
    } = this.appModDummyMainPageItem.settings.paths;

    const parameters = this.appModDummyMainPageItem.createParameters();

    parameters.paramId.value = id;

    const commands = this.appModDummyMainPageItem.createRouterLink(pathView, parameters);

    this.appModDummyMainPageItem.sendEnsureLoadDataRequest();

    this.appDeactivating.isEnabled = true;

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

  getIsItemsDeleteStarted$(): Observable<boolean> {
    return this.isItemsDeleteStarted$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  getParameters(): AppModDummyMainPageListParameters {
    return this.appModDummyMainPageList.getLocation().parameters;
  }

  /**
   * Получить действительный идентификатор объекта сущности "DummyOneToMany".
   * @param {?number} value Значение.
   * @returns {number} Идентификатор состояния элемента расчёта.
   */
  getRealObjectDummyOneToManyId(value?: number): number {
    return value > 0 ? value : this.parameters.paramObjectDummyOneToManyId.value;
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
   * Получить настройку полей.
   * @returns {AppModDummyMainPageListSettingFields} Настройка полей.
   */
  getSettingFields(): AppModDummyMainPageListSettingFields {
    return this.appModDummyMainPageList.settings.fields;
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
    if (this.pageKey === this.appModDummyMainPageItem.settings.key) {
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
      const {
        titleResourceKey
      } = this.appModDummyMainPageList.settings;

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
    const parameters = this.appModDummyMainPageItem.createParameters();

    const {
      paramId
    } = parameters;

    paramId.value = +paramMap.get(paramId.name);

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
      paramName,
      paramObjectDummyOneToManyId,
      paramObjectDummyOneToManyIdsString,
      paramObjectDummyOneToManyName
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

    paramObjectDummyOneToManyId.value = this.getRealObjectDummyOneToManyId(+paramMap.get(paramObjectDummyOneToManyId.name));
    paramObjectDummyOneToManyIdsString.value = paramMap.get(paramObjectDummyOneToManyIdsString.name);
    paramObjectDummyOneToManyName.value = paramMap.get(paramObjectDummyOneToManyName.name);

    return parameters;
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
        [keyCreate]: {
          routerLink: this.appModDummyMainPageItem.createRouterLink(pathCreate)
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
    const paramsPageItem = this.getItemParametersFromRouteParamMap(paramMap);
    const paramsPageList = this.getParametersFromRouteParamMap(paramMap);

    const parameters = new AppModDummyMainPageListStateParameters(paramsPageItem, paramsPageList);

    this.appStore.runActionParametersSet(parameters);

    const location = this.appModDummyMainPageList.getLocation();

    location.path = this.appModDummyMainPageList.settings.path;
    location.parameters = paramsPageList;
    location.paramMap = paramMap;
    location.pageKey = this.pageKey;

    this.appModDummyMainPageList.setLocation(location);

    let input = paramsPageList.createJobListGetInput();

    if (input.equals(this.jobListGetInput)) {
      input = null;
    } else {
      this.jobListGetInput = input;
    }

    return of(input);
  }
}
