// //Author Maxim Kuzmin//makc//

import {AppCoreStoreState} from '@app/core/store/core-store.state';
import {AppModDummyTreeStoreStates} from './mod-dummy-tree-store.states';
import {appModDummyTreeStoreConfigFeatureName} from '@app/mods/dummy-tree/store/mod-dummy-tree-store-config';

/** Мод "DummyTree". Хранилище состояния. Состояние. */
export interface AppModDummyTreeStoreState extends AppCoreStoreState {
  [appModDummyTreeStoreConfigFeatureName]: AppModDummyTreeStoreStates;
}
