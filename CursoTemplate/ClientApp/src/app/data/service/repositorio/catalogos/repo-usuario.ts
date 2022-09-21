import { RolUsuario } from './../../../model/catalogo/rol-usuario';
import { Respuesta } from 'src/app/data/model/respuesta';
import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Repositorio } from '../repositorio';
import { Usuario } from 'src/app/data/model/catalogo/usuario';


@Injectable({ providedIn: "root" })
export class RespositorioUsuario extends Repositorio<Usuario>{
  constructor(public httpClient: HttpClient) {
    super(httpClient, 'Usuario')
  }

  obtenerRolUsuario(usuarioId: number): Observable<Respuesta<RolUsuario[]>> {
    const ruta = `${this.ruta}/GetUsuarioRol/${usuarioId}`;
    return this.cliente.get<Respuesta<RolUsuario[]>>(ruta);
  }

  guardarRolUsuario(listado: RolUsuario[]): Observable<Respuesta<RolUsuario[]>> {
    const ruta = `${this.ruta}/AddUpdateRolUsuario`;
    return this.cliente.post<Respuesta<RolUsuario[]>>(ruta,listado);
  }


}
