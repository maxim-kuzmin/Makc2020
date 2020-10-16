// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobListDeleteInput} from '../../../../jobs/list/delete/mod-dummy-main-job-list-delete-input';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Список. Удаление. */
export class AppModDummyMainPageListStoreActionListDelete implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ListDelete;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobListDeleteInput} jobListDeleteInput
   * Ввод задания на получение элемента.
   */
  constructor(
    public jobListDeleteInput: AppModDummyMainJobListDeleteInput
  ) {
  }
}
