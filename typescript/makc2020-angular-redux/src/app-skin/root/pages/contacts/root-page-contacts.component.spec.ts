// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinRootPageContactsComponent} from './root-page-contacts.component';

describe('AppSkinRootPageContactsComponent', () => {
  let component: AppSkinRootPageContactsComponent;
  let fixture: ComponentFixture<AppSkinRootPageContactsComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinRootPageContactsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinRootPageContactsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
