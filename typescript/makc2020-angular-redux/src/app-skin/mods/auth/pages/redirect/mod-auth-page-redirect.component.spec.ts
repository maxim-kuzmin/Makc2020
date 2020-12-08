// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModAuthPageRedirectComponent} from './mod-auth-page-redirect.component';

describe('AppModAuthPageRedirectComponent', () => {
  let component: AppSkinModAuthPageRedirectComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageRedirectComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [AppSkinModAuthPageRedirectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModAuthPageRedirectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
