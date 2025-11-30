import {inject, Injectable} from "@angular/core";
import {MessageToastComponent} from "../../components/bonus-ui/toast/widgets/message-toast/message-toast.component";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NotificationService {
  
  private toastSubject = new Subject<"success" | "warning" | "error">();
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

  //   messageToastComponent = inject(MessageToastComponent);

  //   showSuccess(message : string): void {
  //     this.messageToastComponent.showToast(message);
  //   }
  //   showWarning(): void {
  //     this.messageToastComponent.showToast("warning");
  //   }

  //   showError(): void {
  //     this.messageToastComponent.showToast("error");
  //   }
}
