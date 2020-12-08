import {inject, TestBed} from '@angular/core/testing';

import {AppCoreAuthTypeOidcJobCurrentUserGetService} from './core-auth-type-oidc-job-current-user-get.service';

describe('AppCoreAuthTypeOidcJobCurrentUserGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcJobCurrentUserGetService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcJobCurrentUserGetService], (service: AppCoreAuthTypeOidcJobCurrentUserGetService) => {
    expect(service).toBeTruthy();
  }));
});
