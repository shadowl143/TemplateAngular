import { AutenticacionService } from '../service/autenticacion.service';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class GuardianAcceso implements CanActivate {
  constructor(private autenticacion: AutenticacionService, private router: Router) { }


  async canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    const autorizado = this.autenticacion.CredencialUsuario().token;
    if (autorizado) {
      const paginas = this.autenticacion.CredencialUsuario().paginas;//  menu/formualrio
      if (state.url == '/' || paginas.find(e => e.clave == state.url.slice(1, -1))) {
        return true;
      }
      this.router.navigate(['/NoAutorizado'])
      return false;
    }
    this.router.navigate(['/Login'])
    return false;
  }

}
