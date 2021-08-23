using ApiPeliculas.Data;
using ApiPeliculas.PeliculasMapper;
using ApiPeliculas.Repositories;
using ApiPeliculas.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculas
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
            /*Cadena conexion*/
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*Inyeccion de dependencias de Interfaz*/
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPeliculaRepository, PeliculaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            /*Añade automapper*/
            services.AddAutoMapper(typeof(PeliculasMappers));

            /*Dependencia del token*/
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //Documentacion API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ApiPeliculasCategorias", new OpenApiInfo
                {
                    Title = "API Categoria Películas",
                    Version = "v1",
                    Description = "Backend películas",
                    Contact = new OpenApiContact()
                    {
                        Email = "hernan_jhc@hotmail.com",
                        Name = "jhc",
                        Url = new Uri("https://mipaginaweb.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
                    }
                });
                c.SwaggerDoc("ApiPeliculas", new OpenApiInfo
                {
                    Title = "API Películas",
                    Version = "v1",
                    Description = "Backend películas",
                    Contact = new OpenApiContact()
                    {
                        Email = "hernan_jhc@hotmail.com",
                        Name = "jhc",
                        Url = new Uri("https://mipaginaweb.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
                    }
                });
                c.SwaggerDoc("ApiPeliculasUsuarios", new OpenApiInfo
                {
                    Title = "API Usuarios Películas",
                    Version = "v1",
                    Description = "Backend películas",
                    Contact = new OpenApiContact()
                    {
                        Email = "hernan_jhc@hotmail.com",
                        Name = "jhc",
                        Url = new Uri("https://mipaginaweb.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://en.wikipedia.org/wiki/MIT_License")
                    }
                });
                var archivoXmlComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaApiComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
                c.IncludeXmlComments(rutaApiComentarios);
            });

            /*Estandar*/
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/ApiPeliculasCategorias/swagger.json", "Api Categorias Peliculas v1");
                    c.SwaggerEndpoint("/swagger/ApiPeliculas/swagger.json", "Api Peliculas v1");
                    c.SwaggerEndpoint("/swagger/ApiPeliculasUsuarios/swagger.json", "Api Usuarios Peliculas v1");
                });
                
            }

            //app.UseSwagger();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
