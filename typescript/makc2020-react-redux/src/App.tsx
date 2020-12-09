import React from 'react';
import { BrowserRouter, Redirect, Route, Switch } from 'react-router-dom';
import './App.css';
import { AppSkinHostLayoutHeaderComponent } from './app-skin/host/layout/header/host-layout-header.component';
import { AppSkinRootPageIndexComponent } from './app-skin/root/pages/index/root-page-index.component';
import { AppSkinRootPageSiteComponent } from './app-skin/root/pages/site/root-page-site.component';
import { AppSkinModDummyMainPageListComponent } from './app-skin/mods/dummy-main/pages/list/mod-dummy-main-page-list.component';
import { AppSkinRootPageErrorComponent } from './app-skin/root/pages/error/root-page-error.component';

function App() {
  return (
    <BrowserRouter>
      <AppSkinHostLayoutHeaderComponent />
      <Switch>
        <Redirect from="/index" to="/" />
        <Route path="/" exact component={AppSkinRootPageIndexComponent} />
        <Route path="/site" component={AppSkinRootPageSiteComponent} />
        <Route
          path="/mods/dummy-main/list"
          component={AppSkinModDummyMainPageListComponent}
        />
        <Route render={() => <AppSkinRootPageErrorComponent code={'404'} />} />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
