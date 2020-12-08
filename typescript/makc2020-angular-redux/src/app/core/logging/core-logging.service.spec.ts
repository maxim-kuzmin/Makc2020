// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreLoggingService} from './core-logging.service';

describe('AppCoreLoggingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreLoggingService]
    });
  });

  it('should be created', inject([AppCoreLoggingService], (service: AppCoreLoggingService) => {
    expect(service).toBeTruthy();
  }));
});
