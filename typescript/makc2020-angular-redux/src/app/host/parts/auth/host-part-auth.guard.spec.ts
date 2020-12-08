// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppHostPartAuthGuard} from './host-part-auth.guard';

describe('AppHostPartAuthGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHostPartAuthGuard]
    });
  });

  it('should ...', inject([AppHostPartAuthGuard], (guard: AppHostPartAuthGuard) => {
    expect(guard).toBeTruthy();
  }));
});
