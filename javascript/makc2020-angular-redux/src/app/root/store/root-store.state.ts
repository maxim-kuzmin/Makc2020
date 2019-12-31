// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppRootStoreStates} from './root-store.states';
import {appRootStoreConfigFeatureName} from '@app/root/store/root-store-config';

/** Корень. Хранилище состояния. Состояние. */
export interface AppRootStoreState extends AppCoreStoreState {
  [appRootStoreConfigFeatureName]: AppRootStoreStates;
}
