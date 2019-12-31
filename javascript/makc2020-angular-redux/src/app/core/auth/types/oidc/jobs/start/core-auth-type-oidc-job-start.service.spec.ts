import {inject, TestBed} from '@angular/core/testing';

import {AppCoreAuthTypeOidcJobStartService} from './core-auth-type-oidc-job-start.service';

describe('AppCoreAuthTypeOidcJobStartService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreAuthTypeOidcJobStartService]
    });
  });

  it('should be created', inject([AppCoreAuthTypeOidcJobStartService], (service: AppCoreAuthTypeOidcJobStartService) => {
    expect(service).toBeTruthy();
  }));
});
