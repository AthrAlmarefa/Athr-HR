import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

export const interceptorGlobalHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  
  const router = inject(Router);

  return next(req).pipe(

    catchError((error : HttpErrorResponse ) => {
      if(error.status === 401){
        alert("Session expired, please log in again");
        localStorage.removeItem("token");
        router.navigate(["/login"]);
        console.log(error);
      }
      if(error.status === 403){
        alert("You don't have permission to access this resource");
        console.log(error);
      }

      return throwError(() => error);
    })


  );
};
