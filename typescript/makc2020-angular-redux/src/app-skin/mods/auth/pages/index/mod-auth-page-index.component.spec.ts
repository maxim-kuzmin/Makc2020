// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinModAuthPageIndexComponent} from './mod-auth-page-index.component';

describe('AppModAuthPageIndexComponent', () => {
  let component: AppSkinModAuthPageIndexComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageIndexComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [AppSkinModAuthPageIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModAuthPageIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
