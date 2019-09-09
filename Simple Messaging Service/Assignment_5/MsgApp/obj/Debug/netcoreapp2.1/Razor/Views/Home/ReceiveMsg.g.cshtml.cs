#pragma checksum "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "084d75d8f90846870eb0f86e62532218225a0d76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReceiveMsg), @"mvc.1.0.view", @"/Views/Home/ReceiveMsg.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ReceiveMsg.cshtml", typeof(AspNetCore.Views_Home_ReceiveMsg))]
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
#line 1 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\_ViewImports.cshtml"
using MsgApp;

#line default
#line hidden
#line 2 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\_ViewImports.cshtml"
using MsgApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"084d75d8f90846870eb0f86e62532218225a0d76", @"/Views/Home/ReceiveMsg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4848912677d1e2a4418d224663bae28a340afb5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ReceiveMsg : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Msgs>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
  
    ViewData["Title"] = "ReceiveMsg";

#line default
#line hidden
            BeginContext(59, 31, true);
            WriteLiteral("\r\n<h2>Receive Messages</h2>\r\n\r\n");
            EndContext();
#line 8 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
 using (Html.BeginForm("ReceiveMsg", "Home", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(157, 241, true);
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                <h4><strong>Retrieve Messages sent to:</strong></h4>\r\n            </div>\r\n            <div class=\"col-sm-2 pad-10\">\r\n                ");
            EndContext();
            BeginContext(399, 34, false);
#line 16 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
           Write(Html.TextBoxFor(m => Model.userID));

#line default
#line hidden
            EndContext();
            BeginContext(433, 81, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-sm-1 pad-10\">\r\n                ");
            EndContext();
            BeginContext(515, 34, false);
#line 19 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
           Write(Html.CheckBoxFor(m => Model.purge));

#line default
#line hidden
            EndContext();
            BeginContext(549, 160, true);
            WriteLiteral("\r\n                <label>Purge </label>\r\n\r\n            </div>\r\n            <input class=\"pad-10\" type=\"submit\" value=\"Retrieve\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 26 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
}

#line default
#line hidden
            BeginContext(712, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 28 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
 if (Model != null && Model.messages != null && Model.messages.Count > 0)
{
    foreach (Msg messsage in Model.messages)
    {

#line default
#line hidden
            BeginContext(845, 76, true);
            WriteLiteral("        <div class=\"container\">\r\n            <div>\r\n                <strong>");
            EndContext();
            BeginContext(922, 15, false);
#line 34 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
                   Write(messsage.sendID);

#line default
#line hidden
            EndContext();
            BeginContext(937, 74, true);
            WriteLiteral("</strong>\r\n            </div>\r\n            <div>\r\n                <strong>");
            EndContext();
            BeginContext(1012, 18, false);
#line 37 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
                   Write(messsage.timeStamp);

#line default
#line hidden
            EndContext();
            BeginContext(1030, 91, true);
            WriteLiteral("</strong>\r\n            </div>\r\n            <div>\r\n                <p>\r\n                    ");
            EndContext();
            BeginContext(1122, 12, false);
#line 41 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
               Write(messsage.msg);

#line default
#line hidden
            EndContext();
            BeginContext(1134, 60, true);
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 45 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
    }
} else if (Model != null && Model.success == true)
{

#line default
#line hidden
            BeginContext(1256, 51, true);
            WriteLiteral("    <h3 style=\"color:red\">No unread messages</h3>\r\n");
            EndContext();
#line 49 "C:\Users\jonre\source\repos\Assignment_5\MsgApp\Views\Home\ReceiveMsg.cshtml"
}

#line default
#line hidden
            BeginContext(1310, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Msgs> Html { get; private set; }
    }
}
#pragma warning restore 1591