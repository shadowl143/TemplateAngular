import { RespositorioRol } from './../../../../data/service/repositorio/catalogos/repo-rol';
import { Rol } from './../../../../data/model/catalogo/rol';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormualarioUsuarioComponent } from '../../usuario/formulario/formulario-usuario.component';

@Component({
  selector: 'app-formulario-rol',
  templateUrl: './formulario-rol.component.html',
  styleUrls: ['./formulario-rol.component.scss']
})
export class FormularioRolComponent implements OnInit {
  formGroup: FormGroup;

  get fg() { return this.formGroup.controls; }
  constructor(private matDialogRef: MatDialogRef<FormularioRolComponent>,
    private formBuilder: FormBuilder,
    private repoRol: RespositorioRol,
    @Inject(MAT_DIALOG_DATA) public id: number) {
    if (id) {
      repoRol.obtenerPorId(id).toPromise().then(e => {
        if (e.exito) {
          Object.assign(this.formGroup.value, e.model);
          this.formGroup.reset(this.formGroup.value);
        }

      });
    }
  }

  ngOnInit() {
    this.formulario();
  }

  formulario() {
    this.formGroup = this.formBuilder.group({
      id: [0],
      clave: ['', Validators.required],
      nombre: ['', Validators.required],
      activo: [true]
    });
  }
  cerrar() {
    this.matDialogRef.close();
  }

  guardar() {
    const model = this.formGroup.value as Rol;
    if (this.formGroup.valid) {

      this.repoRol.guardar(model).toPromise().then(e => {
        if (e.exito) {
          alert(e.mensaje);
          this.matDialogRef.close(true);
        } else {
          alert(e.mensajeError);
        }
      }).catch(ex => {
        alert(ex);
      });


    } else {
      console.error('Formulario es invalido')
    }

  }

  actualizar() {
    const model = this.formGroup.value as Rol;

    if (this.formGroup.valid) {
      this.repoRol.actualizar(this.id, model).toPromise().then(e => {
        if (e.exito) {
          alert(e.mensaje);
          this.matDialogRef.close(true);
        } else {
          alert(e.mensajeError);
        }
      }).catch(ex => {
        alert(ex);
      });
    }
    else {
      if (this.formGroup.valid) {
        this.repoRol.actualizar(this.id, model).toPromise().then(e => {
          if (e.exito) {
            alert(e.mensaje);
            this.matDialogRef.close(true);
          } else {
            alert(e.mensajeError);
          }
        }).catch(ex => {
          alert(ex);
        });
      } else {
        console.log('formulario invalido')
      }

    }
  }

  realizarCambios() {
    if (this.id) {
      this.actualizar();
    } else {
      this.guardar();
    }
  }
}
