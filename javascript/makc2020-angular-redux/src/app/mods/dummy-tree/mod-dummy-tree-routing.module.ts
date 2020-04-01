// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppCoreDeactivatingGuard} from '@app/core/deactivating/core-deactivating.guard';
import {AppHostPartAuthGuard} from '@app/host/parts/auth/host-part-auth.guard';
import {AppSkinModDummyTreeComponent} from '@app-skin/mods/dummy-tree/mod-dummy-tree.component';
import {AppSkinModDummyTreePageIndexComponent} from '@app-skin/mods/dummy-tree/pages/index/mod-dummy-tree-page-index.component';
import {AppSkinModDummyTreePageItemComponent} from '@app-skin/mods/dummy-tree/pages/item/mod-dummy-tree-page-item.component';
import {AppSkinModDummyTreePageListComponent} from '@app-skin/mods/dummy-tree/pages/list/mod-dummy-tree-page-list.component';
import {appModDummyTreeConfigRoutePath} from '@app/mods/dummy-tree/mod-dummy-tree-config';
import {
  appModDummyTreePageIndexConfigKey,
  appModDummyTreePageIndexConfigRoutePath
} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-config';
import {
  appModDummyTreePageItemConfigRoutePath,
  appModDummyTreePageItemCreateConfigKey,
  appModDummyTreePageItemCreateConfigRoutePath,
  appModDummyTreePageItemEditConfigKey,
  appModDummyTreePageItemEditConfigRoutePath,
  appModDummyTreePageItemViewConfigKey,
  appModDummyTreePageItemViewConfigRoutePath
} from './pages/item/mod-dummy-tree-page-item-config';
import {appModDummyTreePageListConfigKey, appModDummyTreePageListConfigRoutePath} from './pages/list/mod-dummy-tree-page-list-config';

const routes: Routes = [
  {
    children: [
      {
        canActivateChild: [AppHostPartAuthGuard],
        children: [
          {
            children: [
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModDummyTreePageItemComponent,
                data: {page: {key: appModDummyTreePageItemCreateConfigKey}},
                path: appModDummyTreePageItemCreateConfigRoutePath
              },
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModDummyTreePageItemComponent,
                data: {page: {key: appModDummyTreePageItemEditConfigKey}},
                path: appModDummyTreePageItemEditConfigRoutePath
              },
              {
                component: AppSkinModDummyTreePageItemComponent,
                data: {page: {key: appModDummyTreePageItemViewConfigKey}},
                path: appModDummyTreePageItemViewConfigRoutePath
              }
            ],
            path: appModDummyTreePageItemConfigRoutePath
          },
          {
            component: AppSkinModDummyTreePageListComponent,
            data: {page: {key: appModDummyTreePageListConfigKey}},
            path: appModDummyTreePageListConfigRoutePath
          },
          {
            component: AppSkinModDummyTreePageIndexComponent,
            data: {page: {key: appModDummyTreePageIndexConfigKey}},
            path: appModDummyTreePageIndexConfigRoutePath
          }
        ],
        path: ''
      }
    ],
    component: AppSkinModDummyTreeComponent,
    path: appModDummyTreeConfigRoutePath
  }
];

/** Мод "DummyTree". Маршрутизация. Модуль. */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppModDummyTreeRoutingModule {
}
