import { ThemePalette } from "@angular/material/core";

export interface RolPagina {
  rolNombre: string;
  rolId: number;
  paginaNombre: string;
  paginaId: number;
  activo: boolean;
}

export interface RolPaginaListCheck {
  name: string;
  completed: boolean;
  color: ThemePalette;
  listaPagina?: RolPagina[];
}
