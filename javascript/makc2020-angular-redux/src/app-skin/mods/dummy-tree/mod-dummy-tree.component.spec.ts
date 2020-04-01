// //Author Maxim Kuzmin//makc//

import {async, TestBed} from '@angular/core/testing';
import {AppSkinModDummyTreeComponent} from './mod-dummy-tree.component';

describe('AppSkinModDummyTreeComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinModDummyTreeComponent
      ],
    }).compileComponents();
  }));
  it('should create the component', async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component).toBeTruthy();
  }));
  it(`should have as title 'DummyTree'`, async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    const component = fixture.debugElement.componentInstance;
    expect(component.model.title).toEqual('DummyTree');
  }));
  it('should render title in a h2 tag', async(() => {
    const fixture = TestBed.createComponent(AppSkinModDummyTreeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('DummyTree');
  }));
});
