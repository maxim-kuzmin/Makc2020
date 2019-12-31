// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetResult} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-result';
import {AppModDummyMainJobOptionsDummyManyToManyGetResult} from '../../../../jobs/options/dummy-many-to-many/get/mod-dummy-main-job-options-dummy-many-to-many-get-result';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';
import {AppModDummyMainPageItemEnumActions} from '../../enums/mod-dummy-main-page-item-enum-actions';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. Успех загрузки. */
export class AppModDummyMainPageItemStoreActionLoadSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageItemEnumActions.LoadSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetResult} jobItemGetResult
   * Результат выполнения задания на получение элемента.
   * @param {AppModDummyMainJobOptionsDummyManyToManyGetResult} jobOptionsDummyManyToManyGetResult
   * Результат выполнения задания на получение вариантов выбора сущности "DummyManyToMany".
   * @param {AppModDummyMainJobOptionsDummyOneToManyGetResult} jobOptionsDummyOneToManyGetResult
   * Результат выполнения задания на получение вариантов выбора сущности "DummyOneToMany".
   */
  constructor(
    public jobItemGetResult: AppModDummyMainJobItemGetResult,
    public jobOptionsDummyManyToManyGetResult: AppModDummyMainJobOptionsDummyManyToManyGetResult,
    public jobOptionsDummyOneToManyGetResult: AppModDummyMainJobOptionsDummyOneToManyGetResult
  ) { }
}
