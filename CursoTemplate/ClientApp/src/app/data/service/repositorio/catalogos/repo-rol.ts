import { RolPagina } from './../../../model/catalogo/rol-pagina';
import { Rol } from './../../../model/catalogo/rol';

import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Repositorio } from '../repositorio';
import { Respuesta } from 'src/app/data/model/respuesta';
import { Observable } from 'rxjs';


@Injectable({providedIn:"root"})
export class RespositorioRol extends Repositorio<Rol>{
  constructor(public httpClient:HttpClient){
    super(httpClient,'Rol')
  }

  obtenerRolPagina(usuarioId: number): Observable<Respuesta<RolPagina[]>> {
    const ruta = `${this.ruta}/GetRolPagina/${usuarioId}`;
    return this.cliente.get<Respuesta<RolPagina[]>>(ruta);
  }

  guardarRolPagina(listado: RolPagina[]): Observable<Respuesta<RolPagina[]>> {
    const ruta = `${this.ruta}/AddUpdateRolPagina`;
    return this.cliente.post<Respuesta<RolPagina[]>>(ruta,listado);
  }
}
