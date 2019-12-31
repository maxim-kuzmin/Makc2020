// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreOverlayService} from './core-overlay.service';

describe('AppCoreOverlayService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreOverlayService]
    });
  });

  it('should be created', inject([AppCoreOverlayService], (service: AppCoreOverlayService) => {
    expect(service).toBeTruthy();
  }));
});
