// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {appCoreExecutionMethod} from '@app/core/execution/core-execution-method';
import {AppCoreExecutionService} from '@app/core/execution/core-execution.service';
import {AppCoreHttpService} from '@app/core/http/core-http.service';
import {AppCoreNavigationService} from '@app/core/navigation/core-navigation.service';
import {AppModDummyTreeJobItemGetResult} from './mod-dummy-tree-job-item-get-result';

/** Мод "DummyTree". Задания. Элемент. Получение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreeJobItemGetService {

  /**
   * Конструктор.
   * @param {AppCoreExecutionService} appExecution Выполнение.
   * @param {AppCoreHttpService} appHttp HTTP.
   * @param {AppCoreNavigationService} appNavigation Навигация.
   */
  constructor(
    private appExecution: AppCoreExecutionService,
    private appHttp: AppCoreHttpService,
    private appNavigation: AppCoreNavigationService
  ) {
  }

  /**
   * Выполнить.
   * @param {AppCoreCommonModJobTreeItemGetInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppModDummyTreeJobItemGetResult>} Результирующий поток.
   */
  execute$(
    input: AppCoreCommonModJobTreeItemGetInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppModDummyTreeJobItemGetResult> {
    const url = this.appNavigation.createAbsoluteUrlOfApi('dummy-tree/item');

    const jobName = this.appExecution.createJobName(appCoreExecutionMethod.get, url, input);

    return this.appHttp.get<AppModDummyTreeJobItemGetResult>(url, input)
      .pipe(
        map(
          result => this.appExecution.onSuccess<AppModDummyTreeJobItemGetResult>(
            jobName,
            result,
            handler
          )
        ),
        catchError(
          error => this.appExecution.onError$(
            jobName,
            error,
            handler
          )
        )
      );
  }
}
