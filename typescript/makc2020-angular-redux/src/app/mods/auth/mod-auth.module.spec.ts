// //Author Maxim Kuzmin//makc//

import {AppModAuthModule} from './mod-auth.module';

describe('AppModAuthModule', () => {
  let module: AppModAuthModule;

  beforeEach(() => {
    module = new AppModAuthModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
