import { AgregarPaginaComponent } from './../agregar-pagina/agregar-pagina.component';
import { FormularioRolComponent } from './../formulario-rol/formulario-rol.component';
import { MatDialog } from '@angular/material/dialog';
import { Rol } from './../../../../data/model/catalogo/rol';
import { RespositorioRol } from './../../../../data/service/repositorio/catalogos/repo-rol';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from 'src/app/data/model/catalogo/usuario';
import { RespositorioUsuario } from 'src/app/data/service/repositorio/catalogos/repo-usuario';

@Component({
  selector: 'app-catalogo-rol',
  templateUrl: './catalogo-rol.component.html',
  styleUrls: ['./catalogo-rol.component.scss']
})
export class CatalogoRolComponent implements OnInit {

  columnaTable = [
    'clave',
    'nombre', 'status','opciones'

  ]
  dataSource = new MatTableDataSource<Rol>([]);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  /**
   *
   */
  constructor(private api: RespositorioRol,private matDialog:MatDialog) {


  }
  ngOnInit(): void {
    this.crearTable();
  }

  crearTable(): void {
    this.api.obtenerTodos().toPromise().then(e => {
      if (e.exito) {
        console.log(e.model)
        this.dataSource = new MatTableDataSource<Rol>(e.model);
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
    this.matDialog.open(FormularioRolComponent,{data:parametro}).afterClosed()
    .toPromise().then(e=>{
      if(e){
        this.crearTable();
      }
    });
  }

  agregarPagina(id:number):void{
    this.matDialog.open(AgregarPaginaComponent,{data:id});
  }

}
