import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter, withInMemoryScrolling } from '@angular/router';
import { OWL_DATE_TIME_LOCALE } from '@danielmoncada/angular-datetime-picker';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { provideToastr } from 'ngx-toastr';
import { routes } from './app.routes';
import {provideStore} from "@ngxs/store";
import {environment} from "../environments/environment";
import {withNgxsReduxDevtoolsPlugin} from "@ngxs/devtools-plugin";
import {NgxsLoggerPlugin, withNgxsLoggerPlugin} from "@ngxs/logger-plugin";

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

export const MY_NATIVE_FORMATS = {
  fullPickerInput: {year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric'},
  datePickerInput: {year: 'numeric', month: 'numeric', day: 'numeric'},
  timePickerInput: {hour: 'numeric', minute: 'numeric'},
  monthYearLabel: {year: 'numeric', month: 'short'},
  dateA11yLabel: {year: 'numeric', month: 'long', day: 'numeric'},
  monthYearA11yLabel: {year: 'numeric', month: 'long'},
};

export const appConfig: ApplicationConfig = {
  providers: [
    {provide: OWL_DATE_TIME_LOCALE, useValue: 'en'},
    provideAnimations(),
    provideToastr(),
    provideRouter(routes, withInMemoryScrolling({
      scrollPositionRestoration: "top",
    })),
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideHttpClient(),
    provideRouter(routes),
    importProvidersFrom(
      TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient],
        },
      }),
      CalendarModule.forRoot({
        provide: DateAdapter,
        useFactory: adapterFactory,
      })
    ),

    provideStore([], {
        developmentMode: !environment.production,
    },
        withNgxsReduxDevtoolsPlugin({disabled: environment.production}),
        withNgxsLoggerPlugin({disabled: environment.production}),
    )
  ]
};
