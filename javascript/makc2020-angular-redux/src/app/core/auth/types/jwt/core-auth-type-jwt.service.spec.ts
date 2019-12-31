// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreAuthTypeJwtService} from './core-auth-type-jwt.service';

describe('AppCoreAuthTypeJwtService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeJwtService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeJwtService], (service: AppCoreAuthTypeJwtService) => {
    expect(service).toBeTruthy();
  }));
});
