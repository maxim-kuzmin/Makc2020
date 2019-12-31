import {inject, TestBed} from '@angular/core/testing';
import {AppRootAuthJobLoginJwtService} from './root-auth-job-login-jwt.service';

describe('AppRootAuthJobLoginJwtService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootAuthJobLoginJwtService]
    });
  });

  it('should be created', inject([AppRootAuthJobLoginJwtService], (service: AppRootAuthJobLoginJwtService) => {
    expect(service).toBeTruthy();
  }));
});
