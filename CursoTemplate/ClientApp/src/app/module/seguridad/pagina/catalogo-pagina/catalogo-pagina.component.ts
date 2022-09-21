import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Pagina } from 'src/app/data/model/seguridad/pagina';
import { RespositorioPagina } from 'src/app/data/service/repositorio/seguridad/repo-pagina';
import { FormularioPaginaComponent } from '../formulario-pagina/formulario-pagina.component';

@Component({
  selector: 'app-catalogo-pagina',
  templateUrl: './catalogo-pagina.component.html',
  styleUrls: ['./catalogo-pagina.component.scss']
})
export class CatalogoPaginaComponent implements OnInit {


  columnaTable = [
    'clave',
    'nombre','menu' ,'status','opciones'

  ]
  dataSource = new MatTableDataSource<Pagina>([]);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  /**
   *
   */
  constructor(private api: RespositorioPagina,private matDialog:MatDialog) {


  }
  ngOnInit(): void {
    this.crearTable();
  }

  crearTable(): void {
    this.api.obtenerTodos().toPromise().then(e => {
      if (e.exito) {
        console.log(e.model)
        this.dataSource = new MatTableDataSource<Pagina>(e.model);
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
    this.matDialog.open(FormularioPaginaComponent,{data:parametro}).afterClosed()
    .toPromise().then(e=>{
      if(e){
        this.crearTable();
      }
    });
  }
}
