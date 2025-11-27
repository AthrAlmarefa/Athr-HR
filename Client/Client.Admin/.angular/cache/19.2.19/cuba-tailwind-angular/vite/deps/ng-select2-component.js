import {
  CdkConnectedOverlay,
  CdkOverlayOrigin,
  OverlayModule
} from "./chunk-I4BS4PAX.js";
import {
  FormGroupDirective,
  FormsModule,
  NgControl,
  NgForm,
  ReactiveFormsModule
} from "./chunk-B3VFGSVT.js";
import "./chunk-ZYG2YSQK.js";
import "./chunk-JHR6EEFH.js";
import {
  ViewportRuler
} from "./chunk-2ASWJUAD.js";
import "./chunk-YH3DE3VK.js";
import {
  CommonModule,
  NgForOf,
  NgIf,
  NgTemplateOutlet
} from "./chunk-KKKUIQ6R.js";
import "./chunk-XLJ7AJ6Q.js";
import {
  Attribute,
  ChangeDetectorRef,
  Component,
  Directive,
  ElementRef,
  EventEmitter,
  HostBinding,
  Injectable,
  Input,
  NgModule,
  NgZone,
  Optional,
  Output,
  Self,
  TemplateRef,
  ViewChild,
  ViewChildren,
  setClassMetadata,
  ɵɵNgOnChangesFeature,
  ɵɵadvance,
  ɵɵattribute,
  ɵɵclassMap,
  ɵɵclassProp,
  ɵɵdefineComponent,
  ɵɵdefineDirective,
  ɵɵdefineInjectable,
  ɵɵdefineInjector,
  ɵɵdefineNgModule,
  ɵɵdirectiveInject,
  ɵɵelement,
  ɵɵelementContainer,
  ɵɵelementContainerEnd,
  ɵɵelementContainerStart,
  ɵɵelementEnd,
  ɵɵelementStart,
  ɵɵgetCurrentView,
  ɵɵhostProperty,
  ɵɵinjectAttribute,
  ɵɵlistener,
  ɵɵloadQuery,
  ɵɵnextContext,
  ɵɵprojection,
  ɵɵprojectionDef,
  ɵɵproperty,
  ɵɵqueryRefresh,
  ɵɵreference,
  ɵɵresetView,
  ɵɵrestoreView,
  ɵɵsanitizeHtml,
  ɵɵstyleProp,
  ɵɵtemplate,
  ɵɵtemplateRefExtractor,
  ɵɵtext,
  ɵɵtextInterpolate,
  ɵɵviewQuery
} from "./chunk-72K37ONP.js";
import {
  fromEvent
} from "./chunk-7J22WABE.js";
import "./chunk-5PA5UEDQ.js";
import {
  Subject,
  filter,
  map,
  mergeMap,
  of,
  tap,
  throttleTime
} from "./chunk-ETBEKOXV.js";
import "./chunk-55JZBEKM.js";
import {
  __spreadProps,
  __spreadValues
} from "./chunk-TXDUYLVM.js";

// node_modules/ng-select2-component/node_modules/ngx-infinite-scroll/fesm2020/ngx-infinite-scroll.mjs
var NgxInfiniteScrollService = class {
  constructor() {
  }
};
NgxInfiniteScrollService.ɵfac = function NgxInfiniteScrollService_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || NgxInfiniteScrollService)();
};
NgxInfiniteScrollService.ɵprov = ɵɵdefineInjectable({
  token: NgxInfiniteScrollService,
  factory: NgxInfiniteScrollService.ɵfac,
  providedIn: "root"
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(NgxInfiniteScrollService, [{
    type: Injectable,
    args: [{
      providedIn: "root"
    }]
  }], function() {
    return [];
  }, null);
})();
function resolveContainerElement(selector, scrollWindow, defaultElement, fromRoot) {
  const hasWindow = window && !!window.document && window.document.documentElement;
  let container = hasWindow && scrollWindow ? window : defaultElement;
  if (selector) {
    const containerIsString = selector && hasWindow && typeof selector === "string";
    container = containerIsString ? findElement(selector, defaultElement.nativeElement, fromRoot) : selector;
    if (!container) {
      throw new Error("ngx-infinite-scroll {resolveContainerElement()}: selector for");
    }
  }
  return container;
}
function findElement(selector, customRoot, fromRoot) {
  const rootEl = fromRoot ? window.document : customRoot;
  return rootEl.querySelector(selector);
}
function inputPropChanged(prop) {
  return prop && !prop.firstChange;
}
function hasWindowDefined() {
  return typeof window !== "undefined";
}
var VerticalProps = {
  clientHeight: "clientHeight",
  offsetHeight: "offsetHeight",
  scrollHeight: "scrollHeight",
  pageYOffset: "pageYOffset",
  offsetTop: "offsetTop",
  scrollTop: "scrollTop",
  top: "top"
};
var HorizontalProps = {
  clientHeight: "clientWidth",
  offsetHeight: "offsetWidth",
  scrollHeight: "scrollWidth",
  pageYOffset: "pageXOffset",
  offsetTop: "offsetLeft",
  scrollTop: "scrollLeft",
  top: "left"
};
var AxisResolver = class {
  constructor(vertical = true) {
    this.vertical = vertical;
    this.propsMap = vertical ? VerticalProps : HorizontalProps;
  }
  clientHeightKey() {
    return this.propsMap.clientHeight;
  }
  offsetHeightKey() {
    return this.propsMap.offsetHeight;
  }
  scrollHeightKey() {
    return this.propsMap.scrollHeight;
  }
  pageYOffsetKey() {
    return this.propsMap.pageYOffset;
  }
  offsetTopKey() {
    return this.propsMap.offsetTop;
  }
  scrollTopKey() {
    return this.propsMap.scrollTop;
  }
  topKey() {
    return this.propsMap.top;
  }
};
function shouldTriggerEvents(alwaysCallback, shouldFireScrollEvent2, isTriggeredCurrentTotal) {
  if (alwaysCallback && shouldFireScrollEvent2) {
    return true;
  }
  if (!isTriggeredCurrentTotal && shouldFireScrollEvent2) {
    return true;
  }
  return false;
}
function createResolver({
  windowElement,
  axis
}) {
  return createResolverWithContainer({
    axis,
    isWindow: isElementWindow(windowElement)
  }, windowElement);
}
function createResolverWithContainer(resolver, windowElement) {
  const container = resolver.isWindow || windowElement && !windowElement.nativeElement ? windowElement : windowElement.nativeElement;
  return __spreadProps(__spreadValues({}, resolver), {
    container
  });
}
function isElementWindow(windowElement) {
  const isWindow = ["Window", "global"].some((obj) => Object.prototype.toString.call(windowElement).includes(obj));
  return isWindow;
}
function getDocumentElement(isContainerWindow, windowElement) {
  return isContainerWindow ? windowElement.document.documentElement : null;
}
function calculatePoints(element, resolver) {
  const height = extractHeightForElement(resolver);
  return resolver.isWindow ? calculatePointsForWindow(height, element, resolver) : calculatePointsForElement(height, element, resolver);
}
function calculatePointsForWindow(height, element, resolver) {
  const {
    axis,
    container,
    isWindow
  } = resolver;
  const {
    offsetHeightKey,
    clientHeightKey
  } = extractHeightPropKeys(axis);
  const scrolled = height + getElementPageYOffset(getDocumentElement(isWindow, container), axis, isWindow);
  const nativeElementHeight = getElementHeight(element.nativeElement, isWindow, offsetHeightKey, clientHeightKey);
  const totalToScroll = getElementOffsetTop(element.nativeElement, axis, isWindow) + nativeElementHeight;
  return {
    height,
    scrolled,
    totalToScroll,
    isWindow
  };
}
function calculatePointsForElement(height, element, resolver) {
  const {
    axis,
    container
  } = resolver;
  const scrolled = container[axis.scrollTopKey()];
  const totalToScroll = container[axis.scrollHeightKey()];
  return {
    height,
    scrolled,
    totalToScroll,
    isWindow: false
  };
}
function extractHeightPropKeys(axis) {
  return {
    offsetHeightKey: axis.offsetHeightKey(),
    clientHeightKey: axis.clientHeightKey()
  };
}
function extractHeightForElement({
  container,
  isWindow,
  axis
}) {
  const {
    offsetHeightKey,
    clientHeightKey
  } = extractHeightPropKeys(axis);
  return getElementHeight(container, isWindow, offsetHeightKey, clientHeightKey);
}
function getElementHeight(elem, isWindow, offsetHeightKey, clientHeightKey) {
  if (isNaN(elem[offsetHeightKey])) {
    const docElem = getDocumentElement(isWindow, elem);
    return docElem ? docElem[clientHeightKey] : 0;
  } else {
    return elem[offsetHeightKey];
  }
}
function getElementOffsetTop(elem, axis, isWindow) {
  const topKey = axis.topKey();
  if (!elem.getBoundingClientRect) {
    return;
  }
  return elem.getBoundingClientRect()[topKey] + getElementPageYOffset(elem, axis, isWindow);
}
function getElementPageYOffset(elem, axis, isWindow) {
  const pageYOffset = axis.pageYOffsetKey();
  const scrollTop = axis.scrollTopKey();
  const offsetTop = axis.offsetTopKey();
  if (isNaN(window.pageYOffset)) {
    return getDocumentElement(isWindow, elem)[scrollTop];
  } else if (elem.ownerDocument) {
    return elem.ownerDocument.defaultView[pageYOffset];
  } else {
    return elem[offsetTop];
  }
}
function shouldFireScrollEvent(container, distance = {
  down: 0,
  up: 0
}, scrollingDown) {
  let remaining;
  let containerBreakpoint;
  if (container.totalToScroll <= 0) {
    return false;
  }
  const scrolledUntilNow = container.isWindow ? container.scrolled : container.height + container.scrolled;
  if (scrollingDown) {
    remaining = (container.totalToScroll - scrolledUntilNow) / container.totalToScroll;
    const distanceDown = distance?.down ? distance.down : 0;
    containerBreakpoint = distanceDown / 10;
  } else {
    const totalHiddenContentHeight = container.scrolled + (container.totalToScroll - scrolledUntilNow);
    remaining = container.scrolled / totalHiddenContentHeight;
    const distanceUp = distance?.up ? distance.up : 0;
    containerBreakpoint = distanceUp / 10;
  }
  const shouldFireEvent = remaining <= containerBreakpoint;
  return shouldFireEvent;
}
function isScrollingDownwards(lastScrollPosition, container) {
  return lastScrollPosition < container.scrolled;
}
function getScrollStats(lastScrollPosition, container, distance) {
  const scrollDown = isScrollingDownwards(lastScrollPosition, container);
  return {
    fire: shouldFireScrollEvent(container, distance, scrollDown),
    scrollDown
  };
}
var ScrollState = class {
  constructor({
    totalToScroll
  }) {
    this.lastScrollPosition = 0;
    this.lastTotalToScroll = 0;
    this.totalToScroll = 0;
    this.triggered = {
      down: 0,
      up: 0
    };
    this.totalToScroll = totalToScroll;
  }
  updateScrollPosition(position) {
    return this.lastScrollPosition = position;
  }
  updateTotalToScroll(totalToScroll) {
    if (this.lastTotalToScroll !== totalToScroll) {
      this.lastTotalToScroll = this.totalToScroll;
      this.totalToScroll = totalToScroll;
    }
  }
  updateScroll(scrolledUntilNow, totalToScroll) {
    this.updateScrollPosition(scrolledUntilNow);
    this.updateTotalToScroll(totalToScroll);
  }
  updateTriggeredFlag(scroll, isScrollingDown) {
    if (isScrollingDown) {
      this.triggered.down = scroll;
    } else {
      this.triggered.up = scroll;
    }
  }
  isTriggeredScroll(totalToScroll, isScrollingDown) {
    return isScrollingDown ? this.triggered.down === totalToScroll : this.triggered.up === totalToScroll;
  }
};
function createScroller(config) {
  const {
    scrollContainer,
    scrollWindow,
    element,
    fromRoot
  } = config;
  const resolver = createResolver({
    axis: new AxisResolver(!config.horizontal),
    windowElement: resolveContainerElement(scrollContainer, scrollWindow, element, fromRoot)
  });
  const scrollState = new ScrollState({
    totalToScroll: calculatePoints(element, resolver)
  });
  const options = {
    container: resolver.container,
    throttle: config.throttle
  };
  const distance = {
    up: config.upDistance,
    down: config.downDistance
  };
  return attachScrollEvent(options).pipe(mergeMap(() => of(calculatePoints(element, resolver))), map((positionStats) => toInfiniteScrollParams(scrollState.lastScrollPosition, positionStats, distance)), tap(({
    stats
  }) => scrollState.updateScroll(stats.scrolled, stats.totalToScroll)), filter(({
    fire,
    scrollDown,
    stats: {
      totalToScroll
    }
  }) => shouldTriggerEvents(config.alwaysCallback, fire, scrollState.isTriggeredScroll(totalToScroll, scrollDown))), tap(({
    scrollDown,
    stats: {
      totalToScroll
    }
  }) => {
    scrollState.updateTriggeredFlag(totalToScroll, scrollDown);
  }), map(toInfiniteScrollAction));
}
function attachScrollEvent(options) {
  let obs = fromEvent(options.container, "scroll");
  if (options.throttle) {
    obs = obs.pipe(throttleTime(options.throttle, void 0, {
      leading: true,
      trailing: true
    }));
  }
  return obs;
}
function toInfiniteScrollParams(lastScrollPosition, stats, distance) {
  const {
    scrollDown,
    fire
  } = getScrollStats(lastScrollPosition, stats, distance);
  return {
    scrollDown,
    fire,
    stats
  };
}
var InfiniteScrollActions = {
  DOWN: "[NGX_ISE] DOWN",
  UP: "[NGX_ISE] UP"
};
function toInfiniteScrollAction(response) {
  const {
    scrollDown,
    stats: {
      scrolled: currentScrollPosition
    }
  } = response;
  return {
    type: scrollDown ? InfiniteScrollActions.DOWN : InfiniteScrollActions.UP,
    payload: {
      currentScrollPosition
    }
  };
}
var InfiniteScrollDirective = class {
  constructor(element, zone) {
    this.element = element;
    this.zone = zone;
    this.scrolled = new EventEmitter();
    this.scrolledUp = new EventEmitter();
    this.infiniteScrollDistance = 2;
    this.infiniteScrollUpDistance = 1.5;
    this.infiniteScrollThrottle = 150;
    this.infiniteScrollDisabled = false;
    this.infiniteScrollContainer = null;
    this.scrollWindow = true;
    this.immediateCheck = false;
    this.horizontal = false;
    this.alwaysCallback = false;
    this.fromRoot = false;
  }
  ngAfterViewInit() {
    if (!this.infiniteScrollDisabled) {
      this.setup();
    }
  }
  ngOnChanges({
    infiniteScrollContainer,
    infiniteScrollDisabled,
    infiniteScrollDistance
  }) {
    const containerChanged = inputPropChanged(infiniteScrollContainer);
    const disabledChanged = inputPropChanged(infiniteScrollDisabled);
    const distanceChanged = inputPropChanged(infiniteScrollDistance);
    const shouldSetup = !disabledChanged && !this.infiniteScrollDisabled || disabledChanged && !infiniteScrollDisabled.currentValue || distanceChanged;
    if (containerChanged || disabledChanged || distanceChanged) {
      this.destroyScroller();
      if (shouldSetup) {
        this.setup();
      }
    }
  }
  setup() {
    if (hasWindowDefined()) {
      this.zone.runOutsideAngular(() => {
        this.disposeScroller = createScroller({
          fromRoot: this.fromRoot,
          alwaysCallback: this.alwaysCallback,
          disable: this.infiniteScrollDisabled,
          downDistance: this.infiniteScrollDistance,
          element: this.element,
          horizontal: this.horizontal,
          scrollContainer: this.infiniteScrollContainer,
          scrollWindow: this.scrollWindow,
          throttle: this.infiniteScrollThrottle,
          upDistance: this.infiniteScrollUpDistance
        }).subscribe((payload) => this.handleOnScroll(payload));
      });
    }
  }
  handleOnScroll({
    type,
    payload
  }) {
    const emitter = type === InfiniteScrollActions.DOWN ? this.scrolled : this.scrolledUp;
    if (hasObservers(emitter)) {
      this.zone.run(() => emitter.emit(payload));
    }
  }
  ngOnDestroy() {
    this.destroyScroller();
  }
  destroyScroller() {
    if (this.disposeScroller) {
      this.disposeScroller.unsubscribe();
    }
  }
};
InfiniteScrollDirective.ɵfac = function InfiniteScrollDirective_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || InfiniteScrollDirective)(ɵɵdirectiveInject(ElementRef), ɵɵdirectiveInject(NgZone));
};
InfiniteScrollDirective.ɵdir = ɵɵdefineDirective({
  type: InfiniteScrollDirective,
  selectors: [["", "infiniteScroll", ""], ["", "infinite-scroll", ""], ["", "data-infinite-scroll", ""]],
  inputs: {
    infiniteScrollDistance: "infiniteScrollDistance",
    infiniteScrollUpDistance: "infiniteScrollUpDistance",
    infiniteScrollThrottle: "infiniteScrollThrottle",
    infiniteScrollDisabled: "infiniteScrollDisabled",
    infiniteScrollContainer: "infiniteScrollContainer",
    scrollWindow: "scrollWindow",
    immediateCheck: "immediateCheck",
    horizontal: "horizontal",
    alwaysCallback: "alwaysCallback",
    fromRoot: "fromRoot"
  },
  outputs: {
    scrolled: "scrolled",
    scrolledUp: "scrolledUp"
  },
  standalone: false,
  features: [ɵɵNgOnChangesFeature]
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(InfiniteScrollDirective, [{
    type: Directive,
    args: [{
      selector: "[infiniteScroll], [infinite-scroll], [data-infinite-scroll]"
    }]
  }], function() {
    return [{
      type: ElementRef
    }, {
      type: NgZone
    }];
  }, {
    scrolled: [{
      type: Output
    }],
    scrolledUp: [{
      type: Output
    }],
    infiniteScrollDistance: [{
      type: Input
    }],
    infiniteScrollUpDistance: [{
      type: Input
    }],
    infiniteScrollThrottle: [{
      type: Input
    }],
    infiniteScrollDisabled: [{
      type: Input
    }],
    infiniteScrollContainer: [{
      type: Input
    }],
    scrollWindow: [{
      type: Input
    }],
    immediateCheck: [{
      type: Input
    }],
    horizontal: [{
      type: Input
    }],
    alwaysCallback: [{
      type: Input
    }],
    fromRoot: [{
      type: Input
    }]
  });
})();
function hasObservers(emitter) {
  return emitter.observed ?? emitter.observers.length > 0;
}
var InfiniteScrollModule = class {
};
InfiniteScrollModule.ɵfac = function InfiniteScrollModule_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || InfiniteScrollModule)();
};
InfiniteScrollModule.ɵmod = ɵɵdefineNgModule({
  type: InfiniteScrollModule,
  declarations: [InfiniteScrollDirective],
  exports: [InfiniteScrollDirective]
});
InfiniteScrollModule.ɵinj = ɵɵdefineInjector({});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(InfiniteScrollModule, [{
    type: NgModule,
    args: [{
      declarations: [InfiniteScrollDirective],
      exports: [InfiniteScrollDirective],
      imports: [],
      providers: []
    }]
  }], null, null);
})();

// node_modules/ng-select2-component/fesm2020/ng-select2-component.mjs
var _c0 = ["selection"];
var _c1 = ["results"];
var _c2 = ["searchInput"];
var _c3 = ["dropdown"];
var _c4 = ["result"];
var _c5 = [[["select2-label"]], [["select2-hint"]]];
var _c6 = ["select2-label", "select2-hint"];
function Select2_span_2_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "span", 21);
  }
}
function Select2_span_8_span_1_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementStart(0, "span");
    ɵɵtext(1, " ");
    ɵɵelementEnd();
  }
}
function Select2_span_8_span_2_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "span", 25);
  }
  if (rf & 2) {
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("innerHTML", ctx_r1.select2Option.label, ɵɵsanitizeHtml);
  }
}
function Select2_span_8_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementStart(0, "span", 22);
    ɵɵtemplate(1, Select2_span_8_span_1_Template, 2, 0, "span", 18)(2, Select2_span_8_span_2_Template, 1, 1, "span", 23);
    ɵɵelementStart(3, "span", 24);
    ɵɵtext(4);
    ɵɵelementEnd()();
  }
  if (rf & 2) {
    const ctx_r1 = ɵɵnextContext();
    ɵɵproperty("title", (ctx_r1.select2Option == null ? null : ctx_r1.select2Option.label) || "");
    ɵɵadvance();
    ɵɵproperty("ngIf", !ctx_r1.select2Option);
    ɵɵadvance();
    ɵɵproperty("ngIf", ctx_r1.select2Option);
    ɵɵadvance();
    ɵɵclassProp("select2-selection__placeholder__option", ctx_r1.option);
    ɵɵadvance();
    ɵɵtextInterpolate(ctx_r1.placeholder);
  }
}
function Select2_span_9_Template(rf, ctx) {
  if (rf & 1) {
    const _r3 = ɵɵgetCurrentView();
    ɵɵelementStart(0, "span", 26);
    ɵɵlistener("click", function Select2_span_9_Template_span_click_0_listener($event) {
      ɵɵrestoreView(_r3);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.reset($event));
    });
    ɵɵtext(1, "×");
    ɵɵelementEnd();
  }
}
function Select2_span_10_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "span", 27);
  }
}
function Select2_ul_11_li_3_span_1_Template(rf, ctx) {
  if (rf & 1) {
    const _r4 = ɵɵgetCurrentView();
    ɵɵelementStart(0, "span", 32);
    ɵɵlistener("click", function Select2_ul_11_li_3_span_1_Template_span_click_0_listener($event) {
      ɵɵrestoreView(_r4);
      const op_r5 = ɵɵnextContext().$implicit;
      const ctx_r1 = ɵɵnextContext(2);
      return ɵɵresetView(ctx_r1.removeSelection($event, op_r5));
    });
    ɵɵtext(1, "×");
    ɵɵelementEnd();
  }
}
function Select2_ul_11_li_3_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementStart(0, "li", 30);
    ɵɵtemplate(1, Select2_ul_11_li_3_span_1_Template, 2, 0, "span", 31);
    ɵɵelement(2, "span", 25);
    ɵɵelementEnd();
  }
  if (rf & 2) {
    const op_r5 = ctx.$implicit;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("title", op_r5.label);
    ɵɵadvance();
    ɵɵproperty("ngIf", !(ctx_r1.disabled || ctx_r1.readonly));
    ɵɵadvance();
    ɵɵproperty("innerHTML", op_r5.label, ɵɵsanitizeHtml);
  }
}
function Select2_ul_11_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementStart(0, "ul", 28)(1, "span", 24);
    ɵɵtext(2);
    ɵɵelementEnd();
    ɵɵtemplate(3, Select2_ul_11_li_3_Template, 3, 3, "li", 29);
    ɵɵelementEnd();
  }
  if (rf & 2) {
    const ctx_r1 = ɵɵnextContext();
    ɵɵadvance();
    ɵɵclassProp("select2-selection__placeholder__option", (ctx_r1.select2Options == null ? null : ctx_r1.select2Options.length) > 0);
    ɵɵadvance();
    ɵɵtextInterpolate(ctx_r1.placeholder);
    ɵɵadvance();
    ɵɵproperty("ngForOf", ctx_r1.option)("ngForTrackBy", ctx_r1.trackBy);
  }
}
function Select2_ng_container_12_ng_container_1_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainer(0);
  }
}
function Select2_ng_container_12_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainerStart(0);
    ɵɵtemplate(1, Select2_ng_container_12_ng_container_1_Template, 1, 0, "ng-container", 33);
    ɵɵelementContainerEnd();
  }
  if (rf & 2) {
    ɵɵnextContext();
    const containerTemplate_r6 = ɵɵreference(17);
    ɵɵadvance();
    ɵɵproperty("ngTemplateOutlet", containerTemplate_r6);
  }
}
function Select2_ng_template_15_ng_container_0_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainer(0);
  }
}
function Select2_ng_template_15_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵtemplate(0, Select2_ng_template_15_ng_container_0_Template, 1, 0, "ng-container", 33);
  }
  if (rf & 2) {
    ɵɵnextContext();
    const containerTemplate_r6 = ɵɵreference(17);
    ɵɵproperty("ngTemplateOutlet", containerTemplate_r6);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_strong_1_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "strong", 25);
  }
  if (rf & 2) {
    const groupOrOption_r8 = ɵɵnextContext(2).$implicit;
    ɵɵproperty("innerHTML", groupOrOption_r8.label, ɵɵsanitizeHtml);
    ɵɵattribute("class", "select2-results__group" + (groupOrOption_r8.classes ? " " + groupOrOption_r8.classes : ""));
  }
}
function Select2_ng_template_16_ng_container_9_li_1_ng_template_2_ng_container_0_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainer(0);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_ng_template_2_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵtemplate(0, Select2_ng_template_16_ng_container_9_li_1_ng_template_2_ng_container_0_Template, 1, 0, "ng-container", 49);
  }
  if (rf & 2) {
    const groupOrOption_r8 = ɵɵnextContext(2).$implicit;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("ngTemplateOutlet", ctx_r1.getTemplate(groupOrOption_r8, "group"))("ngTemplateOutletContext", groupOrOption_r8);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_li_5_div_2_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "div", 52);
  }
  if (rf & 2) {
    const option_r10 = ɵɵnextContext().$implicit;
    ɵɵproperty("innerHTML", option_r10.label, ɵɵsanitizeHtml);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_li_5_ng_template_3_ng_container_0_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainer(0);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_li_5_ng_template_3_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵtemplate(0, Select2_ng_template_16_ng_container_9_li_1_li_5_ng_template_3_ng_container_0_Template, 1, 0, "ng-container", 49);
  }
  if (rf & 2) {
    const option_r10 = ɵɵnextContext().$implicit;
    const ctx_r1 = ɵɵnextContext(4);
    ɵɵproperty("ngTemplateOutlet", ctx_r1.getTemplate(option_r10, "option"))("ngTemplateOutletContext", option_r10);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_li_5_Template(rf, ctx) {
  if (rf & 1) {
    const _r9 = ɵɵgetCurrentView();
    ɵɵelementStart(0, "li", 50, 6);
    ɵɵlistener("mouseenter", function Select2_ng_template_16_ng_container_9_li_1_li_5_Template_li_mouseenter_0_listener() {
      const option_r10 = ɵɵrestoreView(_r9).$implicit;
      const ctx_r1 = ɵɵnextContext(4);
      return ɵɵresetView(ctx_r1.mouseenter(option_r10));
    })("click", function Select2_ng_template_16_ng_container_9_li_1_li_5_Template_li_click_0_listener() {
      const option_r10 = ɵɵrestoreView(_r9).$implicit;
      const ctx_r1 = ɵɵnextContext(4);
      return ɵɵresetView(ctx_r1.click(option_r10));
    });
    ɵɵtemplate(2, Select2_ng_template_16_ng_container_9_li_1_li_5_div_2_Template, 1, 1, "div", 51)(3, Select2_ng_template_16_ng_container_9_li_1_li_5_ng_template_3_Template, 1, 2, "ng-template", null, 7, ɵɵtemplateRefExtractor);
    ɵɵelementEnd();
  }
  if (rf & 2) {
    const option_r10 = ctx.$implicit;
    const j_r11 = ctx.index;
    const liGroup_r12 = ɵɵreference(4);
    const i_r13 = ɵɵnextContext(2).index;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵclassMap(ctx_r1.getOptionStyle(option_r10));
    ɵɵproperty("id", option_r10.id || ctx_r1.id + "-option-" + i_r13 + "-" + j_r11);
    ɵɵattribute("aria-selected", ctx_r1.isSelected(option_r10))("aria-disabled", ctx_r1.isDisabled(option_r10));
    ɵɵadvance(2);
    ɵɵproperty("ngIf", !ctx_r1.hasTemplate(option_r10, "option"))("ngIfElse", liGroup_r12);
  }
}
function Select2_ng_template_16_ng_container_9_li_1_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementStart(0, "li", 45);
    ɵɵtemplate(1, Select2_ng_template_16_ng_container_9_li_1_strong_1_Template, 1, 2, "strong", 46)(2, Select2_ng_template_16_ng_container_9_li_1_ng_template_2_Template, 1, 2, "ng-template", null, 5, ɵɵtemplateRefExtractor);
    ɵɵelementStart(4, "ul", 47);
    ɵɵtemplate(5, Select2_ng_template_16_ng_container_9_li_1_li_5_Template, 5, 7, "li", 48);
    ɵɵelementEnd()();
  }
  if (rf & 2) {
    const optGroup_r14 = ɵɵreference(3);
    const groupOrOption_r8 = ɵɵnextContext().$implicit;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵadvance();
    ɵɵproperty("ngIf", !ctx_r1.hasTemplate(groupOrOption_r8, "group"))("ngIfElse", optGroup_r14);
    ɵɵadvance(4);
    ɵɵproperty("ngForOf", groupOrOption_r8.options)("ngForTrackBy", ctx_r1.trackBy);
  }
}
function Select2_ng_template_16_ng_container_9_li_2_div_2_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "div", 52);
  }
  if (rf & 2) {
    const groupOrOption_r8 = ɵɵnextContext(2).$implicit;
    ɵɵproperty("innerHTML", groupOrOption_r8.label, ɵɵsanitizeHtml);
  }
}
function Select2_ng_template_16_ng_container_9_li_2_ng_template_3_ng_container_0_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainer(0);
  }
}
function Select2_ng_template_16_ng_container_9_li_2_ng_template_3_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵtemplate(0, Select2_ng_template_16_ng_container_9_li_2_ng_template_3_ng_container_0_Template, 1, 0, "ng-container", 49);
  }
  if (rf & 2) {
    const groupOrOption_r8 = ɵɵnextContext(2).$implicit;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("ngTemplateOutlet", ctx_r1.getTemplate(groupOrOption_r8, "option"))("ngTemplateOutletContext", groupOrOption_r8);
  }
}
function Select2_ng_template_16_ng_container_9_li_2_Template(rf, ctx) {
  if (rf & 1) {
    const _r15 = ɵɵgetCurrentView();
    ɵɵelementStart(0, "li", 50, 6);
    ɵɵlistener("mouseenter", function Select2_ng_template_16_ng_container_9_li_2_Template_li_mouseenter_0_listener() {
      ɵɵrestoreView(_r15);
      const groupOrOption_r8 = ɵɵnextContext().$implicit;
      const ctx_r1 = ɵɵnextContext(2);
      return ɵɵresetView(ctx_r1.mouseenter(groupOrOption_r8));
    })("click", function Select2_ng_template_16_ng_container_9_li_2_Template_li_click_0_listener() {
      ɵɵrestoreView(_r15);
      const groupOrOption_r8 = ɵɵnextContext().$implicit;
      const ctx_r1 = ɵɵnextContext(2);
      return ɵɵresetView(ctx_r1.click(groupOrOption_r8));
    });
    ɵɵtemplate(2, Select2_ng_template_16_ng_container_9_li_2_div_2_Template, 1, 1, "div", 51)(3, Select2_ng_template_16_ng_container_9_li_2_ng_template_3_Template, 1, 2, "ng-template", null, 8, ɵɵtemplateRefExtractor);
    ɵɵelementEnd();
  }
  if (rf & 2) {
    const li_r16 = ɵɵreference(4);
    const ctx_r16 = ɵɵnextContext();
    const groupOrOption_r8 = ctx_r16.$implicit;
    const i_r13 = ctx_r16.index;
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵclassMap(ctx_r1.getOptionStyle(groupOrOption_r8));
    ɵɵproperty("id", groupOrOption_r8.id || ctx_r1.id + "-option-" + i_r13);
    ɵɵattribute("aria-selected", ctx_r1.isSelected(groupOrOption_r8))("aria-disabled", ctx_r1.isDisabled(groupOrOption_r8));
    ɵɵadvance(2);
    ɵɵproperty("ngIf", !ctx_r1.hasTemplate(groupOrOption_r8, "option"))("ngIfElse", li_r16);
  }
}
function Select2_ng_template_16_ng_container_9_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelementContainerStart(0);
    ɵɵtemplate(1, Select2_ng_template_16_ng_container_9_li_1_Template, 6, 4, "li", 43)(2, Select2_ng_template_16_ng_container_9_li_2_Template, 5, 7, "li", 44);
    ɵɵelementContainerEnd();
  }
  if (rf & 2) {
    const groupOrOption_r8 = ctx.$implicit;
    ɵɵadvance();
    ɵɵproperty("ngIf", groupOrOption_r8.options);
    ɵɵadvance();
    ɵɵproperty("ngIf", !groupOrOption_r8.options);
  }
}
function Select2_ng_template_16_li_10_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "li", 53);
  }
  if (rf & 2) {
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("innerHTML", ctx_r1.noResultMessage, ɵɵsanitizeHtml);
  }
}
function Select2_ng_template_16_li_11_Template(rf, ctx) {
  if (rf & 1) {
    ɵɵelement(0, "li", 54);
  }
  if (rf & 2) {
    const ctx_r1 = ɵɵnextContext(2);
    ɵɵproperty("innerHTML", ctx_r1.maxResultsMessage, ɵɵsanitizeHtml);
  }
}
function Select2_ng_template_16_Template(rf, ctx) {
  if (rf & 1) {
    const _r7 = ɵɵgetCurrentView();
    ɵɵelementStart(0, "div", 34)(1, "div", 35, 2)(3, "div", 36)(4, "input", 37, 3);
    ɵɵlistener("keydown", function Select2_ng_template_16_Template_input_keydown_4_listener($event) {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.keyDown($event));
    })("keyup", function Select2_ng_template_16_Template_input_keyup_4_listener($event) {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.searchUpdate($event));
    })("change", function Select2_ng_template_16_Template_input_change_4_listener($event) {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.prevChange($event));
    });
    ɵɵelementEnd()();
    ɵɵelementStart(6, "div", 38)(7, "ul", 39, 4);
    ɵɵlistener("scrolled", function Select2_ng_template_16_Template_ul_scrolled_7_listener() {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.onScroll("down"));
    })("scrolledUp", function Select2_ng_template_16_Template_ul_scrolledUp_7_listener() {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.onScroll("up"));
    })("keydown", function Select2_ng_template_16_Template_ul_keydown_7_listener($event) {
      ɵɵrestoreView(_r7);
      const ctx_r1 = ɵɵnextContext();
      return ɵɵresetView(ctx_r1.keyDown($event));
    });
    ɵɵtemplate(9, Select2_ng_template_16_ng_container_9_Template, 3, 2, "ng-container", 40)(10, Select2_ng_template_16_li_10_Template, 1, 1, "li", 41)(11, Select2_ng_template_16_li_11_Template, 1, 1, "li", 42);
    ɵɵelementEnd()()()();
  }
  if (rf & 2) {
    const results_r18 = ɵɵreference(8);
    const ctx_r1 = ɵɵnextContext();
    ɵɵclassProp("select2-container--open", ctx_r1.isOpen)("select2-overlay", ctx_r1.overlay)("select2-position-auto", ctx_r1.listPosition === "auto");
    ɵɵadvance();
    ɵɵclassProp("select2-dropdown--below", !ctx_r1.select2above)("select2-dropdown--above", ctx_r1.select2above);
    ɵɵadvance(2);
    ɵɵclassProp("select2-search--hide", ctx_r1.hideSearch());
    ɵɵadvance();
    ɵɵproperty("id", ctx_r1.id + "-search-field")("value", ctx_r1.searchText);
    ɵɵattribute("tabindex", ctx_r1.isOpen ? ctx_r1.tabIndex : "-1");
    ɵɵadvance(3);
    ɵɵstyleProp("max-height", ctx_r1.resultMaxHeight);
    ɵɵproperty("infiniteScrollDisabled", !ctx_r1.infiniteScroll && !ctx_r1.isOpen)("infiniteScrollDistance", ctx_r1.infiniteScrollDistance)("infiniteScrollThrottle", ctx_r1.infiniteScrollThrottle)("infiniteScrollContainer", results_r18);
    ɵɵadvance(2);
    ɵɵproperty("ngForOf", ctx_r1.filteredData)("ngForTrackBy", ctx_r1.trackBy);
    ɵɵadvance();
    ɵɵproperty("ngIf", !(ctx_r1.filteredData == null ? null : ctx_r1.filteredData.length) && ctx_r1.noResultMessage);
    ɵɵadvance();
    ɵɵproperty("ngIf", ctx_r1.maxResultsExceeded);
  }
}
var timeout = 200;
var unicodePatterns = [{
  l: "a",
  s: /[ⓐａẚàáâầấẫẩãāăằắẵẳȧǡäǟảåǻǎȁȃạậặḁąⱥɐ]/gi
}, {
  l: "aa",
  s: /ꜳ/gi
}, {
  l: "ae",
  s: /[æǽǣ]/gi
}, {
  l: "ao",
  s: /ꜵ/gi
}, {
  l: "au",
  s: /ꜷ/gi
}, {
  l: "av",
  s: /[ꜹꜻ]/gi
}, {
  l: "ay",
  s: /ꜽ/gi
}, {
  l: "b",
  s: /[ⓑｂḃḅḇƀƃɓ]/gi
}, {
  l: "c",
  s: /[ⓒｃćĉċčçḉƈȼꜿↄ]/gi
}, {
  l: "d",
  s: /[ⓓｄḋďḍḑḓḏđƌɖɗꝺ]/gi
}, {
  l: "dz",
  s: /[ǳǆ]/gi
}, {
  l: "e",
  s: /[ⓔｅèéêềếễểẽēḕḗĕėëẻěȅȇẹệȩḝęḙḛɇɛǝ]/gi
}, {
  l: "f",
  s: /[ⓕｆḟƒꝼ]/gi
}, {
  l: "g",
  s: /[ⓖｇǵĝḡğġǧģǥɠꞡᵹꝿ]/gi
}, {
  l: "h",
  s: /[ⓗｈĥḣḧȟḥḩḫẖħⱨⱶɥ]/gi
}, {
  l: "hv",
  s: /ƕ/gi
}, {
  l: "i",
  s: /[ⓘｉìíîĩīĭİïḯỉǐȉȋịįḭɨı]/gi
}, {
  l: "j",
  s: /[ⓙｊĵǰɉ]/gi
}, {
  l: "k",
  s: /[ⓚｋḱǩḳķḵƙⱪꝁꝃꝅꞣ]/gi
}, {
  l: "l",
  s: /[ⓛｌŀĺľḷḹļḽḻſłƚɫⱡꝉꞁꝇꝆ]/gi
}, {
  l: "lj",
  s: /ǉ/gi
}, {
  l: "m",
  s: /[ⓜｍḿṁṃɱɯ]/gi
}, {
  l: "n",
  s: /[ⓝｎǹńñṅňṇņṋṉƞɲŉꞑꞥ]/gi
}, {
  l: "nj",
  s: /ǌ/gi
}, {
  l: "o",
  s: /[ⓞｏòóôồốỗổõṍȭṏōṑṓŏȯȱöȫỏőǒȍȏơờớỡởợọộǫǭøǿɔƟꝋꝍɵ]/gi
}, {
  l: "oi",
  s: /ƣ/gi
}, {
  l: "oe",
  s: /œ/gi
}, {
  l: "oo",
  s: /ꝏ/gi
}, {
  l: "ou",
  s: /ȣ/gi
}, {
  l: "p",
  s: /[ⓟｐṕṗƥᵽꝑꝓꝕ]/gi
}, {
  l: "q",
  s: /[ⓠｑɋꝗꝙ]/gi
}, {
  l: "r",
  s: /[ⓡｒŕṙřȑȓṛṝŗṟɍɽꝛꞧꞃ]/gi
}, {
  l: "s",
  s: /[ⓢｓßẞśṥŝṡšṧṣṩșşȿꞩꞅẛ]/gi
}, {
  l: "t",
  s: /[ⓣｔṫẗťṭțţṱṯŧƭʈⱦꞇ]/gi
}, {
  l: "tz",
  s: /ꜩ/gi
}, {
  l: "u",
  s: /[ⓤｕùúûũṹūṻŭüǜǘǖǚủůűǔȕȗưừứữửựụṳųṷṵʉ]/gi
}, {
  l: "v",
  s: /[ⓥｖṽṿʋꝟʌ]/gi
}, {
  l: "vy",
  s: /ꝡ/gi
}, {
  l: "w",
  s: /[ⓦｗẁẃŵẇẅẘẉⱳ]/gi
}, {
  l: "x",
  s: /[ⓧｘẋẍ]/gi
}, {
  l: "y",
  s: /[ⓨｙỳýŷỹȳẏÿỷẙỵƴɏỿ]/gi
}, {
  l: "z",
  s: /[ⓩｚźẑżžẓẕƶȥɀⱬꝣ]/gi
}];
var defaultMinCountForSearch = 6;
var protectRegexp = new RegExp("[\\-\\[\\]\\/\\{\\}\\(\\)\\*\\+\\?\\.\\\\\\^\\$\\|]", "g");
var Select2Utils = class _Select2Utils {
  static getOptionByValue(data, value) {
    if (Array.isArray(data)) {
      for (const groupOrOption of data) {
        const options = groupOrOption.options;
        if (options) {
          for (const option of options) {
            if (option.value === value) {
              return option;
            }
          }
        } else if (groupOrOption.value === value) {
          return groupOrOption;
        }
      }
    }
    return null;
  }
  static getOptionsByValue(data, value, multiple) {
    if (multiple) {
      const values = Array.isArray(value) ? value : [];
      const result = [];
      for (const v of values) {
        const option = _Select2Utils.getOptionByValue(data, v);
        if (option) {
          result.push(option);
        }
      }
      return result;
    }
    return _Select2Utils.getOptionByValue(data, value);
  }
  static getFirstAvailableOption(data) {
    if (Array.isArray(data)) {
      for (const groupOrOption of data) {
        const options = groupOrOption.options;
        if (options) {
          for (const option of options) {
            if (!option.disabled) {
              return option.value;
            }
          }
        } else {
          const option = groupOrOption;
          if (!option.disabled) {
            return option.value;
          }
        }
      }
    }
    return null;
  }
  static valueIsNotInFilteredData(filteredData, value) {
    if (_Select2Utils.isNullOrUndefined(value)) {
      return true;
    }
    for (const groupOrOption of filteredData) {
      const options = groupOrOption.options;
      if (options) {
        for (const option of options) {
          if (option.value === value) {
            return false;
          }
        }
      } else if (groupOrOption.value === value) {
        return false;
      }
    }
    return true;
  }
  // eslint-disable-next-line
  static getPreviousOption(filteredData, hoveringValue) {
    let findIt = _Select2Utils.isNullOrUndefined(hoveringValue);
    for (let i = filteredData.length - 1; i >= 0; i--) {
      const groupOrOption = filteredData[i];
      const options = groupOrOption.options;
      if (options) {
        for (let j = options.length - 1; j >= 0; j--) {
          const option = options[j];
          if (findIt && !option.disabled && !option.hide) {
            return option;
          }
          if (!findIt) {
            findIt = option.value === hoveringValue;
          }
        }
      } else {
        const option = groupOrOption;
        if (findIt && !option.disabled && !option.hide) {
          return option;
        }
        if (!findIt) {
          findIt = option.value === hoveringValue;
        }
      }
    }
    return null;
  }
  // eslint-disable-next-line
  static getNextOption(filteredData, hoveringValue) {
    let findIt = _Select2Utils.isNullOrUndefined(hoveringValue);
    for (const groupOrOption of filteredData) {
      const options = groupOrOption.options;
      if (options) {
        for (const option of options) {
          if (findIt) {
            if (!option.disabled && !option.hide) {
              return option;
            }
          } else if (!findIt) {
            findIt = option.value === hoveringValue;
          }
        }
      } else {
        const option = groupOrOption;
        if (findIt) {
          if (!option.disabled && !option.hide) {
            return option;
          }
        } else if (!findIt) {
          findIt = option.value === hoveringValue;
        }
      }
    }
    return null;
  }
  static getReduceData(data, maxResults = 0) {
    if (maxResults > 0) {
      let counter = 0;
      const result = [];
      for (const groupOrOption of data) {
        const options = groupOrOption.options;
        if (options) {
          const group = __spreadProps(__spreadValues({}, groupOrOption), {
            options: []
          });
          result.push(group);
          for (const item of options) {
            group.options.push(item);
            counter++;
            if (counter === maxResults) {
              return {
                result,
                reduce: true
              };
            }
          }
        } else {
          result.push(groupOrOption);
          counter++;
        }
        if (counter === maxResults) {
          return {
            result,
            reduce: true
          };
        }
      }
      return {
        result,
        reduce: false
      };
    } else {
      return {
        result: data,
        reduce: false
      };
    }
  }
  static getFilteredData(data, searchText, editPattern) {
    if (searchText) {
      const result = [];
      for (const groupOrOption of data) {
        const options = groupOrOption.options;
        if (options) {
          if (options.some((group) => _Select2Utils.containSearchText(group.label, searchText, editPattern))) {
            const filteredOptions = options.filter((group) => _Select2Utils.containSearchText(group.label, searchText, editPattern));
            result.push(__spreadProps(__spreadValues({}, groupOrOption), {
              options: filteredOptions
            }));
          }
        } else if (_Select2Utils.containSearchText(groupOrOption.label, searchText, editPattern)) {
          result.push(groupOrOption);
        }
      }
      return result;
    } else {
      return data;
    }
  }
  static getFilteredSelectedData(data, selectedOptions) {
    const result = [];
    for (const groupOrOption of data) {
      const options = groupOrOption.options;
      if (options) {
        const filteredOptions = options.filter((group) => _Select2Utils.isSelected(selectedOptions, group, true) === "false");
        if (filteredOptions.length) {
          result.push(__spreadProps(__spreadValues({}, groupOrOption), {
            options: filteredOptions
          }));
        }
      } else if (_Select2Utils.isSelected(selectedOptions, groupOrOption, true) === "false") {
        result.push(groupOrOption);
      }
    }
    return result;
  }
  static isSearchboxHiddex(data, minCountForSearch) {
    if (minCountForSearch === "" || minCountForSearch === void 0 || minCountForSearch === null || isNaN(+minCountForSearch)) {
      minCountForSearch = defaultMinCountForSearch;
    }
    const optionCount = _Select2Utils.getOptionsCount(data);
    return optionCount < +minCountForSearch;
  }
  static isSelected(options, option, multiple) {
    return multiple ? options && options.some((op) => op.value === option.value) ? "true" : "false" : options && option.value === options.value ? "true" : "false";
  }
  static removeSelection(options, option) {
    for (let i = 0; i < options.length; i++) {
      if (options[i].value === option.value) {
        options.splice(i, 1);
        return;
      }
    }
  }
  static getOptionsCount(data) {
    let count = 0;
    if (Array.isArray(data)) {
      for (const groupOrOption of data) {
        const options = groupOrOption.options;
        if (options) {
          count += options.length;
        } else {
          count++;
        }
      }
    }
    return count;
  }
  static isNullOrUndefined(value) {
    return value === null || value === void 0;
  }
  static containSearchText(label, searchText, editPattern) {
    return searchText ? _Select2Utils.formatSansUnicode(label).match(new RegExp(_Select2Utils.formatPattern(searchText, editPattern), "i")) !== null : true;
  }
  static protectPattern(str) {
    return str.replace(protectRegexp, "\\$&");
  }
  static formatSansUnicode(str) {
    for (const unicodePattern of unicodePatterns) {
      str = str.replace(unicodePattern.s, unicodePattern.l);
    }
    return str;
  }
  static formatPattern(str, editPattern) {
    str = _Select2Utils.formatSansUnicode(_Select2Utils.protectPattern(str));
    if (editPattern && typeof editPattern === "function") {
      str = editPattern(str);
    }
    return str;
  }
};
var nextUniqueId = 0;
var displaySearchStatusList = ["default", "hidden", "always"];
var Select2 = class {
  constructor(_viewportRuler, _changeDetectorRef, _parentForm, _parentFormGroup, _control, tabIndex) {
    this._viewportRuler = _viewportRuler;
    this._changeDetectorRef = _changeDetectorRef;
    this._parentForm = _parentForm;
    this._parentFormGroup = _parentFormGroup;
    this._control = _control;
    this.minCharForSearch = 0;
    this.limitSelection = 0;
    this.listPosition = "below";
    this.styleMode = "default";
    this.maxResults = 0;
    this.maxResultsMessage = "Too many results…";
    this.infiniteScrollDistance = 1.5;
    this.infiniteScrollThrottle = 150;
    this.resultMaxHeight = "200px";
    this.update = new EventEmitter();
    this.open = new EventEmitter();
    this.close = new EventEmitter();
    this.focus = new EventEmitter();
    this.blur = new EventEmitter();
    this.search = new EventEmitter();
    this.scroll = new EventEmitter();
    this.removeOption = new EventEmitter();
    this.option = null;
    this.isOpen = false;
    this.focused = false;
    this.hoveringValue = null;
    this.innerSearchText = "";
    this._stateChanges = new Subject();
    this._disabled = false;
    this._required = false;
    this._readonly = false;
    this._multiple = false;
    this._overlay = false;
    this._resettable = false;
    this._hideSelectedItems = false;
    this._clickDetection = false;
    this._uid = `select2-${nextUniqueId++}`;
    this._infiniteScroll = true;
    this._onTouched = () => {
    };
    this._onChange = () => {
    };
    this.id = this.id;
    this._tabIndex = parseInt(tabIndex, 10) || 0;
    if (this._control) {
      this._control.valueAccessor = this;
    }
    this._clickDetectionFc = this.clickDetection.bind(this);
  }
  /** data of options & optiongrps */
  set data(data) {
    this._data = data;
    this.updateFilteredData();
  }
  get multiple() {
    return this._multiple;
  }
  set multiple(value) {
    this._multiple = this._coerceBooleanProperty(value);
    this.ngOnInit();
  }
  /** use the material style */
  get overlay() {
    return this._overlay;
  }
  set overlay(value) {
    this._overlay = this._coerceBooleanProperty(value);
  }
  /** infinite scroll activated */
  get infiniteScroll() {
    return this._infiniteScroll;
  }
  set infiniteScroll(value) {
    this._infiniteScroll = this._coerceBooleanProperty(value);
  }
  get select2Options() {
    return this.multiple ? this.option : null;
  }
  get select2Option() {
    return this.multiple ? null : this.option;
  }
  get searchText() {
    return this.innerSearchText;
  }
  set searchText(text) {
    if (this.customSearchEnabled) {
      this.search.emit({
        component: this,
        value: this._value,
        search: text
      });
    }
    this.innerSearchText = text;
  }
  /** minimal data of show the search field */
  get minCountForSearch() {
    return this._minCountForSearch;
  }
  set minCountForSearch(value) {
    this._minCountForSearch = value;
    this.updateSearchBox();
  }
  /** Unique id of the element. */
  get id() {
    return this._id;
  }
  set id(value) {
    this._id = value || this._uid;
  }
  /** Whether the element is required. */
  get required() {
    return this._required;
  }
  set required(value) {
    this._required = this._coerceBooleanProperty(value);
  }
  /** Whether selected items should be hidden. */
  get disabled() {
    return this._control ? this._control.disabled : this._disabled;
  }
  set disabled(value) {
    this._disabled = this._coerceBooleanProperty(value);
  }
  /** Whether items are hidden when has. */
  get hideSelectedItems() {
    return this._hideSelectedItems;
  }
  set hideSelectedItems(value) {
    this._hideSelectedItems = this._coerceBooleanProperty(value);
  }
  /** Whether the element is readonly. */
  get readonly() {
    return this._readonly;
  }
  set readonly(value) {
    this._readonly = this._coerceBooleanProperty(value);
  }
  /** The input element's value. */
  get value() {
    return this._value;
  }
  set value(value) {
    if (this.testValueChange(this._value, value)) {
      setTimeout(() => {
        this._value = value;
        this.writeValue(value);
      }, 10);
    }
  }
  /** Tab index for the select2 element. */
  get tabIndex() {
    return this.disabled ? -1 : this._tabIndex;
  }
  set tabIndex(value) {
    if (typeof value !== "undefined") {
      this._tabIndex = value;
    }
  }
  /** reset with no selected value */
  get resettable() {
    return this._resettable;
  }
  set resettable(value) {
    this._resettable = this._coerceBooleanProperty(value);
  }
  get ariaInvalid() {
    return this._isErrorState();
  }
  get classMaterial() {
    return this.styleMode === "material";
  }
  get classNostyle() {
    return this.styleMode === "noStyle";
  }
  get select2above() {
    return !this.overlay ? this.listPosition === "above" : this._isAbobeOverlay();
  }
  get _positions() {
    if (this.listPosition === "auto") {
      [{
        originX: "start",
        originY: "bottom",
        overlayX: "start",
        overlayY: "bottom"
      }, {
        originX: "start",
        originY: "top",
        overlayX: "start",
        overlayY: "top"
      }];
    } else {
      return null;
    }
  }
  get resultsElement() {
    return this.resultContainer?.nativeElement;
  }
  ngOnInit() {
    this._viewportRuler.change(100).subscribe(() => {
      if (this.isOpen) {
        this.triggerRect();
      }
    });
    const option = Select2Utils.getOptionsByValue(this._data, this._control ? this._control.value : this.value, this.multiple);
    if (option !== null) {
      this.option = option;
    }
    if (!Array.isArray(option)) {
      this.hoveringValue = this.value;
    }
    this.updateSearchBox();
  }
  ngAfterViewInit() {
    this.cdkConnectedOverlay.positionChange.subscribe((posChange) => {
      if (this.listPosition === "auto" && posChange.connectionPair?.originY && this._overlayPosition !== posChange.connectionPair.originY) {
        this.triggerRect();
        this._overlayPosition = posChange.connectionPair.originY;
        this._changeDetectorRef.detectChanges();
      }
    });
    this.selectionElement = this.selection.nativeElement;
    this.triggerRect();
  }
  ngDoCheck() {
    this.updateSearchBox();
    this._dirtyCheckNativeValue();
    if (this._triggerRect) {
      if (this.overlayWidth !== this._triggerRect.width) {
        this.overlayWidth = this._triggerRect.width;
      }
      if (this._dropdownRect?.height > 0 && this.overlayHeight !== this._dropdownRect.height) {
        this.overlayHeight = this.listPosition === "auto" ? this._dropdownRect.height : 0;
      }
    }
  }
  ngOnDestroy() {
    window.document.body.removeEventListener("click", this._clickDetectionFc);
  }
  updateSearchBox() {
    const hidden = this.customSearchEnabled ? false : Select2Utils.isSearchboxHiddex(this._data, this._minCountForSearch);
    if (this.isSearchboxHidden !== hidden) {
      this.isSearchboxHidden = hidden;
    }
  }
  hideSearch() {
    const displaySearchStatus = displaySearchStatusList.indexOf(this.displaySearchStatus) > -1 ? this.displaySearchStatus : "default";
    return displaySearchStatus === "default" && this.isSearchboxHidden || displaySearchStatus === "hidden";
  }
  getOptionStyle(option) {
    return "select2-results__option " + (option.hide ? "select2-results__option--hide " : "") + (option.value === this.hoveringValue ? "select2-results__option--highlighted " : "") + (option.classes || "");
  }
  mouseenter(option) {
    if (!option.disabled) {
      this.hoveringValue = option.value;
    }
  }
  click(option) {
    if (this.testSelection(option)) {
      this.select(option);
    }
  }
  reset(e) {
    this.select(null);
    e.preventDefault();
    e.stopPropagation();
  }
  prevChange(event) {
    event.stopPropagation();
  }
  toggleOpenAndClose() {
    if (this.disabled) {
      return;
    }
    this._focus(true);
    this.isOpen = !this.isOpen;
    if (this.isOpen) {
      this.innerSearchText = "";
      this.updateFilteredData();
      this._focusSearchboxOrResultsElement();
      setTimeout(() => {
        if (this.option) {
          const option = this.option instanceof Array ? this.option[0] : this.option;
          this.updateScrollFromOption(option);
        } else if (this.resultsElement) {
          this.resultsElement.scrollTop = 0;
        }
        setTimeout(() => {
          this.triggerRect();
          this.cdkConnectedOverlay?.overlayRef?.updatePosition();
        }, 100);
      });
      this.open.emit(this);
    } else {
      this.close.emit(this);
    }
    if (this.isOpen && !this._clickDetection) {
      setTimeout(() => {
        window.document.body.addEventListener("click", this._clickDetectionFc, false);
        this._clickDetection = true;
      }, timeout);
    }
    this._changeDetectorRef.markForCheck();
  }
  hasTemplate(option, defaut) {
    return this.templates instanceof TemplateRef || this.templates?.[option.templateId] instanceof TemplateRef || this.templates?.[defaut] instanceof TemplateRef;
  }
  getTemplate(option, defaut) {
    return this.hasTemplate(option, defaut) ? this.templates[option.templateId] || this.templates[defaut] || this.templates : void 0;
  }
  triggerRect() {
    this._triggerRect = this.selectionElement.getBoundingClientRect();
    this._dropdownRect = this.dropdown?.nativeElement ? this.dropdown.nativeElement.getBoundingClientRect() : void 0;
  }
  testSelection(option) {
    if (option.disabled) {
      return false;
    }
    if (!this.multiple || !this.limitSelection || Array.isArray(this._value) && this._value.length < this.limitSelection) {
      return true;
    }
    return false;
  }
  testValueChange(value1, value2) {
    if ((value1 === null || value1 === void 0) && (value2 === null || value2 === void 0) || value1 === value2) {
      return false;
    }
    if (this.multiple && value1?.length && value2?.length && value1.length === value2.length) {
      for (const e1 of value1) {
        const test = value2.indexOf(e1) > -1;
        if (!test) {
          return true;
        }
      }
      return false;
    }
    return true;
  }
  updateFilteredData() {
    setTimeout(() => {
      let result = this._data;
      if (this.multiple && this.hideSelectedItems) {
        result = Select2Utils.getFilteredSelectedData(result, this.option);
      }
      if (!this.customSearchEnabled && this.searchText && this.searchText.length >= +this.minCharForSearch) {
        result = Select2Utils.getFilteredData(result, this.searchText, this.editPattern);
      }
      if (this.maxResults > 0) {
        const data = Select2Utils.getReduceData(result, +this.maxResults);
        result = data.result;
        this.maxResultsExceeded = data.reduce;
      } else {
        this.maxResultsExceeded = false;
      }
      if (Select2Utils.valueIsNotInFilteredData(result, this.hoveringValue)) {
        this.hoveringValue = Select2Utils.getFirstAvailableOption(result);
      }
      this.filteredData = result;
      this._changeDetectorRef.markForCheck();
    });
  }
  clickDetection(e) {
    if (!this.ifParentContainsClass(e.target, "selection")) {
      if (this.isOpen && !this.ifParentContainsClass(e.target, "select2-dropdown")) {
        this.toggleOpenAndClose();
      }
      if (!this.ifParentContainsId(e.target, this._id)) {
        this.clickExit();
      }
    } else if (this.isOpen && !this.ifParentContainsId(e.target, this._id)) {
      this.toggleOpenAndClose();
      this.clickExit();
    }
  }
  clickExit() {
    this._focus(false);
    window.document.body.removeEventListener("click", this._clickDetectionFc);
    this._clickDetection = false;
  }
  ifParentContainsClass(element, cssClass) {
    return this.getParentElementByClass(element, cssClass) !== null;
  }
  ifParentContainsId(element, id) {
    return this.getParentElementById(element, id) !== null;
  }
  getParentElementByClass(element, cssClass) {
    if (this.containClasses(element, cssClass.trim().split(/\s+/))) {
      return element;
    }
    return element.parentElement ? this.getParentElementByClass(element.parentElement, cssClass) : null;
  }
  getParentElementById(element, id) {
    if (element.id === id) {
      return element;
    }
    return element.parentElement ? this.getParentElementById(element.parentElement, id) : null;
  }
  containClasses(element, cssClasses) {
    if (!element.classList) {
      return false;
    }
    for (const cssClass of cssClasses) {
      if (!element.classList.contains(cssClass)) {
        return false;
      }
    }
    return true;
  }
  focusin() {
    if (!this.disabled) {
      this._focus(true);
    }
  }
  focusout() {
    if (this.selectionElement && !this.selectionElement.classList.contains("select2-focused")) {
      this._focus(false);
      this._onTouched();
    }
  }
  select(option) {
    let value;
    if (option !== null) {
      if (this.multiple) {
        const options = this.option;
        const index = options.findIndex((op) => op.value === option.value);
        if (index === -1) {
          options.push(option);
        } else {
          options.splice(index, 1);
        }
        value = this.option.map((op) => op.value);
      } else {
        this.option = option;
        if (this.isOpen) {
          this.isOpen = false;
          this.close.emit(this);
          if (this.selectionElement) {
            this.selectionElement.focus();
          }
        }
        value = this.option.value;
      }
    } else {
      this.option = null;
    }
    if (this.multiple && this.hideSelectedItems) {
      this.updateFilteredData();
    }
    if (this._control) {
      this._onChange(value);
    } else {
      this._value = value;
    }
    this.update.emit({
      component: this,
      value,
      options: Array.isArray(this.option) ? this.option : this.option ? [this.option] : null
    });
  }
  keyDown(e) {
    if (this._testKey(e, ["ArrowDown", 40])) {
      this.moveDown();
      e.preventDefault();
    } else if (this._testKey(e, ["ArrowUp", 38])) {
      this.moveUp();
      e.preventDefault();
    } else if (this._testKey(e, ["Enter", 13])) {
      this.selectByEnter();
      e.preventDefault();
    } else if (this._testKey(e, ["Escape", "Tab", 9, 27]) && this.isOpen) {
      this.toggleOpenAndClose();
      this._focus(false);
    }
  }
  openKey(e) {
    if (this._testKey(e, ["ArrowDown", "ArrowUp", "Enter", 40, 38, 13])) {
      this.toggleOpenAndClose();
      e.preventDefault();
    } else if (this._testKey(e, ["Escape", "Tab", 9, 27])) {
      this._focus(false);
      this._onTouched();
    }
  }
  trackBy(_index, item) {
    return item.value;
  }
  searchUpdate(e) {
    this.searchText = e.target.value;
    this.updateFilteredData();
  }
  isSelected(option) {
    return Select2Utils.isSelected(this.option, option, this.multiple);
  }
  isDisabled(option) {
    return option.disabled ? "true" : "false";
  }
  removeSelection(e, option) {
    Select2Utils.removeSelection(this.option, option);
    if (this.multiple && this.hideSelectedItems) {
      this.updateFilteredData();
    }
    const value = this.option.map((op) => op.value);
    if (this._control) {
      this._onChange(value);
    } else {
      this._value = value;
    }
    this.update.emit({
      component: this,
      value,
      options: Array.isArray(this.option) ? this.option : this.option ? [this.option] : null
    });
    this.removeOption.emit({
      component: this,
      value,
      removedOption: option
    });
    e.preventDefault();
    e.stopPropagation();
    if (this.isOpen) {
      this._focusSearchboxOrResultsElement();
    }
  }
  /**
   * Sets the model value. Implemented as part of ControlValueAccessor.
   * @param value
   */
  writeValue(value) {
    this._setSelectionByValue(value);
  }
  /**
   * Saves a callback function to be invoked when the select's value
   * changes from user input. Part of the ControlValueAccessor interface
   * required to integrate with Angular's core forms API.
   *
   * @param fn Callback to be triggered when the value changes.
   */
  registerOnChange(fn) {
    this._onChange = fn;
  }
  /**
   * Saves a callback function to be invoked when the select is blurred
   * by the user. Part of the ControlValueAccessor interface required
   * to integrate with Angular's core forms API.
   *
   * @param fn Callback to be triggered when the component has been touched.
   */
  registerOnTouched(fn) {
    this._onTouched = fn;
  }
  /**
   * Sets whether the component should be disabled.
   * Implemented as part of ControlValueAccessor.
   * @param isDisabled
   */
  setDisabledState(isDisabled) {
    this.disabled = isDisabled;
  }
  onScroll(way) {
    this.scroll.emit({
      component: this,
      way,
      search: this.innerSearchText
    });
  }
  _isErrorState() {
    const isInvalid = this._control && this._control.invalid;
    const isTouched = this._control && this._control.touched;
    const isSubmitted = this._parentFormGroup && this._parentFormGroup.submitted || this._parentForm && this._parentForm.submitted;
    return !!(isInvalid && (isTouched || isSubmitted));
  }
  moveUp() {
    this.updateScrollFromOption(Select2Utils.getPreviousOption(this.filteredData, this.hoveringValue));
  }
  moveDown() {
    this.updateScrollFromOption(Select2Utils.getNextOption(this.filteredData, this.hoveringValue));
  }
  updateScrollFromOption(option) {
    if (option) {
      this.hoveringValue = option.value;
      const domElement = this.results.find((r) => r.nativeElement.innerText.trim() === option.label);
      if (domElement && this.resultsElement) {
        this.resultsElement.scrollTop = 0;
        const listClientRect = this.resultsElement.getBoundingClientRect();
        const optionClientRect = domElement.nativeElement.getBoundingClientRect();
        this.resultsElement.scrollTop = optionClientRect.top - listClientRect.top;
      }
    }
  }
  selectByEnter() {
    if (this.hoveringValue) {
      const option = Select2Utils.getOptionByValue(this._data, this.hoveringValue);
      this.select(option);
    }
  }
  _testKey(event, refs = []) {
    return this._isKey(this._getKey(event), refs);
  }
  _getKey(event) {
    let code;
    if (event.key !== void 0) {
      code = event.key;
    } else if (event["keyIdentifier"] !== void 0) {
      code = event["keyIdentifier"];
    } else if (event["keyCode"] !== void 0) {
      code = event["keyCode"];
    } else {
      event.preventDefault();
    }
    return code;
  }
  _isKey(code, refs = []) {
    return refs && refs.length > 0 ? refs.indexOf(code) !== -1 : false;
  }
  /**
   * Sets the selected option based on a value. If no option can be
   * found with the designated value, the select trigger is cleared.
   */
  _setSelectionByValue(value) {
    if (this.option || value !== void 0 && value !== null) {
      const isArray = Array.isArray(value);
      if (this.multiple && value && !isArray) {
        throw new Error("Non array value.");
      } else if (this._data) {
        if (this.multiple) {
          this.option = [];
          if (isArray) {
            const selectedValues = Select2Utils.getOptionsByValue(this._data, value, this.multiple);
            selectedValues.map((item) => this.select(item));
          }
        } else {
          this.select(Select2Utils.getOptionByValue(this._data, value));
        }
      } else if (this._control) {
        this._control.viewToModelUpdate(value);
      }
      this._changeDetectorRef.markForCheck();
    }
  }
  /** Does some manual dirty checking on the native input `value` property. */
  _dirtyCheckNativeValue() {
    const newValue = this.value;
    if (this._previousNativeValue !== newValue) {
      this._previousNativeValue = newValue;
      this._stateChanges.next();
    }
  }
  _coerceBooleanProperty(value) {
    return value != null && `${value}` !== "false";
  }
  _focusSearchboxOrResultsElement() {
    if (!this.isSearchboxHidden) {
      setTimeout(() => {
        if (this.searchInput && this.searchInput.nativeElement) {
          this.searchInput.nativeElement.focus();
        }
      });
    } else if (this.resultsElement) {
      this.resultsElement.focus();
    }
  }
  _focus(state) {
    if (!state && this.focused) {
      this.focused = state;
      this.blur.emit(this);
    } else if (state && !this.focused) {
      this.focused = state;
      this.focus.emit(this);
    }
  }
  _isAbobeOverlay() {
    return this.overlay && this._overlayPosition && this.listPosition === "auto" ? this._overlayPosition === "top" : this.listPosition === "above";
  }
};
Select2.ɵfac = function Select2_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || Select2)(ɵɵdirectiveInject(ViewportRuler), ɵɵdirectiveInject(ChangeDetectorRef), ɵɵdirectiveInject(NgForm, 8), ɵɵdirectiveInject(FormGroupDirective, 8), ɵɵdirectiveInject(NgControl, 10), ɵɵinjectAttribute("tabindex"));
};
Select2.ɵcmp = ɵɵdefineComponent({
  type: Select2,
  selectors: [["select2"]],
  viewQuery: function Select2_Query(rf, ctx) {
    if (rf & 1) {
      ɵɵviewQuery(CdkConnectedOverlay, 5);
      ɵɵviewQuery(_c0, 7);
      ɵɵviewQuery(_c1, 5);
      ɵɵviewQuery(_c2, 5);
      ɵɵviewQuery(_c3, 5);
      ɵɵviewQuery(_c4, 5);
    }
    if (rf & 2) {
      let _t;
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.cdkConnectedOverlay = _t.first);
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.selection = _t.first);
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.resultContainer = _t.first);
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.searchInput = _t.first);
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.dropdown = _t.first);
      ɵɵqueryRefresh(_t = ɵɵloadQuery()) && (ctx.results = _t);
    }
  },
  hostVars: 8,
  hostBindings: function Select2_HostBindings(rf, ctx) {
    if (rf & 2) {
      ɵɵhostProperty("id", ctx.id);
      ɵɵattribute("aria-invalid", ctx.ariaInvalid);
      ɵɵclassProp("material", ctx.classMaterial)("nostyle", ctx.classNostyle)("select2-above", ctx.select2above);
    }
  },
  inputs: {
    data: "data",
    minCharForSearch: "minCharForSearch",
    displaySearchStatus: "displaySearchStatus",
    placeholder: "placeholder",
    customSearchEnabled: "customSearchEnabled",
    limitSelection: "limitSelection",
    listPosition: "listPosition",
    multiple: "multiple",
    overlay: "overlay",
    styleMode: "styleMode",
    noResultMessage: "noResultMessage",
    maxResults: "maxResults",
    maxResultsMessage: "maxResultsMessage",
    infiniteScrollDistance: "infiniteScrollDistance",
    infiniteScrollThrottle: "infiniteScrollThrottle",
    infiniteScroll: "infiniteScroll",
    editPattern: "editPattern",
    templates: "templates",
    resultMaxHeight: "resultMaxHeight",
    minCountForSearch: "minCountForSearch",
    id: "id",
    required: "required",
    disabled: "disabled",
    hideSelectedItems: "hideSelectedItems",
    readonly: "readonly",
    value: "value",
    tabIndex: "tabIndex",
    resettable: "resettable"
  },
  outputs: {
    update: "update",
    open: "open",
    close: "close",
    focus: "focus",
    blur: "blur",
    search: "search",
    scroll: "scroll",
    removeOption: "removeOption"
  },
  standalone: false,
  ngContentSelectors: _c6,
  decls: 18,
  vars: 26,
  consts: [["selection", "", "trigger", "cdkOverlayOrigin"], ["containerTemplate", ""], ["dropdown", ""], ["searchInput", ""], ["results", ""], ["optGroup", ""], ["result", ""], ["liGroup", ""], ["li", ""], [1, "select2-label", 3, "click"], ["class", "select2-required", 4, "ngIf"], [1, "select2", "select2-container", "select2-container--default", "select2-container--focus"], ["cdkOverlayOrigin", "", 1, "selection", 3, "click", "focus", "blur", "keydown"], ["role", "combobox", 1, "select2-selection"], ["class", "select2-selection__rendered", 3, "title", 4, "ngIf"], ["class", "select2-selection__reset", "role", "presentation", 3, "click", 4, "ngIf"], ["class", "select2-selection__arrow", "role", "presentation", 4, "ngIf"], ["class", "select2-selection__rendered", 4, "ngIf"], [4, "ngIf"], [1, "select2-subscript-wrapper"], ["cdkConnectedOverlay", "", "cdkConnectedOverlayHasBackdrop", "", "cdkConnectedOverlayBackdropClass", "select2-overlay-backdrop", 3, "backdropClick", "cdkConnectedOverlayOrigin", "cdkConnectedOverlayOpen", "cdkConnectedOverlayMinWidth", "cdkConnectedOverlayHeight", "cdkConnectedOverlayPositions"], [1, "select2-required"], [1, "select2-selection__rendered", 3, "title"], [3, "innerHTML", 4, "ngIf"], [1, "select2-selection__placeholder"], [3, "innerHTML"], ["role", "presentation", 1, "select2-selection__reset", 3, "click"], ["role", "presentation", 1, "select2-selection__arrow"], [1, "select2-selection__rendered"], ["class", "select2-selection__choice", 3, "title", 4, "ngFor", "ngForOf", "ngForTrackBy"], [1, "select2-selection__choice", 3, "title"], ["class", "select2-selection__choice__remove", "role", "presentation", 3, "click", 4, "ngIf"], ["role", "presentation", 1, "select2-selection__choice__remove", 3, "click"], [4, "ngTemplateOutlet"], [1, "select2-container", "select2-container--default", "select2-container-dropdown"], [1, "select2-dropdown"], [1, "select2-search", "select2-search--dropdown"], ["type", "search", "role", "textbox", "autocomplete", "off", "autocorrect", "off", "autocapitalize", "off", "spellcheck", "false", 1, "select2-search__field", 3, "keydown", "keyup", "change", "id", "value"], [1, "select2-results"], ["role", "tree", "tabindex", "-1", "infiniteScroll", "", 1, "select2-results__options", 3, "scrolled", "scrolledUp", "keydown", "infiniteScrollDisabled", "infiniteScrollDistance", "infiniteScrollThrottle", "infiniteScrollContainer"], [4, "ngFor", "ngForOf", "ngForTrackBy"], ["class", "select2-no-result select2-results__option", 3, "innerHTML", 4, "ngIf"], ["class", "select2-too-much-result select2-results__option", 3, "innerHTML", 4, "ngIf"], ["class", "select2-results__option", "role", "group", 4, "ngIf"], ["role", "treeitem", 3, "id", "class", "mouseenter", "click", 4, "ngIf"], ["role", "group", 1, "select2-results__option"], [3, "innerHTML", 4, "ngIf", "ngIfElse"], [1, "select2-results__options", "select2-results__options--nested"], ["role", "treeitem", 3, "id", "class", "mouseenter", "click", 4, "ngFor", "ngForOf", "ngForTrackBy"], [4, "ngTemplateOutlet", "ngTemplateOutletContext"], ["role", "treeitem", 3, "mouseenter", "click", "id"], ["class", "select2-label-content", 3, "innerHTML", 4, "ngIf", "ngIfElse"], [1, "select2-label-content", 3, "innerHTML"], [1, "select2-no-result", "select2-results__option", 3, "innerHTML"], [1, "select2-too-much-result", "select2-results__option", 3, "innerHTML"]],
  template: function Select2_Template(rf, ctx) {
    if (rf & 1) {
      const _r1 = ɵɵgetCurrentView();
      ɵɵprojectionDef(_c5);
      ɵɵelementStart(0, "div", 9);
      ɵɵlistener("click", function Select2_Template_div_click_0_listener() {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.toggleOpenAndClose());
      });
      ɵɵprojection(1);
      ɵɵtemplate(2, Select2_span_2_Template, 1, 0, "span", 10);
      ɵɵelementEnd();
      ɵɵelementStart(3, "div", 11)(4, "div", 12, 0);
      ɵɵlistener("click", function Select2_Template_div_click_4_listener() {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.toggleOpenAndClose());
      })("focus", function Select2_Template_div_focus_4_listener() {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.focusin());
      })("blur", function Select2_Template_div_blur_4_listener() {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.focusout());
      })("keydown", function Select2_Template_div_keydown_4_listener($event) {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.openKey($event));
      });
      ɵɵelementStart(7, "div", 13);
      ɵɵtemplate(8, Select2_span_8_Template, 5, 6, "span", 14)(9, Select2_span_9_Template, 2, 0, "span", 15)(10, Select2_span_10_Template, 1, 0, "span", 16)(11, Select2_ul_11_Template, 4, 5, "ul", 17);
      ɵɵelementEnd()();
      ɵɵtemplate(12, Select2_ng_container_12_Template, 2, 1, "ng-container", 18);
      ɵɵelementStart(13, "div", 19);
      ɵɵprojection(14, 1);
      ɵɵelementEnd()();
      ɵɵtemplate(15, Select2_ng_template_15_Template, 1, 1, "ng-template", 20);
      ɵɵlistener("backdropClick", function Select2_Template_ng_template_backdropClick_15_listener() {
        ɵɵrestoreView(_r1);
        return ɵɵresetView(ctx.toggleOpenAndClose());
      });
      ɵɵtemplate(16, Select2_ng_template_16_Template, 12, 25, "ng-template", null, 1, ɵɵtemplateRefExtractor);
    }
    if (rf & 2) {
      const trigger_r19 = ɵɵreference(6);
      ɵɵadvance(2);
      ɵɵproperty("ngIf", ctx.required);
      ɵɵadvance();
      ɵɵclassProp("select2-container--below", !ctx.select2above)("select2-container--above", ctx.select2above)("select2-container--open", ctx.isOpen)("select2-container--disabled", ctx.disabled);
      ɵɵadvance();
      ɵɵclassProp("select2-focused", ctx.focused);
      ɵɵattribute("tabindex", !ctx.isOpen ? ctx.tabIndex : "-1");
      ɵɵadvance(3);
      ɵɵclassProp("select2-selection--multiple", ctx.multiple)("select2-selection--single", !ctx.multiple);
      ɵɵadvance();
      ɵɵproperty("ngIf", !ctx.multiple);
      ɵɵadvance();
      ɵɵproperty("ngIf", !ctx.multiple && ctx.resettable && ctx.select2Option && !(ctx.disabled || ctx.readonly));
      ɵɵadvance();
      ɵɵproperty("ngIf", !ctx.multiple);
      ɵɵadvance();
      ɵɵproperty("ngIf", ctx.multiple);
      ɵɵadvance();
      ɵɵproperty("ngIf", !ctx.overlay);
      ɵɵadvance(3);
      ɵɵproperty("cdkConnectedOverlayOrigin", trigger_r19)("cdkConnectedOverlayOpen", ctx.isOpen && ctx.overlay)("cdkConnectedOverlayMinWidth", ctx.overlayWidth)("cdkConnectedOverlayHeight", ctx.overlayHeight)("cdkConnectedOverlayPositions", ctx._positions);
    }
  },
  dependencies: [NgForOf, NgIf, NgTemplateOutlet, CdkConnectedOverlay, CdkOverlayOrigin, InfiniteScrollDirective],
  styles: ['.select2-label[_ngcontent-%COMP%]{color:#000;color:var(--select2-label-text-color, #000)}.select2-container[_ngcontent-%COMP%]{box-sizing:border-box;display:inline-block;margin:0;position:relative;vertical-align:middle;width:100%}.select2-container[_ngcontent-%COMP%]   .select2-container-dropdown[_ngcontent-%COMP%]{position:absolute;width:0px;opacity:0}.select2-container[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]{box-sizing:border-box;cursor:pointer;display:block;height:28px;-webkit-user-select:none;user-select:none}.select2-container[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]{display:block;padding:0 0 0 8px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;flex:1 1 auto}.select2-container[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__clear[_ngcontent-%COMP%]{position:relative}.select2-container[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{box-sizing:border-box;cursor:pointer;display:block;min-height:32px;-webkit-user-select:none;user-select:none}.select2-container[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]{display:inline-block;overflow:hidden;padding-left:8px;text-overflow:ellipsis;white-space:nowrap}.select2-container[_ngcontent-%COMP%]   .select2-search--inline[_ngcontent-%COMP%]{float:left}.select2-container[_ngcontent-%COMP%]   .select2-search--inline[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]{box-sizing:border-box;border:none;font-size:100%;margin-top:5px;padding:0}.select2-container[_ngcontent-%COMP%]   .select2-search--inline[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]::-webkit-search-cancel-button{-webkit-appearance:none}.select2-dropdown[_ngcontent-%COMP%]{background:white;background:var(--select2-dropdown-background, white);border:1px solid #aaa;border:1px solid var(--select2-dropdown-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);box-sizing:border-box;display:block;position:absolute;width:100%;z-index:1051;height:0;overflow:hidden}.select2-dropdown[_ngcontent-%COMP%]   .select2-label-content[_ngcontent-%COMP%]{display:contents}.select2-results[_ngcontent-%COMP%]{display:block}.select2-results__options[_ngcontent-%COMP%]{list-style:none;margin:0;padding:0}.select2-results__option[_ngcontent-%COMP%]{padding:6px;-webkit-user-select:none;user-select:none;color:#000;color:var(--select2-option-text-color, #000)}.select2-results__option[aria-selected][_ngcontent-%COMP%]{cursor:pointer}.select2-container.select2-container-dropdown.select2-container--open[_ngcontent-%COMP%]{width:100%;opacity:1}.select2-container--open[_ngcontent-%COMP%]   .select2-dropdown[_ngcontent-%COMP%]{overflow:auto;height:auto}.select2-container--open[_ngcontent-%COMP%]   .select2-dropdown--above[_ngcontent-%COMP%]{border-bottom:none;border-bottom-left-radius:0;border-bottom-right-radius:0;bottom:27px;display:flex;flex-direction:column-reverse}.select2-container--open[_ngcontent-%COMP%]   .select2-dropdown--below[_ngcontent-%COMP%]{border-top:none;border-top-left-radius:0;border-top-right-radius:0}.select2-search--dropdown[_ngcontent-%COMP%]{display:block;padding:4px}.select2-search--dropdown[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]{padding:4px;width:100%;box-sizing:border-box}.select2-search--dropdown[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]::-webkit-search-cancel-button{-webkit-appearance:none}.select2-search--dropdown.select2-search--hide[_ngcontent-%COMP%]{display:none}.select2-close-mask[_ngcontent-%COMP%]{border:0;margin:0;padding:0;display:block;position:fixed;left:0;top:0;min-height:100%;min-width:100%;height:auto;width:auto;opacity:0;z-index:99;background:#fff;filter:alpha(opacity=0)}.select2-required[_ngcontent-%COMP%]:before{content:"*";color:red;color:var(--select2-required-color, red)}.select2-hidden-accessible[_ngcontent-%COMP%]{border:0!important;clip:rect(0 0 0 0)!important;height:1px!important;margin:-1px!important;overflow:hidden!important;padding:0!important;position:absolute!important;width:1px!important}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]{background:#fff;background:var(--select2-selection-background, #fff);border:1px solid #aaa;border:1px solid var(--select2-selection-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);display:flex}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]{color:#444;color:var(--select2-selection-text-color, #444);line-height:28px}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__clear[_ngcontent-%COMP%]{cursor:pointer;float:right;font-weight:700}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__placeholder[_ngcontent-%COMP%]{color:#999;color:var(--select2-placeholder-color, #999)}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__placeholder[_ngcontent-%COMP%]   span[_ngcontent-%COMP%]{overflow:hidden;white-space:nowrap;text-overflow:ellipsis;text-overflow:var(--select2-placeholder-overflow, ellipsis)}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__placeholder__option[_ngcontent-%COMP%]{display:none}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__reset[_ngcontent-%COMP%], .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__arrow[_ngcontent-%COMP%]{display:flex;width:20px;align-items:center;justify-content:center}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__arrow[_ngcontent-%COMP%]:before{content:" ";border-color:#888 transparent;border-color:var(--select2-arrow-color, #888) transparent;border-style:solid;border-width:5px 4px 0;height:0;width:0}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__reset[_ngcontent-%COMP%]{color:#999;color:var(--select2-reset-color, #999)}.select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]{background:#eee;background:var(--select2-selection-disabled-background, #eee);cursor:default}.select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__clear[_ngcontent-%COMP%]{display:none}.select2-container--default.select2-container--open[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__arrow[_ngcontent-%COMP%]:before{border-color:transparent transparent #888;border-color:transparent transparent var(--select2-arrow-color, #888);border-width:0 4px 5px}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{background:#fff;background:var(--select2-selection-background, #fff);border:1px solid #aaa;border:1px solid var(--select2-selection-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);cursor:text}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]{flex:1 1 auto;box-sizing:border-box;list-style:none;margin:0;padding:0 5px;width:100%}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]   li[_ngcontent-%COMP%]{list-style:none}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__placeholder[_ngcontent-%COMP%]{display:block;width:100%;color:#999;color:var(--select2-placeholder-color, #999);margin-top:5px;float:left;overflow:hidden;white-space:nowrap;text-overflow:ellipsis;text-overflow:var(--select2-placeholder-overflow, ellipsis)}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__placeholder__option[_ngcontent-%COMP%]{display:none}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__clear[_ngcontent-%COMP%]{cursor:pointer;float:right;font-weight:700;margin-top:5px;margin-right:10px}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__choice[_ngcontent-%COMP%]{color:#000;color:var(--select2-selection-choice-text-color, #000);background:#e4e4e4;background:var(--select2-selection-choice-background, #e4e4e4);border:1px solid #aaa;border:1px solid var(--select2-selection-choice-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);cursor:default;float:left;margin-right:5px;margin-top:5px;padding:0 5px}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__choice__remove[_ngcontent-%COMP%]{color:#999;color:var(--select2-selection-choice-close-color, #999);cursor:pointer;display:inline-block;font-weight:700;margin-right:2px}.select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__choice__remove[_ngcontent-%COMP%]:hover{color:#333;color:var(--select2-selection-choice-hover-close-color, #333)}.select2-container--default.select2-container--focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{border:solid #000 1px;border:solid var(--select2-selection-focus-border-color, #000) 1px;outline:none}.select2-container--default[_ngcontent-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .select2-container--default[_ngcontent-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{border:solid #000 1px;border:solid var(--select2-selection-focus-border-color, #000) 1px;outline:none}.select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{background:#eee;background:var(--select2-selection-disabled-background, #eee);cursor:default}.select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection__choice__remove[_ngcontent-%COMP%]{display:none}.select2-container--default.select2-container--open.select2-container--above[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .select2-container--default.select2-container--open.select2-container--above[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{border-top-left-radius:0;border-top-right-radius:0}.select2-container--default.select2-container--open.select2-container--below[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .select2-container--default.select2-container--open.select2-container--below[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{border-bottom-left-radius:0;border-bottom-right-radius:0}.select2-container--default[_ngcontent-%COMP%]   .select2-search--dropdown[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]{border:1px solid #aaa;border:1px solid var(--select2-search-border-color, #aaa);background:#fff;background:1px solid var(--select2-search-background, #fff);border-radius:0;border-radius:var(--select2-search-border-radius, 0px)}.select2-container--default[_ngcontent-%COMP%]   .select2-search--inline[_ngcontent-%COMP%]   .select2-search__field[_ngcontent-%COMP%]{background:transparent;border:none;outline:none;box-shadow:none;-webkit-appearance:textfield}.select2-container--default[_ngcontent-%COMP%]   .select2-results[_ngcontent-%COMP%] > .select2-results__options[_ngcontent-%COMP%]{overflow-y:auto}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[role=group][_ngcontent-%COMP%]{padding:0}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[aria-disabled=true][_ngcontent-%COMP%]{color:#999;color:var(--select2-option-disabled-text-color, #999);background:transparent;background:var(--select2-option-disabled-background, transparent)}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[aria-selected=true][_ngcontent-%COMP%]{color:#000;color:var(--select2-option-selected-text-color, #000);background:#ddd;background:var(--select2-option-selected-background, #ddd)}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{padding-left:1em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__group[_ngcontent-%COMP%]{padding-left:0}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{margin-left:-1em;padding-left:2em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{margin-left:-2em;padding-left:3em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{margin-left:-3em;padding-left:4em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{margin-left:-4em;padding-left:5em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]   .select2-results__option[_ngcontent-%COMP%]{margin-left:-5em;padding-left:6em}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option--highlighted[aria-selected][_ngcontent-%COMP%]{background:#5897fb;background:var(--select2-option-highlighted-background, #5897fb);color:#fff;color:var(--select2-option-highlighted-text-color, #fff)}.select2-container--default[_ngcontent-%COMP%]   .select2-results__option--hide[_ngcontent-%COMP%]{display:none}.select2-container--default[_ngcontent-%COMP%]   .select2-results__group[_ngcontent-%COMP%]{cursor:default;display:block;padding:6px;color:gray;color:var(--select2-option-group-text-color, gray);background:transparent;background:var(--select2-option-group-background, transparent)}.select2-no-result[_ngcontent-%COMP%]{color:#888;color:var(--select2-no-result-color, #888);font-style:italic;font-style:var(--select2-no-result-font-style, italic)}.select2-too-much-result[_ngcontent-%COMP%]{color:#888;color:var(--select2-too-much-result-color, #888);font-style:italic;font-style:var(--select2-too-much-font-style, italic)}.nostyle[_nghost-%COMP%]   .select2-dropdown[_ngcontent-%COMP%]{border-color:transparent}.nostyle[_nghost-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .nostyle[_nghost-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{background:transparent;border-color:transparent}.nostyle[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-focused[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .nostyle[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%], .nostyle[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .nostyle[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{background:transparent;border-color:transparent}.material[_nghost-%COMP%]{display:inline-block;width:300px}.material[_nghost-%COMP%] > .select2-container[_ngcontent-%COMP%]{padding-bottom:1.29688em;vertical-align:inherit}.material[_nghost-%COMP%] > .select2-container[_ngcontent-%COMP%]   .selection[_ngcontent-%COMP%]{padding:.4375em 0;border-top:.84375em solid transparent;display:inline-flex;align-items:baseline;width:100%;height:auto}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{width:100%;border:0;border-radius:0;height:24px;box-sizing:border-box}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:before, .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:before{content:" ";display:block;position:absolute;bottom:1.65em;background:#ddd;background:var(--select2-material-underline, #ddd);height:1px;width:100%}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:after, .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:after{content:" ";display:block;position:absolute;bottom:1.63em;background:#5a419e;background:var(--select2-material-underline-active, #5a419e);height:2px;width:0%;left:50%;transition:none}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%], .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__rendered[_ngcontent-%COMP%]{padding-left:1px;line-height:inherit}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]   .select2-selection__placeholder[_ngcontent-%COMP%], .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]   .select2-selection__placeholder[_ngcontent-%COMP%]{display:block;color:#00000061;color:var(--select2-material-placeholder-color, rgba(0, 0, 0, .38));transition:transform .3s;position:absolute;transform-origin:0 21px;left:0;top:20px}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-container--open[_ngcontent-%COMP%]{left:0;bottom:1.6em}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection__placeholder__option[_ngcontent-%COMP%]{transform:translateY(-1.5em) scale(.75) perspective(100px) translateZ(.001px);width:133.33333%}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection__arrow[_ngcontent-%COMP%]{top:20px}.material[_nghost-%COMP%]   .select2-container--default.select2-container--open[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:after, .material[_nghost-%COMP%]   .select2-container--default.select2-container--open[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:after, .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-focused[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:after, .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:after{transition:width .3s cubic-bezier(.12,1,.77,1),left .3s cubic-bezier(.12,1,.77,1);width:100%;left:0%}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-dropdown[_ngcontent-%COMP%]{border-radius:0;border:0;box-shadow:0 5px 5px #00000080}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-results__option[aria-selected=true][_ngcontent-%COMP%], .material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-results__option--highlighted[aria-selected][_ngcontent-%COMP%]{background:rgba(0,0,0,.04);background:var(--select2-material-option-selected-background, rgba(0, 0, 0, .04));color:#000;color:var(--select2-material-option-highlighted-text-color, #000)}.material[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-results__option[aria-selected=true][_ngcontent-%COMP%]{color:#ff5722;color:var(--select2-material-option-selected-text-color, #ff5722)}.material[_nghost-%COMP%]   .select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .material[_nghost-%COMP%]   .select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{background:transparent}.material[_nghost-%COMP%]   .select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:before, .material[_nghost-%COMP%]   .select2-container--default.select2-container--disabled[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:before{background:linear-gradient(to right,rgba(0,0,0,.26) 0,rgba(0,0,0,.26) 33%,transparent 0);background:var(--select2-material-underline-disabled, linear-gradient(to right, rgba(0, 0, 0, .26) 0, rgba(0, 0, 0, .26) 33%, transparent 0));background-size:4px 1px;background-repeat:repeat-x;background-position:0 bottom}.material.ng-invalid.ng-touched[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:before, .material.ng-invalid.ng-touched[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%]:after, .material.ng-invalid.ng-touched[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:before, .material.ng-invalid.ng-touched[_nghost-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]:after{background:red;background:var(--select2-material-underline-invalid, red)}.material[_nghost-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], .material[_nghost-%COMP%]:not(.select2-container--open)   .select2-focused[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{border:0}.material[_nghost-%COMP%]   .select2-subscript-wrapper[_ngcontent-%COMP%]{position:absolute;top:calc(100% - 1.72917em);font-size:75%;color:#888;color:var(--select2-hint-text-color, #888)}  .select2-overlay-backdrop{background:rgba(0,0,0,.32);background:var(--select2-overlay-backdrop, transparent)}  .cdk-overlay-container .select2-container .select2-dropdown.select2-dropdown--above{bottom:28px}  .cdk-overlay-container .select2-container--open.select2-position-auto .select2-dropdown{margin-bottom:28px}  .cdk-overlay-container .select2-container--open.select2-position-auto .select2-dropdown.select2-dropdown--above{bottom:0;margin-bottom:0;margin-top:28px}@supports (-moz-appearance: none){select2.material[_ngcontent-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], select2.material[_ngcontent-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{height:26px}}@supports (-ms-scroll-limit: 0){select2.material[_ngcontent-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--single[_ngcontent-%COMP%], select2.material[_ngcontent-%COMP%]   .select2-container--default[_ngcontent-%COMP%]   .select2-selection--multiple[_ngcontent-%COMP%]{height:25px}}']
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(Select2, [{
    type: Component,
    args: [{
      selector: "select2",
      template: `<div class="select2-label" (click)="toggleOpenAndClose()">
    <ng-content select="select2-label"></ng-content>
    <span *ngIf="required" class="select2-required"></span>
</div>
<div
    class="select2 select2-container select2-container--default select2-container--focus"
    [class.select2-container--below]="!select2above"
    [class.select2-container--above]="select2above"
    [class.select2-container--open]="isOpen"
    [class.select2-container--disabled]="disabled"
>
    <div
        class="selection"
        #selection
        #trigger="cdkOverlayOrigin"
        [attr.tabindex]="!this.isOpen ? tabIndex : '-1'"
        (click)="toggleOpenAndClose()"
        (focus)="focusin()"
        (blur)="focusout()"
        (keydown)="openKey($event)"
        cdkOverlayOrigin
        [class.select2-focused]="focused"
    >
        <div
            class="select2-selection"
            [class.select2-selection--multiple]="multiple"
            [class.select2-selection--single]="!multiple"
            role="combobox"
        >
            <span *ngIf="!multiple" class="select2-selection__rendered" [title]="select2Option?.label || ''">
                <span *ngIf="!select2Option">&nbsp;</span>
                <span *ngIf="select2Option" [innerHTML]="select2Option.label"></span>
                <span [class.select2-selection__placeholder__option]="option" class="select2-selection__placeholder">{{
                    placeholder
                }}</span>
            </span>
            <span
                (click)="reset($event)"
                *ngIf="!multiple && resettable && select2Option && !(disabled || readonly)"
                class="select2-selection__reset"
                role="presentation"
                >×</span
            >
            <span *ngIf="!multiple" class="select2-selection__arrow" role="presentation"> </span>
            <ul *ngIf="multiple" class="select2-selection__rendered">
                <span
                    [class.select2-selection__placeholder__option]="select2Options?.length > 0"
                    class="select2-selection__placeholder"
                    >{{ placeholder }}</span
                >
                <li *ngFor="let op of option; trackBy: trackBy" class="select2-selection__choice" [title]="op.label">
                    <span
                        *ngIf="!(disabled || readonly)"
                        (click)="removeSelection($event, op)"
                        class="select2-selection__choice__remove"
                        role="presentation"
                        >×</span
                    >
                    <span [innerHTML]="op.label"></span>
                </li>
            </ul>
        </div>
    </div>
    <ng-container *ngIf="!overlay">
        <ng-container *ngTemplateOutlet="containerTemplate"></ng-container>
    </ng-container>

    <div class="select2-subscript-wrapper">
        <ng-content select="select2-hint"></ng-content>
    </div>
</div>

<ng-template
    cdkConnectedOverlay
    cdkConnectedOverlayHasBackdrop
    cdkConnectedOverlayBackdropClass="select2-overlay-backdrop"
    [cdkConnectedOverlayOrigin]="trigger"
    [cdkConnectedOverlayOpen]="this.isOpen && overlay"
    [cdkConnectedOverlayMinWidth]="overlayWidth"
    [cdkConnectedOverlayHeight]="overlayHeight"
    [cdkConnectedOverlayPositions]="_positions"
    (backdropClick)="toggleOpenAndClose()"
>
    <ng-container *ngTemplateOutlet="containerTemplate"></ng-container>
</ng-template>

<ng-template #containerTemplate>
    <div
        class="select2-container select2-container--default select2-container-dropdown"
        [class.select2-container--open]="isOpen"
        [class.select2-overlay]="overlay"
        [class.select2-position-auto]="listPosition === 'auto'"
    >
        <div
            #dropdown
            class="select2-dropdown"
            [class.select2-dropdown--below]="!select2above"
            [class.select2-dropdown--above]="select2above"
        >
            <div class="select2-search select2-search--dropdown" [class.select2-search--hide]="hideSearch()">
                <input
                    #searchInput
                    [id]="id + '-search-field'"
                    [value]="searchText"
                    (keydown)="keyDown($event)"
                    (keyup)="searchUpdate($event)"
                    (change)="prevChange($event)"
                    class="select2-search__field"
                    type="search"
                    role="textbox"
                    autocomplete="off"
                    autocorrect="off"
                    autocapitalize="off"
                    spellcheck="false"
                    [attr.tabindex]="this.isOpen ? tabIndex : '-1'"
                />
            </div>
            <div class="select2-results">
                <ul
                    #results
                    class="select2-results__options"
                    [style.max-height]="resultMaxHeight"
                    role="tree"
                    tabindex="-1"
                    infiniteScroll
                    [infiniteScrollDisabled]="!infiniteScroll && !isOpen"
                    [infiniteScrollDistance]="infiniteScrollDistance"
                    [infiniteScrollThrottle]="infiniteScrollThrottle"
                    [infiniteScrollContainer]="results"
                    (scrolled)="onScroll('down')"
                    (scrolledUp)="onScroll('up')"
                    (keydown)="keyDown($event)"
                >
                    <ng-container *ngFor="let groupOrOption of filteredData; index as i; trackBy: trackBy">
                        <li *ngIf="groupOrOption.options" class="select2-results__option" role="group">
                            <strong
                                *ngIf="!hasTemplate(groupOrOption, 'group'); else optGroup"
                                [attr.class]="
                                    'select2-results__group' +
                                    (groupOrOption.classes ? ' ' + groupOrOption.classes : '')
                                "
                                [innerHTML]="groupOrOption.label"
                            ></strong>
                            <ng-template #optGroup>
                                <ng-container
                                    *ngTemplateOutlet="getTemplate(groupOrOption, 'group'); context: groupOrOption"
                                >
                                </ng-container>
                            </ng-template>

                            <ul class="select2-results__options select2-results__options--nested">
                                <li
                                    *ngFor="let option of groupOrOption.options; index as j; trackBy: trackBy"
                                    #result
                                    [id]="option.id || id + '-option-' + i + '-' + j"
                                    [class]="getOptionStyle(option)"
                                    role="treeitem"
                                    [attr.aria-selected]="isSelected(option)"
                                    [attr.aria-disabled]="isDisabled(option)"
                                    (mouseenter)="mouseenter(option)"
                                    (click)="click(option)"
                                >
                                    <div
                                        *ngIf="!hasTemplate(option, 'option'); else liGroup"
                                        class="select2-label-content"
                                        [innerHTML]="option.label"
                                    ></div>
                                    <ng-template #liGroup>
                                        <ng-container
                                            *ngTemplateOutlet="getTemplate(option, 'option'); context: option"
                                        >
                                        </ng-container>
                                    </ng-template>
                                </li>
                            </ul>
                        </li>
                        <li
                            *ngIf="!groupOrOption.options"
                            #result
                            [id]="groupOrOption.id || id + '-option-' + i"
                            [class]="getOptionStyle(groupOrOption)"
                            role="treeitem"
                            [attr.aria-selected]="isSelected(groupOrOption)"
                            [attr.aria-disabled]="isDisabled(groupOrOption)"
                            (mouseenter)="mouseenter(groupOrOption)"
                            (click)="click(groupOrOption)"
                        >
                            <div
                                *ngIf="!hasTemplate(groupOrOption, 'option'); else li"
                                [innerHTML]="groupOrOption.label"
                                class="select2-label-content"
                            ></div>
                            <ng-template #li>
                                <ng-container
                                    *ngTemplateOutlet="getTemplate(groupOrOption, 'option'); context: groupOrOption"
                                >
                                </ng-container>
                            </ng-template>
                        </li>
                    </ng-container>
                    <li
                        class="select2-no-result select2-results__option"
                        *ngIf="!filteredData?.length && noResultMessage"
                        [innerHTML]="noResultMessage"
                    ></li>
                    <li
                        class="select2-too-much-result select2-results__option"
                        *ngIf="maxResultsExceeded"
                        [innerHTML]="maxResultsMessage"
                    ></li>
                </ul>
            </div>
        </div>
    </div>
</ng-template>
`,
      styles: ['.select2-label{color:#000;color:var(--select2-label-text-color, #000)}.select2-container{box-sizing:border-box;display:inline-block;margin:0;position:relative;vertical-align:middle;width:100%}.select2-container .select2-container-dropdown{position:absolute;width:0px;opacity:0}.select2-container .select2-selection--single{box-sizing:border-box;cursor:pointer;display:block;height:28px;-webkit-user-select:none;user-select:none}.select2-container .select2-selection--single .select2-selection__rendered{display:block;padding:0 0 0 8px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap;flex:1 1 auto}.select2-container .select2-selection--single .select2-selection__clear{position:relative}.select2-container .select2-selection--multiple{box-sizing:border-box;cursor:pointer;display:block;min-height:32px;-webkit-user-select:none;user-select:none}.select2-container .select2-selection--multiple .select2-selection__rendered{display:inline-block;overflow:hidden;padding-left:8px;text-overflow:ellipsis;white-space:nowrap}.select2-container .select2-search--inline{float:left}.select2-container .select2-search--inline .select2-search__field{box-sizing:border-box;border:none;font-size:100%;margin-top:5px;padding:0}.select2-container .select2-search--inline .select2-search__field::-webkit-search-cancel-button{-webkit-appearance:none}.select2-dropdown{background:white;background:var(--select2-dropdown-background, white);border:1px solid #aaa;border:1px solid var(--select2-dropdown-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);box-sizing:border-box;display:block;position:absolute;width:100%;z-index:1051;height:0;overflow:hidden}.select2-dropdown .select2-label-content{display:contents}.select2-results{display:block}.select2-results__options{list-style:none;margin:0;padding:0}.select2-results__option{padding:6px;-webkit-user-select:none;user-select:none;color:#000;color:var(--select2-option-text-color, #000)}.select2-results__option[aria-selected]{cursor:pointer}.select2-container.select2-container-dropdown.select2-container--open{width:100%;opacity:1}.select2-container--open .select2-dropdown{overflow:auto;height:auto}.select2-container--open .select2-dropdown--above{border-bottom:none;border-bottom-left-radius:0;border-bottom-right-radius:0;bottom:27px;display:flex;flex-direction:column-reverse}.select2-container--open .select2-dropdown--below{border-top:none;border-top-left-radius:0;border-top-right-radius:0}.select2-search--dropdown{display:block;padding:4px}.select2-search--dropdown .select2-search__field{padding:4px;width:100%;box-sizing:border-box}.select2-search--dropdown .select2-search__field::-webkit-search-cancel-button{-webkit-appearance:none}.select2-search--dropdown.select2-search--hide{display:none}.select2-close-mask{border:0;margin:0;padding:0;display:block;position:fixed;left:0;top:0;min-height:100%;min-width:100%;height:auto;width:auto;opacity:0;z-index:99;background:#fff;filter:alpha(opacity=0)}.select2-required:before{content:"*";color:red;color:var(--select2-required-color, red)}.select2-hidden-accessible{border:0!important;clip:rect(0 0 0 0)!important;height:1px!important;margin:-1px!important;overflow:hidden!important;padding:0!important;position:absolute!important;width:1px!important}.select2-container--default .select2-selection--single{background:#fff;background:var(--select2-selection-background, #fff);border:1px solid #aaa;border:1px solid var(--select2-selection-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);display:flex}.select2-container--default .select2-selection--single .select2-selection__rendered{color:#444;color:var(--select2-selection-text-color, #444);line-height:28px}.select2-container--default .select2-selection--single .select2-selection__clear{cursor:pointer;float:right;font-weight:700}.select2-container--default .select2-selection--single .select2-selection__placeholder{color:#999;color:var(--select2-placeholder-color, #999)}.select2-container--default .select2-selection--single .select2-selection__placeholder span{overflow:hidden;white-space:nowrap;text-overflow:ellipsis;text-overflow:var(--select2-placeholder-overflow, ellipsis)}.select2-container--default .select2-selection--single .select2-selection__placeholder__option{display:none}.select2-container--default .select2-selection--single .select2-selection__reset,.select2-container--default .select2-selection--single .select2-selection__arrow{display:flex;width:20px;align-items:center;justify-content:center}.select2-container--default .select2-selection--single .select2-selection__arrow:before{content:" ";border-color:#888 transparent;border-color:var(--select2-arrow-color, #888) transparent;border-style:solid;border-width:5px 4px 0;height:0;width:0}.select2-container--default .select2-selection--single .select2-selection__reset{color:#999;color:var(--select2-reset-color, #999)}.select2-container--default.select2-container--disabled .select2-selection--single{background:#eee;background:var(--select2-selection-disabled-background, #eee);cursor:default}.select2-container--default.select2-container--disabled .select2-selection--single .select2-selection__clear{display:none}.select2-container--default.select2-container--open .select2-selection--single .select2-selection__arrow:before{border-color:transparent transparent #888;border-color:transparent transparent var(--select2-arrow-color, #888);border-width:0 4px 5px}.select2-container--default .select2-selection--multiple{background:#fff;background:var(--select2-selection-background, #fff);border:1px solid #aaa;border:1px solid var(--select2-selection-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);cursor:text}.select2-container--default .select2-selection--multiple .select2-selection__rendered{flex:1 1 auto;box-sizing:border-box;list-style:none;margin:0;padding:0 5px;width:100%}.select2-container--default .select2-selection--multiple .select2-selection__rendered li{list-style:none}.select2-container--default .select2-selection--multiple .select2-selection__placeholder{display:block;width:100%;color:#999;color:var(--select2-placeholder-color, #999);margin-top:5px;float:left;overflow:hidden;white-space:nowrap;text-overflow:ellipsis;text-overflow:var(--select2-placeholder-overflow, ellipsis)}.select2-container--default .select2-selection--multiple .select2-selection__placeholder__option{display:none}.select2-container--default .select2-selection--multiple .select2-selection__clear{cursor:pointer;float:right;font-weight:700;margin-top:5px;margin-right:10px}.select2-container--default .select2-selection--multiple .select2-selection__choice{color:#000;color:var(--select2-selection-choice-text-color, #000);background:#e4e4e4;background:var(--select2-selection-choice-background, #e4e4e4);border:1px solid #aaa;border:1px solid var(--select2-selection-choice-border-color, #aaa);border-radius:4px;border-radius:var(--select2-selection-border-radius, 4px);cursor:default;float:left;margin-right:5px;margin-top:5px;padding:0 5px}.select2-container--default .select2-selection--multiple .select2-selection__choice__remove{color:#999;color:var(--select2-selection-choice-close-color, #999);cursor:pointer;display:inline-block;font-weight:700;margin-right:2px}.select2-container--default .select2-selection--multiple .select2-selection__choice__remove:hover{color:#333;color:var(--select2-selection-choice-hover-close-color, #333)}.select2-container--default.select2-container--focused .select2-selection--multiple{border:solid #000 1px;border:solid var(--select2-selection-focus-border-color, #000) 1px;outline:none}.select2-container--default:not(.select2-container--open) .select2-focused .select2-selection--single,.select2-container--default:not(.select2-container--open) .select2-focused .select2-selection--multiple{border:solid #000 1px;border:solid var(--select2-selection-focus-border-color, #000) 1px;outline:none}.select2-container--default.select2-container--disabled .select2-selection--multiple{background:#eee;background:var(--select2-selection-disabled-background, #eee);cursor:default}.select2-container--default.select2-container--disabled .select2-selection__choice__remove{display:none}.select2-container--default.select2-container--open.select2-container--above .select2-selection--single,.select2-container--default.select2-container--open.select2-container--above .select2-selection--multiple{border-top-left-radius:0;border-top-right-radius:0}.select2-container--default.select2-container--open.select2-container--below .select2-selection--single,.select2-container--default.select2-container--open.select2-container--below .select2-selection--multiple{border-bottom-left-radius:0;border-bottom-right-radius:0}.select2-container--default .select2-search--dropdown .select2-search__field{border:1px solid #aaa;border:1px solid var(--select2-search-border-color, #aaa);background:#fff;background:1px solid var(--select2-search-background, #fff);border-radius:0;border-radius:var(--select2-search-border-radius, 0px)}.select2-container--default .select2-search--inline .select2-search__field{background:transparent;border:none;outline:none;box-shadow:none;-webkit-appearance:textfield}.select2-container--default .select2-results>.select2-results__options{overflow-y:auto}.select2-container--default .select2-results__option[role=group]{padding:0}.select2-container--default .select2-results__option[aria-disabled=true]{color:#999;color:var(--select2-option-disabled-text-color, #999);background:transparent;background:var(--select2-option-disabled-background, transparent)}.select2-container--default .select2-results__option[aria-selected=true]{color:#000;color:var(--select2-option-selected-text-color, #000);background:#ddd;background:var(--select2-option-selected-background, #ddd)}.select2-container--default .select2-results__option .select2-results__option{padding-left:1em}.select2-container--default .select2-results__option .select2-results__option .select2-results__group{padding-left:0}.select2-container--default .select2-results__option .select2-results__option .select2-results__option{margin-left:-1em;padding-left:2em}.select2-container--default .select2-results__option .select2-results__option .select2-results__option .select2-results__option{margin-left:-2em;padding-left:3em}.select2-container--default .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option{margin-left:-3em;padding-left:4em}.select2-container--default .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option{margin-left:-4em;padding-left:5em}.select2-container--default .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option .select2-results__option{margin-left:-5em;padding-left:6em}.select2-container--default .select2-results__option--highlighted[aria-selected]{background:#5897fb;background:var(--select2-option-highlighted-background, #5897fb);color:#fff;color:var(--select2-option-highlighted-text-color, #fff)}.select2-container--default .select2-results__option--hide{display:none}.select2-container--default .select2-results__group{cursor:default;display:block;padding:6px;color:gray;color:var(--select2-option-group-text-color, gray);background:transparent;background:var(--select2-option-group-background, transparent)}.select2-no-result{color:#888;color:var(--select2-no-result-color, #888);font-style:italic;font-style:var(--select2-no-result-font-style, italic)}.select2-too-much-result{color:#888;color:var(--select2-too-much-result-color, #888);font-style:italic;font-style:var(--select2-too-much-font-style, italic)}:host.nostyle .select2-dropdown{border-color:transparent}:host.nostyle .select2-selection--single,:host.nostyle .select2-selection--multiple{background:transparent;border-color:transparent}:host.nostyle .select2-container--default .select2-focused .select2-selection--single,:host.nostyle .select2-container--default .select2-focused .select2-selection--multiple,:host.nostyle .select2-container--default:not(.select2-container--open) .select2-focused .select2-selection--single,:host.nostyle .select2-container--default:not(.select2-container--open) .select2-focused .select2-selection--multiple{background:transparent;border-color:transparent}:host.material{display:inline-block;width:300px}:host.material>.select2-container{padding-bottom:1.29688em;vertical-align:inherit}:host.material>.select2-container .selection{padding:.4375em 0;border-top:.84375em solid transparent;display:inline-flex;align-items:baseline;width:100%;height:auto}:host.material .select2-container--default .select2-selection--single,:host.material .select2-container--default .select2-selection--multiple{width:100%;border:0;border-radius:0;height:24px;box-sizing:border-box}:host.material .select2-container--default .select2-selection--single:before,:host.material .select2-container--default .select2-selection--multiple:before{content:" ";display:block;position:absolute;bottom:1.65em;background:#ddd;background:var(--select2-material-underline, #ddd);height:1px;width:100%}:host.material .select2-container--default .select2-selection--single:after,:host.material .select2-container--default .select2-selection--multiple:after{content:" ";display:block;position:absolute;bottom:1.63em;background:#5a419e;background:var(--select2-material-underline-active, #5a419e);height:2px;width:0%;left:50%;transition:none}:host.material .select2-container--default .select2-selection--single .select2-selection__rendered,:host.material .select2-container--default .select2-selection--multiple .select2-selection__rendered{padding-left:1px;line-height:inherit}:host.material .select2-container--default .select2-selection--single .select2-selection__placeholder,:host.material .select2-container--default .select2-selection--multiple .select2-selection__placeholder{display:block;color:#00000061;color:var(--select2-material-placeholder-color, rgba(0, 0, 0, .38));transition:transform .3s;position:absolute;transform-origin:0 21px;left:0;top:20px}:host.material .select2-container--default .select2-container--open{left:0;bottom:1.6em}:host.material .select2-container--default .select2-selection__placeholder__option{transform:translateY(-1.5em) scale(.75) perspective(100px) translateZ(.001px);width:133.33333%}:host.material .select2-container--default .select2-selection__arrow{top:20px}:host.material .select2-container--default.select2-container--open .select2-selection--single:after,:host.material .select2-container--default.select2-container--open .select2-selection--multiple:after,:host.material .select2-container--default .select2-focused .select2-selection--single:after,:host.material .select2-container--default .select2-focused .select2-selection--multiple:after{transition:width .3s cubic-bezier(.12,1,.77,1),left .3s cubic-bezier(.12,1,.77,1);width:100%;left:0%}:host.material .select2-container--default .select2-dropdown{border-radius:0;border:0;box-shadow:0 5px 5px #00000080}:host.material .select2-container--default .select2-results__option[aria-selected=true],:host.material .select2-container--default .select2-results__option--highlighted[aria-selected]{background:rgba(0,0,0,.04);background:var(--select2-material-option-selected-background, rgba(0, 0, 0, .04));color:#000;color:var(--select2-material-option-highlighted-text-color, #000)}:host.material .select2-container--default .select2-results__option[aria-selected=true]{color:#ff5722;color:var(--select2-material-option-selected-text-color, #ff5722)}:host.material .select2-container--default.select2-container--disabled .select2-selection--single,:host.material .select2-container--default.select2-container--disabled .select2-selection--multiple{background:transparent}:host.material .select2-container--default.select2-container--disabled .select2-selection--single:before,:host.material .select2-container--default.select2-container--disabled .select2-selection--multiple:before{background:linear-gradient(to right,rgba(0,0,0,.26) 0,rgba(0,0,0,.26) 33%,transparent 0);background:var(--select2-material-underline-disabled, linear-gradient(to right, rgba(0, 0, 0, .26) 0, rgba(0, 0, 0, .26) 33%, transparent 0));background-size:4px 1px;background-repeat:repeat-x;background-position:0 bottom}:host.material.ng-invalid.ng-touched .select2-container--default .select2-selection--single:before,:host.material.ng-invalid.ng-touched .select2-container--default .select2-selection--single:after,:host.material.ng-invalid.ng-touched .select2-container--default .select2-selection--multiple:before,:host.material.ng-invalid.ng-touched .select2-container--default .select2-selection--multiple:after{background:red;background:var(--select2-material-underline-invalid, red)}:host.material:not(.select2-container--open) .select2-focused .select2-selection--single,:host.material:not(.select2-container--open) .select2-focused .select2-selection--multiple{border:0}:host.material .select2-subscript-wrapper{position:absolute;top:calc(100% - 1.72917em);font-size:75%;color:#888;color:var(--select2-hint-text-color, #888)}::ng-deep .select2-overlay-backdrop{background:rgba(0,0,0,.32);background:var(--select2-overlay-backdrop, transparent)}::ng-deep .cdk-overlay-container .select2-container .select2-dropdown.select2-dropdown--above{bottom:28px}::ng-deep .cdk-overlay-container .select2-container--open.select2-position-auto .select2-dropdown{margin-bottom:28px}::ng-deep .cdk-overlay-container .select2-container--open.select2-position-auto .select2-dropdown.select2-dropdown--above{bottom:0;margin-bottom:0;margin-top:28px}@supports (-moz-appearance: none){select2.material .select2-container--default .select2-selection--single,select2.material .select2-container--default .select2-selection--multiple{height:26px}}@supports (-ms-scroll-limit: 0){select2.material .select2-container--default .select2-selection--single,select2.material .select2-container--default .select2-selection--multiple{height:25px}}\n']
    }]
  }], function() {
    return [{
      type: ViewportRuler
    }, {
      type: ChangeDetectorRef
    }, {
      type: NgForm,
      decorators: [{
        type: Optional
      }]
    }, {
      type: FormGroupDirective,
      decorators: [{
        type: Optional
      }]
    }, {
      type: NgControl,
      decorators: [{
        type: Self
      }, {
        type: Optional
      }]
    }, {
      type: void 0,
      decorators: [{
        type: Attribute,
        args: ["tabindex"]
      }]
    }];
  }, {
    data: [{
      type: Input
    }],
    minCharForSearch: [{
      type: Input
    }],
    displaySearchStatus: [{
      type: Input
    }],
    placeholder: [{
      type: Input
    }],
    customSearchEnabled: [{
      type: Input
    }],
    limitSelection: [{
      type: Input
    }],
    listPosition: [{
      type: Input
    }],
    multiple: [{
      type: Input
    }],
    overlay: [{
      type: Input
    }],
    styleMode: [{
      type: Input
    }],
    noResultMessage: [{
      type: Input
    }],
    maxResults: [{
      type: Input
    }],
    maxResultsMessage: [{
      type: Input
    }],
    infiniteScrollDistance: [{
      type: Input
    }],
    infiniteScrollThrottle: [{
      type: Input
    }],
    infiniteScroll: [{
      type: Input
    }],
    editPattern: [{
      type: Input
    }],
    templates: [{
      type: Input
    }],
    resultMaxHeight: [{
      type: Input
    }],
    update: [{
      type: Output
    }],
    open: [{
      type: Output
    }],
    close: [{
      type: Output
    }],
    focus: [{
      type: Output
    }],
    blur: [{
      type: Output
    }],
    search: [{
      type: Output
    }],
    scroll: [{
      type: Output
    }],
    removeOption: [{
      type: Output
    }],
    minCountForSearch: [{
      type: Input
    }],
    id: [{
      type: Input
    }, {
      type: HostBinding,
      args: ["id"]
    }],
    required: [{
      type: Input
    }],
    disabled: [{
      type: Input
    }],
    hideSelectedItems: [{
      type: Input
    }],
    readonly: [{
      type: Input
    }],
    value: [{
      type: Input
    }],
    tabIndex: [{
      type: Input
    }],
    resettable: [{
      type: Input
    }],
    ariaInvalid: [{
      type: HostBinding,
      args: ["attr.aria-invalid"]
    }],
    classMaterial: [{
      type: HostBinding,
      args: ["class.material"]
    }],
    classNostyle: [{
      type: HostBinding,
      args: ["class.nostyle"]
    }],
    select2above: [{
      type: HostBinding,
      args: ["class.select2-above"]
    }],
    cdkConnectedOverlay: [{
      type: ViewChild,
      args: [CdkConnectedOverlay]
    }],
    selection: [{
      type: ViewChild,
      args: ["selection", {
        static: true
      }]
    }],
    resultContainer: [{
      type: ViewChild,
      args: ["results"]
    }],
    results: [{
      type: ViewChildren,
      args: ["result"]
    }],
    searchInput: [{
      type: ViewChild,
      args: ["searchInput"]
    }],
    dropdown: [{
      type: ViewChild,
      args: ["dropdown"]
    }]
  });
})();
var Select2Hint = class {
};
Select2Hint.ɵfac = function Select2Hint_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || Select2Hint)();
};
Select2Hint.ɵdir = ɵɵdefineDirective({
  type: Select2Hint,
  selectors: [["select2-hint"]],
  standalone: false
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(Select2Hint, [{
    type: Directive,
    args: [{
      selector: "select2-hint"
    }]
  }], null, null);
})();
var Select2Label = class {
};
Select2Label.ɵfac = function Select2Label_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || Select2Label)();
};
Select2Label.ɵdir = ɵɵdefineDirective({
  type: Select2Label,
  selectors: [["select2-label"]],
  standalone: false
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(Select2Label, [{
    type: Directive,
    args: [{
      selector: "select2-label"
    }]
  }], null, null);
})();
var Select2Module = class {
};
Select2Module.ɵfac = function Select2Module_Factory(__ngFactoryType__) {
  return new (__ngFactoryType__ || Select2Module)();
};
Select2Module.ɵmod = ɵɵdefineNgModule({
  type: Select2Module,
  declarations: [Select2Hint, Select2Label, Select2],
  imports: [CommonModule, FormsModule, OverlayModule, ReactiveFormsModule, InfiniteScrollModule],
  exports: [FormsModule, ReactiveFormsModule, Select2Hint, Select2Label, Select2]
});
Select2Module.ɵinj = ɵɵdefineInjector({
  imports: [CommonModule, FormsModule, OverlayModule, ReactiveFormsModule, InfiniteScrollModule, FormsModule, ReactiveFormsModule]
});
(() => {
  (typeof ngDevMode === "undefined" || ngDevMode) && setClassMetadata(Select2Module, [{
    type: NgModule,
    args: [{
      imports: [CommonModule, FormsModule, OverlayModule, ReactiveFormsModule, InfiniteScrollModule],
      declarations: [Select2Hint, Select2Label, Select2],
      exports: [FormsModule, ReactiveFormsModule, Select2Hint, Select2Label, Select2]
    }]
  }], null, null);
})();
export {
  Select2,
  Select2Hint,
  Select2Label,
  Select2Module,
  Select2Utils,
  defaultMinCountForSearch,
  protectRegexp,
  timeout,
  unicodePatterns
};
//# sourceMappingURL=ng-select2-component.js.map
