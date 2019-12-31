// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Observable, of, Subject} from 'rxjs';
import {AppHostMenuJobNodeFindInput} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-input';
import {
  appHostMenuJobListGetResultCreate,
  AppHostMenuJobNodeFindResult
} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-result';
import {appRootMenuJobListGetOutputCreate} from '@app/host/menu/jobs/node/find/host-menu-job-node-find-output';
import {AppHostMenuDataService} from '@app/host/menu/data/host-menu-data.service';
import {AppHostMenuJobNodesFindInput} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-input';
import {
  AppHostMenuJobNodesFindResult,
  appHostMenuJobTreeGetResultCreate
} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-result';
import {appRootMenuJobTreeGetOutputCreate} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-output';
import {AppHostMenuOption} from '@app/host/menu/host-menu-option';
import {AppHostMenuDataNode} from '@app/host/menu/data/host-menu-data-node';
import {AppHostMenuDataItem} from '@app/host/menu/data/host-menu-data-item';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppRootMenuDataNodes} from './root-menu-data-nodes';

/** Корень. Меню. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootMenuDataService extends AppHostMenuDataService {

  /**
   * Узлы.
   * @type {AppRootMenuDataNodes}
   */
  nodes: AppRootMenuDataNodes;

  /**
   * @inheritDoc
   * @param {AppHostMenuJobNodeFindInput} input
   * @returns {Observable<AppHostMenuJobNodeFindResult>}
   */
  findNode$(input: AppHostMenuJobNodeFindInput): Observable<AppHostMenuJobNodeFindResult> {
    const result = appHostMenuJobListGetResultCreate();

    const {
      axis,
      dataKey,
      trimDepth
    } = input;

    const node = this.nodes.findNode(dataKey, axis, trimDepth);

    const isOk = result.isOk = !!node;

    if (isOk) {
      if (input.lookupOptionByMenuNodeKey) {
        this.applyOptionsToNodes(input.lookupOptionByMenuNodeKey, [node]);
      }

      const output = appRootMenuJobListGetOutputCreate();

      output.node = node;

      result.data = output;
    }

    return of(result);
  }

  /**
   * @inheritDoc
   * @param {AppHostMenuJobNodesFindInput} input
   * @returns {Observable<AppHostMenuJobNodesFindResult>}
   */
  findNodes$(input: AppHostMenuJobNodesFindInput): Observable<AppHostMenuJobNodesFindResult> {
    const result = appHostMenuJobTreeGetResultCreate();

    const {
      axis,
      dataKey,
      trimDepth
    } = input;

    const nodes = this.nodes.findNodes(dataKey, axis, trimDepth);

    if (nodes.length > 0 && input.lookupOptionByMenuNodeKey) {
      this.applyOptionsToNodes(input.lookupOptionByMenuNodeKey, nodes);
    }

    result.isOk = true;

    const output = appRootMenuJobTreeGetOutputCreate();

    output.nodes = nodes;

    result.data = output;

    return of(result);
  }

  /**
   * @inheritDoc
   * @param {AppCoreLocalizationService} appLocalizer
   * @param {AppCoreNavigationService} appNavigation
   * @param {Subject<boolean>} unsubscribe$
   */
  onApplicationStart(
    appLocalizer: AppCoreLocalizationService,
    appNavigation: AppCoreNavigationService,
    unsubscribe$: Subject<boolean>
  ) {
    this.nodes = new AppRootMenuDataNodes(
      appLocalizer,
      appNavigation,
      unsubscribe$
    );
  }

  /**
   * @param {AppHostMenuOption} option
   * @param {AppHostMenuDataItem} data
   */
  private applyOptionToNodeData(option: AppHostMenuOption, data: AppHostMenuDataItem) {
    if (option.routerLink !== undefined) {
      data.routerLink = option.routerLink;
    }

    if (option.url !== undefined) {
      data.url = option.url;
    }

    if (option.icon !== undefined) {
      data.icon = option.icon;
    }

    if (option.titleResourceKey !== undefined) {
      data.titleResourceKey = option.titleResourceKey;
    }
  }

  /**
   * @param { [key: string]: AppHostMenuOption } lookupOptionByMenuNodeKey
   * @param {AppHostMenuDataNode[]} nodes
   */
  private applyOptionsToNodes(
    lookupOptionByMenuNodeKey: { [key: string]: AppHostMenuOption },
    nodes: AppHostMenuDataNode[]
  ) {
    const indexesToRemove: number[] = [];

    nodes.forEach((node, index) => {
      const option = lookupOptionByMenuNodeKey[node.key];

      if (option) {
        if (option.isNeededToRemove) {
          indexesToRemove.push(index);

          node.children = [];
        } else {
          this.applyOptionToNodeData(option, node.data);
        }
      }

      if (node.children.length > 0) {
        this.applyOptionsToNodes(lookupOptionByMenuNodeKey, node.children);
      }
    });

    indexesToRemove.forEach((item, index) => {
      nodes.splice(item - index, 1);
    });
  }
}
