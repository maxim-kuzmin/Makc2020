// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinModDummyMainComponent} from './mod-dummy-main.component';

describe('AppSkinModDummyMainComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModDummyMainComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'DummyMain'`, async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('DummyMain');
  }));
  it('should render title in a h2 tag', async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyMainComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('DummyMain');
  }));
});
