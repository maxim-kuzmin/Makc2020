// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppHostLayoutFooterActions} from '@app/host/layout/footer/host-layout-footer-actions';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. Очистка. */
export class AppHostLayoutFooterStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppHostLayoutFooterActions.Clear;
}
