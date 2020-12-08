// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {appCoreLocalizationConfigLanguageRu} from '@app/core/localization/core-localization-config';
import {AppHostPartCalendarLocale} from './host-part-calendar-locale';
import {AppSkinHostPartCalendarStore} from './host-part-calendar-store';

/** Хост. Часть "Calendar". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppSkinHostPartCalendarService {

  /** @type {AppHostPartCalendarLocale} */
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
    } as AppHostPartCalendarLocale
  };

  /** Конструктор. */
  constructor(
    private appStore: AppSkinHostPartCalendarStore
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
