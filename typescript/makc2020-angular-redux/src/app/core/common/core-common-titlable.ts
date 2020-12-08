// //Author Maxim Kuzmin//makc//

import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreTitleService} from '@app/core/title/core-title.service';

/** Ядро. Общее. Озаглавливаемый. */
export abstract class AppCoreCommonTitlable extends AppCoreCommonUnsubscribable {

  /**
   * Счётчик элементов заголовка.
   * @type {number}
   */
  protected titleItemsCount = 0;

  /**
   * Конструктор.
   * @param {AppCoreTitleService} appTitle Заголовок.
   */
  protected constructor(
    protected appTitle: AppCoreTitleService,
  ) {
    super();
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    if (this.titleItemsCount > 0) {
      this.appTitle.runActionLastItemsRemove(this.titleItemsCount);

      this.titleItemsCount = 0;
    }
  }
}
