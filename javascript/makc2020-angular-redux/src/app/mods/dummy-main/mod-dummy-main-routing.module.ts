// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppCoreDeactivatingGuard} from '@app/core/deactivating/core-deactivating.guard';
import {AppHostAuthGuard} from '@app/host/auth/host-auth.guard';
import {AppSkinModDummyMainComponent} from '@app-skin/mods/dummy-main/mod-dummy-main.component';
import {AppSkinModDummyMainPageIndexComponent} from '@app-skin/mods/dummy-main/pages/index/mod-dummy-main-page-index.component';
import {AppSkinModDummyMainPageItemComponent} from '@app-skin/mods/dummy-main/pages/item/mod-dummy-main-page-item.component';
import {AppSkinModDummyMainPageListComponent} from '@app-skin/mods/dummy-main/pages/list/mod-dummy-main-page-list.component';
import {appModDummyMainConfigRoutePath} from '@app/mods/dummy-main/mod-dummy-main-config';
import {
  appModDummyMainPageIndexConfigKey,
  appModDummyMainPageIndexConfigRoutePath
} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-config';
import {
  appModDummyMainPageItemConfigRoutePath,
  appModDummyMainPageItemCreateConfigKey,
  appModDummyMainPageItemCreateConfigRoutePath,
  appModDummyMainPageItemEditConfigKey,
  appModDummyMainPageItemEditConfigRoutePath,
  appModDummyMainPageItemViewConfigKey,
  appModDummyMainPageItemViewConfigRoutePath
} from './pages/item/mod-dummy-main-page-item-config';
import {appModDummyMainPageListConfigKey, appModDummyMainPageListConfigRoutePath} from './pages/list/mod-dummy-main-page-list-config';

const routes: Routes = [
  {
    children: [
      {
        canActivateChild: [AppHostAuthGuard],
        children: [
          {
            children: [
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModDummyMainPageItemComponent,
                data: {page: {key: appModDummyMainPageItemCreateConfigKey}},
                path: appModDummyMainPageItemCreateConfigRoutePath
              },
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModDummyMainPageItemComponent,
                data: {page: {key: appModDummyMainPageItemEditConfigKey}},
                path: appModDummyMainPageItemEditConfigRoutePath
              },
              {
                component: AppSkinModDummyMainPageItemComponent,
                data: {page: {key: appModDummyMainPageItemViewConfigKey}},
                path: appModDummyMainPageItemViewConfigRoutePath
              }
            ],
            path: appModDummyMainPageItemConfigRoutePath
          },
          {
            component: AppSkinModDummyMainPageListComponent,
            data: {page: {key: appModDummyMainPageListConfigKey}},
            path: appModDummyMainPageListConfigRoutePath
          },
          {
            component: AppSkinModDummyMainPageIndexComponent,
            data: {page: {key: appModDummyMainPageIndexConfigKey}},
            path: appModDummyMainPageIndexConfigRoutePath
          }
        ],
        path: ''
      }
    ],
    component: AppSkinModDummyMainComponent,
    path: appModDummyMainConfigRoutePath
  }
];

/** Мод "DummyMain". Маршрутизация. Модуль. */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppModDummyMainRoutingModule {
}
