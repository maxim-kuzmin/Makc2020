// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModDummyMainPageItemParameters} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-parameters';
import {AppModDummyMainPageListLocation} from './mod-dummy-main-page-list-location';
import {AppModDummyMainPageListParameters} from './mod-dummy-main-page-list-parameters';
import {AppModDummyMainPageListSettings} from './mod-dummy-main-page-list-settings';

/** Мод "DummyMain". Страницы. Список. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainPageListService {

  /** @type {Subject} */
  private ensureLoadDataRequest$ = new Subject();

  /** @type {AppModDummyMainPageListLocation} */
  private location = new AppModDummyMainPageListLocation();

  /** @type {BehaviorSubject<AppModDummyMainPageListLocation>} */
  private readonly locationChanged$: BehaviorSubject<AppModDummyMainPageListLocation>;

  /**
   * Настройки.
   * @type {AppModDummyMainPageListSettings}
   */
  settings = new AppModDummyMainPageListSettings();

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   */
  constructor(
    private appSettings: AppCoreSettings
  ) {
    this.locationChanged$ = new BehaviorSubject<AppModDummyMainPageListLocation>(this.location);
  }

  /**
   * Создать параметры.
   * @param {?number} index Индекс.
   * @returns {AppModDummyMainPageItemParameters} Параметры.
   */
  createParameters(index?: string): AppModDummyMainPageListParameters {
    if (index === undefined || index === null) {
      index = this.settings.index;
    }

    return new AppModDummyMainPageListParameters(this.appSettings, index);
  }

  /**
   * Создать строку запроса.
   * @param {AppModDummyMainPageListParameters} parameters Параметры.
   * @returns {any} Строка запроса.
   */
  createQueryString(parameters: AppModDummyMainPageListParameters): any {
    if (!parameters) {
      parameters = this.createParameters('');
    }

    const result = parameters.createQueryString();

    const {
      paramIsDataRefreshed,
      paramName,
      paramObjectDummyOneToManyId,
      paramPageNumber,
      paramPageSize,
      paramSelectedItemId,
      paramSelectedItemIdsString,
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

    if (paramObjectDummyOneToManyId.isValueDiffer(byDefault.paramObjectDummyOneToManyId.value)) {
      result[paramObjectDummyOneToManyId.name] = paramObjectDummyOneToManyId.value;
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

    if (paramSelectedItemIdsString.isValueDiffer(byDefault.paramSelectedItemIdsString.value)) {
      result[paramSelectedItemIdsString.name] = paramSelectedItemIdsString.value;
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
   * @param {AppModDummyMainPageListParameters} parameters Параметры.
   * @returns {any[]} Ссылка маршрутизатора.
   */
  createRouterLink(parameters: AppModDummyMainPageListParameters = null): any[] {
    if (!parameters) {
      const location = this.getLocation();

      parameters = location.parameters;
    }

    const qs = this.createQueryString(parameters);

    return [this.settings.path, qs];
  }

  /**
   * Получить местоположение.
   * @returns {AppModDummyMainPageListLocation} Текущие параметры.
   */
  getLocation(): AppModDummyMainPageListLocation {
    return this.location;
  }

  /**
   * Получить поток местоположений.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   * @returns {Observable<AppModDummyMainPageListLocation>} Поток местоположений.
   */
  getLocation$(unsubscribe$: Subject<boolean>): Observable<AppModDummyMainPageListLocation> {
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
   * @param {AppModDummyMainPageListLocation} location Местоположение.
   */
  setLocation(location: AppModDummyMainPageListLocation) {
    this.location = location;

    this.locationChanged$.next(this.location);
  }
}
