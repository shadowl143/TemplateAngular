import { Menu } from './../../../model/seguridad/menu';

import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Repositorio } from '../repositorio';


@Injectable({providedIn:"root"})
export class RespositorioMenu extends Repositorio<Menu>{
  constructor(public httpClient:HttpClient){
    super(httpClient,'Menu')
  }


}
