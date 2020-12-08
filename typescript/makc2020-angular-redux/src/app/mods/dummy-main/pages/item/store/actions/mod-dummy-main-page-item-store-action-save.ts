// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainJobItemGetOutput} from '../../../../jobs/item/get/mod-dummy-main-job-item-get-output';
import {AppModDummyMainPageItemEnumActions} from '../../enums/mod-dummy-main-page-item-enum-actions';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. Сохранение. */
export class AppModDummyMainPageItemStoreActionSave implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageItemEnumActions.Save;

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetOutput} jobItemGetOutput
   * Выход задания на получение элемента.
   */
  constructor(
    public jobItemGetOutput: AppModDummyMainJobItemGetOutput
  ) {
  }
}
