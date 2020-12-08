// //Author Maxim Kuzmin//makc//

import {AppHostLayoutMenuActions} from '../host-layout-menu-actions';
import {AppHostLayoutMenuState} from '../host-layout-menu-state';
import {AppHostLayoutMenuStoreActions} from './host-layout-menu-store.actions';
import {AppHostLayoutMenuStoreState} from './host-layout-menu-store.state';

/** Хост. Разметка. Меню. Хранилище состояния. Редьюсер. */
export function appHostLayoutMenuStoreReducer(
  state = new AppHostLayoutMenuStoreState(),
  action: AppHostLayoutMenuStoreActions
): AppHostLayoutMenuStoreState {
  const target = new AppHostLayoutMenuState();

  target.action = action.type;

  const source: AppHostLayoutMenuState = state.lookupStateByMenuLevel[action.menuLevel];

  if (source) {
    target.jobNodesFindInput = source.jobNodesFindInput;
    target.jobNodesFindResult = source.jobNodesFindResult;
  }

  const lookupStateByMenuLevel = {
    ...state.lookupStateByMenuLevel,
    [action.menuLevel]: target
  };

  switch (action.type) {
    case AppHostLayoutMenuActions.Clear: {
      lookupStateByMenuLevel[action.menuLevel] = undefined;
    }
      break;
    case AppHostLayoutMenuActions.Load:
      target.jobNodesFindInput = action.jobNodesFindInput;
      break;
    case AppHostLayoutMenuActions.LoadSuccess:
      target.jobNodesFindResult = action.jobNodesFindResult;
      break;
    default:
      return state;
  }

  return {
    ...state,
    lookupStateByMenuLevel: lookupStateByMenuLevel
  };
}
