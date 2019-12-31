// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppCoreDeactivatingGuard} from '@app/core/deactivating/core-deactivating.guard';
import {AppHostAuthGuard} from '@app/host/auth/host-auth.guard';
import {AppSkinModAuthComponent} from '@app-skin/mods/auth/mod-auth.component';
import {AppSkinModAuthPageIndexComponent} from '@app-skin/mods/auth/pages/index/mod-auth-page-index.component';
import {AppSkinModAuthPageLogonComponent} from '@app-skin/mods/auth/pages/logon/mod-auth-page-logon.component';
import {AppSkinModAuthPageRedirectComponent} from '@app-skin/mods/auth/pages/redirect/mod-auth-page-redirect.component';
import {AppSkinModAuthPageRegisterComponent} from '@app-skin/mods/auth/pages/register/mod-auth-page-register.component';
import {appModAuthConfigRoutePath} from './mod-auth-config';
import {appModAuthPageIndexConfigKey, appModAuthPageIndexConfigRoutePath} from './pages/index/mod-auth-page-index-config';
import {appModAuthPageLogonConfigKey, appModAuthPageLogonConfigRoutePath} from './pages/logon/mod-auth-page-logon-config';
import {appModAuthPageRedirectConfigKey, appModAuthPageRedirectConfigRoutePath} from './pages/redirect/mod-auth-page-redirect-config';
import {appModAuthPageRegisterConfigKey, appModAuthPageRegisterConfigRoutePath} from './pages/register/mod-auth-page-register-config';

const routes: Routes = [
  {
    children: [
      {
        children: [
          {
            canActivateChild: [AppHostAuthGuard],
            children: [
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModAuthPageIndexComponent,
                data: {page: {key: appModAuthPageIndexConfigKey}},
                path: appModAuthPageIndexConfigRoutePath
              },
              {
                canDeactivate: [AppCoreDeactivatingGuard],
                component: AppSkinModAuthPageRegisterComponent,
                data: {page: {key: appModAuthPageRegisterConfigKey}},
                path: appModAuthPageRegisterConfigRoutePath
              }
            ],
            path: ''
          },
          {
            component: AppSkinModAuthPageLogonComponent,
            data: {page: {key: appModAuthPageLogonConfigKey}},
            path: appModAuthPageLogonConfigRoutePath
          },
          {
            component: AppSkinModAuthPageRedirectComponent,
            data: {page: {key: appModAuthPageRedirectConfigKey}},
            path: appModAuthPageRedirectConfigRoutePath
          }
        ],
        path: ''
      }
    ],
    component: AppSkinModAuthComponent,
    path: appModAuthConfigRoutePath
  }
];

/** Мод "Auth". Маршрутизация. Модуль. */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppModAuthRoutingModule {
}
