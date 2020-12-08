// //Author Maxim Kuzmin//makc//

import {AppDataModule} from './data.module';

describe('AppDataModule', () => {
  let module: AppDataModule;

  beforeEach(() => {
    module = new AppDataModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
