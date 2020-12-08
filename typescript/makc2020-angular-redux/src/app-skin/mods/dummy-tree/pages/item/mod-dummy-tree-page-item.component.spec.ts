// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModDummyTreePageItemComponent} from './mod-dummy-tree-page-item.component';

describe('AppSkinModDummyTreePageItemComponent', () => {
  let component: AppSkinModDummyTreePageItemComponent;
  let fixture: ComponentFixture<AppSkinModDummyTreePageItemComponent>;

  beforeEach(waitForAsync(() => {
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
