import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobFilteredDeleteService} from './mod-dummy-tree-job-filtered-delete.service';

describe('AppModDummyTreeJobFilteredDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobFilteredDeleteService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobFilteredDeleteService], (service: AppModDummyTreeJobFilteredDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
