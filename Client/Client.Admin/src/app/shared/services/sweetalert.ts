import { Injectable } from '@angular/core';
import Swal, { SweetAlertPosition, SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SweetAlertService {

  constructor() { }

  show(
    title: string,
    icon: SweetAlertIcon = 'success',
    position: SweetAlertPosition = 'top-end',
    timer: number = 3000
  ) {
    Swal.fire({
      title: title,
      icon: icon,
      toast: true,
      position: position,
      showConfirmButton: false,
      timer: timer,
      timerProgressBar: true,
    });
  }
}
