// //Author Maxim Kuzmin//makc//

import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {AppSkinHostLayoutMenuComponent} from './host-layout-menu.component';

describe('AppSkinHostLayoutMenuComponent', () => {
  let component: AppSkinHostLayoutMenuComponent;
  let fixture: ComponentFixture<AppSkinHostLayoutMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSkinHostLayoutMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSkinHostLayoutMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
