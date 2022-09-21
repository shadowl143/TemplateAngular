import { Router } from '@angular/router';
import { AutenticacionService } from './../service/autenticacion.service';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  /**
   *
   */
  constructor(private credencia: AutenticacionService,private router:Router) {


  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = `Bearer ${this.credencia.CredencialUsuario().token}`;
    const headers = new HttpHeaders({
      Authorization: token,
    });

    const headersClone = req.clone({ headers })
    return next.handle(headersClone).pipe(
      catchError((err) => {
        console.log(err);
        if([401,403].indexOf(err.status)!==-1){
          window.localStorage.removeItem('Credencial');
            this.router.navigate(['/Login']);
        }
        const error=err.error.message||err.statusText;
        return throwError(err);
      }));
  }
}
