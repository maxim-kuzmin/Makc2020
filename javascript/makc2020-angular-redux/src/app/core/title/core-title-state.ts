// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreTitleEnumActions} from './enums/core-title-enum-actions';
import {AppCoreTitleDataItem} from './data/core-title-data-item';

/** Ядро. Заголовок. Состояние. */
export class AppCoreTitleState extends AppCoreCommonState<AppCoreTitleEnumActions> {

  /**
   * Элементы.
   * @type {AppCoreTitleDataItem[]}
   */
  items: AppCoreTitleDataItem[] = [];
}
