// //Author Maxim Kuzmin//makc//

import {AppHostMenuDataItem} from '@app/host/menu/data/host-menu-data-item';

/** Хост. Разметка. Меню. Данные. Элемент. */
export interface AppHostLayoutMenuDataItem {

  /**
   * Данные.
   * @type {AppHostMenuDataItem}
   */
  data: AppHostMenuDataItem;

  /**
   * Признак выбранности.
   * @type {boolean}
   */
  isSelected: boolean;
}

/**
 * Хост. Разметка. Меню. Данные. Элемент. Создать.
 * @param {AppHostMenuDataItem} data Данные.
 * @param {boolean} isSelected Признак выбранности.
 * @returns {AppHostLayoutMenuDataItem} Элемент.
 */
export function appHostLayoutMenuDataItemCreate(
  data: AppHostMenuDataItem,
  isSelected: boolean = null
): AppHostLayoutMenuDataItem {
  return {
    data,
    isSelected: isSelected !== null ? isSelected : false
  } as AppHostLayoutMenuDataItem;
}
