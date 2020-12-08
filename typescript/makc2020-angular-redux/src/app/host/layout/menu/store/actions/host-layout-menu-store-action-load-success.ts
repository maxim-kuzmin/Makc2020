// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutMenuActions} from '@app/host/layout/menu/host-layout-menu-actions';
import {AppHostPartMenuJobNodesFindResult} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-result';

/** Хост. Разметка. Меню. Хранилище состояния. Действия. Успех загрузки. */
export class AppHostLayoutMenuStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutMenuActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppHostPartMenuJobNodesFindResult} jobNodesFindResult
   * @param {number} menuLevel Уровень меню.
   * Результат выполнения задания на получение списка.
   */
  constructor(
    public jobNodesFindResult: AppHostPartMenuJobNodesFindResult,
    public menuLevel: number
  ) {
  }
}
