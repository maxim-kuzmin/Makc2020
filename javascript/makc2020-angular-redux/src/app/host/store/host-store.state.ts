// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppHostStoreStates} from './host-store.states';
import {appHostStoreConfigFeatureName} from '@app/host/store/host-store-config';

/** Хост. Хранилище состояния. Состояние. */
export interface AppHostStoreState extends AppCoreStoreState {
  [appHostStoreConfigFeatureName]: AppHostStoreStates;
}
