// //Author Maxim Kuzmin//makc//

import {AppHostLayoutFooterActions} from '../host-layout-footer-actions';
import {AppHostLayoutFooterState} from '../host-layout-footer-state';
import {AppHostLayoutFooterStoreActions} from './host-layout-footer-store.actions';

/** Хост. Разметка. Подвал. Хранилище состояния. Редьюсер. */
export function appHostLayoutFooterStoreReducer(
  state = new AppHostLayoutFooterState(),
  action: AppHostLayoutFooterStoreActions
): AppHostLayoutFooterState {
  switch (action.type) {
    case AppHostLayoutFooterActions.Clear:
      return  undefined;
    case AppHostLayoutFooterActions.Load:
      return {
        ...state,
        action: action.type,
        jobContentLoadInput: action.jobContentLoadInput
      };
    case AppHostLayoutFooterActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobContentLoadResult: action.jobContentLoadResult
      };
    default:
      return state;
  }
}
