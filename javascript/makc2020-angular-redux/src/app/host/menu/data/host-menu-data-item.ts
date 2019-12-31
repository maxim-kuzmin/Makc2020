// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';

/** Хост. Меню. Данные. Элемент. */
export interface AppHostMenuDataItem {

  /**
   * Иконка.
   * @type {string}
   */
  icon: string;

  /**
   * Ссылка маршрутизатора.
   * @type {any[]}
   */
  routerLink: any[];

  /**
   * Заголовок.
   * @type {string}
   */
  title: string;

  /**
   * Заголовок. Ресурс. Ключ.
   * @type {string}
   */
  titleResourceKey: string;

  /**
   * URL.
   * @type {string}
   */
  url: string;
}

/**
 * Хост. Меню. Данные. Элемент. Создать.
 * @param {string} titleResourceKey Заголовок.
 * @param {any[]} routerLink Ссылка маршрутизатора.
 * @param {string} url URL.
 * @param icon {string} Иконка.
 * @param {AppCoreLocalizationService} appLocalizer Локализатор.
 * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
 * @returns {AppHostMenuDataItem} Элемент.
 */
export function appHostMenuDataItemCreate(
  titleResourceKey: string,
  routerLink: any[],
  url: string,
  icon: string,
  appLocalizer: AppCoreLocalizationService,
  unsubscribe$: Subject<boolean>
): AppHostMenuDataItem {
  const result = {
    icon,
    titleResourceKey,
    routerLink,
    url
  } as AppHostMenuDataItem;

  if (appLocalizer && unsubscribe$) {
    appLocalizer.createTranslator(
      result.titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      result.title = s;
    });
  }

  return result;
}
