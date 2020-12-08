// //Author Maxim Kuzmin//makc//

import {CollectionViewer, DataSource} from '@angular/cdk/collections';
import {BehaviorSubject, Observable} from 'rxjs';
import {AppModDummyMainPageListDataItem} from '@app/mods/dummy-main/pages/list/data/mod-dummy-main-page-list-data-item';

/** Мод "DummyMain". Страницы. Список. Данные. Источник. */
export class AppSkinModDummyMainPageListDataSource
  extends DataSource<AppModDummyMainPageListDataItem> {

  private dataSubject = new BehaviorSubject<AppModDummyMainPageListDataItem[]>([]);

  /** @inheritdoc */
  connect(collectionViewer: CollectionViewer): Observable<AppModDummyMainPageListDataItem[]> {
    return this.dataSubject.asObservable();
  }

  /** @inheritdoc */
  disconnect(collectionViewer: CollectionViewer) {
    this.dataSubject.complete();
  }

  /**
   * Загрузить данные.
   * @param {AppSkinModDummyMainPageListDataItem[]} data Данные.
   */
  loadData(data: AppModDummyMainPageListDataItem[]) {
    this.dataSubject.next(data);
  }
}
