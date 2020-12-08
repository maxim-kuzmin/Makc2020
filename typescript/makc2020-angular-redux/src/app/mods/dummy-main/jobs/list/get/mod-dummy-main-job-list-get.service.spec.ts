import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobListGetService} from './mod-dummy-main-job-list-get.service';

describe('AppModDummyMainJobListGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobListGetService]
    });
  });

  it('should be created', inject([AppModDummyMainJobListGetService], (service: AppModDummyMainJobListGetService) => {
    expect(service).toBeTruthy();
  }));
});
