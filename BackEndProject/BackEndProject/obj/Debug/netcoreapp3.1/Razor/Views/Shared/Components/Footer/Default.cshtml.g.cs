#pragma checksum "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e74d79b57b8b9a988e4e80005f3afd93ed00b33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#line 1 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\_ViewImports.cshtml"
using BackEndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e74d79b57b8b9a988e4e80005f3afd93ed00b33", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95e5cf500e2c947de4e1e951dbb837b727c781bb", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bio>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/payment.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("payment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
 <section class=""footer-area bg_cover"" style=""background-image: url(assets/images/bg-footer.jpg)"">
        <div class=""footer-widget pt-30 pb-70"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-lg-4"">
                        <div class=""footer-contact mt-50"">
                            <h4 class=""footer-title"">Contact Details</h4>

                            <ul>
                                <li><i class=""fas fa-map-marker-alt""></i> ");
#nullable restore
#line 12 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\Shared\Components\Footer\Default.cshtml"
                                                                     Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li><i class=\"fas fa-phone\"></i> <a href=\"tell:123-456-789\">");
#nullable restore
#line 13 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\Shared\Components\Footer\Default.cshtml"
                                                                                       Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li><i class=\"fas fa-envelope\"></i><a href=\"mailto://email@yourwebsitename.com\">");
#nullable restore
#line 14 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\Shared\Components\Footer\Default.cshtml"
                                                                                                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li><i class=\"far fa-clock\"></i> ");
#nullable restore
#line 15 "C:\Users\farid\Desktop\Lahiye\BackendProject\BackEndProject\BackEndProject\Views\Shared\Components\Footer\Default.cshtml"
                                                            Write(Model.WorkTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                            </ul>
                        </div> <!-- footer contact -->
                    </div>
                    <div class=""col-lg-8"">
                        <div class=""footer-link-wrapper d-flex flex-wrap justify-content-between"">
                            <div class=""footer-link mt-50"">
                                <h4 class=""footer-title"">Information</h4>

                                <ul class=""link"">
                                    <li><a href=""#"">Delivery</a></li>
                                    <li><a href=""#"">Legal Notice</a></li>
                                    <li><a href=""about.html"">About us</a></li>
                                    <li><a href=""#"">Secure payment</a></li>
                                    <li><a href=""contact.html"">Contact us</a></li>
                                </ul>
                            </div> <!-- footer link -->
                            <div class=""footer-link mt-50"">
                     ");
            WriteLiteral(@"           <h4 class=""footer-title"">Customer</h4>

                                <ul class=""link"">
                                    <li><a href=""shop-4-column.html"">Prices drop</a></li>
                                    <li><a href=""shop-4-column.html"">New Product</a></li>
                                    <li><a href=""shop-3-column.html"">Best Sales</a></li>
                                    <li><a href=""#"">Sitemap</a></li>
                                    <li><a href=""login.html"">Login</a></li>
                                </ul>
                            </div> <!-- footer link -->
                            <div class=""footer-link mt-50"">
                                <h4 class=""footer-title"">About Us</h4>

                                <ul class=""link"">
                                    <li><a href=""#"">About Our Shop</a></li>
                                    <li><a href=""#"">Secure Shopping </a></li>
                                    <li><a href=""#"">Delivery in");
            WriteLiteral(@"fomation </a></li>
                                    <li><a href=""#"">Store Locations </a></li>
                                    <li><a href=""#"">Affiliates </a></li>
                                </ul>
                            </div> <!-- footer link -->
                            <div class=""footer-link mt-50"">
                                <h4 class=""footer-title"">My account</h4>

                                <ul class=""link"">
                                    <li><a href=""#"">Personal info</a></li>
                                    <li><a href=""#"">Order</a></li>
                                    <li><a href=""#"">Credit Slips</a></li>
                                    <li><a href=""#"">Address</a></li>
                                </ul>
                            </div> <!-- footer link -->
                        </div> <!-- footer link wrapper -->
                    </div>
                </div> <!-- row -->
            </div> <!-- container -->
        </div> <!");
            WriteLiteral(@"-- footer widget -->

        <div class=""footer-copyright"">
            <div class=""container"">
                <div class=""footer-copyright-payment text-center d-lg-flex justify-content-between align-items-center"">
                    <div class=""copyright-text"">
                        <p>Copyright 2020 &copy; <a href=""https://hasthemes.com/"">HasThemes</a> . All Rights Reserved</p>
                    </div>
                    <div class=""payment"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8e74d79b57b8b9a988e4e80005f3afd93ed00b339954", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div> <!-- footer copyright payment -->\r\n            </div> <!-- container -->\r\n        </div> <!-- footer copyright -->\r\n    </section>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bio> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
