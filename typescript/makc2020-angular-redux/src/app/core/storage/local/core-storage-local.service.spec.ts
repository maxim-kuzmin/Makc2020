// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreStorageLocalService} from './core-storage-local.service';

describe('AppCoreStorageLocalService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreStorageLocalService]
    });
  });

  it('should be created', inject([AppCoreStorageLocalService], (service: AppCoreStorageLocalService) => {
    expect(service).toBeTruthy();
  }));
});
