// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModDummyMainComponent} from './mod-dummy-main.component';

describe('AppSkinModDummyMainComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModDummyMainComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'DummyMain'`, waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('DummyMain');
  }));
  it('should render title in a h2 tag', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('DummyMain');
  }));
});
