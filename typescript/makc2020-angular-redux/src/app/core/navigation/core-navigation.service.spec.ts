// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreNavigationService} from './core-navigation.service';

describe('AppCoreNavigationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreNavigationService]
    });
  });

  it('should be created', inject([AppCoreNavigationService], (service: AppCoreNavigationService) => {
    expect(service).toBeTruthy();
  }));
});
