// //Author Maxim Kuzmin//makc//

import {Observable} from 'rxjs';
import {AppCoreCommonUnsubscribable} from '@app/core/common/core-common-unsubscribable';
import {AppHostLayoutFooterState} from './host-layout-footer-state';
import {AppHostLayoutFooterStore} from './host-layout-footer-store';
import {AppCoreLocalizationStore} from '@app/core/localization/core-localization-store';
import {AppCoreLocalizationState} from '@app/core/localization/core-localization-state';
import {AppHostLayoutFooterJobContentLoadInput} from '@app/host/layout/footer/jobs/content/load/host-layout-footer-job-content-load-input';
import { Injectable } from "@angular/core";

/** Хост. Разметка. Подвал. Модель. */
@Injectable()
export class AppHostLayoutFooterModel extends AppCoreCommonUnsubscribable {

  /**
   * Конструктор.
   * @param {AppCoreLocalizationStore} appLocalizerStore Хранилище состояния локализатора.
   * @param {AppHostLayoutFooterStore} appStore Хранилище состояния.
   */
  constructor(
    private appLocalizerStore: AppCoreLocalizationStore,
    private appStore: AppHostLayoutFooterStore
  ) {
    super();

    this.onGetLocalizerState = this.onGetLocalizerState.bind(this);
  }

  /**
   * Получить состояние.
   * @returns {AppHostLayoutFooterState} Состояние.
   */
  getState(): AppHostLayoutFooterState {
    return this.appStore.getState();
  }

  /**
   * Получить поток состояния.
   * @returns {Observable<AppHostLayoutFooterState>} Поток состояния.
   */
  getState$(): Observable<AppHostLayoutFooterState> {
    return this.appStore.getState$(this.unsubscribe$);
  }

  /** Обработчик события после инициализации вида. */
  onAfterViewInit() {
    this.appLocalizerStore.getState$(
      this.unsubscribe$
    ).subscribe(
      this.onGetLocalizerState
    );
  }

  /** @inheritDoc */
  onDestroy() {
    super.onDestroy();

    this.appStore.runActionClear();
  }

  private onGetLocalizerState(localizerState: AppCoreLocalizationState) {
    this.appStore.runActionLoad(
      new AppHostLayoutFooterJobContentLoadInput(localizerState.languageKey)
    );
  }
}
