// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModAuthPageLogonComponent} from './mod-auth-page-logon.component';

describe('AppSkinModAuthPageLogonComponent', () => {
  let component: AppSkinModAuthPageLogonComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageLogonComponent>;

  beforeEach(async(() => {
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
