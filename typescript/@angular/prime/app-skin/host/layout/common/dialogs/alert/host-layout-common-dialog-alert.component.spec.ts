// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinHostLayoutCommonDialogAlertComponent} from './host-layout-common-dialog-alert.component';

describe('AppSkinHostLayoutCommonDialogAlertComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinHostLayoutCommonDialogAlertComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinHostLayoutCommonDialogAlertComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
