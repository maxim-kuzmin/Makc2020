// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutMenuActions} from '@app/host/layout/menu/host-layout-menu-actions';
import {AppHostMenuJobNodesFindInput} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-input';

/** Хост. Разметка. Меню. Хранилище состояния. Действия. Загрузка. */
export class AppHostLayoutMenuStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutMenuActions.Load;

  /**
   * Конструктор.
   * @param {AppHostMenuJobNodesFindInput} jobNodesFindInput
   * @param {number} menuLevel Уровень меню.
   * Ввод задания на получение списка.
   */
  constructor(
    public jobNodesFindInput: AppHostMenuJobNodesFindInput,
    public menuLevel: number
  ) {
  }
}
