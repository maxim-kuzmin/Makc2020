// //Author Maxim Kuzmin//makc//

import {createFeatureSelector} from '@ngrx/store';
import {AppHostStoreState} from './host-store.state';
import {AppHostStoreStates} from './host-store.states';
import {appHostStoreConfigFeatureName} from './host-store-config';

/** Хост. Хранилище состояния. Селектор. */
export const appHostStoreSelector = createFeatureSelector<AppHostStoreState, AppHostStoreStates>(
  appHostStoreConfigFeatureName
);
