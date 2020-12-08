// //Author Maxim Kuzmin//makc//

import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppHostControlValidationMessageSettingTexts} from '../settings/host-control-validation-message-setting-texts';

/** Хост. Элементы управления. Валидация. Сообщение. Ресурсы. Тексты */
export class AppHostControlValidationMessageResourceTexts {

  /**
   * Текст об обязательности выбора чекбокса.
   * @type {string}
   */
  textCheckBox = '';

  /**
   * Текст о некорректном адресе электронной почты.
   * @type {string}
   */
  textEmail = '';

  /**
   * Текст о нарушении требования минимальной длины.
   * @type {string}
   */
  textMinLength = '';

  /**
   * Текст о нарушении требования обязательности.
   * @type {string}
   */
  textRequired = '';

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostControlValidationMessageSettingTexts} settingTexts Настройка текстов.
   * @param {Subject<boolean>} unsubscribe$ Отказ от подписки.
   */
  constructor(
    appLocalizer: AppCoreLocalizationService,
    settingTexts: AppHostControlValidationMessageSettingTexts,
    unsubscribe$: Subject<boolean>
  ) {
    const {
      textCheckBoxResourceKey,
      textEmailResourceKey,
      textMinLengthResourceKey,
      textRequiredResourceKey
    } = settingTexts;

    appLocalizer.createTranslator(
      textCheckBoxResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.textCheckBox = s;
    });

    appLocalizer.createTranslator(
      textEmailResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.textEmail = s;
    });

    appLocalizer.createTranslator(
      textMinLengthResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.textMinLength = s;
    });

    appLocalizer.createTranslator(
      textRequiredResourceKey
    ).translate$().pipe(takeUntil(unsubscribe$)).subscribe(s => {
      this.textRequired = s;
    });
  }
}
