// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinCoreDialogAlertComponent} from './core-dialog-alert.component';

describe('AppSkinCoreDialogAlertComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinCoreDialogAlertComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinCoreDialogAlertComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
