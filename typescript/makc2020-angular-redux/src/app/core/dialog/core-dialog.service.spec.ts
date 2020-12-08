// //Author Maxim Kuzmin//makc//

import {inject, TestBed} from '@angular/core/testing';
import {AppCoreDialogService} from './core-dialog.service';

describe('AppCoreDialogService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppCoreDialogService]
    });
  });

  it('should be created', inject([AppCoreDialogService], (service: AppCoreDialogService) => {
    expect(service).toBeTruthy();
  }));
});
