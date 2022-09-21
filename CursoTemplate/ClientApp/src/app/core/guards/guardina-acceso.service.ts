import { AutenticacionService } from '../service/autenticacion.service';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from "@angular/router";

@Injectable({
  providedIn:'root'
})
export class GuardianAcceso implements CanActivate{
  constructor(private autenticacion:AutenticacionService,private router:Router) {}


  async canActivate(next:ActivatedRouteSnapshot,state:RouterStateSnapshot):Promise<boolean> {
    const autorizado=this.autenticacion.CredencialUsuario().token;
    if(!autorizado){
      this.router.navigate(['/Login'])
      return false;
    }
    return true;
    // else{

    // }

   return true;
  }

}
