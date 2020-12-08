// //Author Maxim Kuzmin//makc//

import {AppModDummyMainModule} from './mod-dummy-main.module';

describe('AppModDummyMainModule', () => {
  let module: AppModDummyMainModule;

  beforeEach(() => {
    module = new AppModDummyMainModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
