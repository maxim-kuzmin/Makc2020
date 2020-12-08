import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobFilteredDeleteService} from './mod-dummy-main-job-filtered-delete.service';

describe('AppModDummyMainJobFilteredDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobFilteredDeleteService]
    });
  });

  it('should be created', inject([AppModDummyMainJobFilteredDeleteService], (service: AppModDummyMainJobFilteredDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
