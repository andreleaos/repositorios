#pragma checksum "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d50f3c41adbb80efa3b33d3c27157a26aa04d0f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pessoa_Listar), @"mvc.1.0.view", @"/Views/Pessoa/Listar.cshtml")]
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
#line 1 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\_ViewImports.cshtml"
using ProjetoFinanceiro.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\_ViewImports.cshtml"
using ProjetoFinanceiro.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d50f3c41adbb80efa3b33d3c27157a26aa04d0f6", @"/Views/Pessoa/Listar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eddc3890ce7384b31acc219812de7172d5a400f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Pessoa_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProjetoFinanceiro.Web.Models.Dtos.PessoaDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
  
    ViewData["Title"] = "Listar";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Listar</h4>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d50f3c41adbb80efa3b33d3c27157a26aa04d0f63909", async() => {
                WriteLiteral("Adicionar Novo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.ActionLink("Atualizar", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 41 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 42 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
           Write(Html.ActionLink("Excluir", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\Andre\source\repos\ProjetoFinanceiro-Youtube\Aula_16\ProjetoFinanceiro\ProjetoFinanceiro.Web\Views\Pessoa\Listar.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProjetoFinanceiro.Web.Models.Dtos.PessoaDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591