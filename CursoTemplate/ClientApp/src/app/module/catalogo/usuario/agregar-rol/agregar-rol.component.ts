import { AlertasService } from './../../../../data/service/utilerias/alert.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RespositorioUsuario } from 'src/app/data/service/repositorio/catalogos/repo-usuario';
import { RolUsuarioListCheck } from './../../../../data/model/catalogo/rol-usuario';
import { Component, Inject, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { InjectFlags } from '@angular/compiler/src/core';

@Component({
  selector: 'app-agregar-rol',
  templateUrl: './agregar-rol.component.html',
  styleUrls: ['./agregar-rol.component.scss']
})
export class AgregarRolComponent implements OnInit {
  task: RolUsuarioListCheck = {
    name: 'Seleccione un rol',
    completed: false,
    color: 'primary',
    listaRol: [

    ],
  };
  allComplete: boolean = false;
  subscription = new Subscription;

  constructor(private repoUsuario:RespositorioUsuario,private matDialogRef:MatDialogRef<AgregarRolComponent>,
    @Inject(MAT_DIALOG_DATA) private id:number,private alerta:AlertasService
    ) {
      repoUsuario.obtenerRolUsuario(id).toPromise().then(e=>{
        if(e.exito){
          this.task.listaRol=e.model

        }else{
          this.alerta.alertaError('No es posible hacer la consulta');
        }
      });

     }

  ngOnInit(): void {
  }

  guardar(){
    const model=this.task.listaRol;
    this.repoUsuario.guardarRolUsuario(model!).toPromise().then(e=>{
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
    if (this.task.listaRol == null) {
      return false;
    }
    return this.task.listaRol.filter(t => t.activo).length > 0 && !this.allComplete;
  }

  setAll(completed: boolean) {
    this.allComplete = completed;
    if (this.task.listaRol == null) {
      return;
    }
    this.task.listaRol.forEach(t => (t.activo = completed));
  }

  updateAllComplete() {
    this.allComplete = this.task.listaRol != null && this.task.listaRol.every(t => t.activo);
  }

}
