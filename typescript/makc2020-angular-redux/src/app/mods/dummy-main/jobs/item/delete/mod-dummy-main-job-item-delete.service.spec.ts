import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobItemDeleteService} from './mod-dummy-main-job-item-delete.service';

describe('AppModDummyMainJobItemDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobItemDeleteService]
    });
  });

  it('should be created', inject([AppModDummyMainJobItemDeleteService], (service: AppModDummyMainJobItemDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
