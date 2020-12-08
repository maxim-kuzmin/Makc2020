// //Author Maxim Kuzmin//makc//

import {Directionality} from '@angular/cdk/bidi';
import {
  Overlay,
  OverlayKeyboardDispatcher,
  OverlayOutsideClickDispatcher,
  OverlayPositionBuilder,
  ScrollStrategyOptions
} from '@angular/cdk/overlay';
import {DOCUMENT, Location} from '@angular/common';
import {ComponentFactoryResolver, Inject, Injectable, Injector, NgZone, Renderer2, RendererFactory2} from '@angular/core';
import {AppCoreOverlayContainer} from './core-overlay-container';

/** Ядро. Наложение. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreOverlayService extends Overlay {

  // tslint:disable-next-line:variable-name
  private readonly __scrollStrategies: ScrollStrategyOptions;
  // tslint:disable-next-line:variable-name
  private readonly __overlayContainer: AppCoreOverlayContainer;
  // tslint:disable-next-line:variable-name
  private readonly __componentFactoryResolver: ComponentFactoryResolver;
  // tslint:disable-next-line:variable-name
  private readonly __positionBuilder: OverlayPositionBuilder;
  // tslint:disable-next-line:variable-name
  private readonly __keyboardDispatcher: OverlayKeyboardDispatcher;
  // tslint:disable-next-line:variable-name
  private readonly __injector: Injector;
  // tslint:disable-next-line:variable-name
  private readonly __ngZone: NgZone;
  // tslint:disable-next-line:variable-name
  private readonly __document: any;
  // tslint:disable-next-line:variable-name
  private readonly __directionality: Directionality;
// tslint:disable-next-line:variable-name
  private __location: Location;
  // tslint:disable-next-line:variable-name
  private __outsideClickDispatcher: OverlayOutsideClickDispatcher;

  private renderer: Renderer2;

  constructor(
    scrollStrategies: ScrollStrategyOptions,
    // tslint:disable-next-line:variable-name
    _overlayContainer: AppCoreOverlayContainer,
    // tslint:disable-next-line:variable-name
    _componentFactoryResolver: ComponentFactoryResolver,
    // tslint:disable-next-line:variable-name
    _positionBuilder: OverlayPositionBuilder,
    // tslint:disable-next-line:variable-name
    _keyboardDispatcher: OverlayKeyboardDispatcher,
    // tslint:disable-next-line:variable-name
    _injector: Injector,
    // tslint:disable-next-line:variable-name
    _ngZone: NgZone,
    // tslint:disable-next-line:variable-name
    @Inject(DOCUMENT) _document: any,
    // tslint:disable-next-line:variable-name
    _directionality: Directionality,
    // tslint:disable-next-line:variable-name
    _location: Location,
    // tslint:disable-next-line:variable-name
    _outsideClickDispatcher: OverlayOutsideClickDispatcher,
    // tslint:disable-next-line:variable-name
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
      _directionality,
      _location,
      _outsideClickDispatcher
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
    this.__location = _location;
    this.__outsideClickDispatcher = _outsideClickDispatcher;

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
      this.__directionality,
      this.__location,
      this.__outsideClickDispatcher
    );
  }
}
