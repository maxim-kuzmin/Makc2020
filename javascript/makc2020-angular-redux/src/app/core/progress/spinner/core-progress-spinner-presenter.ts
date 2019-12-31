// //Author Maxim Kuzmin//makc//

import {ElementRef} from '@angular/core';
import {AppCoreSpinnerManager} from '../../spinner/core-spinner-manager';
import {AppCoreSpinnerService} from '../../spinner/core-spinner.service';

/** Ядро. Прогресс. Спиннер. Представитель. */
export class AppCoreProgressSpinnerPresenter {

  /** @type {AppCoreSpinnerManager} */
  private sm: AppCoreSpinnerManager;

  /**
   * Конструктор.
   * @param {AppCoreSpinnerService} appSpinner Спиннер.
   */
  constructor(
    private appSpinner: AppCoreSpinnerService
  ) { }

  /** Спрятать. */
  hide() {
    this.sm.hideSpinner();
  }

  /** Показать. */
  show() {
    this.sm.showSpinner();
  }

  /**
   * Установить контейнер.
   * @param {ElementRef} container Контейнер.
   * @param {() => void} onAfterHide Обработчик события, возникающего после скрытия.
   */
  setContainer(
    container: ElementRef,
    onAfterHide: () => void
  ) {
    this.sm = new AppCoreSpinnerManager(
      this.appSpinner,
      container,
      onAfterHide
    );
  }
}
