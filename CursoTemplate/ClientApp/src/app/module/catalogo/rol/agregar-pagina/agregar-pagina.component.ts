import { RespositorioRol } from 'src/app/data/service/repositorio/catalogos/repo-rol';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { RolPaginaListCheck } from 'src/app/data/model/catalogo/rol-pagina';
import { RespositorioUsuario } from 'src/app/data/service/repositorio/catalogos/repo-usuario';
import { AlertasService } from 'src/app/data/service/utilerias/alert.service';

@Component({
  selector: 'app-agregar-pagina',
  templateUrl: './agregar-pagina.component.html',
  styleUrls: ['./agregar-pagina.component.scss']
})
export class AgregarPaginaComponent implements OnInit {
  task: RolPaginaListCheck = {
    name: 'Seleccione las paginas',
    completed: false,
    color: 'primary',
    listaPagina: [

    ],
  };
  allComplete: boolean = false;
  subscription = new Subscription;

  constructor(private repoRol:RespositorioRol,private matDialogRef:MatDialogRef<AgregarPaginaComponent>,
    @Inject(MAT_DIALOG_DATA) private id:number,private alerta:AlertasService
    ) {
      repoRol.obtenerRolPagina(id).toPromise().then(e=>{
        if(e.exito){
          this.task.listaPagina=e.model

        }else{
          this.alerta.alertaError('No es posible hacer la consulta');
        }
      });

     }

  ngOnInit(): void {
  }

  guardar(){
    const model=this.task.listaPagina;
    this.repoRol.guardarRolPagina(model!).toPromise().then(e=>{
      if(e.exito){
        this.alerta.alertaExitosa('Datos actualizados');
        this.matDialogRef.close();
      }
      else{
        this.alerta.alertaError('No se actualizaron los datos');
      }
    });
  }

  someComplete(): boolean {
    if (this.task.listaPagina == null) {
      return false;
    }
    return this.task.listaPagina.filter(t => t.activo).length > 0 && !this.allComplete;
  }

  setAll(completed: boolean) {
    this.allComplete = completed;
    if (this.task.listaPagina == null) {
      return;
    }
    this.task.listaPagina.forEach(t => (t.activo = completed));
  }

  updateAllComplete() {
    this.allComplete = this.task.listaPagina != null && this.task.listaPagina.every(t => t.activo);
  }
}
