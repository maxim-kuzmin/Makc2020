// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {OverlayContainer} from '@angular/cdk/overlay';

/** Ядро. Наложение. Контейнер. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreOverlayContainer extends OverlayContainer {

  /**
   * Клонировать для элемента.
   * @param {HTMLElement} containerElement HTML-элемент контейнера.
   * @returns {OverlayContainer} Контейнер наложения.
   */
  public cloneForElement(containerElement: HTMLElement): OverlayContainer {
    const result = new AppSkinCoreOverlayContainer(this._document);

    result._containerElement = containerElement;

    return result;
  }
}
