// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModDummyTreeComponent} from './mod-dummy-tree.component';

describe('AppSkinModDummyTreeComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModDummyTreeComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'DummyTree'`, waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('DummyTree');
  }));
  it('should render title in a h2 tag', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('DummyTree');
  }));
});
