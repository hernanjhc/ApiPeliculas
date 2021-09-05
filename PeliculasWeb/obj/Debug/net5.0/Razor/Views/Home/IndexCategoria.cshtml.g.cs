#pragma checksum "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2867f65e7e0222dbd75a369aaf8200bd548bf7f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexCategoria), @"mvc.1.0.view", @"/Views/Home/IndexCategoria.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\_ViewImports.cshtml"
using PeliculasWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\_ViewImports.cshtml"
using PeliculasWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2867f65e7e0222dbd75a369aaf8200bd548bf7f1", @"/Views/Home/IndexCategoria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4202265a9fcef4b45af732c569546b836f8c81ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexCategoria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PeliculasWeb.Models.Pelicula>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
  
    ViewData["Title"] = "Filtrar películas en categoría";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"row mt-3\">\r\n");
#nullable restore
#line 9 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
     if (Model.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
         foreach (var item in Model)
        {
            //Cada pelicula ocupa 4 columnas

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-4\">\r\n                <div class=\"card\" style=\"width:18rem;\">\r\n");
#nullable restore
#line 17 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                     if (item.RutaImagen != null)
                    {
                        var base64 = Convert.ToBase64String(item.RutaImagen);
                        var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 778, "\"", 791, 1);
#nullable restore
#line 21 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
WriteAttributeValue("", 784, imgsrc, 784, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" />\r\n");
#nullable restore
#line 22 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 25 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                                          Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">Duración: ");
#nullable restore
#line 26 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                                                  Write(item.Duracion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Clasificación: ");
#nullable restore
#line 27 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                                                       Write(item.Clasificacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Fecha de Creación: ");
#nullable restore
#line 28 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                                                           Write(item.FechaCreacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Descripción: ");
#nullable restore
#line 29 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
                                                     Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 33 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>No hay películas para mostrar</p>\r\n");
#nullable restore
#line 38 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\IndexCategoria.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PeliculasWeb.Models.Pelicula>> Html { get; private set; }
    }
}
#pragma warning restore 1591