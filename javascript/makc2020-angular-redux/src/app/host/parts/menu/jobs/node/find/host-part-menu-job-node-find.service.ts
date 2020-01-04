// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostPartMenuJobNodeFindResult} from './host-part-menu-job-node-find-result';
import {AppHostPartMenuJobNodeFindInput} from './host-part-menu-job-node-find-input';
import {AppHostPartMenuDataService} from '@app/host/parts/menu/data/host-part-menu-data.service';

/** Хост. Часть "Menu". Задания. Узел. Поиск. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartMenuJobNodeFindService {

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
   * @param {AppHostPartMenuJobNodeFindInput} input Ввод.
   * @returns {Observable<AppHostPartMenuJobNodeFindResult>} Результирующий поток.
   */
  execute$(
    logger: AppCoreLoggingService,
    input: AppHostPartMenuJobNodeFindInput
  ): Observable<AppHostPartMenuJobNodeFindResult> {
    const jobName = this.appExecution.createJobName(
      appCoreExecutionMethod.get,
      `${AppHostPartMenuDataService.name}.${this.appMenuData.findNode$.name}`,
      input
    );

    return this.appMenuData.findNode$(input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppHostPartMenuJobNodeFindResult>(
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
