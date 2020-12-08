// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinCoreDialogAlertComponent} from './core-dialog-alert.component';

describe('AppSkinCoreDialogAlertComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinCoreDialogAlertComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinCoreDialogAlertComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
