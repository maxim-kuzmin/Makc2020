// //Author Maxim Kuzmin//makc//

import {createFeatureSelector} from '@ngrx/store';
import {AppModDummyMainStoreState} from './mod-dummy-main-store.state';
import {AppModDummyMainStoreStates} from './mod-dummy-main-store.states';
import {appModDummyMainStoreConfigFeatureName} from './mod-dummy-main-store-config';

/** Мод "DummyMain". Хранилище состояния. Селектор. */
export const appModDummyMainStoreSelector = createFeatureSelector<AppModDummyMainStoreState, AppModDummyMainStoreStates>(
  appModDummyMainStoreConfigFeatureName
);
