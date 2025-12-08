import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";

import { language } from "../../../../data/header";
import { Language } from "../../../../interface/header";
import { LayoutService } from "../../../../services/layout.service";
import { LanguageService } from "../../../../services/language.service";

@Component({
  selector: "app-header-language",
  imports: [CommonModule],
  templateUrl: "./language.component.html",
  styleUrl: "./language.component.scss",
})
export class LanguageComponent {
  public languages = language;
  public selectedLanguage: Language;

  constructor(
    public layoutService: LayoutService,
    public translate: TranslateService,
    private langService: LanguageService
  ) {
    const savedLang = localStorage.getItem("lang");

    this.selectedLanguage =
      this.languages.find((l) => l.code === savedLang) || this.languages[0];
  }

  selectLanguage(language: Language) {
    this.selectedLanguage = language;
    this.langService.setLanguage(language.code);
  }
}
