import { Menu } from './../../../../data/model/seguridad/menu';
import { RespositorioMenu } from './../../../../data/service/repositorio/seguridad/repo-menu';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-formulario-menu',
  templateUrl: './formulario-menu.component.html',
  styleUrls: ['./formulario-menu.component.scss']
})
export class FormularioMenuComponent implements OnInit {
  formGroup: FormGroup;

  get fg() { return this.formGroup.controls; }
  constructor(private matDialogRef: MatDialogRef<FormularioMenuComponent>,
    private formBuilder: FormBuilder,
    private repoMenu: RespositorioMenu,
    @Inject(MAT_DIALOG_DATA) public id: number) {
    if (id) {
      repoMenu.obtenerPorId(id).toPromise().then(e => {
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
      icono:['',Validators.required],
      clave: ['', Validators.required],
      nombre: ['', Validators.required],
      activo: [true]
    });
  }
  cerrar() {
    this.matDialogRef.close();
  }

  guardar() {
    const model = this.formGroup.value as Menu;
    if (this.formGroup.valid) {

      this.repoMenu.guardar(model).toPromise().then(e => {
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
    const model = this.formGroup.value as Menu;

    if (this.formGroup.valid) {
      this.repoMenu.actualizar(this.id, model).toPromise().then(e => {
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
        this.repoMenu.actualizar(this.id, model).toPromise().then(e => {
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
