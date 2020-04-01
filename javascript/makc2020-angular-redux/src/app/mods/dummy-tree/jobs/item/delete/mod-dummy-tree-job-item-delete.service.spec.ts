import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobItemDeleteService} from './mod-dummy-tree-job-item-delete.service';

describe('AppModDummyTreeJobItemDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobItemDeleteService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobItemDeleteService], (service: AppModDummyTreeJobItemDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
