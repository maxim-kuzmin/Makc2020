import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobItemInsertService} from './mod-dummy-tree-job-item-insert.service';

describe('AppModDummyTreeJobItemInsertService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobItemInsertService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobItemInsertService], (service: AppModDummyTreeJobItemInsertService) => {
    expect(service).toBeTruthy();
  }));
});
