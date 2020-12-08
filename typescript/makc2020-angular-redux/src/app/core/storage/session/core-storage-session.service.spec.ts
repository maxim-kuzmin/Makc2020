// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreStorageSessionService} from './core-storage-session.service';

describe('AppCoreStorageSessionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreStorageSessionService]
    });
  });

  it('should be created', inject([AppCoreStorageSessionService], (service: AppCoreStorageSessionService) => {
    expect(service).toBeTruthy();
  }));
});
