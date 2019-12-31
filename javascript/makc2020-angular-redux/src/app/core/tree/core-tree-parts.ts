// //Author Maxim Kuzmin//makc//

import {AppCoreTreeNode} from './core-tree-node';

/**
 * Ядро. Дерево. Части.
 * @param <TData> Тип данных.
 */
export interface AppCoreTreeParts<TData, TNode extends AppCoreTreeNode<TData>> {

  /**
   * Низы.
   * @type {TNode[][]}
   */
  bottoms: TNode[][];

  /**
   * Корни.
   * @type {TNode[]}
   */
  roots: TNode[];

  /**
   * Верхи.
   * @type {TNode[][]}
   */
  tops: TNode[][];
}

/**
 * Хост. Меню. Данные. Части. Создать.
 * @param {TNode[][]} bottoms Низы.
 * @param {TNode[]} roots Корни.
 * @param {TNode[][]} tops Верхи.
 * @returns {AppCoreTreeParts<TData, TNode>} Части дерева.
 */
export function appCoreTreePartsCreate<TData, TNode extends AppCoreTreeNode<TData>>(
  bottoms: TNode[][] = null,
  roots: TNode[] = null,
  tops: TNode[][] = null
): AppCoreTreeParts<TData, TNode> {
  return {
    bottoms: bottoms || [],
    roots: roots || [],
    tops: tops || []
  } as AppCoreTreeParts<TData, TNode>;
}
