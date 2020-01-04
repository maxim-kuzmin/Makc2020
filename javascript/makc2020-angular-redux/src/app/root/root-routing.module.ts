// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AppHostPartAuthGuard} from '@app/host/parts/auth/host-part-auth.guard';
import {AppSkinRootPageAdministrationComponent} from '@app-skin/root/pages/administration/root-page-administration.component';
import {AppSkinRootPageContactsComponent} from '@app-skin/root/pages/contacts/root-page-contacts.component';
import {AppSkinRootPageErrorComponent} from '@app-skin/root/pages/error/root-page-error.component';
import {AppSkinRootPageIndexComponent} from '@app-skin/root/pages/index/root-page-index.component';
import {AppSkinRootPageSiteComponent} from '@app-skin/root/pages/site/root-page-site.component';
import {
  appRootPageAdministrationConfigKey,
  appRootPageAdministrationConfigRoutePath
} from './pages/administration/root-page-administration-config';
import {appRootPageContactsConfigKey, appRootPageContactsConfigRoutePath} from './pages/contacts/root-page-contacts-config';
import {
  appRootPageError404ConfigKey,
  appRootPageErrorConfigKey,
  appRootPageErrorConfigRoutePath
} from './pages/error/root-page-error-config';
import {appRootPageIndexConfigKey, appRootPageIndexConfigRoutePath} from './pages/index/root-page-index-config';
import {appRootPageSiteConfigKey, appRootPageSiteConfigRoutePath} from './pages/site/root-page-site-config';

const routes: Routes = [
  {
    canActivateChild: [AppHostPartAuthGuard],
    children: [
      {
        component: AppSkinRootPageAdministrationComponent,
        data: {page: {key: appRootPageAdministrationConfigKey}},
        path: appRootPageAdministrationConfigRoutePath
      },
      {
        component: AppSkinRootPageErrorComponent,
        data: {page: {key: appRootPageErrorConfigKey}},
        path: appRootPageErrorConfigRoutePath
      },
      {
        component: AppSkinRootPageIndexComponent,
        data: {page: {key: appRootPageIndexConfigKey}},
        path: appRootPageIndexConfigRoutePath,
        pathMatch: 'full'
      },
      {
        component: AppSkinRootPageSiteComponent,
        data: {page: {key: appRootPageSiteConfigKey}},
        path: appRootPageSiteConfigRoutePath
      },
      {
        component: AppSkinRootPageContactsComponent,
        data: {page: {key: appRootPageContactsConfigKey}},
        path: appRootPageContactsConfigRoutePath
      }
    ],
    path: ''
  },
  {
    component: AppSkinRootPageErrorComponent,
    data: {page: {key: appRootPageError404ConfigKey}},
    path: '**'
  }
];

/** Корень. Маршрутизация. Модуль. */
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppRootRoutingModule {
}
