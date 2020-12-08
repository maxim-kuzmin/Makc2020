import {inject, TestBed} from '@angular/core/testing';

import {AppModDummyTreeJobListDeleteService} from './mod-dummy-tree-job-list-delete.service';

describe('AppModDummyTreeJobListDeleteService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobListDeleteService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobListDeleteService], (service: AppModDummyTreeJobListDeleteService) => {
    expect(service).toBeTruthy();
  }));
});
