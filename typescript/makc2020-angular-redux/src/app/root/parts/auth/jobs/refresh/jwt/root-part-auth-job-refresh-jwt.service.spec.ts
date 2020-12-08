import {inject, TestBed} from '@angular/core/testing';
import {AppRootPartAuthJobRefreshJwtService} from './root-part-auth-job-refresh-jwt.service';

describe('AppRootPartAuthJobRefreshJwtService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootPartAuthJobRefreshJwtService]
    });
  });

  it('should be created', inject([AppRootPartAuthJobRefreshJwtService], (service: AppRootPartAuthJobRefreshJwtService) => {
    expect(service).toBeTruthy();
  }));
});
