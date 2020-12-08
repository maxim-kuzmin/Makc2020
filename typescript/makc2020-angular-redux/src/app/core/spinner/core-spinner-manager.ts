// //Author Maxim Kuzmin//makc//

import {ElementRef} from '@angular/core';
import {AppCoreCommonDisposable} from '../common/core-common-disposable';
import {AppCoreExecutableAsync} from '../executable/core-executable-async';
import {AppCoreSpinnerService} from './core-spinner.service';

/** @type {number} */
const delayInMillisecond = 100;

/** @type {number} */
const timeoutInMillisecond = 1000;

/** Ядро. Спиннер. Менеджер. */
export class AppCoreSpinnerManager {

  /** @type {AppCoreCommonDisposable} */
  private spinnerRef: AppCoreCommonDisposable;

  /** @type {Date} */
  private startDate: Date;

  /** @type {AppCoreExecutableAsync} */
  private showSpinnerAsync = new AppCoreExecutableAsync(() => {
    setTimeout(this.showSpinnerImmediately, delayInMillisecond);
  });

  /** @type {AppCoreExecutableAsync} */
  private hideSpinnerAsync = new AppCoreExecutableAsync(() => {
    if (!!this.spinnerRef) {
      if (!!this.startDate) {
        const timeDiff = Math.abs((new Date()).getTime() - this.startDate.getTime());

        if (timeDiff < timeoutInMillisecond) {
          setTimeout(this.hideSpinnerImmediately, timeoutInMillisecond - timeDiff);
        } else {
          this.hideSpinnerImmediately();
        }
      } else {
        this.hideSpinnerImmediately();
      }
    } else {
      this.startDate = new Date();

      this.hideSpinnerImmediately();
    }
  });

  /**
   * Конструктор.
   * @param {AppCoreSpinnerService} appSpinner Спиннер.
   * @param {ElementRef} container Контейнер.
   * Признак того, что контейнер должен быть удалён при скрытии.
   * @param {() => void} onAfterHide Обработчик события, возникающего после скрытия.
   */
  constructor(
    private appSpinner: AppCoreSpinnerService,
    private container: ElementRef,
    private onAfterHide: () => void
  ) {
    this.hideSpinnerImmediately = this.hideSpinnerImmediately.bind(this);
    this.showSpinnerImmediately = this.showSpinnerImmediately.bind(this);
  }

  /** Показать спиннер. */
  showSpinner() {
    this.showSpinnerAsync.execute();
  }

  /** Спрятать спиннер. */
  hideSpinner() {
    this.hideSpinnerAsync.execute();
  }

  private hideSpinnerImmediately() {
    if (!!this.spinnerRef) {
      this.spinnerRef.dispose();

      this.spinnerRef = null;
      this.startDate = null;
    }

    if (this.onAfterHide) {
      this.onAfterHide();
    }
  }

  private showSpinnerImmediately() {
    if (!this.spinnerRef && !this.startDate) {
      this.spinnerRef = this.appSpinner.create(this.container);
      this.startDate = new Date();
    } else if (!!this.startDate) {
      this.startDate = null;
    }
  }
}
