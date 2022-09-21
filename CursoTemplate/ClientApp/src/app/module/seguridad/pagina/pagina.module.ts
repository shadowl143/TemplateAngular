import { CatalogosModule } from './../../../shared/modules/component.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaginaRoutingModule } from './pagina-routing.module';
import { CatalogoPaginaComponent } from './catalogo-pagina/catalogo-pagina.component';
import { FormularioPaginaComponent } from './formulario-pagina/formulario-pagina.component';


@NgModule({
  declarations: [
    CatalogoPaginaComponent,
    FormularioPaginaComponent
  ],
  imports: [
    CommonModule,
    PaginaRoutingModule,
    CatalogosModule
  ]
})
export class PaginaModule { }
