using ContextoDB.Data;
using CursoTemplate.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace CursoTemplate
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);
            ConfigurarServicios(builder);
            IConfiguration configuracion = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuracion).CreateLogger();
            builder.Host.UseSerilog();
            var app= builder.Build();
            Configuracion(app);
            return app;

        }

        private static void ConfigurarServicios(WebApplicationBuilder builder)
        {

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Contexto>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    SaveSigninToken = true,
                    ValidateActor=true,
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer=builder.Configuration["ConfiguracionJWT:Issuer"],
                    ValidAudience= builder.Configuration["ConfiguracionJWT:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["ConfiguracionJWT:Contrasenia"])),
                    ClockSkew=TimeSpan.Zero
                };
            });
            builder.Services.AddCors(cors =>            {
                cors.AddPolicy("Autenticacion",
                    c => c.SetIsOriginAllowed(origen => true)
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            LlamarClasesScope.CrearClases(builder);

        }

        public static void Configuracion(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("Autenticacion");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;
        }

    }
}
