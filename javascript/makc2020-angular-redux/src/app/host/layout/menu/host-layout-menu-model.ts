// //Author Maxim Kuzmin//makc//

import {Observable, of} from 'rxjs';
import {switchMap, takeUntil} from 'rxjs/operators';
import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppCoreTreeEnumAxisMany} from '@app/core/tree/enums/core-tree-enum-axis-many';
import {AppHostLayoutMenuDataItem} from '@app/host/layout/menu/data/host-layout-menu-data-item';
import {AppHostMenuDataItem} from '@app/host/menu/data/host-menu-data-item';
import {AppHostMenuJobNodeFindInput} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-input';
import {AppHostMenuJobNodesFindInput} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-input';
import {AppHostMenuState} from '@app/host/menu/host-menu-state';
import {AppHostMenuStore} from '@app/host/menu/host-menu-store';
import {AppHostLayoutMenuState} from './host-layout-menu-state';
import {AppHostLayoutMenuStore} from './host-layout-menu-store';

/** Хост. Разметка. Меню. Модель. */
export class AppHostLayoutMenuModel extends AppCoreCommonUnsubscribable {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostMenuStore} appMenuStore Хранилище состояния меню.
   * @param {AppHostLayoutMenuStore} appStore Хранилище состояния.
   */
  constructor(
    private appLocalizer: AppCoreLocalizationService,
    private appMenuStore: AppHostMenuStore,
    private appStore: AppHostLayoutMenuStore
  ) {
    super();

    this.onMenuStateSwitchMap = this.onMenuStateSwitchMap.bind(this);
    this.executeActionLoad = this.executeActionLoad.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppHostLayoutMenuState} Состояние.
   */
  getState(): AppHostLayoutMenuState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @param {number} menuLevel Уровень меню.
   * @returns {Observable<AppHostLayoutMenuState>} Поток состояния.
   */
  getState$(menuLevel: number): Observable<AppHostLayoutMenuState> {
    return this.appStore.getState$(menuLevel, this.unsubscribe$);
  }

  /**
   * Локализировать элементы.
   * @param {AppHostMenuDataItem[]} items Элементы.
   */
  localizeItems(items: AppHostLayoutMenuDataItem[]) {
    items.forEach(item => {
      this.localizeItem(item.data);
    });
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
    this.appMenuStore.getState$(this.unsubscribe$).pipe(
      switchMap(this.onMenuStateSwitchMap)
    ).subscribe(
      this.executeActionLoad
    );
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  /** @param {AppHostMenuJobNodeFindInput} input */
  private executeActionLoad(input: AppHostMenuJobNodesFindInput) {
    this.appStore.runActionLoad(input);
  }

  /** @param {AppHostMenuDataItem} item */
  private localizeItem(item: AppHostMenuDataItem) {
    this.appLocalizer.createTranslator(
      item.titleResourceKey
    ).translate$().pipe(takeUntil(this.unsubscribe$)).subscribe(s => {
      item.title = s;
    });
  }

  /**
   * @param {AppHostMenuState} menuState
   * @returns {Observable<AppHostMenuJobNodeFindInput>}
   */
  private onMenuStateSwitchMap(menuState: AppHostMenuState): Observable<AppHostMenuJobNodesFindInput> {
    const input = new AppHostMenuJobNodesFindInput(
      menuState.menuNodeKey,
      AppCoreTreeEnumAxisMany.Ancestors,
      1,
      menuState.lookupOptionByMenuNodeKey
    );

    return of(input);
  }
}
