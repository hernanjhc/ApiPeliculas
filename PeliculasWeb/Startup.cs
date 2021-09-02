using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeliculasWeb.Repositories;
using PeliculasWeb.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Agregamos autenticacion. JWT se guarda en cokie del navegador
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.HttpOnly = true;
                    //tiempo de duracion de cokie
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = "/Home/Login";
                    options.AccessDeniedPath = "/Home/AccessDenied";
                    options.SlidingExpiration = true;
                });

            services.AddControllersWithViews();

            //Llamados http
            services.AddHttpClient();

            /*Damos soporte para CORS*/
            services.AddCors();

            //Agregar Repositorios como inyección de dependencias
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            //configurar sesion
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Damos soporte para cors: Desde API permite conectarse de un dominio diferente
            //Dar acceso a cors: Desde App para usar cors
            app.UseCors(x => 
            x.AllowAnyOrigin()  //acceder desde cualquier origen
            .AllowAnyMethod()   //acceder desde cualquier método
            .AllowAnyHeader());
        }
    }
}
