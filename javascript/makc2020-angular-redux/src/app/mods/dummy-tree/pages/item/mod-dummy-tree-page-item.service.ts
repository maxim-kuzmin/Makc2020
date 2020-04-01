// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppModDummyTreePageListService} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list.service';
import {AppModDummyTreePageItemLocation} from './mod-dummy-tree-page-item-location';
import {AppModDummyTreePageItemParameters} from './mod-dummy-tree-page-item-parameters';
import {AppModDummyTreePageItemSettings} from './mod-dummy-tree-page-item-settings';

/** Мод "DummyTree". Страницы. Элемент. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreePageItemService {

  /** @type {AppModDummyTreePageItemLocation} */
  private location = new AppModDummyTreePageItemLocation();

  /** @type {BehaviorSubject<AppModDummyTreePageItemLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModDummyTreePageItemLocation>;

  /**
   * Настройки.
   * @type {AppModDummyTreePageItemSettings}
   */
  settings = new AppModDummyTreePageItemSettings();

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListService} appModDummyTreePageList Страница "ModDummyTreePageList".
   */
  constructor(
    private appModDummyTreePageList: AppModDummyTreePageListService
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModDummyTreePageItemLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {number} index Индекс.
   * @returns {AppModDummyTreePageItemParameters} Параметры.
   */
  createParameters(index: string): AppModDummyTreePageItemParameters {
    return new AppModDummyTreePageItemParameters(index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModDummyTreePageItemParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModDummyTreePageItemParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    return  parameters.createQueryString();
  }

  /**
   * Создать ссылку маршрутизатора.
   * @param {string} path Путь.
   * @param {AppModDummyTreePageItemParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(path: string = null, parameters: AppModDummyTreePageItemParameters = null): any[] {
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

    const listLocation = this.appModDummyTreePageList.getLocation();

    const listQs = this.appModDummyTreePageList.createQueryString(listLocation.parameters);

    qs = {...qs, ...listQs};

    return path === this.settings.paths.pathCreate
      ? [path, qs]
      : [path, parameters.paramId.value, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModDummyTreePageItemLocation} Текущие параметры.
   */
  getLocation(): AppModDummyTreePageItemLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyTreePageItemLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModDummyTreePageItemLocation> {
    return this.locationChanged$.pipe(
      takeUntil(unsubscribe$)
    );
  }

  /**
   * Установить местоположение.
   * @param {AppModDummyTreePageItemLocation} location Местоположение.
   */
  setLocation(location: AppModDummyTreePageItemLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
