// //Author Maxim Kuzmin//makc//

import {Directionality} from '@angular/cdk/bidi';
import {Overlay, OverlayKeyboardDispatcher, OverlayPositionBuilder, ScrollStrategyOptions} from '@angular/cdk/overlay';
import {DOCUMENT} from '@angular/common';
import {ComponentFactoryResolver, Inject, Injectable, Injector, NgZone, Renderer2, RendererFactory2} from '@angular/core';
import {AppCoreOverlayContainer} from './core-overlay-container';

/** Ядро. Наложение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreOverlayService extends Overlay {

  private readonly __scrollStrategies: ScrollStrategyOptions;
  private readonly __overlayContainer: AppCoreOverlayContainer;
  private readonly __componentFactoryResolver: ComponentFactoryResolver;
  private readonly __positionBuilder: OverlayPositionBuilder;
  private readonly __keyboardDispatcher: OverlayKeyboardDispatcher;
  private readonly __injector: Injector;
  private readonly __ngZone: NgZone;
  private readonly __document: any;
  private readonly __directionality: Directionality;

  private renderer: Renderer2;

  constructor(
    scrollStrategies: ScrollStrategyOptions,
    _overlayContainer: AppCoreOverlayContainer,
    _componentFactoryResolver: ComponentFactoryResolver,
    _positionBuilder: OverlayPositionBuilder,
    _keyboardDispatcher: OverlayKeyboardDispatcher,
    _injector: Injector,
    _ngZone: NgZone,
    @Inject(DOCUMENT) _document: any,
    _directionality: Directionality,
    rendererFactory: RendererFactory2
  ) {
    super(
      scrollStrategies,
      _overlayContainer,
      _componentFactoryResolver,
      _positionBuilder,
      _keyboardDispatcher,
      _injector,
      _ngZone,
      _document,
      _directionality
    );

    this.__scrollStrategies = scrollStrategies;
    this.__overlayContainer = _overlayContainer;
    this.__componentFactoryResolver = _componentFactoryResolver;
    this.__positionBuilder = _positionBuilder;
    this.__keyboardDispatcher = _keyboardDispatcher;
    this.__injector = _injector;
    this.__ngZone = _ngZone;
    this.__document = _document;
    this.__directionality = _directionality;

    this.renderer = rendererFactory.createRenderer(null, null);
  }

  /**
   * Клонировать для элемента.
   * @param {HTMLElement} containerElement HTML-элемент контейнера.
   * @returns {Overlay} Наложение.
   */
  public cloneForElement(containerElement: HTMLElement): Overlay {
    const overlayContainer = this.__overlayContainer.cloneForElement(containerElement);

    this.renderer.setStyle(containerElement, 'transform', 'translateZ(0)');

    return new Overlay(
      this.__scrollStrategies,
      overlayContainer,
      this.__componentFactoryResolver,
      this.__positionBuilder,
      this.__keyboardDispatcher,
      this.__injector,
      this.__ngZone,
      this.__document,
      this.__directionality
    );
  }
}
