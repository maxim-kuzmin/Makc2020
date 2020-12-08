// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobListGetResult} from '../../../../jobs/list/get/mod-dummy-main-job-list-get-result';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Успех загрузки. */
export class AppModDummyMainPageListStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobListGetResult} jobListGetResult
   * Результат выполнения задания на получение списка.
   * @param {AppModDummyMainJobOptionsDummyOneToManyGetResult} jobOptionsDummyOneToManyGetResult
   * Результат выполнения задания на получение вариантов выбора сущности "DummyOneToMany".
   */
  constructor(
    public jobListGetResult: AppModDummyMainJobListGetResult,
    public jobOptionsDummyOneToManyGetResult: AppModDummyMainJobOptionsDummyOneToManyGetResult
  ) {
  }
}
