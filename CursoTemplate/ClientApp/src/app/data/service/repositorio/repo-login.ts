import { Credencial } from '../../model/seguridad/credencial';
import { Respuesta } from 'src/app/data/model/respuesta';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Login } from 'src/app/data/model/login';
import { Injectable } from "@angular/core";
import { Repositorio } from "./repositorio";

@Injectable({providedIn:"root"})
export class RespositorioLogin extends Repositorio<Login>{
  constructor(public httpClient:HttpClient){
    super(httpClient,'Login')
  }

  iniciarSesion(model:Login):Observable<Respuesta<Credencial>>{
    return this.cliente.post<Respuesta<Credencial>>(this.ruta,model);
  }
}
