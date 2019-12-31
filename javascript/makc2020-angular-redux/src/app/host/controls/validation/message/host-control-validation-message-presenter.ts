// //Author Maxim Kuzmin//makc//

import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppHostControlValidationMessageView} from './host-control-validation-message-view';
import {AppHostControlValidationMessageResources} from './host-control-validation-message-resources';
import {AppHostControlValidationMessageSettings} from './host-control-validation-message-settings';

/** Хост. Элементы управления. Валидация. Сообщение. Представитель. */
export class AppHostControlValidationMessagePresenter extends AppCoreCommonUnsubscribable {

  /**
   * Ресурсы.
   * @type {AppHostControlValidationMessageResources}
   */
  resources: AppHostControlValidationMessageResources;

  // TODO: валидация праймовского чекбокса
  /**
   * Признак видимости сообщения о нарушении требования обязательности выбора чекбокса.
   * @type {boolean}
   */
  get messageCheckBoxIsVisible(): boolean {
    return false;
    // if (this.view.requiredTrue && (!this.view.control.model || !this.view.control.value)) {
    //   this.view.control.control.setErrors({'incorrect': true});
    //   return true;
    // } else {
    //   return false;
    // }
  }

  /**
   * Текст сообщения о нарушении требования обязательности выбора чекбокса.
   * @type {string}
   */
  get messageCheckBoxText(): string {
    return this.resources.texts.textCheckBox;
  }

  /**
   * Признак видимости сообщения о некорректности адреса электронной почты.
   * @type {boolean}
   */
  get messageEmailIsVisible(): boolean {
    return this.view.hasError('email');
  }

  /**
   * Текст сообщения о некорректности адреса электронной почты.
   * @type {string}
   */
  get messageEmailText(): string {
    return this.resources.texts.textEmail;
  }

  /**
   * Признак видимости сообщения о нарушении требования минимальной длины.
   * @type {boolean}
   */
  get messageMinLengthIsVisible(): boolean {
    return this.view.hasError('minlength');
  }

  /**
   * Текст сообщения о нарушении требования минимальной длины.
   * @type {string}
   */
  get messageMinLengthText(): string {
    return this.resources.texts.textMinLength.replace(
      new RegExp('{{label}}', 'g'),
      this.view.label
    ).replace(
      new RegExp('{{number}}', 'g'),
      this.view.minLength.toString()
    );
  }

  /**
   * Признак видимости сообщения о несоответствии паттерну.
   * @type {boolean}
   */
  get messagePatternIsVisible(): boolean {
    return this.view.hasError('pattern');
  }

  /**
   * Текст сообщения о несоответствии паттерну.
   * @type {string}
   */
  get messagePatternText(): string {
    return this.view.messagePatternText;
  }

  /**
   * Признак видимости сообщения о нарушении требования обязательности.
   * @type {boolean}
   */
  get messageRequiredIsVisible(): boolean {
    return this.view.hasError('required');
  }

  /**
   * Текст сообщения о нарушении требования обязательности.
   * @type {string}
   */
  get messageRequiredText(): string {
    return this.resources.texts.textRequired.replace(
      new RegExp('{{label}}', 'g'),
      this.view.label
    );
  }

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   * @param {AppHostControlValidationMessageView} view Вид.
   */
  constructor(
    protected appLocalizer: AppCoreLocalizationService,
    private view: AppHostControlValidationMessageView
  ) {
    super();

    this.resources = new AppHostControlValidationMessageResources(
      this.appLocalizer,
      new AppHostControlValidationMessageSettings(),
      this.unsubscribe$
    );
  }
}
