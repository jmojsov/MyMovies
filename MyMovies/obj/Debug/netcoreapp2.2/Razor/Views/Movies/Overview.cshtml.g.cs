#pragma checksum "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45c1f5e20e00bc80f52d5755dc2bdcd7f2531ecb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Overview), @"mvc.1.0.view", @"/Views/Movies/Overview.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movies/Overview.cshtml", typeof(AspNetCore.Views_Movies_Overview))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45c1f5e20e00bc80f52d5755dc2bdcd7f2531ecb", @"/Views/Movies/Overview.cshtml")]
    public class Views_Movies_Overview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MyMovies.Models.Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
   
    Layout = "_Layout";
    ViewBag.Title = "Home";

#line default
#line hidden
            BeginContext(99, 90, true);
            WriteLiteral("\r\n\r\n    \r\n    <div class=\"container\" style=\"margin-top:20px\">\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 11 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
             foreach (var movie in @Model)
            {

#line default
#line hidden
            BeginContext(248, 108, true);
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <div class=\"card\">\r\n                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 356, "\"", 377, 1);
#line 15 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
WriteAttributeValue("", 362, movie.ImageUrl, 362, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(378, 134, true);
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n                        <div class=\"card-body\">\r\n                            <h5 class=\"card-title\">");
            EndContext();
            BeginContext(513, 11, false);
#line 17 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
                                              Write(movie.Title);

#line default
#line hidden
            EndContext();
            BeginContext(524, 56, true);
            WriteLiteral("</h5>\r\n                            <p class=\"card-text\">");
            EndContext();
            BeginContext(581, 17, false);
#line 18 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
                                            Write(movie.Description);

#line default
#line hidden
            EndContext();
            BeginContext(598, 37, true);
            WriteLiteral(".</p>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 635, "\"", 667, 2);
            WriteAttributeValue("", 642, "/Movies/Details/", 642, 16, true);
#line 19 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
WriteAttributeValue("", 658, movie.Id, 658, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(668, 127, true);
            WriteLiteral(" class=\"btn btn-primary\">Go somewhere</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 23 "C:\Users\Joco\Desktop\CODE\MyMovies\MyMovies\Views\Movies\Overview.cshtml"
            }

#line default
#line hidden
            BeginContext(810, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MyMovies.Models.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591