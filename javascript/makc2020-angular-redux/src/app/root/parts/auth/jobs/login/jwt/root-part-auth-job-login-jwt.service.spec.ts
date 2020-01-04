import {inject, TestBed} from '@angular/core/testing';
import {AppRootPartAuthJobLoginJwtService} from './root-part-auth-job-login-jwt.service';

describe('AppRootPartAuthJobLoginJwtService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootPartAuthJobLoginJwtService]
    });
  });

  it('should be created', inject([AppRootPartAuthJobLoginJwtService], (service: AppRootPartAuthJobLoginJwtService) => {
    expect(service).toBeTruthy();
  }));
});
