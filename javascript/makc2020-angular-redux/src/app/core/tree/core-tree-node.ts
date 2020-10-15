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
   * Признак необходимости удаления.
   * @type {boolean}
   */
  isNeededToRemove: boolean;

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
 * Хост. Часть "Menu". Данные. Узел. Создать.
 * @param {string} key Ключ.
 * @param {TData} data Данные.
 * @param {string} parentKey Ключ родителя.
 * @param {number} level Уровень.
 * @param {number} childCount Количество детей.
 * @param {number} descendantCount Количество потомков.
 * @param {AppCoreTreeNode<TData>[]} children Дети.
 * @param {boolean} isNeededToRemove Признак необходимости удаления.
 * @returns {AppCoreTreeNode<TData>} Узел.
 */
export function appCoreTreeNodeCreate<TData>(
  key: string,
  data: TData,
  parentKey: string,
  level: number = null,
  childCount: number = null,
  descendantCount: number = null,
  children: AppCoreTreeNode<TData>[] = null,
  isNeededToRemove = false
): AppCoreTreeNode<TData> {
  return  {
    childCount: childCount !== null ? childCount : 0,
    children: children || [],
    data,
    descendantCount: descendantCount !== null ? descendantCount : 0,
    level: level !== null ? level : 0,
    key,
    parentKey,
    isNeededToRemove
  } as AppCoreTreeNode<TData>;
}
