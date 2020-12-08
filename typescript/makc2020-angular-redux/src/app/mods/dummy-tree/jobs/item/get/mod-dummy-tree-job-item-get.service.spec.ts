import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobItemGetService} from './mod-dummy-tree-job-item-get.service';

describe('AppModDummyTreeJobItemGetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobItemGetService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobItemGetService], (service: AppModDummyTreeJobItemGetService) => {
    expect(service).toBeTruthy();
  }));
});
