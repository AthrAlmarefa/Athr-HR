import { Component } from "@angular/core";
import { CardComponent } from "../../../../../shared/components/ui/card/card.component";
import { FeatherIconComponent } from "../../../../../shared/components/ui/feather-icon/feather-icon.component";

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

  toastMessage: string = ""; 

  showToast(type: keyof typeof this.toast) {
    
    if (type === "success") {
      this.toastMessage = "Success: We've updated your info";
    } else if (type === "warning") {
      this.toastMessage = "Software drivers needed to be updated in advance";
    } else if (type === "error") {
      this.toastMessage = "A database connection error has occurred";
    }


    this.toast = { success: false, warning: false, error: false }; 
    this.toast[type] = true;

    setTimeout(() => {
      this.toast[type] = false;
    }, 5000);
  }

  closeToast(type: keyof typeof this.toast) {
    this.toast[type] = false;
  }
}
