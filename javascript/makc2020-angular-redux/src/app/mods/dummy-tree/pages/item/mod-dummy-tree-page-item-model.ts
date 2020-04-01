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
import {AppModDummyTreeJobItemGetInput} from '@app/mods/dummy-tree/jobs/item/get/mod-dummy-tree-job-item-get-input';
import {AppModDummyTreeJobItemGetOutput} from '@app/mods/dummy-tree/jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreePageListService} from '../list/mod-dummy-tree-page-list.service';
import {AppModDummyTreePageItemResources} from './mod-dummy-tree-page-item-resources';
import {AppModDummyTreePageItemSettingErrors} from './settings/mod-dummy-tree-page-item-setting-errors';
import {AppModDummyTreePageItemSettingFields} from './settings/mod-dummy-tree-page-item-setting-fields';
import {AppModDummyTreePageItemService} from './mod-dummy-tree-page-item.service';
import {AppModDummyTreePageItemParameters} from './mod-dummy-tree-page-item-parameters';
import {AppModDummyTreePageItemState} from './mod-dummy-tree-page-item-state';
import {AppModDummyTreePageItemStore} from './mod-dummy-tree-page-item-store';
import {appModDummyTreePageItemConfigIndex} from './mod-dummy-tree-page-item-config';

/** Мод "DummyTree". Страницы. Элемент. Модель. */
@Injectable()
export class AppModDummyTreePageItemModel extends AppCoreCommonPageModel {

  /** @type {Subject<boolean>} */
  private isDataChangeAllowedChanged$ = new Subject<boolean>();

  /** @type {AppModDummyTreeJobItemGetInput} */
  private jobItemGetInput: AppModDummyTreeJobItemGetInput;

  /** @type {AppModDummyTreePageItemParameters} */
  private parameters: AppModDummyTreePageItemParameters;

  /**
   * Ресурсы.
   * @type {AppModDummyTreePageItemResources}
   */
  resources: AppModDummyTreePageItemResources;

  /**
   * Конструктор.
   * @param {AppCoreDialogService} appDialog Диалог.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppCoreExceptionStore} appExceptionStore Хранилище состояния исключения.
   * @param {AppHostPartMenuService} appMenu Меню.
   * @param {AppModDummyTreePageItemService} appModDummyTreePageItem Страница "ModDummyTreePageItem".
   * @param {AppModDummyTreePageListService} appModDummyTreePageList Страница "ModDummyTreePageList".
   * @param {AppCoreNavigationService} appNavigation Навигация.
   * @param {AppHostPartRouteService} appRoute Маршрут.
   * @param {AppModDummyTreePageItemStore} appStore Хранилище состояния.
   * @param {AppCoreTitleService} appTitle Заголовок.
   * @param {FormBuilder} extFormBuilder Построитель форм.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    public appDialog: AppCoreDialogService,
    appLocalizer: AppCoreLocalizationService,
    appExceptionStore: AppCoreExceptionStore,
    private appMenu: AppHostPartMenuService,
    private appModDummyTreePageItem: AppModDummyTreePageItemService,
    private appModDummyTreePageList: AppModDummyTreePageListService,
    private appNavigation: AppCoreNavigationService,
    appRoute: AppHostPartRouteService,
    private appStore: AppModDummyTreePageItemStore,
    appTitle: AppCoreTitleService,
    public extFormBuilder: FormBuilder,
    extRoute: ActivatedRoute,
    private extRouter: Router
  ) {
    super(
      appExceptionStore,
      appRoute,
      appTitle,
      extRoute
    );

    this.onGetJobItemGetInput = this.onGetJobItemGetInput.bind(this);
    this.onRouteParamMapSwitchMapToJobItemGetInput = this.onRouteParamMapSwitchMapToJobItemGetInput.bind(this);

    this.resources = new AppModDummyTreePageItemResources(
      appLocalizer,
      this.appModDummyTreePageItem.settings,
      this.unsubscribe$
    );
  }

  /**
   * Создать параметры.
   * @returns {AppModDummyTreePageItemParameters} Параметры.
   */
  createParameters(): AppModDummyTreePageItemParameters {
    return this.appModDummyTreePageItem.createParameters(this.parameters.index);
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
   * @returns {AppModDummyTreePageItemSettingErrors} Настройка ошибок.
   */
  getSettingErrors(): AppModDummyTreePageItemSettingErrors {
    return this.appModDummyTreePageItem.settings.errors;
  }

  /**
   * Получить настройку полей.
   * @returns {AppModDummyTreePageItemSettingFields} Настройка полей.
   */
  getSettingFields(): AppModDummyTreePageItemSettingFields {
    return this.appModDummyTreePageItem.settings.fields;
  }

  /**
   * Получить состояние.
   * @returns {AppModDummyTreePageItemState} Состояние.
   */
  getState(): AppModDummyTreePageItemState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppModDummyTreePageItemState>} Поток состояния.
   */
  getState$(): Observable<AppModDummyTreePageItemState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /**
   * Выполнить действие "Обновление".
   * @param {AppModDummyTreePageItemParameters} parameters Параметры.
   */
  executeActionRefresh(parameters: AppModDummyTreePageItemParameters = null) {
    if (parameters) {
      const location = this.appModDummyTreePageItem.getLocation();

      location.parameters = parameters;

      this.appModDummyTreePageItem.setLocation(location);
    }

    const commands = this.appModDummyTreePageItem.createRouterLink(null, parameters);

    this.extRouter.navigate(commands).catch();
  }

  /**
   * Выполнить действие "Сохранение".
   * @param {AppModDummyTreeJobItemGetOutput} input
   */
  executeActionSave(input: AppModDummyTreeJobItemGetOutput) {
    this.appModDummyTreePageList.sendEnsureLoadDataRequest();

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

    this.isDataChangeAllowedChanged$.next(pageKey !== this.appModDummyTreePageItem.settings.keys.keyView);

    this.parameters = this.appModDummyTreePageItem.createParameters(appModDummyTreePageItemConfigIndex);
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
      } = this.appModDummyTreePageItem;

      const {
        keyCreate,
        keyEdit,
        keyView
      } = settings.keys;

      switch (this.pageKey) {
        case keyCreate:
          titleResourceKey = settings.titleOfModDummyTreePageItemCreateResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyTreePageItemCreateTranslated$;
          break;
        case keyEdit:
          titleResourceKey = settings.titleOfModDummyTreePageItemEditResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyTreePageItemEditTranslated$;
          break;
        case keyView:
          titleResourceKey = settings.titleOfModDummyTreePageItemViewResourceKey;
          titleTranslated$ = this.resources.titleOfModDummyTreePageItemViewTranslated$;
          break;
        default:
          isOk = false;
          break;
      }

      if (isOk) {
        this.appTitle.executeActionItemAdd(
          this.appModDummyTreePageItem.settings.titleResourceKey,
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

  /** @param {AppModDummyTreeJobItemGetInput} input */
  private onGetJobItemGetInput(input: AppModDummyTreeJobItemGetInput) {
    if (this.pageKey) {
      const {
        settings
      } = this.appModDummyTreePageItem;

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
        [this.appModDummyTreePageList.settings.key]: <AppHostPartMenuOption>{
          routerLink: this.appModDummyTreePageList.createRouterLink()
        },
        [keyCreate]: <AppHostPartMenuOption>{
          routerLink: this.appModDummyTreePageItem.createRouterLink(pathCreate)
        }
      };

      switch (this.pageKey) {
        case keyCreate: {
          lookupOptionByMenuNodeKey[keyCreate] = <AppHostPartMenuOption>{
            routerLink: this.appModDummyTreePageItem.createRouterLink(pathCreate)
          };

          lookupOptionByMenuNodeKey[keyEdit] = <AppHostPartMenuOption>{
            isNeededToRemove: true
          };

          lookupOptionByMenuNodeKey[keyView] = <AppHostPartMenuOption>{
            isNeededToRemove: true
          };
        }
          break;
        case keyEdit:
        case keyView: {
          lookupOptionByMenuNodeKey[keyEdit] = <AppHostPartMenuOption>{
            routerLink: this.appModDummyTreePageItem.createRouterLink(pathEdit)
          };

          lookupOptionByMenuNodeKey[keyView] = <AppHostPartMenuOption>{
            routerLink: this.appModDummyTreePageItem.createRouterLink(pathView)
          };
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
   * @returns {Observable<AppModDummyTreeJobItemGetInput>}
   */
  private onRouteParamMapSwitchMapToJobItemGetInput(paramMap: ParamMap): Observable<AppModDummyTreeJobItemGetInput> {
    const {
      settings
    } = this.appModDummyTreePageItem;

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

    let input: AppModDummyTreeJobItemGetInput;

    if (isOk) {
      const parameters = this.createParameters();

      const {
        paramId,
        paramName
      } = parameters;

      paramId.value = +paramMap.get(paramId.name);
      paramName.value = paramMap.get(paramName.name);

      const location = this.appModDummyTreePageItem.getLocation();

      location.path = path;
      location.parameters = parameters;
      location.paramMap = paramMap;
      location.pageKey = this.pageKey;

      this.appModDummyTreePageItem.setLocation(location);

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
