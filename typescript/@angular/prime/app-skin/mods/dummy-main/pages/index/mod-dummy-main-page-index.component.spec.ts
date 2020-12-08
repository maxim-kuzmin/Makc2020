// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModDummyMainPageIndexComponent} from './mod-dummy-main-page-index.component';

describe('AppModDummyMainPageIndexComponent', () => {
  let component: AppSkinModDummyMainPageIndexComponent;
  let fixture: ComponentFixture<AppSkinModDummyMainPageIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AppSkinModDummyMainPageIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyMainPageIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
