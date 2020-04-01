import {inject, TestBed} from '@angular/core/testing';
import {AppModDummyTreeJobItemUpdateService} from './mod-dummy-tree-job-item-update.service';

describe('AppModDummyTreeJobItemUpdateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyTreeJobItemUpdateService]
    });
  });

  it('should be created', inject([AppModDummyTreeJobItemUpdateService], (service: AppModDummyTreeJobItemUpdateService) => {
    expect(service).toBeTruthy();
  }));
});
