#pragma checksum "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd47b81786b08d9d39b2b5030a652a164fbdda26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd47b81786b08d9d39b2b5030a652a164fbdda26", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.AgendarViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 54, true);
            WriteLiteral("<nav id=\"corpoIndex\">\r\n    <h2>Próximos Eventos</h2>\r\n");
            EndContext();
#line 4 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
     foreach (var evento in @Model.EventosPrincipal)
    {

#line default
#line hidden
            BeginContext(162, 42, true);
            WriteLiteral("        <div class=\"evento\">\r\n        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 204, "\"", 230, 2);
            WriteAttributeValue("", 210, "/imagens/", 210, 9, true);
#line 7 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 219, evento.Img, 219, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(231, 27, true);
            WriteLiteral(">\r\n        <p class=\"desc\">");
            EndContext();
            BeginContext(259, 22, false);
#line 8 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
                   Write(evento.DescricaoEvento);

#line default
#line hidden
            EndContext();
            BeginContext(281, 31, true);
            WriteLiteral("</p>\r\n        <p id=\"hora\">Dia ");
            EndContext();
            BeginContext(313, 15, false);
#line 9 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
                    Write(evento.Agendado);

#line default
#line hidden
            EndContext();
            BeginContext(328, 4, true);
            WriteLiteral(" ás ");
            EndContext();
            BeginContext(333, 14, false);
#line 9 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
                                        Write(evento.Horario);

#line default
#line hidden
            EndContext();
            BeginContext(347, 28, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <br>\r\n");
            EndContext();
#line 12 "C:\Users\49826159859\Documents\git so\RoleTopMVC\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(382, 97, true);
            WriteLiteral("        <ul>\r\n            <li><b>Faça Seu Orçamento</b></li>\r\n        </ul>\r\n    </div>\r\n</nav>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMVC.ViewModels.AgendarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
