// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModDummyTreePageIndexComponent} from './mod-dummy-tree-page-index.component';

describe('AppModDummyTreePageIndexComponent', () => {
  let component: AppSkinModDummyTreePageIndexComponent;
  let fixture: ComponentFixture<AppSkinModDummyTreePageIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AppSkinModDummyTreePageIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyTreePageIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
