// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {appCoreLocalizationConfigLanguageRu} from '@app/core/localization/core-localization-config';
import {AppHostCalendarLocale} from './host-calendar-locale';
import {AppSkinHostCalendarStore} from './host-calendar-store';

/** Хост. Календарь. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinHostCalendarService {

  /** @type {AppHostCalendarLocale} */
  private lookupLocaleByLanguageKey = {
    [appCoreLocalizationConfigLanguageRu.key]: {
      firstDayOfWeek: 1,
      dayNames: ['Воскресенье', 'Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суббота'],
      dayNamesShort: ['Вос', 'Пон', 'Вто', 'Сре', 'Чет', 'Пят', 'Суб'],
      dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
      monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
      monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн', 'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
      today: 'Сегодня',
      clear: 'Сбросить',
      dateFormat: 'dd.mm.yy'
    } as AppHostCalendarLocale
  };

  /** Конструктор. */
  constructor(
    private appStore: AppSkinHostCalendarStore
  ) {
  }

  /** Выполнить действие "Очистка". */
  executeActionClear() {
    this.appStore.runActionClear();
  }

  /**
   * Выполнить действие "Загрузка".
   * @type {string} languageKey Ключ языка.
   */
  executeActionLoad(languageKey: string) {
    const locale = this.lookupLocaleByLanguageKey[languageKey]
      || this.lookupLocaleByLanguageKey[appCoreLocalizationConfigLanguageRu.key];

    this.appStore.runActionLoad(languageKey, locale);
  }
}
