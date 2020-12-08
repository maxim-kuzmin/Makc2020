// //Author Maxim Kuzmin//makc//

import {SelectItem} from 'primeng/api';
import {AppHostLayoutHeaderView} from '@app/host/layout/header/host-layout-header-view';

/** Хост. Разметка. Шапка. Вид. */
export class AppSkinHostLayoutHeaderView extends AppHostLayoutHeaderView {

  /** @type {SelectItem[]} */
  languageOptions: SelectItem[];

  /** @inheritDoc */
  build() {
    this.languageOptions = this.languages.map(language => ({
      label: language.name,
      title: language.name,
      value: language.key
    } as SelectItem));
  }
}
