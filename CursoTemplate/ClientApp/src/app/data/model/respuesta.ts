export interface Respuesta<T> {
  exito: boolean;
  mensaje: string;
  mensajeError: string;
  model: T;
}
