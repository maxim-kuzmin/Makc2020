// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreDeactivatingService} from './core-deactivating.service';

describe('AppCoreDeactivatingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreDeactivatingService]
    });
  });

  it('should ...', inject([AppCoreDeactivatingService], (guard: AppCoreDeactivatingService) => {
    expect(guard).toBeTruthy();
  }));
});
