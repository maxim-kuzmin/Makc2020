// //Author Maxim Kuzmin//makc//

import {createFeatureSelector} from '@ngrx/store';
import {AppModDummyTreeStoreState} from './mod-dummy-tree-store.state';
import {AppModDummyTreeStoreStates} from './mod-dummy-tree-store.states';
import {appModDummyTreeStoreConfigFeatureName} from './mod-dummy-tree-store-config';

/** Мод "DummyTree". Хранилище состояния. Селектор. */
export const appModDummyTreeStoreSelector = createFeatureSelector<AppModDummyTreeStoreState, AppModDummyTreeStoreStates>(
  appModDummyTreeStoreConfigFeatureName
);
