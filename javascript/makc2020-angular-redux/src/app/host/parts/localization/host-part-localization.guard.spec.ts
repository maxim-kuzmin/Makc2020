// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppHostPartLocalizationGuard} from './host-part-localization.guard';

describe('AppHostPartLocalizationGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHostPartLocalizationGuard]
    });
  });

  it('should ...', inject([AppHostPartLocalizationGuard], (guard: AppHostPartLocalizationGuard) => {
    expect(guard).toBeTruthy();
  }));
});
