import { Menu } from "./menu";
import { Pagina } from "./pagina";


export interface Credencial {
  usuarioId: number;
  nombreUsuario: string;
  token: string;
  rolId: number;
  menus: Menu[];
  paginas: Pagina[];
}
