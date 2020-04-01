// //Author Maxim Kuzmin//makc//

import {AppModDummyTreeModule} from './mod-dummy-tree.module';

describe('AppModDummyTreeModule', () => {
  let module: AppModDummyTreeModule;

  beforeEach(() => {
    module = new AppModDummyTreeModule(null);
  });

  it('should create an instance', () => {
    expect(module).toBeTruthy();
  });
});
