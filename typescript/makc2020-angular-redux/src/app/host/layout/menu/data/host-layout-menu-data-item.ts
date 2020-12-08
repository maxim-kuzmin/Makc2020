// //Author Maxim Kuzmin//makc//

import {AppHostPartMenuDataItem} from '@app/host/parts/menu/data/host-part-menu-data-item';

/** Хост. Разметка. Меню. Данные. Элемент. */
export interface AppHostLayoutMenuDataItem {

  /**
   * Данные.
   * @type {AppHostPartMenuDataItem}
   */
  data: AppHostPartMenuDataItem;

  /**
   * Признак выбранности.
   * @type {boolean}
   */
  isSelected: boolean;
}

/**
 * Хост. Разметка. Меню. Данные. Элемент. Создать.
 * @param {AppHostPartMenuDataItem} data Данные.
 * @param {boolean} isSelected Признак выбранности.
 * @returns {AppHostLayoutMenuDataItem} Элемент.
 */
export function appHostLayoutMenuDataItemCreate(
  data: AppHostPartMenuDataItem,
  isSelected: boolean = null
): AppHostLayoutMenuDataItem {
  return {
    data,
    isSelected: isSelected !== null ? isSelected : false
  } as AppHostLayoutMenuDataItem;
}
