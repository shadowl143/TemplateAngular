import { Credencial } from './../../data/model/seguridad/credencial';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AutenticacionService {

  readonly nombreCredencial = "Credencial";
  constructor(private router: Router) { }

  public asignarCredencial(credencial: Credencial) {
    window.localStorage.setItem(this.nombreCredencial, JSON.stringify(credencial))
  }

  public salir() {
    window.localStorage.removeItem(this.nombreCredencial);
    this.router.navigate(['Login']);
  }

  public CredencialUsuario(): Credencial {
    const json = window.localStorage.getItem(this.nombreCredencial);
    if (!json) {
      return {
        menus: [],
        nombreUsuario: '',
        paginas: [],
        token: '',
        rolId: 0,
        usuarioId: 0
      }
    }
    return JSON.parse(json);
  }
}
