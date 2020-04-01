// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModDummyTreePageListLocation} from './mod-dummy-tree-page-list-location';
import {AppModDummyTreePageListParameters} from './mod-dummy-tree-page-list-parameters';
import {AppModDummyTreePageListSettings} from './mod-dummy-tree-page-list-settings';
import {AppModDummyTreePageItemParameters} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-parameters';

/** Мод "DummyTree". Страницы. Список. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreePageListService {

  /** @type {Subject} */
  private ensureLoadDataRequest$ = new Subject();

  /** @type {AppModDummyTreePageListLocation} */
  private location = new AppModDummyTreePageListLocation();

  /** @type {BehaviorSubject<AppModDummyTreePageListLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModDummyTreePageListLocation>;

  /**
   * Настройки.
   * @type {AppModDummyTreePageListSettings}
   */
  settings = new AppModDummyTreePageListSettings();

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   */
  constructor(
    private appSettings: AppCoreSettings
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModDummyTreePageListLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {number} index Индекс.
   * @returns {AppModDummyTreePageItemParameters} Параметры.
   */
  createParameters(index: string): AppModDummyTreePageListParameters {
    return new AppModDummyTreePageListParameters(this.appSettings, index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModDummyTreePageListParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModDummyTreePageListParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    const result = parameters.createQueryString();

    const {
      paramIsDataRefreshed,
      paramName,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSortDirection,
      paramSortField
    } = parameters;

    const byDefault = this.createParameters(parameters.index);

    if (paramIsDataRefreshed.isValueDiffer(byDefault.paramIsDataRefreshed.value)) {
      result[paramIsDataRefreshed.name] = paramIsDataRefreshed.value;
    }

    if (paramName.isValueDiffer(byDefault.paramName.value)) {
      result[paramName.name] = paramName.value;
    }

    if (paramPageNumber.isValueDiffer(byDefault.paramPageNumber.value)) {
      result[paramPageNumber.name] = paramPageNumber.value;
    }

    if (paramPageSize.isValueDiffer(byDefault.paramPageSize.value)) {
      result[paramPageSize.name] = paramPageSize.value;
    }

    if (paramSelectedItemId.isValueDiffer(byDefault.paramSelectedItemId.value)) {
      result[paramSelectedItemId.name] = paramSelectedItemId.value;
    }

    if (paramSortDirection.isValueDiffer(byDefault.paramSortDirection.value)) {
      result[paramSortDirection.name] = paramSortDirection.value;
    }

    if (paramSortField.isValueDiffer(byDefault.paramSortField.value)) {
      result[paramSortField.name] = paramSortField.value;
    }

    return result;
  }

  /**
   * Создать ссылку маршрутизатора.
   * @param {AppModDummyTreePageListParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(parameters: AppModDummyTreePageListParameters = null): any[] {
    if (!parameters) {
      const location = this.getLocation();

      parameters = location.parameters;
    }

    const qs = this.createQueryString(parameters);

    return [this.settings.path, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModDummyTreePageListLocation} Текущие параметры.
   */
  getLocation(): AppModDummyTreePageListLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyTreePageListLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModDummyTreePageListLocation> {
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
   * @param {AppModDummyTreePageListLocation} location Местоположение.
   */
  setLocation(location: AppModDummyTreePageListLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
