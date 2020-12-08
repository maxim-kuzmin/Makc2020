// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinCoreProgressSpinnerComponent} from './core-progress-spinner.component';

describe('AppSkinCoreProgressSpinnerComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinCoreProgressSpinnerComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinCoreProgressSpinnerComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
