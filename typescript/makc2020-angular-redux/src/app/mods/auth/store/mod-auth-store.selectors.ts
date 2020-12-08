// //Author Maxim Kuzmin//makc//

import {createFeatureSelector} from '@ngrx/store';
import {AppModAuthStoreState} from './mod-auth-store.state';
import {AppModAuthStoreStates} from './mod-auth-store.states';
import {appModAuthStoreConfigFeatureName} from './mod-auth-store-config';

/** Мод "Auth". Хранилище состояния. Селектор. */
export const appModAuthStoreSelector = createFeatureSelector<AppModAuthStoreState, AppModAuthStoreStates>(
  appModAuthStoreConfigFeatureName
);
