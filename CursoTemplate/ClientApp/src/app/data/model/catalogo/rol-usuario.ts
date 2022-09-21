import { ThemePalette } from "@angular/material/core";

export interface RolUsuario {
  rolNombre: string;
  rolId: number;
  nombreUsuario: string;
  nombreCompleto: string;
  usuarioId: number;
  activo: boolean;
}


export interface RolUsuarioListCheck {
  name: string;
  completed: boolean;
  color: ThemePalette;
  listaRol?: RolUsuario[];
}
