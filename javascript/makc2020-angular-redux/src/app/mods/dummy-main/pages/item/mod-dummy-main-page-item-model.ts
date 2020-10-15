// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {filter, switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonPageModel} from '@app/core/common/page/core-common-page-model';
import {AppCoreDialogService} from '@app/core/dialog/core-dialog.service';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreExceptionStore} from '@app/core/exception/core-exception-store';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppCoreTitleService} from '@app/core/title/core-title.service';
import {AppHostPartMenuService} from '@app/host/parts/menu/host-part-menu.service';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartRouteService} from '@app/host/parts/route/host-part-route.service';
import {AppModDummyMainJobItemGetInput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainJobItemGetOutput} from '@app/mods/dummy-main/jobs/item/get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainPageListService} from '../list/mod-dummy-main-page-list.service';
import {AppModDummyMainPageItemResources} from './mod-dummy-main-page-item-resources';
import {AppModDummyMainPageItemSettingErrors} from './settings/mod-dummy-main-page-item-setting-errors';
import {AppModDummyMainPageItemSettingFields} from './settings/mod-dummy-main-page-item-setting-fields';
import {AppModDummyMainPageItemService} from './mod-dummy-main-page-item.service';
import {AppModDummyMainPageItemParameters} from './mod-dummy-main-page-item-parameters';
import {AppModDummyMainPageItemState} from './mod-dummy-main-page-item-state';
import {AppModDummyMainPageItemStore} from './mod-dummy-main-page-item-store';
import {appModDummyMainPageItemConfigIndex} from './mod-dummy-main-page-item-config';

/** Мод "DummyMain". Страницы. Элемент. Модель. */
@Injectable()
export class AppModDummyMainPageItemModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataChangeAllowedChanged$ = new Subject<boolean>();

  /** @type {AppModDummyMainJobItemGetInput} */
  private jobItemGetInput: AppModDummyMainJobItemGetInput;

  /** @type {AppModDummyMainPageItemParameters} */
  private parameters: AppModDummyMainPageItemParameters;

  /**
   * Ресурсы.
   * @type {AppModDummyMainPageItemResources}
   */
  resources: AppModDummyMainPageItemResources;

  /**
   * Конструктор.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyMainPageItemService} appModDummyMainPageItem Страница "ModDummyMainPageItem".
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyMainPageItemStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    public appDialog: AppCoreDialogService,
    appExceptionStore: AppCoreExceptionStore,
    appLocalizer: AppCoreLocalizationService,
    private appMenu: AppHostPartMenuService,
    private appModDummyMainPageItem: AppModDummyMainPageItemService,
    private appModDummyMainPageList: AppModDummyMainPageListService,
    private appNavigation: AppCoreNavigationService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyMainPageItemStore,
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

    this.onGetJobItemGetInput = this.onGetJobItemGetInput.bind(this);
    this.onRouteParamMapSwitchMapToJobItemGetInput = this.onRouteParamMapSwitchMapToJobItemGetInput.bind(this);

    this.resources = new AppModDummyMainPageItemResources(
      appLocalizer,
      this.appModDummyMainPageItem.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModDummyMainPageItemParameters} Параметры.
   */
  createParameters(): AppModDummyMainPageItemParameters {
    return this.appModDummyMainPageItem.createParameters(this.parameters.index);
  }

  /**
   * Получить поток признаков того, что изменение данных разрешено.
   * @returns {Observable<boolean>} Поток признаков того, что изменение данных разрешено.
   */
  getIsDataChangeAllowed$(): Observable<boolean> {
    return this.isDataChangeAllowedChanged$.pipe(
      takeUntil(this.unsubscribe$)
    );
  }

  /**
   * Получить настройку ошибок.
   * @returns {AppModDummyMainPageItemSettingErrors} Настройка ошибок.
   */
  getSettingErrors(): AppModDummyMainPageItemSettingErrors {
    return this.appModDummyMainPageItem.settings.errors;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModDummyMainPageItemSettingFields} Настройка полей.
   */
  getSettingFields(): AppModDummyMainPageItemSettingFields {
    return this.appModDummyMainPageItem.settings.fields;
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyMainPageItemState} Состояние.
   */
  getState(): AppModDummyMainPageItemState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyMainPageItemState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyMainPageItemState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModDummyMainPageItemParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModDummyMainPageItemParameters = null) {
    if (parameters) {
      const location = this.appModDummyMainPageItem.getLocation();

      location.parameters = parameters;

      this.appModDummyMainPageItem.setLocation(location);
    }

    const commands = this.appModDummyMainPageItem.createRouterLink(null, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Сохранение".
   * @param {AppModDummyMainJobItemGetOutput} input
   */
  executeActionSave(input: AppModDummyMainJobItemGetOutput) {
    this.appModDummyMainPageList.sendEnsureLoadDataRequest();

    this.appStore.runActionSave(input);
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
  protected onGetPageKeyOverInit(pageKey: string) {
    super.onGetPageKeyOverInit(pageKey);

    this.isDataChangeAllowedChanged$.next(pageKey !== this.appModDummyMainPageItem.settings.keys.keyView);

    this.parameters = this.appModDummyMainPageItem.createParameters(appModDummyMainPageItemConfigIndex);
  }

  /**
   * @inheritDoc
   * @param {string} pageKey
   */
  protected onGetPageKeyOverAfterViewInit(pageKey: string) {
    super.onGetPageKeyOverAfterViewInit(pageKey);

    this.extRoute.paramMap.pipe(
      takeUntil(this.unsubscribe$),
      switchMap(this.onRouteParamMapSwitchMapToJobItemGetInput),
      filter(input => !!input)
    ).subscribe(
      this.onGetJobItemGetInput
    );
  }

  private executeTitleActionItemAdd() {
    if (this.titleItemsCount === 0) {
      let isOk = true;
      let titleResourceKey: string;
      let titleTranslated$: Observable<string>;

      const {
        settings
      } = this.appModDummyMainPageItem;

      const {
        keyCreate,
        keyEdit,
        keyView
      } = settings.keys;

      switch (this.pageKey) {
        case keyCreate:
          titleResourceKey = settings.titleOfModDummyMainPageItemCreateResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyMainPageItemCreateTranslated$;
          break;
        case keyEdit:
          titleResourceKey = settings.titleOfModDummyMainPageItemEditResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyMainPageItemEditTranslated$;
          break;
        case keyView:
          titleResourceKey = settings.titleOfModDummyMainPageItemViewResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyMainPageItemViewTranslated$;
          break;
        default:
          isOk = false;
          break;
      }

      if (isOk) {
        this.appTitle.executeActionItemAdd(
          this.appModDummyMainPageItem.settings.titleResourceKey,
          this.resources.titleTranslated$,
          this.unsubscribe$
        );

        this.appTitle.executeActionItemAdd(
          titleResourceKey,
          titleTranslated$,
          this.unsubscribe$
        );

        this.titleItemsCount = 2;
      }
    }
  }

  /** @param {AppModDummyMainJobItemGetInput} input */
  private onGetJobItemGetInput(input: AppModDummyMainJobItemGetInput) {
    if (this.pageKey) {
      const {
        settings
      } = this.appModDummyMainPageItem;

      const {
        keyCreate,
        keyEdit,
        keyView
      } = settings.keys;

      const {
        pathCreate,
        pathEdit,
        pathView
      } = settings.paths;

      const lookupOptionByMenuNodeKey = {
        [this.appModDummyMainPageList.settings.key]: {
          routerLink: this.appModDummyMainPageList.createRouterLink()
        } as AppHostPartMenuOption,
        [keyCreate]: {
          routerLink: this.appModDummyMainPageItem.createRouterLink(pathCreate)
        } as AppHostPartMenuOption
      };

      switch (this.pageKey) {
        case keyCreate: {
          lookupOptionByMenuNodeKey[keyCreate] = {
            routerLink: this.appModDummyMainPageItem.createRouterLink(pathCreate)
          } as AppHostPartMenuOption;

          lookupOptionByMenuNodeKey[keyEdit] = {
            isNeededToRemove: true
          } as AppHostPartMenuOption;

          lookupOptionByMenuNodeKey[keyView] = {
            isNeededToRemove: true
          } as AppHostPartMenuOption;
        }
          break;
        case keyEdit:
        case keyView: {
          lookupOptionByMenuNodeKey[keyEdit] = {
            routerLink: this.appModDummyMainPageItem.createRouterLink(pathEdit)
          } as AppHostPartMenuOption;

          lookupOptionByMenuNodeKey[keyView] = {
            routerLink: this.appModDummyMainPageItem.createRouterLink(pathView)
          } as AppHostPartMenuOption;
        }
          break;
      }

      this.appMenu.executeActionSet(this.pageKey, lookupOptionByMenuNodeKey);

      this.executeTitleActionItemAdd();
    }

    this.appStore.runActionLoad(input);
  }

  /**
   * @param {ParamMap} paramMap
   * @returns {Observable<AppModDummyMainJobItemGetInput>}
   */
  private onRouteParamMapSwitchMapToJobItemGetInput(paramMap: ParamMap): Observable<AppModDummyMainJobItemGetInput> {
    const {
      settings
    } = this.appModDummyMainPageItem;

    const {
      keyCreate,
      keyEdit,
      keyView
    } = settings.keys;

    const {
      pathCreate,
      pathEdit,
      pathView
    } = settings.paths;

    let isOk = true;
    let path: string;

    switch (this.pageKey) {
      case keyCreate:
        path = pathCreate;
        break;
      case keyEdit:
        path = pathEdit;
        break;
      case keyView:
        path = pathView;
        break;
      default:
        isOk = false;
        break;
    }

    let input: AppModDummyMainJobItemGetInput;

    if (isOk) {
      const parameters = this.createParameters();

      const {
        paramId,
        paramName
      } = parameters;

      paramId.value = +paramMap.get(paramId.name);
      paramName.value = paramMap.get(paramName.name);

      const location = this.appModDummyMainPageItem.getLocation();

      location.path = path;
      location.parameters = parameters;
      location.paramMap = paramMap;
      location.pageKey = this.pageKey;

      this.appModDummyMainPageItem.setLocation(location);

      input = parameters.createJobItemGetInput();

      if (input.equals(this.jobItemGetInput)) {
        input = null;
      } else {
        this.jobItemGetInput = input;
      }
    }

    return of(input);
  }
}
