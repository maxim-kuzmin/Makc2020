// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostLayoutMenuActions} from '@app/host/layout/menu/host-layout-menu-actions';
import {AppHostMenuJobNodesFindInput} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-input';
import {AppHostMenuJobNodesFindResult} from '@app/host/menu/jobs/nodes/find/host-menu-job-nodes-find-result';

/** Хост. Разметка. Меню. Состояние. */
export class AppHostLayoutMenuState extends AppCoreCommonState<AppHostLayoutMenuActions> {

  /**
   * Ввод задания на поиск узлов.
   * @type {AppHostMenuJobNodesFindInput}
   */
  jobNodesFindInput: AppHostMenuJobNodesFindInput;

  /**
   * Результат выполнения задания на поиск узлов.
   * @type {AppHostMenuJobNodesFindResult}
   */
  jobNodesFindResult: AppHostMenuJobNodesFindResult;

  /**
   * Уровень меню.
   * @type {number}
   */
  menuLevel: number;
}
