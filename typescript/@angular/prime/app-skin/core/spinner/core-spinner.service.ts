// //Author Maxim Kuzmin//makc//

import {ComponentPortal} from '@angular/cdk/portal';
import {ElementRef, Injectable} from '@angular/core';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {AppCoreSpinnerService} from '@app/core/spinner/core-spinner.service';
import {AppCoreOverlayService} from '../../../app/core/overlay/core-overlay.service';
import {AppSkinCoreSpinnerComponent} from './core-spinner.component';
import {AppSkinCoreSpinnerRef} from './core-spinner-ref';

/** Ядро. Спиннер. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinCoreSpinnerService extends AppCoreSpinnerService {

  /**
   * Конструктор.
   * @param {AppCoreOverlayService} appCoreOverlay Наложение.
   */
  constructor(
    private appCoreOverlay: AppCoreOverlayService
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @param {?ElementRef} elRef Ссылка на элемент, внутри которого будет размещён спиннер.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить созданный спиннер.
   */
  create(elRef?: ElementRef): AppCoreCommonDisposable {
    const overlay = elRef
      ? this.appCoreOverlay.cloneForElement(elRef.nativeElement)
      : this.appCoreOverlay;

    const overlayRef = overlay.create({
      positionStrategy: overlay.position().global().centerHorizontally().centerVertically(),
      hasBackdrop: true
    });

    overlayRef.attach(new ComponentPortal(AppSkinCoreSpinnerComponent));

    return new AppSkinCoreSpinnerRef(overlayRef);
  }
}
