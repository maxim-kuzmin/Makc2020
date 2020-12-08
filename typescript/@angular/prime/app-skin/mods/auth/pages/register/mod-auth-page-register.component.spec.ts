// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModAuthPageRegisterComponent} from './mod-auth-page-register.component';

describe('AppSkinModAuthPageRegisterComponent', () => {
  let component: AppSkinModAuthPageRegisterComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageRegisterComponent>;

  beforeEach(async(() => {
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
