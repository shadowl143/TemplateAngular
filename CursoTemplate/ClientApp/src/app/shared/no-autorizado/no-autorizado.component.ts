import { Route, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common'
@Component({
  selector: 'app-no-autorizado',
  templateUrl: './no-autorizado.component.html',
  styleUrls: ['./no-autorizado.component.scss']
})
export class NoAutorizadoComponent implements OnInit {

  constructor(private route:Router) { }

  ngOnInit(): void {
  }

  regresar(){
    this.route.navigate(['/']);
  }

}
