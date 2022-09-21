import { MatDialog } from '@angular/material/dialog';
import { FormularioMenuComponent } from './../formulario-menu/formulario-menu.component';
import { Menu } from './../../../../data/model/seguridad/menu';
import { RespositorioMenu } from './../../../../data/service/repositorio/seguridad/repo-menu';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Rol } from 'src/app/data/model/catalogo/rol';
import { RespositorioRol } from 'src/app/data/service/repositorio/catalogos/repo-rol';

@Component({
  selector: 'app-catalogo-menu',
  templateUrl: './catalogo-menu.component.html',
  styleUrls: ['./catalogo-menu.component.scss']
})
export class CatalogoMenuComponent implements OnInit {

  columnaTable = [
    'clave',
    'nombre', 'status','opciones'

  ]
  dataSource = new MatTableDataSource<Menu>([]);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  /**
   *
   */
  constructor(private api: RespositorioMenu,private matDialog:MatDialog) {


  }
  ngOnInit(): void {
    this.crearTable();
  }

  crearTable(): void {
    this.api.obtenerTodos().toPromise().then(e => {
      if (e.exito) {
        console.log(e.model)
        this.dataSource = new MatTableDataSource<Menu>(e.model);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      } else {
        alert('Error al consultar la api');
      }
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  abrirFormulario(id?:number){
    const parametro=id==null?null:id;
    this.matDialog.open(FormularioMenuComponent,{data:parametro}).afterClosed()
    .toPromise().then(e=>{
      if(e){
        this.crearTable();
      }
    });
  }
}
