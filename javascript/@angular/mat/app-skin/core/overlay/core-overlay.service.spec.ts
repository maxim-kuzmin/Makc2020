// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppSkinCoreOverlayService} from './core-overlay.service';

describe('AppCoreOverlayService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppSkinCoreOverlayService]
    });
  });

  it('should be created', inject([AppSkinCoreOverlayService], (service: AppSkinCoreOverlayService) => {
    expect(service).toBeTruthy();
  }));
});
