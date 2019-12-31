import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyMainJobItemInsertService} from './mod-dummy-main-job-item-insert.service';

describe('AppModDummyMainJobItemInsertService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobItemInsertService]
    });
  });

  it('should be created', inject([AppModDummyMainJobItemInsertService], (service: AppModDummyMainJobItemInsertService) => {
    expect(service).toBeTruthy();
  }));
});
