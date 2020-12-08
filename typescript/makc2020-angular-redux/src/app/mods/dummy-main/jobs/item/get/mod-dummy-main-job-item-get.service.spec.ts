import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobItemGetService} from './mod-dummy-main-job-item-get.service';

describe('AppModDummyMainJobItemGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobItemGetService]
    });
  });

  it('should be created', inject([AppModDummyMainJobItemGetService], (service: AppModDummyMainJobItemGetService) => {
    expect(service).toBeTruthy();
  }));
});
