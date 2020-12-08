import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobListGetService} from './mod-dummy-tree-job-list-get.service';

describe('AppModDummyTreeJobListGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobListGetService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobListGetService], (service: AppModDummyTreeJobListGetService) => {
    expect(service).toBeTruthy();
  }));
});
