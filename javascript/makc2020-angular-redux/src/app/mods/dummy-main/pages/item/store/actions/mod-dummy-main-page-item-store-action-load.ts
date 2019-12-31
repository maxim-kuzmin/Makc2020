// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetInput} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-input';
import {AppModDummyMainPageItemEnumActions} from '../../enums/mod-dummy-main-page-item-enum-actions';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. Загрузка. */
export class AppModDummyMainPageItemStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageItemEnumActions.Load;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetInput} jobItemGetInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobItemGetInput: AppModDummyMainJobItemGetInput
  ) { }
}
