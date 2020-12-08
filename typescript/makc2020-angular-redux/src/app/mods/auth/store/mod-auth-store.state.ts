// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppModAuthStoreStates} from './mod-auth-store.states';
import {appModAuthStoreConfigFeatureName} from '@app/mods/auth/store/mod-auth-store-config';

/** Мод "Auth". Хранилище состояния. Состояние. */
export interface AppModAuthStoreState extends AppCoreStoreState {
  [appModAuthStoreConfigFeatureName]: AppModAuthStoreStates;
}
