// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinModDummyMainPageListComponent} from './mod-dummy-main-page-list.component';

describe('AppSkinModDummyMainPageListComponent', () => {
  let component: AppSkinModDummyMainPageListComponent;
  let fixture: ComponentFixture<AppSkinModDummyMainPageListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinModDummyMainPageListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinModDummyMainPageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
