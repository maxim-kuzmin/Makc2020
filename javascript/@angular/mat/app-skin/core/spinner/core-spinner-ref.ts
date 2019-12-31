// //Author Maxim Kuzmin//makc//

import {OverlayRef} from '@angular/cdk/overlay';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';

/** Ядро. Спиннер. Ссылка. */
export class AppSkinCoreSpinnerRef implements AppCoreCommonDisposable {

  /**
   * Конструктор.
   * @param {OverlayRef} overlayRef Ссылка на наложение.
   */
  constructor(
    private overlayRef: OverlayRef
  ) { }

  /** @inheritdoc */
  dispose() {
    this.overlayRef.dispose();
  }
}
