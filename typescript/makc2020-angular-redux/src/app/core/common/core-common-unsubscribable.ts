// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';

/** Ядро. Общее. Отписываемый. */
export abstract class AppCoreCommonUnsubscribable {

  /**
   * Отказ от подписки.
   * @type {Subject<boolean>}
   */
  protected unsubscribe$ = new Subject<boolean>();

  /** Обработчик события уничтожения. */
  onDestroy() {
    this.unsubscribe$.next(true);
    this.unsubscribe$.complete();
  }
}
