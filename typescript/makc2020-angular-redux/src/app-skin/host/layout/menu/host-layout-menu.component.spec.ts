// //Author Maxim Kuzmin//makc//

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinHostLayoutMenuComponent} from './host-layout-menu.component';

describe('AppSkinHostLayoutMenuComponent', () => {
  let component: AppSkinHostLayoutMenuComponent;
  let fixture: ComponentFixture<AppSkinHostLayoutMenuComponent>;

  beforeEach(waitForAsync(() => {
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
