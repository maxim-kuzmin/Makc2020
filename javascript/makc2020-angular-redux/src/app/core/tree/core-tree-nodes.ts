// //Author Maxim Kuzmin//makc//

import {AppCoreTreeEnumAxisMany} from './enums/core-tree-enum-axis-many';
import {AppCoreTreeEnumAxisOne} from './enums/core-tree-enum-axis-one';
import {AppCoreTreeNode} from './core-tree-node';
import {AppCoreTreeParts, appCoreTreePartsCreate} from './core-tree-parts';

/**
 * Ядро. Дерево. Узлы.
 * @param <TData> Тип данных.
 * @param <TNode> Тип узла.
 */
export abstract class AppCoreTreeNodes<TData, TNode extends AppCoreTreeNode<TData>> {

  /** @type {Map<string, TNode>} */
  private lookupNodeByKey = new Map<string, TNode>();

  /** @type {TNode[]>} */
  private rootNodes: TNode[] = [];

  /**
   * Добавить узел.
   * @param {TNode} node Узел
   */
  addNode(node: TNode) {
    this.lookupNodeByKey[node.key] = node;

    const {
      parentKey
    } = node;

    const parent = this.lookupNodeByKey[parentKey];

    if (parent) {
      parent.children.push(node);

      parent.childCount++;

      node.level = parent.level + 1;

      this.refreshDescendantCounts(parent);
    } else {
      this.rootNodes.push(node);
    }
  }

  /**
   * Найти узел.
   * @param {string} key Ключ.
   * @param {AppCoreTreeEnumAxisOne} axis Ось.
   * @param {number} trimDepth Глубина обрезания.
   * Варианты:
   * 1. минус 1 - потомки не обрезаются;
   * 2. 0 - обрезаются все потомки;
   * 3. больше 0 - обрезаются те потомки, поколение которых больше указанного числа,
   * где число 1 соответсвует поколению детей, число 2 - поколению внуков и т.д.
   */
  findNode(key: string, axis: AppCoreTreeEnumAxisOne, trimDepth: number): TNode {
    let result: TNode;

    let treeParts: AppCoreTreeParts<TData, TNode>;

    switch (axis) {
      case AppCoreTreeEnumAxisOne.Parent: {
        const parent = this.getParentByKey(key);

        if (parent) {
          treeParts = this.createTreeParts(
            parent.key,
            0,
            0,
            trimDepth
          );
        }
      }
        break;
      case AppCoreTreeEnumAxisOne.Self: {
        const node = this.lookupNodeByKey[key];

        if (node) {
          treeParts = this.createTreeParts(
            key,
            0,
            0,
            trimDepth
          );
        }
      }
        break;
    }

    if (treeParts) {
      const {
        roots
      } = treeParts;

      if (roots.length > 0) {
        result = treeParts.roots[0];
      }
    }

    if (result === undefined) {
      result = null;
    }

    return result;
  }

  /**
   * Найти узлы.
   * @param {string} key Ключ.
   * @param {AppCoreTreeEnumAxisMany} axis Ось.
   * @param {number} trimDepth Глубина обрезания.
   * Варианты:
   * 1. минус 1 - потомки не обрезаются;
   * 2. 0 - обрезаются все потомки;
   * 3. больше 0 - обрезаются те потомки, поколение которых больше указанного числа,
   * где число 1 соответсвует поколению детей, число 2 - поколению внуков и т.д.
   */
  findNodes(key: string, axis: AppCoreTreeEnumAxisMany, trimDepth: number): TNode[] {
    let result: TNode[];

    let treeParts: AppCoreTreeParts<TData, TNode>;

    switch (axis) {
      case AppCoreTreeEnumAxisMany.Ancestors:
      case AppCoreTreeEnumAxisMany.AncestorsWithRoot: {
        treeParts = this.createTreeParts(
          key,
          0,
          -1,
          trimDepth
        );
      }
        break;
      case AppCoreTreeEnumAxisMany.Descendants: {
        treeParts = this.createTreeParts(
          key,
          -1,
          0,
          trimDepth
        );
      }
        break;
      case AppCoreTreeEnumAxisMany.Siblings: {
        const parent = this.getParentByKey(key);

        if (parent) {
          treeParts = this.createTreeParts(
            parent.key,
            -1,
            0,
            trimDepth
          );
        }
      }
        break;
    }

    if (treeParts) {
      switch (axis) {
        case AppCoreTreeEnumAxisMany.Ancestors:
        case AppCoreTreeEnumAxisMany.AncestorsWithRoot: {
          if (treeParts.tops.length > 0) {
            result = treeParts.tops[0];
          }
        }
          break;
        case AppCoreTreeEnumAxisMany.Siblings:
        case AppCoreTreeEnumAxisMany.Descendants: {
          if (treeParts.bottoms.length > 0) {
            result = treeParts.bottoms[0];
          }
        }
          break;
      }
    }

    if (!result) {
      result = [];
    }

    if (axis === AppCoreTreeEnumAxisMany.AncestorsWithRoot && treeParts.roots.length > 0) {
      result.unshift(treeParts.roots[0]);
    }

    return result;
  }

  /**
   * @param {TNode[]} top
   * @param {TNode} node
   * @param {number} nodesCount
   * @param {number} count
   */
  private buildTop(top: TNode[], node: TNode, nodesCount: number, count: number) {
    if (nodesCount < 1 || count < nodesCount) {
      const {
        parentKey
      } = node;

      const parent = this.lookupNodeByKey[parentKey];

      if (parent) {
        const parentNode = parent as TNode;

        top.push(this.cloneNode(parentNode));

        this.buildTop(top, parentNode, nodesCount, ++count);
      }
    }
  }

  /**
   * @param {TNode} node
   * @returns {TNode}
   */
  private cloneNode(node: TNode): TNode {
    return JSON.parse(JSON.stringify(node));
  }

  /**
   * @param {string} rootNodeKey
   * @param {number} bottomNodesCount
   * @param {number} topNodesCount
   * @param {number} trimDepth
   */
  private createTreeParts(
    rootNodeKey: string,
    bottomNodesCount: number,
    topNodesCount: number,
    trimDepth: number
  ): AppCoreTreeParts<TData, TNode> {
    const bottoms: TNode[][] = [];
    const roots: TNode[] = [];
    const tops: TNode[][] = [];

    if (rootNodeKey) {
      const rootNode: TNode = this.lookupNodeByKey[rootNodeKey];

      if (rootNode) {
        roots.push(this.cloneNode(rootNode));
      }
    } else {
      this.rootNodes.forEach((rootNode) => {
        roots.push(this.cloneNode(rootNode));
      });
    }

    if (bottomNodesCount !== 0) {
      roots.forEach((node) => {
        const bottom: TNode[] = [];

        node.children.forEach((child, index) => {
          if (bottomNodesCount > 0 && index >= bottomNodesCount) {
            return;
          }

          const childNode = child as TNode;

          bottom.push(childNode);
        });

        bottoms.push(bottom);
      });
    }

    if (topNodesCount !== 0) {
      roots.forEach((node) => {
        const top: TNode[] = [];

        this.buildTop(top, node, topNodesCount, 0);

        tops.push(top);
      });
    }

    if (trimDepth >= 0) {
      roots.forEach((node) => {
        this.trimNode(node, trimDepth, 0);
      });

      tops.forEach((nodes) => {
        nodes.forEach((node) => {
          this.trimNode(node, trimDepth, 0);
        });
      });
    }

    return appCoreTreePartsCreate(bottoms, roots, tops);
  }

  /**
   * @param {string} key
   * @returns {TNode}
   */
  private getParentByKey(key: string): TNode {
    const node = this.lookupNodeByKey[key];

    return node ? node.parent : null;
  }

  /** @param {AppCoreTreeNode<TNode>} node */
  private refreshDescendantCounts(node: AppCoreTreeNode<TData>) {
    node.descendantCount++;

    const {
      parentKey
    } = node;

    const parent = this.lookupNodeByKey[parentKey];

    if (parent) {
      this.refreshDescendantCounts(parent);
    }
  }

  /**
   * @param {TNode} node
   * @param {number} trimDepth
   * @param {number} count
   */
  private trimNode(node: TNode, trimDepth: number, count: number) {
    if (count < trimDepth) {
      node.children.forEach((child) => {
        const childNode = child as TNode;

        this.trimNode(childNode, trimDepth, ++count);
      });
    } else {
      node.children = [];
    }
  }
}
