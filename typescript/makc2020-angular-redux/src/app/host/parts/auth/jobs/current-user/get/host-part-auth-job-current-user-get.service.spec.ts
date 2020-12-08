import {inject, TestBed} from '@angular/core/testing';

import {AppHostPartAuthJobCurrentUserGetService} from './host-part-auth-job-current-user-get.service';

describe('AppHostPartAuthJobCurrentUserGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHostPartAuthJobCurrentUserGetService]
    });
  });

  it('should be created', inject([AppHostPartAuthJobCurrentUserGetService], (service: AppHostPartAuthJobCurrentUserGetService) => {
    expect(service).toBeTruthy();
  }));
});
