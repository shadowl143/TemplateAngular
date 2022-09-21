import { CatalogosModule } from './../../../shared/modules/component.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuRoutingModule } from './menu-routing.module';
import { CatalogoMenuComponent } from './catalogo-menu/catalogo-menu.component';
import { FormularioMenuComponent } from './formulario-menu/formulario-menu.component';


@NgModule({
  declarations: [
    CatalogoMenuComponent,
    FormularioMenuComponent
  ],
  imports: [
    CommonModule,
    MenuRoutingModule,
    CatalogosModule
  ]
})
export class MenuModule { }
