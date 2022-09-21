import { Pagina } from './../../../model/seguridad/pagina';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Repositorio } from '../repositorio';


@Injectable({providedIn:"root"})
export class RespositorioPagina extends Repositorio<Pagina>{
  constructor(public httpClient:HttpClient){
    super(httpClient,'Pagina')
  }


}
