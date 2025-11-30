import { Component } from "@angular/core";

import { CardComponent } from "../../../../../shared/components/ui/card/card.component";
import { FeatherIconComponent } from "../../../../../shared/components/ui/feather-icon/feather-icon.component";
import { NotificationService } from "../../../../../shared/services/notification.service";

@Component({
  selector: "app-message-toast",
  imports: [CardComponent, FeatherIconComponent],
  templateUrl: "./message-toast.component.html",
  styleUrl: "./message-toast.component.scss",
})
export class MessageToastComponent {
  toast = {
    success: false,
    warning: false,
    error: false,
  };

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {
    this.notificationService.toastState$.subscribe((type) => {
      this.showToast(type);
    });
  }

  showToast(type: keyof typeof this.toast) {
    this.toast[type] = true;

    setTimeout(() => {
      this.toast[type] = false;
    }, 5000);
  }

  closeToast(type: keyof typeof this.toast) {
    this.toast[type] = false;
  }
  // public toast = {
  //   success: false,
  //   warning: false,
  //   error: false,
  // };

  // showToast(value: keyof typeof this.toast) {
  //   this.toast[value] = true;

  //   setTimeout(() => {
  //     this.toast[value] = false;
  //   }, 5000);
  // }

  // closeToast(value: keyof typeof this.toast) {
  //   this.toast[value] = false;
  // }
}
