// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {ActivatedRoute, ActivatedRouteSnapshot, Event, NavigationEnd, Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {filter, map, switchMap, takeUntil} from 'rxjs/operators';
import {AppHostRouteData, appHostRouteDataCreate} from './host-route-data';
import {AppHostRouteDataPage} from '@app/host/route/data/host-route-data-page';

/** Хост. Маршрут. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostRouteService {

  /**
   * Конструктор.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private extRouter: Router
  ) {
    this.onNavigationEnd = this.onNavigationEnd.bind(this);
  }

  /**
   * Получить ключ страницы.
   * @param {ActivatedRoute} extRoute Маршрут.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns Observable<string> Ключ страницы.
   */
  getPageKey$(extRoute: ActivatedRoute, unsubscribe$: Subject<boolean>) {
    return extRoute.data.pipe(
      filter(routeData => !!routeData.page),
      map(routeData => routeData.page.key),
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Получить поток данных.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppHostRouteData>} Поток данных.
   */
  getData$(unsubscribe$: Subject<boolean>): Observable<AppHostRouteData> {
    return this.extRouter.events.pipe(
      filter(event => event instanceof NavigationEnd),
      switchMap(this.onNavigationEnd),
      takeUntil(unsubscribe$)
    );
  }

  /**
   * @param {Event} event
   * @returns {Observable<AppHostRouteData>}
   */
  private onNavigationEnd(event: Event): Observable<AppHostRouteData> {
    let routeData: AppHostRouteData;

    if (event instanceof NavigationEnd) {
      routeData = appHostRouteDataCreate();

      this.fillRouteData(routeData, this.extRouter.routerState.snapshot.root);
    }

    return of(routeData);
  }

  /**
   * @param {AppHostRouteData} routeData
   * @param {ActivatedRouteSnapshot} route
   */
  private fillRouteData(routeData: AppHostRouteData, route: ActivatedRouteSnapshot) {
    if (route.children.length > 0) {
      route.children.forEach(child => {
        this.fillRouteData(routeData, child);
      });
    } else {
      const page = route.data.page;

      if (page) {
        routeData.page = <AppHostRouteDataPage>page;
      }
    }
  }
}
