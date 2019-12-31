// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostMenuJobNodeFindResult} from './host-menu-job-node-find-result';
import {AppHostMenuJobNodeFindInput} from './host-menu-job-node-find-input';
import {AppHostMenuDataService} from '@app/host/menu/data/host-menu-data.service';

/** Хост. Меню. Задания. Узел. Поиск. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostMenuJobNodeFindService {

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
   * @param {AppHostMenuJobNodeFindInput} input Ввод.
   * @returns {Observable<AppHostMenuJobNodeFindResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostMenuJobNodeFindInput
  ): Observable<AppHostMenuJobNodeFindResult> {
    const jobName = this.appExecution.createJobName(
      appCoreExecutionMethod.get,
      `${AppHostMenuDataService.name}.${this.appMenuData.findNode$.name}`,
      input
    );

    return this.appMenuData.findNode$(input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppHostMenuJobNodeFindResult>(
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
