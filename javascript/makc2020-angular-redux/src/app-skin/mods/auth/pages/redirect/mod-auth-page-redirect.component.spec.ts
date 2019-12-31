// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModAuthPageRedirectComponent} from './mod-auth-page-redirect.component';

describe('AppModAuthPageRedirectComponent', () => {
  let component: AppSkinModAuthPageRedirectComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageRedirectComponent>;

  beforeEach(async(() => {
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
