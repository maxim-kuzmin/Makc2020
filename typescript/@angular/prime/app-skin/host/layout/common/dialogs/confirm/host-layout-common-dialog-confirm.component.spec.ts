// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinHostLayoutCommonDialogConfirmComponent} from './host-layout-common-dialog-confirm.component';

describe('AppSkinHostLayoutCommonDialogConfirmComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinHostLayoutCommonDialogConfirmComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinHostLayoutCommonDialogConfirmComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
