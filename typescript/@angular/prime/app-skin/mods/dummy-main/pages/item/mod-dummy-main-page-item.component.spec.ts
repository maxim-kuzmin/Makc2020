// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModDummyMainPageItemComponent} from './mod-dummy-main-page-item.component';

describe('AppSkinModDummyMainPageItemComponent', () => {
  let component: AppSkinModDummyMainPageItemComponent;
  let fixture: ComponentFixture<AppSkinModDummyMainPageItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModDummyMainPageItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyMainPageItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
