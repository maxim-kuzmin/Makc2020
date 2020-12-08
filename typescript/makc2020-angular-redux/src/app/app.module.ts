// //Author Maxim Kuzmin//makc//

import {HttpClient, HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {EffectsModule} from '@ngrx/effects';
import {DefaultRouterStateSerializer, StoreRouterConnectingModule} from '@ngrx/router-store';
import {StoreModule} from '@ngrx/store';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {OAuthModule} from 'angular-oauth2-oidc';
import {AppSkinModule} from '@app-skin/app.module';
import {environment} from '../environments/environment';
import {AppRoutingModule} from './app-routing.module';
import {appCoreConfigAuthTypeOidcModule} from '@app/core/core-config';
import {AppCoreModule} from './core/core.module';
import {appCoreLoggingDiTokenLoggerName} from './core/logging/core-logging-di';
import {AppCoreLoggingService} from './core/logging/core-logging.service';
import {appCoreStoreReducers} from './core/store/core-store.reducers';
import {AppDataModule} from './data/data.module';
import {AppHostModule} from './host/host.module';
import {AppRootModule} from './root/root.module';
import {AppSkinComponent} from '@app-skin/app.component';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

/** Приложение. Модуль. */
@NgModule({
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppCoreModule.forRoot(),
    AppDataModule.forRoot(),
    AppHostModule.forRoot(),
    AppRoutingModule,
    AppRootModule.forRoot(),
    AppSkinModule,
    OAuthModule.forRoot(appCoreConfigAuthTypeOidcModule),
    StoreModule.forRoot(appCoreStoreReducers, {
      runtimeChecks: {
        strictStateImmutability: false,
        strictActionImmutability: false,
        strictStateSerializability: false,
        strictActionSerializability: false,
        strictActionWithinNgZone: false
      }
    }),
    EffectsModule.forRoot([]),
    StoreRouterConnectingModule.forRoot({serializer: DefaultRouterStateSerializer}),
    StoreDevtoolsModule.instrument({maxAge: 25, logOnly: environment.production}),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      }
    })
  ],
  declarations: [],
  providers: [
    {provide: appCoreLoggingDiTokenLoggerName, useValue: AppModule.name},
    AppCoreLoggingService
  ],
  bootstrap: [AppSkinComponent]
})
export class AppModule {
}
