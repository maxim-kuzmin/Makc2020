// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreTitleService} from './core-title.service';

describe('AppCoreTitleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreTitleService]
    });
  });

  it('should be created', inject([AppCoreTitleService], (service: AppCoreTitleService) => {
    expect(service).toBeTruthy();
  }));
});
