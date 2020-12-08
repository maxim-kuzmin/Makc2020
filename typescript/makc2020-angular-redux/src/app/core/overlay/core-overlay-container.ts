// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {OverlayContainer} from '@angular/cdk/overlay';

/** Ядро. Наложение. Контейнер. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreOverlayContainer extends OverlayContainer {

  /**
   * Клонировать для элемента.
   * @param {HTMLElement} containerElement HTML-элемент контейнера.
   * @returns {OverlayContainer} Контейнер наложения.
   */
  public cloneForElement(containerElement: HTMLElement): OverlayContainer {
    const result = new AppCoreOverlayContainer(this._document, this._platform);

    result._containerElement = containerElement;

    return result;
  }
}
