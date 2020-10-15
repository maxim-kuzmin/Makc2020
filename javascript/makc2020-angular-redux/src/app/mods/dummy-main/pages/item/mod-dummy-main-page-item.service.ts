// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyMainPageListService} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list.service';
import {AppModDummyMainPageItemLocation} from './mod-dummy-main-page-item-location';
import {AppModDummyMainPageItemParameters} from './mod-dummy-main-page-item-parameters';
import {AppModDummyMainPageItemSettings} from './mod-dummy-main-page-item-settings';

/** Мод "DummyMain". Страницы. Элемент. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainPageItemService {

  /** @type {Subject} */
  private ensureLoadDataRequest$ = new Subject();

  /** @type {AppModDummyMainPageItemLocation} */
  private location = new AppModDummyMainPageItemLocation();

  /** @type {BehaviorSubject<AppModDummyMainPageItemLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModDummyMainPageItemLocation>;

  /**
   * Настройки.
   * @type {AppModDummyMainPageItemSettings}
   */
  settings = new AppModDummyMainPageItemSettings();

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListService} appModDummyMainPageList Страница "ModDummyMainPageList".
   */
  constructor(
    private appModDummyMainPageList: AppModDummyMainPageListService
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModDummyMainPageItemLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {number} index Индекс.
   * @returns {AppModDummyMainPageItemParameters} Параметры.
   */
  createParameters(index: string): AppModDummyMainPageItemParameters {
    if (index === undefined || index === null) {
      index = this.settings.index;
    }

    return new AppModDummyMainPageItemParameters(index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModDummyMainPageItemParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModDummyMainPageItemParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    return  parameters.createQueryString();
  }

  /**
   * Создать ссылку маршрутизатора.
   * @param {string} path Путь.
   * @param {AppModDummyMainPageItemParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(path: string = null, parameters: AppModDummyMainPageItemParameters = null): any[] {
    if (!path || !parameters) {
      const location = this.getLocation();

      if (!path) {
        path = location.path;
      }

      if (!parameters) {
        parameters = location.parameters;
      }
    }

    let qs = this.createQueryString(parameters);

    const listLocation = this.appModDummyMainPageList.getLocation();

    const listQs = this.appModDummyMainPageList.createQueryString(listLocation.parameters);

    qs = {...qs, ...listQs};

    return path === this.settings.paths.pathCreate
      ? [path, qs]
      : [path, parameters.paramId.value, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModDummyMainPageItemLocation} Текущие параметры.
   */
  getLocation(): AppModDummyMainPageItemLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyMainPageItemLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModDummyMainPageItemLocation> {
    return this.locationChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Получить поток запросов на обеспечение загрузки данных.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<any>} Поток запросов на обеспечение загрузки данных.
   */
  receiveEnsureLoadDataRequest$(unsubscribe$: Subject<boolean>): Observable<any> {
    return this.ensureLoadDataRequest$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /** Отправить запрос на обеспечение загрузки данных. */
  sendEnsureLoadDataRequest() {
    this.ensureLoadDataRequest$.next();
  }

  /**
   * Установить местоположение.
   * @param {AppModDummyMainPageItemLocation} location Местоположение.
   */
  setLocation(location: AppModDummyMainPageItemLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
