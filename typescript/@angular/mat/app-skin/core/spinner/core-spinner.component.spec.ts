// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinCoreSpinnerComponent} from './core-spinner.component';

describe('AppSkinCoreSpinnerComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinCoreSpinnerComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinCoreSpinnerComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
});
