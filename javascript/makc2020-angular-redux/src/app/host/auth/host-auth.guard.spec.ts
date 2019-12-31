// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppHostAuthGuard} from './host-auth.guard';

describe('AppHostAuthGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHostAuthGuard]
    });
  });

  it('should ...', inject([AppHostAuthGuard], (guard: AppHostAuthGuard) => {
    expect(guard).toBeTruthy();
  }));
});
