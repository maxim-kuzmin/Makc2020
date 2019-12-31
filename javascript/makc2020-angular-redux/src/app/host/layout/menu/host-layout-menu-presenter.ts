// //Author Maxim Kuzmin//makc//

import {AppCoreExecutableAsync} from '@app/core/executable/core-executable-async';
import {AppHostMenuDataNode} from '@app/host/menu/data/host-menu-data-node';
import {AppHostLayoutMenuActions} from './host-layout-menu-actions';
import {AppHostLayoutMenuModel} from './host-layout-menu-model';
import {AppHostLayoutMenuDataItem, appHostLayoutMenuDataItemCreate} from './data/host-layout-menu-data-item';
import {AppHostLayoutMenuState} from './host-layout-menu-state';
import {AppHostLayoutMenuView} from './host-layout-menu-view';

/** Хост. Разметка. Меню. Представитель. */
export class AppHostLayoutMenuPresenter {

  /** @type {AppCoreExecutableAsync} */
  private onActionLoadSuccessAsync: AppCoreExecutableAsync;

  /**
   * Конструктор.
   * @param {AppHostLayoutMenuModel} model Модель.
   * @param {AppHostLayoutMenuView} view Вид.
   */
  constructor(
    private model: AppHostLayoutMenuModel,
    private view: AppHostLayoutMenuView,
  ) {
    this.onActionLoadSuccess = this.onActionLoadSuccess.bind(this);
    this.onActionLoadSuccessAsync = new AppCoreExecutableAsync(this.onActionLoadSuccess);

    this.onGetState = this.onGetState.bind(this);
  }

  /**
   * @param {AppHostMenuDataNode} node
   * @param {AppHostMenuDataNode} selectedNode
   * @returns {AppHostLayoutMenuDataItem}
   */
  private createDataItem(
    node: AppHostMenuDataNode,
    selectedNode: AppHostMenuDataNode
  ): AppHostLayoutMenuDataItem {
    let nodeKey = node.key;

    if (!selectedNode) {
      selectedNode = node;

      const {
        jobNodesFindInput
      } = this.model.getState();

      nodeKey = jobNodesFindInput.dataKey;
    }

    const isSelected = nodeKey === selectedNode.key;

    return appHostLayoutMenuDataItemCreate(node.data, isSelected);
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
    this.model.getState$(this.view.menuLevel).subscribe(this.onGetState);

    this.model.onAfterViewInit();
  }

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.model.onDestroy();
  }

  private onActionLoadSuccess() {
    const {
      jobNodesFindResult: result
    } = this.model.getState();

    if (result) {
      const {
        data
      } = result;

      let items: AppHostLayoutMenuDataItem[];

      const parentNodeLevel = this.view.menuLevel - 1;

      let prevNode: AppHostMenuDataNode;

      data.nodes.forEach((node => {
        if (node.level === parentNodeLevel) {
          items = node.children.map(x => this.createDataItem(x, prevNode));

          return;
        }

        prevNode = node;
      }));

      if (!items) {
        items = [];
      }

      this.view.data = items;

      this.model.localizeItems(this.view.data);

      this.view.isDataLoaded = true;
    }
  }

  /** @param {AppHostLayoutMenuState} state */
  private onGetState(state: AppHostLayoutMenuState) {
    if (state) {
      const {
        action
      } = state;

      if (action === AppHostLayoutMenuActions.LoadSuccess) {
        this.onActionLoadSuccessAsync.execute();
      }
    }
  }
}
