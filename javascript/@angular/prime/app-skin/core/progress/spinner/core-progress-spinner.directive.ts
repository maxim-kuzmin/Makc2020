// //Author Maxim Kuzmin//makc//

import {Directive, ViewContainerRef} from '@angular/core';
import {AppCoreProgressSpinnerPresenter} from '@app/core/progress/spinner/core-progress-spinner-presenter';
import {AppCoreSpinnerService} from '@app/core/spinner/core-spinner.service';

/** Ядро. Прогресс. Спиннер. Директива. */
@Directive({
  selector: '[appSkinCoreProgressSpinner]',
  exportAs: 'AppSkinCoreProgressSpinnerDirective'
})
export class AppSkinCoreProgressSpinnerDirective {

  /**
   * Мой представитель.
   * @type {AppCoreProgressSpinnerPresenter}
   */
  myPresenter: AppCoreProgressSpinnerPresenter;

  /**
   * Конструктор.
   * @param {AppCoreSpinnerService} appSpinner Спиннер.
   * @param {ViewContainerRef} viewContainerRef Ссылка на представление контейнера.
   */
  constructor(
    appSpinner: AppCoreSpinnerService,
    private viewContainerRef: ViewContainerRef
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
   * @param {?() => void} onAfterHide Обработчик события, возникающего после скрытия.
   */
  init(onAfterHide?: () => void) {
    this.myPresenter.setContainer(this.viewContainerRef.element, onAfterHide);
  }

  /** Показать. */
  show() {
    this.myPresenter.show();
  }
}
