// //Author Maxim Kuzmin//makc//

import {AppRootModule} from './root.module';

describe('AppRootModule', () => {
  let module: AppRootModule;

  beforeEach(() => {
    module = new AppRootModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
