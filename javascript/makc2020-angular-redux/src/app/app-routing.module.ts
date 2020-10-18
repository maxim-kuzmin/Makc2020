// //Author Maxim Kuzmin//makc//

import {NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';
import {
  appModsConfigModAuthRoutePath,
  appModsConfigModDummyMainRoutePath,
  appModsConfigModDummyTreeRoutePath,
  appModsConfigRoutePath
} from '@app/mods/mods-config';

const routes: Routes = [
  {
    path: appModsConfigRoutePath,
    children: [
      {
        path: appModsConfigModDummyMainRoutePath,
        loadChildren: () => import('./mods/dummy-main/mod-dummy-main.module').then(m => m.AppModDummyMainModule)
      },
      {
        path: appModsConfigModDummyTreeRoutePath,
        loadChildren: () => import('./mods/dummy-tree/mod-dummy-tree.module').then(m => m.AppModDummyTreeModule)
      },
      {
        path: appModsConfigModAuthRoutePath,
        loadChildren: () => import('./mods/auth/mod-auth.module').then(m => m.AppModAuthModule)
      }
    ]
  }
];

/** Приложение. Маршрутизация. Модуль. */
@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      // enableTracing: true, // <-- debugging purposes only
      onSameUrlNavigation: 'reload',
      preloadingStrategy: PreloadAllModules,
      // //makc//!!!//>//Если это раскомментировать, то при включенной аутентификации SSO
      // (значение authTypeOidcIsEnabled равно true в файле environment.ts) приложение перестаёт
      // работать. Однако это нужно для SSR (отрисовки на сервере), поэтому с этим надо срочно
      // разобраться - SSR должен работать вместе с SSO! //

      // initialNavigation: 'enabled'

      // //makc//!!!//<//
    })
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {
}
