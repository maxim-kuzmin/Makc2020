// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostLayoutMenuActions} from '@app/host/layout/menu/host-layout-menu-actions';
import {AppHostPartMenuJobNodesFindInput} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-input';
import {AppHostPartMenuJobNodesFindResult} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find-result';

/** Хост. Разметка. Меню. Состояние. */
export class AppHostLayoutMenuState extends AppCoreCommonState<AppHostLayoutMenuActions> {

  /**
   * Ввод задания на поиск узлов.
   * @type {AppHostPartMenuJobNodesFindInput}
   */
  jobNodesFindInput: AppHostPartMenuJobNodesFindInput;

  /**
   * Результат выполнения задания на поиск узлов.
   * @type {AppHostPartMenuJobNodesFindResult}
   */
  jobNodesFindResult: AppHostPartMenuJobNodesFindResult;

  /**
   * Уровень меню.
   * @type {number}
   */
  menuLevel: number;
}
