// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreExecutionService} from './core-execution.service';

describe('AppCoreExecutionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreExecutionService]
    });
  });

  it('should be created', inject([AppCoreExecutionService], (service: AppCoreExecutionService) => {
    expect(service).toBeTruthy();
  }));
});
