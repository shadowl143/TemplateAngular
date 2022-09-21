import { AlertasService } from './../../../../data/service/utilerias/alert.service';
import { RespositorioMenu } from './../../../../data/service/repositorio/seguridad/repo-menu';
import { Pagina } from 'src/app/data/model/seguridad/pagina';
import { RespositorioPagina } from 'src/app/data/service/repositorio/seguridad/repo-pagina';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Menu } from 'src/app/data/model/seguridad/menu';
import { FormularioMenuComponent } from '../../menu/formulario-menu/formulario-menu.component';

@Component({
  selector: 'app-formulario-pagina',
  templateUrl: './formulario-pagina.component.html',
  styleUrls: ['./formulario-pagina.component.scss']
})
export class FormularioPaginaComponent implements OnInit {
  formGroup: FormGroup;
  listMenu:Menu[]=[];
  ctlMenu=new FormControl('');
  get fg() { return this.formGroup.controls; }
  constructor(private matDialogRef: MatDialogRef<FormularioMenuComponent>,
    private formBuilder: FormBuilder,
    private repoPagina: RespositorioPagina,
    private repoMenu:RespositorioMenu,
    private alertas:AlertasService,
    @Inject(MAT_DIALOG_DATA) public id: number) {
    this.cargarMenu();
    if (id) {
      repoPagina.obtenerPorId(id).toPromise().then(e => {
        if (e.exito) {
          Object.assign(this.formGroup.value, e.model);
          this.formGroup.reset(this.formGroup.value);
          this.ctlMenu.setValue(e.model.menuNombre);
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
      clave:['',[Validators.required]],
      icon:['',[Validators.required]],
      nombre:['',[Validators.required]],
      menuNombre:['',[Validators.required]],
      menuId: [0,[Validators.required]],
      activo: [true]
    });
  }
  cerrar() {
    this.matDialogRef.close();
  }
 cargarMenu(){
  this.repoMenu.obtenerTodos().toPromise().then(e=>{
    if(e.exito){
      this.listMenu=e.model;
    }else{
      this.alertas.alertaError(e.mensajeError)
    }
  });
 }

 seleccionaMenu(model?:Menu){
  console.log(model);
  if(model){
    this.fg['menuNombre'].setValue(model.nombre);
    this.fg['menuId'].setValue(model.id);

  }else{
    this.alertas.alertaAdvertencia('Seleccione un menu valido');
  }
 }
  guardar() {
    const model = this.formGroup.value as Pagina;
    if (this.formGroup.valid) {

      this.repoPagina.guardar(model).toPromise().then(e => {
        if (e.exito) {
          this.alertas.alertaExitosa(e.mensaje);
          this.matDialogRef.close(true);
        } else {
          this.alertas.alertaError(e.mensajeError);
        }
      }).catch(ex => {
        this.alertas.alertaError(ex);
      });


    } else {
      console.error('Formulario es invalido')
    }

  }

  actualizar() {
    const model = this.formGroup.value as Pagina;

    if (this.formGroup.valid) {
      this.repoPagina.actualizar(this.id, model).toPromise().then(e => {
        if (e.exito) {
          this.alertas.alertaExitosa(e.mensaje);
          this.matDialogRef.close(true);
        } else {
          this.alertas.alertaError(e.mensajeError);
        }
      }).catch(ex => {
        this.alertas.alertaError(ex);
      });
    }
    else {
      if (this.formGroup.valid) {
        this.repoPagina.actualizar(this.id, model).toPromise().then(e => {
          if (e.exito) {
            this.alertas.alertaExitosa(e.mensaje);
            this.matDialogRef.close(true);
          } else {
            this.alertas.alertaError(e.mensajeError);
          }
        }).catch(ex => {
          this.alertas.alertaError(ex);
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
