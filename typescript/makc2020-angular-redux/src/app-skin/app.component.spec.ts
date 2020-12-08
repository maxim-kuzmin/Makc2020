// //Author Maxim Kuzmin//makc//

import { TestBed, waitForAsync } from '@angular/core/testing';
import {AppSkinComponent} from './app.component';

describe('AppSkinComponent', () => {
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppSkinComponent
      ],
    }).compileComponents();
  }));
  it('should create the app', waitForAsync(() => {
    const fixture = TestBed.createComponent(AppSkinComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
/*
  it(`should have as title 'ClientApp'`, async(() => {
    const fixture = TestBed.createComponent(AppSkinComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('ClientApp');
  }));
  it('should render title in a h1 tag', async(() => {
    const fixture = TestBed.createComponent(AppSkinComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Welcome to ClientApp!');
  }));
*/
});
