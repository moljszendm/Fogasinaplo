#pragma checksum "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dde77f6f323ed8bb2b7ea9667c323630909fc0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fogasok_Eredmenyek), @"mvc.1.0.view", @"/Views/Fogasok/Eredmenyek.cshtml")]
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
#line 1 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\_ViewImports.cshtml"
using Fogasnaplo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\_ViewImports.cshtml"
using Fogasnaplo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dde77f6f323ed8bb2b7ea9667c323630909fc0c", @"/Views/Fogasok/Eredmenyek.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee176d08ef1abcf4497a5041ed876b35818bea84", @"/Views/_ViewImports.cshtml")]
    public class Views_Fogasok_Eredmenyek : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fogasnaplo.Models.FogasokKeresese>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
  
    ViewData["Title"] = "Eredmények";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<table class=\"table\" id=\"fogas-tablazat\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
           Write(Html.DisplayNameFor(model => model.FogasLista[0].CsapatNev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
           Write(Html.DisplayNameFor(model => model.FogasLista[0].Suly));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
         foreach (var item in Model.FogasLista)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 27 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
               Write(Html.DisplayFor(modelItem => item.CsapatNev));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
               Write(Html.DisplayFor(modelItem => item.Suly));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\mszen\Desktop\Projekt\Fogasnaplo20220415_2229\Fogasnaplo\Fogasnaplo\Views\Fogasok\Eredmenyek.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fogasnaplo.Models.FogasokKeresese> Html { get; private set; }
    }
}
#pragma warning restore 1591
