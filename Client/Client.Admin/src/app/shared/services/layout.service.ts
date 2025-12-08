import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class LayoutService {
  public closeSidebar: boolean = true;
  public fullScreen: boolean = false;
  public isLanguage: boolean = false;
  public isSearchOpen: boolean = false;
  public margin: number = 0;
  public scrollMargin: number = -4500;

 public config = {
    settings: {
      layout_type: localStorage.getItem('layout_type') || 'ltr',
      layout_version: 'light-only',
      sidebar_type: 'compact-wrapper',
      icon: "stroke-svg",
      layout: ''
    },
    color: {
      primary: '#7366ff',
      secondary: '#838383',
    }
  };

  constructor() {
    this.applyDirection(this.config.settings.layout_type);
  }

  applyDirection(dir: string) {
    document.documentElement.setAttribute("dir", dir);
    document.body.className = `${dir} ${this.config.settings.layout_version}`;
  }

  setLayoutType(dir: string) {
    this.config.settings.layout_type = dir;
    localStorage.setItem("layout_type", dir);
    this.applyDirection(dir);
  }

  applyLayout(layout: string) {
    if (layout == "dubai") {
      this.config.settings.sidebar_type = "compact-wrapper";
    } else if (layout == "los-angeles") {
      this.config.settings.sidebar_type = "horizontal-wrapper material-type";
      this.scrollMargin = -5000;
    } else if (layout == "paris") {
      this.config.settings.sidebar_type = "compact-wrapper dark-sidebar";
    } else if (layout == "tokyo") {
      this.config.settings.sidebar_type = "compact-sidebar";
    } else if (layout == "moscow") {
      this.config.settings.sidebar_type = "compact-sidebar compact-small";
    } else if (layout == "singapore") {
      this.config.settings.sidebar_type = "horizontal-wrapper enterprice-type";
    } else if (layout == "newyork") {
      this.config.settings.sidebar_type = "compact-wrapper box-layout";
    } else if (layout == "barcelona") {
      this.config.settings.sidebar_type =
        "horizontal-wrapper enterprice-type advance-layout";
    } else if (layout == "madrid") {
      this.config.settings.sidebar_type = "compact-wrapper color-sidebar";
    } else if (layout == "rome") {
      this.config.settings.sidebar_type =
        "compact-sidebar compact-small material-icon";
    } else if (layout == "seoul") {
      this.config.settings.sidebar_type = "compact-wrapper modern-type";
    } else if (layout == "london") {
      this.config.settings.sidebar_type = "only-body";
    }
  }
}
