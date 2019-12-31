import {inject, TestBed} from '@angular/core/testing';

import {AppCoreAuthTypeOidcJobLogoutService} from './core-auth-type-oidc-job-logout.service';

describe('AppCoreAuthTypeOidcJobLogoutService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcJobLogoutService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcJobLogoutService], (service: AppCoreAuthTypeOidcJobLogoutService) => {
    expect(service).toBeTruthy();
  }));
});
