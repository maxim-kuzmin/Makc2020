// //Author Maxim Kuzmin//makc//

/**
 * Ядро. Дерево. Узел.
 * @param <TData> Тип данных.
 */
export interface AppCoreTreeNode<TData> {

  /**
   * Количество детей.
   * @type {number}
   */
  childCount: number;

  /**
   * Дети.
   * @type {AppCoreTreeNode<TData>}
   */
  children: AppCoreTreeNode<TData>[];

  /**
   * Данные.
   * @type {TData}
   */
  data: TData;

  /**
   * Количество потомков.
   * @type {number}
   */
  descendantCount: number;

  /**
   * Уровень.
   * @type {number}
   */
  level: number;

  /**
   * Ключ.
   * @type {string}
   */
  key: string;

  /**
   * Ключ родителя.
   * @type {string}
   */
  parentKey: string;
}

/**
 * Хост. Меню. Данные. Узел. Создать.
 * @param {string} key Ключ.
 * @param {TData} data Данные.
 * @param {string} parentKey Ключ родителя.
 * @param {number} level Уровень.
 * @param {number} childCount Количество детей.
 * @param {number} descendantCount Количество потомков.
 * @param {AppCoreTreeNode<TData>[]} children Дети.
 * @returns {AppCoreTreeNode<TData>} Узел.
 */
export function appCoreTreeNodeCreate<TData>(
  key: string,
  data: TData,
  parentKey: string,
  level: number = null,
  childCount: number = null,
  descendantCount: number = null,
  children: AppCoreTreeNode<TData>[] = null
): AppCoreTreeNode<TData> {
  return  {
    childCount: childCount !== null ? childCount : 0,
    children: children || [],
    data: data,
    descendantCount: descendantCount !== null ? descendantCount : 0,
    level: level !== null ? level : 0,
    key: key,
    parentKey: parentKey
  } as AppCoreTreeNode<TData>;
}
