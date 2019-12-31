// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreAuthTypeOidcService} from './core-auth-type-oidc.service';

describe('AppCoreAuthTypeOidcService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcService], (service: AppCoreAuthTypeOidcService) => {
    expect(service).toBeTruthy();
  }));
});
