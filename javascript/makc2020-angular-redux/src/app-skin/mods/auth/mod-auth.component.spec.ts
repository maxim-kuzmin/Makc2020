// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModAuthComponent} from './mod-auth.component';

describe('AppSkinModAuthComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModAuthComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModAuthComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'Auth'`, waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModAuthComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('Auth');
  }));
  it('should render title in a h2 tag', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModAuthComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Auth');
  }));
});
