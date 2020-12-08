// //Author Maxim Kuzmin//makc//

import {BehaviorSubject, Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppSettings} from './app-settings';
import {AppCoreLocalizationService} from './core/localization/core-localization.service';

/** Приложение. Ресурсы. */
export class AppResources {

  /**
   * Заголовок.
   * @type {string}
   */
  title = '';

  /**
   * Событие, возникающее после перевода заголовка.
   * @type {BehaviorSubject<string>}
   */
  titleTranslated$ = new BehaviorSubject<string>('');

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppSettings} settings Настройки.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settings: AppSettings,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      titleResourceKey
    } = settings;

    appLocalizer.createTranslator(
      titleResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.title = s;
      this.titleTranslated$.next(this.title);
    });
  }
}
