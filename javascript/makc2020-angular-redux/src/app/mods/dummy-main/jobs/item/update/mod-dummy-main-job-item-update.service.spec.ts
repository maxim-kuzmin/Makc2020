import {inject, TestBed} from '@angular/core/testing';
import {AppModDummyMainJobItemUpdateService} from './mod-dummy-main-job-item-update.service';

describe('AppModDummyMainJobItemUpdateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppModDummyMainJobItemUpdateService]
    });
  });

  it('should be created', inject([AppModDummyMainJobItemUpdateService], (service: AppModDummyMainJobItemUpdateService) => {
    expect(service).toBeTruthy();
  }));
});
