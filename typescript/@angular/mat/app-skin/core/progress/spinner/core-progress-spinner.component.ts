// //Author Maxim Kuzmin//makc//

import {Component, ElementRef, ViewChild} from '@angular/core';
import {AppCoreProgressSpinnerPresenter} from '@app/core/progress/spinner/core-progress-spinner-presenter';
import {AppCoreSpinnerService} from '@app/core/spinner/core-spinner.service';

/** Ядро. Прогресс. Спиннер. Компонент. */
@Component({
  selector: 'app-skin-core-progress-spinner',
  templateUrl: './core-progress-spinner.component.html',
  styleUrls: ['./core-progress-spinner.component.css'],
})
export class AppSkinCoreProgressSpinnerComponent {

  /** @type {ElementRef} */
  @ViewChild('ctrlContainer', { static: true }) private ctrlContainer: ElementRef;

  /**
   * Мой представитель.
   * @type {AppCoreProgressSpinnerPresenter}
   */
  myPresenter: AppCoreProgressSpinnerPresenter;

  /**
   * Конструктор.
   * @param {AppCoreSpinnerService} appSpinner Спиннер.
   */
  constructor(
    appSpinner: AppCoreSpinnerService
  ) {
    this.myPresenter = new AppCoreProgressSpinnerPresenter(
      appSpinner
    );
  }

  /** Спрятать. */
  hide() {
    this.myPresenter.hide();
  }

  /**
   * Инициализировать.
   * @param {() => void} onAfterHide Обработчик события, возникающего после скрытия.
   */
  init(onAfterHide: () => void) {
    this.myPresenter.setContainer(this.ctrlContainer, onAfterHide);
  }

  /** Показать. */
  show() {
    this.myPresenter.show();
  }
}
