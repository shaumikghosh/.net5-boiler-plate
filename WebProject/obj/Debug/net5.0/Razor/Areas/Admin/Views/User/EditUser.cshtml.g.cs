#pragma checksum "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98057918e1ad95164fa09198bc5e0ee55e9e2378"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_EditUser), @"mvc.1.0.view", @"/Areas/Admin/Views/User/EditUser.cshtml")]
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
#line 1 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\_ViewImports.cshtml"
using WebProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\_ViewImports.cshtml"
using DataModel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\_ViewImports.cshtml"
using DataModel.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98057918e1ad95164fa09198bc5e0ee55e9e2378", @"/Areas/Admin/Views/User/EditUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f2345afb6deccdb0ea32afd778dc6ff4b74936b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_User_EditUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UpdateUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
  
    ViewData["Title"] = "EditUser";
    Layout = "~/Areas/Admin/Views/Shared/_ServersideLayout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
 if (TempData["UserUpdate201"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-light\" role=\"alert\">\r\n        ");
#nullable restore
#line 9 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
   Write(TempData["UserUpdate201"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 11 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Content Header (Page header) -->
<div class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h5 class=""m-0 text-dark"">Edit User</h5>
            </div><!-- /.col -->
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Dashboard</a></li>
                    <li class=""breadcrumb-item active"">Edit User</li>
                </ol>
            </div><!-- /.col -->
        </div><!-- /.row -->
    </div><!-- /.container-fluid -->
</div>
");
#nullable restore
#line 28 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""card card-primary"" style=""width:600px;margin:auto"">
                <div class=""card-header"">
                </div>
                <!-- /.card-header -->
                <!-- form start -->
");
#nullable restore
#line 37 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                 using (Html.BeginForm("EditUser", "User", new { area = "Admin" }, FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
               Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                                             ;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card-body\">\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 43 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.LabelFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 44 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.TextBoxFor(model => model.FirstName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 45 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.ValidationMessageFor(model => model.FirstName, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 48 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.LabelFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 49 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.TextBoxFor(model => model.LastName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 50 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.ValidationMessageFor(model => model.LastName, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 53 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.LabelFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 54 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 55 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Email, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 58 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.LabelFor(model => model.UserRole));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 59 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.DropDownListFor(model => model.UserRole, new SelectList(ViewBag.Roles), Model.UserRole, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 60 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                       Write(Html.ValidationMessageFor(model => model.UserRole, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            User Enablity\r\n                            <div class=\"form-group\">\r\n                                ");
#nullable restore
#line 65 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                           Write(Html.RadioButtonFor(model => model.UserEnablity, false));

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;\r\n                                ");
#nullable restore
#line 66 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                            Write("Enabled");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                &nbsp;&nbsp;&nbsp;&nbsp;\r\n                                ");
#nullable restore
#line 68 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                           Write(Html.RadioButtonFor(model => model.UserEnablity, true));

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;\r\n                                ");
#nullable restore
#line 69 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                            Write("Disabled");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.card-body -->\r\n");
            WriteLiteral("                    <div class=\"card-footer\">\r\n                        <button type=\"submit\" class=\"btn btn-primary\">Update</button>\r\n                    </div>\r\n");
#nullable restore
#line 78 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 85 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
}
else {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 style=\"text-align:center;\">The Id you are looking for not found!</h1>\r\n");
#nullable restore
#line 88 "F:\.NET5 Boiler Plate\Template\WebProject\WebProject\Areas\Admin\Views\User\EditUser.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UpdateUser> Html { get; private set; }
    }
}
#pragma warning restore 1591