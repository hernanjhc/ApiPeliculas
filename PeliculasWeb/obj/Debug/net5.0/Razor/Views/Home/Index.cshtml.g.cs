#pragma checksum "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64d72add558aa993ea6a542639be8150c256ed61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d72add558aa993ea6a542639be8150c256ed61", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4202265a9fcef4b45af732c569546b836f8c81ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PeliculasWeb.Models.ViewModels.IndexVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexCategoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexBusqueda", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Página de Inicio";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"row mt-4\">\r\n    <div class=\"col-sm-12\">\r\n");
#nullable restore
#line 9 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
         if (TempData["alert"] != null)
        {
            //Bootstrap. alert dismisible. https://getbootstrap.com/docs/5.1/components/alerts/

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h5><div class=\"alert alert-danger alert-dismissible fade show\" role=\"alert\"></div></h5>\r\n            <strong>");
#nullable restore
#line 13 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
               Write(TempData["alert"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n            <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>\r\n");
#nullable restore
#line 15 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-6 offset-3\">\r\n        <h2 class=\"text-center\">Últimas Películas</h2>\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""row mt-2"">
    <div class=""col-sm-4 offset-4"">
        <div class=""dropdown"">
            <button class=""btn btn-secondary dropdown-toggle w-100"" type=""button"" id=""dropdownMenuButton""
                    data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                Categorías
            </button>
            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
");
#nullable restore
#line 36 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                 foreach (var item in Model.ListaCategorias)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64d72add558aa993ea6a542639be8150c256ed617504", async() => {
                WriteLiteral(" ");
#nullable restore
#line 39 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                           Write(item.Nombre);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"col-sm-4 float-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64d72add558aa993ea6a542639be8150c256ed6110660", async() => {
                WriteLiteral("\r\n            <input type=\"search\" name=\"nombre\" placeholder=\"Buscar Película\" class=\"form-control mr-sm2\" />\r\n            <button class=\"btn btn-outline-success my-2 my-sm-0\" type=\"submit\">Buscar</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
            WriteLiteral("<div class=\"row mt-3\">\r\n");
#nullable restore
#line 58 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
     if (Model.ListaPeliculas.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
         foreach (var item in Model.ListaPeliculas)
        {
            //Cada pelicula ocupa 4 columnas

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-4\">\r\n                <div class=\"card\" style=\"width:18rem;\">\r\n");
#nullable restore
#line 66 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                     if (item.RutaImagen != null)
                    {
                        var base64 = Convert.ToBase64String(item.RutaImagen);
                        var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 2788, "\"", 2801, 1);
#nullable restore
#line 70 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
WriteAttributeValue("", 2794, imgsrc, 2794, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" />\r\n");
#nullable restore
#line 71 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 74 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                          Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">Duración: ");
#nullable restore
#line 75 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                                  Write(item.Duracion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Clasificación: ");
#nullable restore
#line 76 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                                       Write(item.Clasificacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Fecha de Creación: ");
#nullable restore
#line 77 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                                           Write(item.FechaCreacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">Descripción: ");
#nullable restore
#line 78 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
                                                     Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 82 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>No hay películas para mostrar</p>\r\n");
#nullable restore
#line 87 "C:\Proyectos\Test\ApiPeliculas\PeliculasWeb\Views\Home\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PeliculasWeb.Models.ViewModels.IndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
