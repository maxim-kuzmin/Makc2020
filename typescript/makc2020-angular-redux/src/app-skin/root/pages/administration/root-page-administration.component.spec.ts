// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinRootPageAdministrationComponent} from './root-page-administration.component';

describe('AppSkinRootPageAdministrationComponent', () => {
  let component: AppSkinRootPageAdministrationComponent;
  let fixture: ComponentFixture<AppSkinRootPageAdministrationComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinRootPageAdministrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinRootPageAdministrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
