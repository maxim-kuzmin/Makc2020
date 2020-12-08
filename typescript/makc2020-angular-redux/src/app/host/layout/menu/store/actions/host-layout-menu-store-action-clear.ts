// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutMenuActions} from '@app/host/layout/menu/host-layout-menu-actions';

/** Хост. Разметка. Меню. Хранилище состояния. Действия. Очистка. */
export class AppHostLayoutMenuStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutMenuActions.Clear;

  /**
   * Конструктор.
   * @param {number} menuLevel Уровень меню.
   * Ввод задания на получение списка.
   */
  constructor(
    public menuLevel: number
  ) {
  }
}
