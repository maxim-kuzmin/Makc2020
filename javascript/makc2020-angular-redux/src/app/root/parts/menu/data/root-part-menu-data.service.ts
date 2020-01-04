// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {Observable, of, Subject} from 'rxjs';
import {AppHostPartMenuJobNodeFindInput} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-input';
import {
  appHostPartMenuJobListGetResultCreate,
  AppHostPartMenuJobNodeFindResult
} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-result';
import {appHostPartMenuJobListGetOutputCreate} from '@app/host/parts/menu/jobs/node/find/host-part-menu-job-node-find-output';
import {AppHostPartMenuDataService} from '@app/host/parts/menu/data/host-part-menu-data.service';
import {AppHostPartMenuJobNodesFindInput} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-input';
import {
  AppHostPartMenuJobNodesFindResult,
  appHostPartMenuJobTreeGetResultCreate
} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-result';
import {appHostPartMenuJobTreeGetOutputCreate} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-output';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';
import {AppHostPartMenuDataNode} from '@app/host/parts/menu/data/host-part-menu-data-node';
import {AppHostPartMenuDataItem} from '@app/host/parts/menu/data/host-part-menu-data-item';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppRootPartMenuDataNodes} from './root-part-menu-data-nodes';

/** Корень. Часть "Menu". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPartMenuDataService extends AppHostPartMenuDataService {

  /**
   * Узлы.
   * @type {AppRootPartMenuDataNodes}
   */
  nodes: AppRootPartMenuDataNodes;

  /**
   * @inheritDoc
   * @param {AppHostPartMenuJobNodeFindInput} input
   * @returns {Observable<AppHostPartMenuJobNodeFindResult>}
   */
  findNode$(input: AppHostPartMenuJobNodeFindInput): Observable<AppHostPartMenuJobNodeFindResult> {
    const result = appHostPartMenuJobListGetResultCreate();

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

      const output = appHostPartMenuJobListGetOutputCreate();

      output.node = node;

      result.data = output;
    }

    return of(result);
  }

  /**
   * @inheritDoc
   * @param {AppHostPartMenuJobNodesFindInput} input
   * @returns {Observable<AppHostPartMenuJobNodesFindResult>}
   */
  findNodes$(input: AppHostPartMenuJobNodesFindInput): Observable<AppHostPartMenuJobNodesFindResult> {
    const result = appHostPartMenuJobTreeGetResultCreate();

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

    const output = appHostPartMenuJobTreeGetOutputCreate();

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
    this.nodes = new AppRootPartMenuDataNodes(
      appLocalizer,
      appNavigation,
      unsubscribe$
    );
  }

  /**
   * @param {AppHostPartMenuOption} option
   * @param {AppHostPartMenuDataItem} data
   */
  private applyOptionToNodeData(option: AppHostPartMenuOption, data: AppHostPartMenuDataItem) {
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
   * @param {AppHostPartMenuDataNode[]} nodes
   */
  private applyOptionsToNodes(
    lookupOptionByMenuNodeKey: { [key: string]: AppHostPartMenuOption },
    nodes: AppHostPartMenuDataNode[]
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
