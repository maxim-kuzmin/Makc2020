// //Author Maxim Kuzmin//makc//

import {createFeatureSelector} from '@ngrx/store';
import {AppRootStoreState} from './root-store.state';
import {AppRootStoreStates} from './root-store.states';
import {appRootStoreConfigFeatureName} from './root-store-config';

/** Корень. Хранилище состояния. Селектор. */
export const appRootStoreSelector = createFeatureSelector<AppRootStoreState, AppRootStoreStates>(
  appRootStoreConfigFeatureName
);
