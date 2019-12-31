// //Author Maxim Kuzmin//makc//

/** Хост. Календарь. Локаль. */
export interface AppHostCalendarLocale {
  firstDayOfWeek: number;
  dayNames: string[];
  dayNamesShort: string[];
  dayNamesMin: string[];
  monthNames: string[];
  monthNamesShort: string[];
  today: string;
  clear: string;
  dateFormat: string;
}
