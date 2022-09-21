const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:51855';

const PROXY_CONFIG = [
  {
    context: [
      "/api/Usuario",
      "/api/RolUsuario",
      "/api/RolPagina",
      "/api/Login",
      "/api/Rol",
      "/api/Menu",
      "/api/Pagina",
      "/weatherforecast",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
