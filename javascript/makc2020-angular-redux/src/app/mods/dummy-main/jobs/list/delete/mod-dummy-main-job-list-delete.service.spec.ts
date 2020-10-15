import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobListDeleteService} from './mod-dummy-main-job-list-delete.service';

describe('AppModDummyMainJobListDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobListDeleteService]
    });
  });

  it('should be created', inject([AppModDummyMainJobListDeleteService], (service: AppModDummyMainJobListDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
