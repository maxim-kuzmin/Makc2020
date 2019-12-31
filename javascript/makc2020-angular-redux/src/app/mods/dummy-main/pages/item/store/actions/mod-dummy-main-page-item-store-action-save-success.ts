// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetResult} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-result';
import {AppModDummyMainPageItemEnumActions} from '../../enums/mod-dummy-main-page-item-enum-actions';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. Успех сохранения. */
export class AppModDummyMainPageItemStoreActionSaveSuccess implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageItemEnumActions.SaveSuccess;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetResult} jobItemGetResult
   * Результат выполнения задания на получение элемента.
   */
  constructor(
    public jobItemGetResult: AppModDummyMainJobItemGetResult
  ) { }
}
