import { Injectable} from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NotificationService {
  
  private readonly toastSubject = new Subject<"success" | "warning" | "error">();
  toastState$ = this.toastSubject.asObservable();

  showSuccess() {
    this.toastSubject.next("success");
  }

  showWarning() {
    this.toastSubject.next("warning");
  }

  showError() {
    this.toastSubject.next("error");
  }
}
