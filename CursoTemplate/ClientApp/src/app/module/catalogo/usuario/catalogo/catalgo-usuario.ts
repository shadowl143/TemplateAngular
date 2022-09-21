import { AgregarRolComponent } from './../agregar-rol/agregar-rol.component';
import { AlertasService } from './../../../../data/service/utilerias/alert.service';
import { Usuario } from './../../../../data/model/catalogo/usuario';
import { Component, OnInit, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { RespositorioUsuario } from 'src/app/data/service/repositorio/catalogos/repo-usuario';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DataSource } from '@angular/cdk/collections';
import { MatDialog } from '@angular/material/dialog';
import { FormualarioUsuarioComponent } from '../formulario/formulario-usuario.component';

@Component({
  selector: 'app-catalogo-usuario',
  templateUrl: './catalogo-usuario.html',
  styleUrls: ['./catalogo-usuario.scss']

})
export class CatalogoUsuario implements OnInit {
  columnaTable = [
    'nombreCompleto',
    'nombreUsuario', 'fechaRegistro', 'status','opciones'

  ]
  dataSource = new MatTableDataSource<Usuario>([]);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  /**
   *
   */
  constructor(private repoUsaurio: RespositorioUsuario,private matDialog:MatDialog,private alerta:AlertasService) {


  }
  ngOnInit(): void {
    this.crearTable();
  }

  crearTable(): void {
    this.repoUsaurio.obtenerTodos().toPromise().then(e => {
      if (e.exito) {
        console.log(e.model)
        this.dataSource = new MatTableDataSource<Usuario>(e.model);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      } else {
        this.alerta.alertaError('Error al consultar la api');
      }
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  abrirFormulario(id?:number): void{
    const parametro=id==null?null:id;
    this.matDialog.open(FormualarioUsuarioComponent,{data:parametro}).afterClosed()
    .toPromise().then(e=>{
      if(e){
        this.crearTable();
      }
    });

  }
  agregarRol(id:number):void{
    this.matDialog.open(AgregarRolComponent,{data:id});
  }
}
