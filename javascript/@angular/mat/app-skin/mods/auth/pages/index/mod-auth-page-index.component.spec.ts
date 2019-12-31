// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModAuthPageIndexComponent} from './mod-auth-page-index.component';

describe('AppModAuthPageIndexComponent', () => {
  let component: AppSkinModAuthPageIndexComponent;
  let fixture: ComponentFixture<AppSkinModAuthPageIndexComponent>;

  beforeEach(async(() => {
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
