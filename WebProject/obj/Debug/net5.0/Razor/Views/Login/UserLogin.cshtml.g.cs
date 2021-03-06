#pragma checksum "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b814075eea538fc2d0fd5b5f97918e486a1f626"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_UserLogin), @"mvc.1.0.view", @"/Views/Login/UserLogin.cshtml")]
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
#line 1 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\_ViewImports.cshtml"
using WebProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\_ViewImports.cshtml"
using DataModel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\_ViewImports.cshtml"
using DataModel.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b814075eea538fc2d0fd5b5f97918e486a1f626", @"/Views/Login/UserLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f2345afb6deccdb0ea32afd778dc6ff4b74936b", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_UserLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
  
    ViewData["Title"] = "User Login";
    Layout = "~/Views/Shared/_WebLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""login-area"" style=""width:500px;margin: 3% auto"">
    <div class=""card"">
        <div class=""card-header"" style=""border-top:3px solid"">
            <h4 class=""text-center font-weight-bold""><i class=""fas fa-sign-in-alt""></i> Member Login Panel</h4>
        </div>
        <div class=""card-body"">
");
#nullable restore
#line 14 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
             using (Html.BeginForm("UserLogin", "Login", new { url = ViewContext.HttpContext.Request.Query["url"] }, FormMethod.Post))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
           Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <i class=\"fas fa-envelope\"></i> ");
#nullable restore
#line 18 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                                               Write(Html.LabelFor(model => model.Email, new { @class = "form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 19 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 20 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"mt-3\">\r\n                    <i class=\"fas fa-key\"></i> ");
#nullable restore
#line 23 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                                          Write(Html.LabelFor(model => model.Password, new { @class = "form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 24 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.PasswordFor(model => model.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 25 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"mt-3\">\r\n                    ");
#nullable restore
#line 28 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.CheckBoxFor(model => model.RememberMe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 29 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.LabelFor(model => model.RememberMe, new { @class = "form-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <button type=\"submit\" class=\"btn btn-info btn-block mt-3\"><i class=\"fas fa-sign-in-alt\"></i> Login</button>\r\n                <div class=\"mt-3\">\r\n                    ");
#nullable restore
#line 33 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.ActionLink("Have not account yet?", "Signup", "Signup", null, new { @class = "float-left" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 34 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
               Write(Html.ActionLink("Forgot password?", "ForgetPassword", "ForgetPassword", null, new { @class = "float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 36 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("SweetAlert", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 42 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
     if (TempData["InvalidCredentialError"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                title: \"Status!\",\r\n                text: \"");
#nullable restore
#line 47 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                  Write(TempData["InvalidCredentialError"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                icon: \"error\",\r\n                button: \"Ok!\",\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 52 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
     if (TempData["UserDeactivated"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                title: \"Status!\",\r\n                text: \"");
#nullable restore
#line 58 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                  Write(TempData["UserDeactivated"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                icon: \"error\",\r\n                button: \"Ok!\",\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 63 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
     if (TempData["RegistrationCompleteMessage"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                title: \"Status!\",\r\n                text: \"");
#nullable restore
#line 69 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                  Write(TempData["RegistrationCompleteMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                icon: \"success\",\r\n                button: \"Ok!\",\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 74 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
     if (TempData["PasswordResetSuccess"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                title: \"Status!\",\r\n                text: \"");
#nullable restore
#line 80 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                  Write(TempData["PasswordResetSuccess"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                icon: \"success\",\r\n                button: \"Ok!\",\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 85 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
     if (TempData["AccountDeactivated"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                title: \"Status!\",\r\n                text: \"");
#nullable restore
#line 91 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
                  Write(TempData["AccountDeactivated"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n                icon: \"success\",\r\n                button: \"Ok!\",\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 96 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Views\Login\UserLogin.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
