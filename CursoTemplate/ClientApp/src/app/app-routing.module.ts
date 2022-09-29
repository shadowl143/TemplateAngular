import { NoAutorizadoComponent } from './shared/no-autorizado/no-autorizado.component';
import { NoEncontradoComponent } from './shared/no-encontrado/no-encontrado.component';
import { CatalogoRolComponent } from './module/catalogo/rol/catalogo-rol/catalogo-rol.component';
import { GuardianAcceso } from './core/guards/guardina-acceso.service';
import { CanActivate } from '@angular/router';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { LoginComponent } from './shared/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes:Routes=[
  {
    path:'Login',
    component:LoginComponent
  },{
    path:'NoAutorizado',
    component:NoAutorizadoComponent
  },
  {
    path:'',
    component:SidebarComponent,
    canActivate:[GuardianAcceso],
    children:[
      {
        //lazy loading
        path:'usuario',
        loadChildren:()=>import('./module/catalogo/usuario/usuario.module').then(e => e.UsuarioModule),

      },
      {
        path:'rol',
        loadChildren:()=>import('./module/catalogo/rol/rol.module').then(e => e.RolModule),
      },
      {
        path:'menu',
        loadChildren:()=>import('./module/seguridad/menu/menu.module').then(e => e.MenuModule),
      }
      ,
      {
        path:'pagina',
        loadChildren:()=>import('./module/seguridad/pagina/pagina.module').then(e => e.PaginaModule),
      },
      {
        path:'**',
        component:NoEncontradoComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
