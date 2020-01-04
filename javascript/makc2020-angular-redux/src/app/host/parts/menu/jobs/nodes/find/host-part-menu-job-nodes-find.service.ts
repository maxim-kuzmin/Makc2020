// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostPartMenuJobNodesFindResult} from './host-part-menu-job-nodes-find-result';
import {AppHostPartMenuJobNodesFindInput} from './host-part-menu-job-nodes-find-input';
import {AppHostPartMenuDataService} from '@app/host/parts/menu/data/host-part-menu-data.service';

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartMenuJobNodesFindService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppHostPartMenuDataService} appMenuData Данные меню.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appMenuData: AppHostPartMenuDataService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostPartMenuJobNodesFindInput} input Ввод.
   * @returns {Observable<AppHostPartMenuJobNodesFindResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostPartMenuJobNodesFindInput
  ): Observable<AppHostPartMenuJobNodesFindResult> {
    const jobName = this.appExecution.createJobName(
      appCoreExecutionMethod.get,
      `${AppHostPartMenuDataService.name}.${this.appMenuData.findNodes$.name}`,
      input
    );

    return this.appMenuData.findNodes$(input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppHostPartMenuJobNodesFindResult>(
            jobName,
            result,
            logger
          )
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            logger
          )
        )
      );
  }
}
