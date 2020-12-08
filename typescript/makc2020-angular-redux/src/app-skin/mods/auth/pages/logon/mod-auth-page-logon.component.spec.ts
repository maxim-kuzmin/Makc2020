// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModAuthPageLogonComponent} from './mod-auth-page-logon.component';

describe('AppSkinModAuthPageLogonComponent', () => {
  let component: AppSkinModAuthPageLogonComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageLogonComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModAuthPageLogonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModAuthPageLogonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
