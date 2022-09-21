import { AlertasService } from './../../../../data/service/utilerias/alert.service';
import { RespositorioUsuario } from './../../../../data/service/repositorio/catalogos/repo-usuario';
import { Usuario } from './../../../../data/model/catalogo/usuario';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { InjectFlags } from '@angular/compiler/src/core';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-formulario-usuario',
  templateUrl: 'formulario-usuario.component.html',
  styleUrls: ['formulario-usuario.component.scss']
})

export class FormualarioUsuarioComponent implements OnInit {
  ocultarPass = true;
  ocultarConf = true;
  fecha = new Date();
  cambioPass = true;
  formGroup: FormGroup;

  get fg() { return this.formGroup.controls; }
  constructor(private matDialogRef: MatDialogRef<FormualarioUsuarioComponent>,
    private formBuilder: FormBuilder,
    private repoUsuario: RespositorioUsuario,
    @Inject(MAT_DIALOG_DATA) public id: number,
    private alerta:AlertasService) {
    if (id) {
      this.cambioPass = false;
      repoUsuario.obtenerPorId(id).toPromise().then(e => {
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
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      nombreUsuario: ['', [Validators.required, Validators.maxLength(10), Validators.minLength(5)]],
      password: ['', Validators.required],
      confPassword: [''],
      fechaRegistro: [''],
      email: ['', [Validators.required, Validators.email]],

      activo: [true]
    });
  }
  cerrar() {
    this.matDialogRef.close();
  }

  guardar() {
    const model = this.formGroup.value as Usuario;
    model.CambiarPass=this.cambioPass;
    if (this.formGroup.valid) {
      if (this.validarContrasenia()) {
        model.fechaRegistro = this.fecha;
        this.repoUsuario.guardar(model).toPromise().then(e => {
          if (e.exito) {
            this.alerta.alertaExitosa(e.mensaje);
            this.matDialogRef.close(true);
          } else {
            this.alerta.alertaError(e.mensajeError);
          }
        }).catch(ex => {
          this.alerta.alertaError(ex);

        });
      }

    } else {
      console.error('Formulario es invalido')
    }

  }

  actualizar() {
    const model = this.formGroup.value as Usuario;
    model.CambiarPass=this.cambioPass;
    if (this.cambioPass) {
      if (this.validarContrasenia()) {
        if(this.formGroup.valid){
          this.repoUsuario.actualizar(this.id, model).toPromise().then(e => {
            if (e.exito) {
              this.alerta.alertaExitosa(e.mensaje);
              this.matDialogRef.close(true);
            } else {
              this.alerta.alertaError(e.mensajeError);
            }
          }).catch(ex => {
            this.alerta.alertaError(ex);
          });
        }

      } else {
        this.alerta.alertaInformacion("Las contraseñas no coinciden");
      }
    } else {
      this.fg['password'].removeValidators([Validators.required]);
      this.fg['password'].updateValueAndValidity();
      if (this.formGroup.valid) {
        this.repoUsuario.actualizar(this.id, model).toPromise().then(e => {
          if (e.exito) {
            this.alerta.alertaExitosa(e.mensaje);
            this.matDialogRef.close(true);
          } else {
            this.alerta.alertaError(e.mensajeError);
          }
        }).catch(ex => {
           this.alerta.alertaError(ex);
        });
      }else{
        console.log('formulario invalido')
      }

    }
  }

  realizarCambios(){
    if(this.id){
      this.actualizar();
    }else{
      this.guardar();
    }
  }
  validarContrasenia(): boolean {
    if (this.fg['password'].value === this.fg['confPassword'].value) {
      return true;
    }
    return false;
  }

  cambiarPassword(check: boolean) {
    this.cambioPass = check;
  }
}
