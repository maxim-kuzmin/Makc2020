// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModDummyTreePageItemComponent} from './mod-dummy-tree-page-item.component';

describe('AppSkinModDummyTreePageItemComponent', () => {
  let component: AppSkinModDummyTreePageItemComponent;
  let fixture: ComponentFixture<AppSkinModDummyTreePageItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModDummyTreePageItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyTreePageItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
