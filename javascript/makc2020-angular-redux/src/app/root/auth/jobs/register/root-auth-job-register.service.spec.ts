// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppRootAuthJobRegisterService} from './root-auth-job-register.service';

describe('AppRootAuthJobRegisterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootAuthJobRegisterService]
    });
  });

  it('should be created', inject([AppRootAuthJobRegisterService], (service: AppRootAuthJobRegisterService) => {
    expect(service).toBeTruthy();
  }));
});
