#pragma checksum "G:\DotNetCore\SanaDotNetCore\SanaDotNet\ServiceHost\Pages\Shared\EditorTemplates\Password.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "014b4ee6132f40fe12b0fdf145cd9ddd04646826"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.EditorTemplates.Pages_Shared_EditorTemplates_Password), @"mvc.1.0.view", @"/Pages/Shared/EditorTemplates/Password.cshtml")]
namespace ServiceHost.Pages.Shared.EditorTemplates
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
#line 1 "G:\DotNetCore\SanaDotNetCore\SanaDotNet\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\DotNetCore\SanaDotNetCore\SanaDotNet\ServiceHost\Pages\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"014b4ee6132f40fe12b0fdf145cd9ddd04646826", @"/Pages/Shared/EditorTemplates/Password.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f1dc0cf3c651edca1d55dc1ad49e15a18462a67", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_EditorTemplates_Password : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "G:\DotNetCore\SanaDotNetCore\SanaDotNet\ServiceHost\Pages\Shared\EditorTemplates\Password.cshtml"
Write(Html.TextBoxFor(model => model, new {@class="k-textbox", type="password" }));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591
