import {inject, TestBed} from '@angular/core/testing';

import {AppCoreAuthTypeOidcJobRefreshTokenService} from './core-auth-type-oidc-job-refresh-token.service';

describe('AppCoreAuthTypeOidcJobRefreshTokenService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcJobRefreshTokenService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcJobRefreshTokenService], (service: AppCoreAuthTypeOidcJobRefreshTokenService) => {
    expect(service).toBeTruthy();
  }));
});
