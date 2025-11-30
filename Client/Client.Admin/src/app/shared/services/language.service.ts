import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { BehaviorSubject } from "rxjs";
import { LayoutService } from "./layout.service";

@Injectable({
  providedIn: "root",
})
export class LanguageService {
  readonly languageSubject = new BehaviorSubject<string>("en");
  language$ = this.languageSubject.asObservable();

  constructor(
    readonly translate: TranslateService,
    readonly layoutService: LayoutService
  ) {
    const saved = localStorage.getItem("lang") || "en";
    this.setLanguage(saved);
  }

  setLanguage(lang: string) {
    this.translate.use(lang);
    this.languageSubject.next(lang);

    localStorage.setItem("lang", lang);

    if (lang === "ae" || lang === "ar" || lang === "sa") {
      this.layoutService.setLayoutType("rtl");
    } else {
      this.layoutService.setLayoutType("ltr");
    }
  }
}
