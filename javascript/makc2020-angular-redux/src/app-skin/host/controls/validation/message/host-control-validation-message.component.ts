// //Author Maxim Kuzmin//makc//

import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {AbstractControl} from '@angular/forms';
import {AppCoreLocalizationService} from '@app/core/localization/core-localization.service';
import {AppHostControlValidationMessageView} from '@app/host/controls/validation/message/host-control-validation-message-view';
import {AppHostControlValidationMessagePresenter} from '@app/host/controls/validation/message/host-control-validation-message-presenter';
import {AppSkinHostControlValidationMessageView} from './host-control-validation-message-view';

/** Хост. Элементы управления. Валидация. Сообщение. Компонент. */
@Component({
  selector: 'app-skin-host-control-validation-message',
  templateUrl: './host-control-validation-message.component.html',
  styleUrls: ['./host-control-validation-message.component.css']
})
export class AppSkinHostControlValidationMessageComponent implements OnDestroy, OnInit {

  @Input() control: AbstractControl;
  @Input() label: string;
  @Input() messagePatternText: string;
  @Input() offsetRight: boolean;
  @Input() requiredTrue = false;

  /**
   * Мой представитель.
   * @type {AppHostControlValidationMessagePresenter}
   */
  myPresenter: AppHostControlValidationMessagePresenter;

  /**
   * Мой вид.
   * @type {AppHostControlValidationMessageView}
   */
  myView: AppSkinHostControlValidationMessageView;

  /**
   * Конструктор.
   * @param {AppCoreLocalizationService} appLocalizer Локализатор.
   */
  constructor(
    private appLocalizer: AppCoreLocalizationService
  ) {
  }

  /** @inheritDoc */
  ngOnDestroy() {
    this.myPresenter.onDestroy();
  }

  /** @inheritDoc */
  ngOnInit() {
    this.myView = new AppSkinHostControlValidationMessageView(
      this.control,
      this.label,
      this.messagePatternText,
      this.offsetRight,
      this.requiredTrue
    );

    this.myPresenter = new AppHostControlValidationMessagePresenter(
      this.appLocalizer,
      this.myView
    );
  }
}
