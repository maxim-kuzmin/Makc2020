import {inject, TestBed} from '@angular/core/testing';

import {AppCoreAuthTypeOidcJobLoginService} from './core-auth-type-oidc-job-login.service';

describe('AppCoreAuthTypeOidcJobLoginService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcJobLoginService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcJobLoginService], (service: AppCoreAuthTypeOidcJobLoginService) => {
    expect(service).toBeTruthy();
  }));
});
