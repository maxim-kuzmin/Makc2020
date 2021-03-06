// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModDummyTreePageListComponent} from './mod-dummy-tree-page-list.component';

describe('AppSkinModDummyTreePageListComponent', () => {
  let component: AppSkinModDummyTreePageListComponent;
  let fixture: ComponentFixture<AppSkinModDummyTreePageListComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModDummyTreePageListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyTreePageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
