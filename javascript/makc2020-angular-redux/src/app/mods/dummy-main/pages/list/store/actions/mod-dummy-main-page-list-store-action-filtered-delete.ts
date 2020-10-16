// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobListGetInput} from '../../../../jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Отфильтрованное. Удаление. */
export class AppModDummyMainPageListStoreActionFilteredDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.FilteredDelete;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobListGetInput} jobListGetInput
   * Ввод задания на получение списка.
   */
  constructor(
    public jobListGetInput: AppModDummyMainJobListGetInput
  ) {
  }
}
