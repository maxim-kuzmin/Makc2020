// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreDeactivatingGuard} from './core-deactivating.guard';

describe('AppCoreDeactivatingGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreDeactivatingGuard]
    });
  });

  it('should ...', inject([AppCoreDeactivatingGuard], (guard: AppCoreDeactivatingGuard) => {
    expect(guard).toBeTruthy();
  }));
});
