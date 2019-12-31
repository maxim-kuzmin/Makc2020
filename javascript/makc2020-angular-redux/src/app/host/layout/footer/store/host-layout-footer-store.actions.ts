// //Author Maxim Kuzmin//makc//

import {AppHostLayoutFooterStoreActionClear} from './actions/host-layout-footer-store-action-clear';
import {AppHostLayoutFooterStoreActionLoad} from './actions/host-layout-footer-store-action-load';
import {AppHostLayoutFooterStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';

/** Хост. Разметка. Подвал. Хранилище состояния. Действия. */
export type AppHostLayoutFooterStoreActions =
  | AppHostLayoutFooterStoreActionClear
  | AppHostLayoutFooterStoreActionLoad
  | AppHostLayoutFooterStoreActionLoadSuccess;
