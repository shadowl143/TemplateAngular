import { RespositorioLogin } from './../../data/service/repositorio/repo-login';
import { AutenticacionService } from './../../core/service/autenticacion.service';
import { Credencial } from './../../data/model/seguridad/credencial';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from 'src/app/data/model/login';
import { Respuesta } from 'src/app/data/model/respuesta';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  hide = true;
  formGroup:FormGroup;
  get getForm(){return this.formGroup.controls}

  constructor(private formBuilder:FormBuilder,private http:RespositorioLogin,private autenticacion :AutenticacionService
    ,private router:Router) {
        if(autenticacion.CredencialUsuario().token){
          router.navigate(['/'])
        }

     }

  ngOnInit(): void {
    this.formGroup=this.formBuilder.group({
      usuario:['',Validators.required],
      contrasenia:['',[Validators.required]]
    });
    AutenticacionService

  }

  inciarSesion():void{
    const model=this.formGroup.value as Login;
    if(this.formGroup.valid){
      this.http.iniciarSesion(model).toPromise().then(e=>{
        if(e.exito && e.model){
          this.autenticacion.asignarCredencial(e.model);
          this.router.navigate(['/']);
        }else {
          alert(e.mensaje)
        }
      }).catch(err=>{
        alert(err)
      });
    }else{
      alert('Formulario no valido');

    }
  }

}
