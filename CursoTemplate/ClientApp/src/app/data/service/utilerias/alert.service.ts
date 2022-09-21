import { Injectable } from '@angular/core';
import { MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
@Injectable({providedIn: 'root'})
export class AlertasService {
  posicionHorizontal:MatSnackBarHorizontalPosition='center';
  posicionVertical:MatSnackBarVerticalPosition='top';

  constructor(public snackBar:MatSnackBar) { }

 alertaExitosa(mensaje:string):void{
    this.snackBar.open('✔️'+mensaje,'',{
      duration:1200,
      horizontalPosition:this.posicionHorizontal,
      verticalPosition:this.posicionVertical
    });
 }
 alertaError(mensaje:string):void{
  this.snackBar.open('❌'+mensaje,'',{
    duration:1200,
    horizontalPosition:this.posicionHorizontal,
    verticalPosition:this.posicionVertical
  });
}
alertaInformacion(mensaje:string):void{
  this.snackBar.open('ℹ️'+mensaje,'',{
    duration:1200,
    horizontalPosition:this.posicionHorizontal,
    verticalPosition:this.posicionVertical
  });
}
alertaAdvertencia(mensaje:string):void{
  this.snackBar.open('⚠️'+mensaje,'',{
    duration:1200,
    horizontalPosition:this.posicionHorizontal,
    verticalPosition:this.posicionVertical
  });
}

}
