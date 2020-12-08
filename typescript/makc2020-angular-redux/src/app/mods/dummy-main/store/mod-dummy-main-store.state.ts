// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppModDummyMainStoreStates} from './mod-dummy-main-store.states';
import {appModDummyMainStoreConfigFeatureName} from '@app/mods/dummy-main/store/mod-dummy-main-store-config';

/** Мод "DummyMain". Хранилище состояния. Состояние. */
export interface AppModDummyMainStoreState extends AppCoreStoreState {
  [appModDummyMainStoreConfigFeatureName]: AppModDummyMainStoreStates;
}
