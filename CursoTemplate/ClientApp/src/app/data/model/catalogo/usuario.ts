export interface Usuario {
  id: number;
  nombre: string;
  apellido: string;
  nombreUsuario: string;
  password: string;
  fechaRegistro: Date;
  activo: boolean;
  CambiarPass:boolean;
}
