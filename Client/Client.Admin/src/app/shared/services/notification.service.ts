import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { TranslateService } from "@ngx-translate/core";

export interface ToastData {
  type: "success" | "warning" | "error";
  message: string;
}

@Injectable({
  providedIn: "root",
})
export class NotificationService {
  private readonly toastSubject = new Subject<ToastData>();
  toastState$ = this.toastSubject.asObservable();

  constructor(private readonly translate: TranslateService) {}

  showSuccess(message: string) {
    const translatedMsg = this.translate.instant(message);
    this.toastSubject.next({ type: "success", message: translatedMsg });
  }

  showWarning(message: string) {
    const translatedMsg = this.translate.instant(message);
    this.toastSubject.next({ type: "warning", message: translatedMsg });
  }

  showError(message: string) {
    const translatedMsg = this.translate.instant(message);
    this.toastSubject.next({ type: "error", message: translatedMsg });
  }
}
