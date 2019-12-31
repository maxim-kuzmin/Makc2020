// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostMenuJobNodesFindResult} from './host-menu-job-nodes-find-result';
import {AppHostMenuJobNodesFindInput} from './host-menu-job-nodes-find-input';
import {AppHostMenuDataService} from '@app/host/menu/data/host-menu-data.service';

/** Хост. Меню. Задания. Узлы. Поиск. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostMenuJobNodesFindService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppHostMenuDataService} appMenuData Данные меню.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appMenuData: AppHostMenuDataService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostMenuJobNodesFindInput} input Ввод.
   * @returns {Observable<AppHostMenuJobNodesFindResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostMenuJobNodesFindInput
  ): Observable<AppHostMenuJobNodesFindResult> {
    const jobName = this.appExecution.createJobName(
      appCoreExecutionMethod.get,
      `${AppHostMenuDataService.name}.${this.appMenuData.findNodes$.name}`,
      input
    );

    return this.appMenuData.findNodes$(input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppHostMenuJobNodesFindResult>(
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
