// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModAuthPageRegisterComponent} from './mod-auth-page-register.component';

describe('AppSkinModAuthPageRegisterComponent', () => {
  let component: AppSkinModAuthPageRegisterComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageRegisterComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModAuthPageRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModAuthPageRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
