// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppRootPartAuthJobRegisterService} from './root-part-auth-job-register.service';

describe('AppRootPartAuthJobRegisterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppRootPartAuthJobRegisterService]
    });
  });

  it('should be created', inject([AppRootPartAuthJobRegisterService], (service: AppRootPartAuthJobRegisterService) => {
    expect(service).toBeTruthy();
  }));
});
