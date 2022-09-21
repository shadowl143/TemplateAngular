import { Router } from '@angular/router';
import { AutenticacionService } from './../../core/service/autenticacion.service';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import {MediaMatcher} from '@angular/cdk/layout';
import { Menu } from 'src/app/data/model/seguridad/menu';
import { Pagina } from 'src/app/data/model/seguridad/pagina';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit,OnDestroy {
  openMenu=true;
  mobileQuery: MediaQueryList;
  paginas:Pagina[]=[];
  menus:Menu[]=[];
  menuAsignado:Menu;

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,
    private autenticacion:AutenticacionService, private router:Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.menus=autenticacion.CredencialUsuario().menus;
    this.paginas=autenticacion.CredencialUsuario().paginas;

  }
  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  cerrarMenu(){
    this.openMenu=!this.openMenu;

  }
  menuVacio:Menu;
  mostrarPaginas(menu:Menu){
    if(menu==this.menuAsignado){

      this.menuAsignado=this.menuVacio;
    }else{
      this.menuAsignado=menu;

    }
  }

  navegarA(page:string):void{
    this.router.navigate([page])
  }

  cerrarSesion(){
    this.autenticacion.salir();
  }
}
