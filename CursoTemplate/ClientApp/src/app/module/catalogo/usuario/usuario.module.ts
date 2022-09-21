import { CatalogosModule } from './../../../shared/modules/component.module';
import { UsuarioRoutingModule } from './usuario.routin.module';
import { CatalogoUsuario } from './catalogo/catalgo-usuario';
import { NgModule } from '@angular/core';
import { FormualarioUsuarioComponent } from './formulario/formulario-usuario.component';
import { AgregarRolComponent } from './agregar-rol/agregar-rol.component';

@NgModule({
  declarations:[
    CatalogoUsuario,
    FormualarioUsuarioComponent,
    AgregarRolComponent,
  ],
  imports: [
    UsuarioRoutingModule,
    CatalogosModule

  ],
  exports: [],
})
export class UsuarioModule { }
