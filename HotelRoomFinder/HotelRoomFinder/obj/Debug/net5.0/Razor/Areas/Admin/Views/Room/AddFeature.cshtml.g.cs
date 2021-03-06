#pragma checksum "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37f5a0504c0736b2db26b9d4b9b5e7cacaf92019"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Room_AddFeature), @"mvc.1.0.view", @"/Areas/Admin/Views/Room/AddFeature.cshtml")]
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
#line 1 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using HotelRoomFinder.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using HotelRoomFinder.Areas.Admin.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using HotelRoomFinder.Areas.Admin.Model.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using HotelRoomFinder.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\_ViewImports.cshtml"
using HotelRoomFinder.Constants;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f5a0504c0736b2db26b9d4b9b5e7cacaf92019", @"/Areas/Admin/Views/Room/AddFeature.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f828c1f1907057813ffcae1a7df5e2c7088aba0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Room_AddFeature : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddFeatureViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:150px; height:150px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Hotel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary my-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
  
    ViewData["Title"] = "AddFeature";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Add Feature To ");
#nullable restore
#line 6 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
              Write(Model.Room.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"d-flex flex-wrap gap-5\">\r\n");
#nullable restore
#line 9 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
     foreach (var feature in @Model.Features)
    {
        var f = Model.Room.Features.Find(f => f.FeatureId == feature.Id && !f.IsDeleted);
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
         if (f != null)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div data-base-feature-id=\"");
#nullable restore
#line 15 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                  Write(f.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-room-id=\"");
#nullable restore
#line 15 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                                       Write(Model.Room.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-feature-id=\"");
#nullable restore
#line 15 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                                                                        Write(feature.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"feature-item d-flex flex-column\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37f5a0504c0736b2db26b9d4b9b5e7cacaf920197770", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 515, "~/img/features/", 515, 15, true);
#nullable restore
#line 16 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
AddHtmlAttributeValue("", 530, feature.Icon, 530, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <p class=\"text-center\">");
#nullable restore
#line 17 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                  Write(feature.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"d-flex flex-column\">\r\n                    <button type=\"button\" class=\"remove-feature btn btn-danger btn-sm\">Remove</button>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 22 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div data-room-id=\"");
#nullable restore
#line 25 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                          Write(Model.Room.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-feature-id=\"");
#nullable restore
#line 25 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                                           Write(feature.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"feature-item d-flex flex-column\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37f5a0504c0736b2db26b9d4b9b5e7cacaf9201910814", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1021, "~/img/features/", 1021, 15, true);
#nullable restore
#line 26 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
AddHtmlAttributeValue("", 1036, feature.Icon, 1036, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <p class=\"text-center\">");
#nullable restore
#line 27 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
                                  Write(feature.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"d-flex flex-column\">\r\n                    <button type=\"button\" class=\"add-feature btn btn-primary btn-sm\">Add</button>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Aykhan\source\repos\HotelRoomFinder\HotelRoomFinder\Areas\Admin\Views\Room\AddFeature.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37f5a0504c0736b2db26b9d4b9b5e7cacaf9201913374", async() => {
                WriteLiteral("END");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    $("".add-feature"").on(""click"", async function() {
        var button = $(this);
        var featureId = $(this).closest("".feature-item"").data(""feature-id"");
        var roomId = $(this).closest("".feature-item"").data(""room-id"");

        $(button).html(`
                <div class=""spinner-border text-primary"" role=""status"">
                  <span class=""visually-hidden"">Loading...</span>
                </div>
                `);
        $.ajax({
                url: `/Admin/Room/AddFeature/${featureId}`,
                method: ""post"",
                data: {
                    roomId
                },
                success: function(response) {
                    window.location.reload();
                }
        })
    })

    $("".remove-feature"").on(""click"", async function() {
        var button = $(this);
        var featureId = $(this).closest("".feature-item"").data(""base-feature-id"");

        $(button).html(`
                <div class=""spinner-border te");
                WriteLiteral(@"xt-primary"" role=""status"">
                  <span class=""visually-hidden"">Loading...</span>
                </div>
                `);
        $.ajax({
                url: `/Admin/Room/RemoveFeature/${featureId}`,
                method: ""post"",
                success: function(response) {
                    $(button).html(`
                    Add
                    `)
                    .removeClass(""remove-feature"")
                    .removeClass(""btn-danger"")
                    .addClass(""add-feature"")
                    .addClass(""btn-primary"")
                }
                })
    })
</script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddFeatureViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
