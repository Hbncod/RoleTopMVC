#pragma checksum "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fec50db6cbcb07f14617a597d5c7862f4bdcbdcc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agendar_MeusEventos), @"mvc.1.0.view", @"/Views/Agendar/MeusEventos.cshtml")]
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
#line 1 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fec50db6cbcb07f14617a597d5c7862f4bdcbdcc", @"/Views/Agendar/MeusEventos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Agendar_MeusEventos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMVC.ViewModels.HistoricoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section id=""lista-eventos"">
    <table>
        <tr>
            <thead>
                <th rowspan=""2"">Data</th>
                <th rowspan=""2"">Horario</th>
                <th rowspan=""2"">Descrição</th>
                <th rowspan=""2"">Convidados</th>
                <th rowspan=""2"">Equipamentos</th>
                <th rowspan=""2"">Cartaz</th>
                <th rowspan=""2"">Status Evento</th>
            </thead>
        </tr>
        <tbody>
");
#nullable restore
#line 17 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
             foreach (var dados in Model.Eventos)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                <td>");
#nullable restore
#line 20 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
               Write(dados.Agendado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
               Write(dados.Horario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
               Write(dados.DescricaoEvento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
               Write(dados.NumeroConvidados);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 24 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                 if(dados.Som > 0 && dados.Luzes > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"letras\">Som e Luzes</td>\r\n");
#nullable restore
#line 27 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }
                else if(dados.Som > 0 )
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"letras\">Som </td>\r\n");
#nullable restore
#line 31 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }
                else if(dados.Luzes > 0 )
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td class=\"letras\">Luzes</td>\r\n");
#nullable restore
#line 35 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"letras\">Por Imagem</td>\r\n                <br>\r\n                \r\n");
#nullable restore
#line 39 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                 if(@dados.Status == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Pendente</td>\r\n");
#nullable restore
#line 42 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }
                else if(@dados.Status == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Aprovado</td>\r\n");
#nullable restore
#line 46 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                 if(@dados.Status == 2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td id=\"reprovado\">Reprovado</td>\r\n");
#nullable restore
#line 50 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 52 "E:\Personal\RoleTopMVC\RoleTopMVC\Views\Agendar\MeusEventos.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMVC.ViewModels.HistoricoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
