import { CatalogosModule } from './../../../shared/modules/component.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolRoutingModule } from './rol-routing.module';
import { CatalogoRolComponent } from './catalogo-rol/catalogo-rol.component';
import { FormularioRolComponent } from './formulario-rol/formulario-rol.component';
import { AgregarPaginaComponent } from './agregar-pagina/agregar-pagina.component';


@NgModule({
  declarations: [
    CatalogoRolComponent,
    FormularioRolComponent,
    AgregarPaginaComponent
  ],
  imports: [
    CommonModule,
    RolRoutingModule,
    CatalogosModule
  ]
})
export class RolModule { }
