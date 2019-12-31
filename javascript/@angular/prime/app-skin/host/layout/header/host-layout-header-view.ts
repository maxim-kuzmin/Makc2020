// //Author Maxim Kuzmin//makc//

import {AppHostLayoutHeaderView} from '@app/host/layout/header/host-layout-header-view';
import {SelectItem} from 'primeng/api';

/** Хост. Разметка. Шапка. Вид. */
export class AppSkinHostLayoutHeaderView extends AppHostLayoutHeaderView {

  /** @type {SelectItem[]} */
  languageOptions: SelectItem[];

  /** @inheritDoc */
  build() {
    this.languageOptions = this.languages.map(language => <SelectItem>{
      label: language.name,
      title: language.name,
      value: language.key
    });
  }
}
