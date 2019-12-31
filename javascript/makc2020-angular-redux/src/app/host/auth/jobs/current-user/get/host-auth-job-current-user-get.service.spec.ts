import {inject, TestBed} from '@angular/core/testing';

import {AppHostAuthJobCurrentUserGetService} from './host-auth-job-current-user-get.service';

describe('AppHostAuthJobCurrentUserGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHostAuthJobCurrentUserGetService]
    });
  });

  it('should be created', inject([AppHostAuthJobCurrentUserGetService], (service: AppHostAuthJobCurrentUserGetService) => {
    expect(service).toBeTruthy();
  }));
});
