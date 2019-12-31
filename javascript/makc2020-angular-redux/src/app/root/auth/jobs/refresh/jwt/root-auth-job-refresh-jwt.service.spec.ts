import {inject, TestBed} from '@angular/core/testing';
import {AppRootAuthJobRefreshJwtService} from './root-auth-job-refresh-jwt.service';

describe('AppRootAuthJobRefreshJwtService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootAuthJobRefreshJwtService]
    });
  });

  it('should be created', inject([AppRootAuthJobRefreshJwtService], (service: AppRootAuthJobRefreshJwtService) => {
    expect(service).toBeTruthy();
  }));
});
