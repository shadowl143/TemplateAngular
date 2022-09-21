import { Respuesta } from 'src/app/data/model/respuesta';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export abstract class Repositorio<T> {
  private readonly _ruta:string;

  constructor(public httpClient:HttpClient,public controller:string) {
    this._ruta='api/'+controller
  }

  get ruta(){
    return this._ruta
  }
  get cliente(){
    return this.httpClient;
  }

  obtenerPorId(id:number):Observable<Respuesta<T>>{
    return this.httpClient.get<Respuesta<T>>(`${this.ruta}/${id}`);
  }

  obtenerTodos():Observable<Respuesta<T[]>>{
    return this.httpClient.get<Respuesta<T[]>>(this.ruta);
  }

  guardar(model:T):Observable<Respuesta<T[]>>{
    console.log('muestrame modelo ',model);
    return this.cliente.post<Respuesta<T[]>>(this.ruta,model);
  }

  actualizar(id:number,model:T):Observable<Respuesta<T[]>>{
    return this.httpClient.put<Respuesta<T[]>>(`${this.ruta}/${id}`,model);
  }

  ActivarDeshabilitar(id:number,estatus:boolean):Observable<Respuesta<T[]>>{
    return this.httpClient.put<Respuesta<T[]>>(`${this.ruta}/'cambiarEstatus/'${id}`,estatus);
  }

}
