// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinCoreSpinnerComponent} from './core-spinner.component';

describe('AppSkinCoreSpinnerComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinCoreSpinnerComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinCoreSpinnerComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
