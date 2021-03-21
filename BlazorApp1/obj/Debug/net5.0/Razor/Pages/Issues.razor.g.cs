#pragma checksum "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff74df10c91d1fa365e8dff9a0ce068c6714252a"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using BlazorApp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using BlazorApp1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\_Imports.razor"
using BlazorApp1.Model;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/issues")]
    public partial class Issues : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"d-flex justify-content-center mt-4\"><h3>Issues</h3></div>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>\r\n    Fill in the form below and describe your problem.<br>\r\n    We\'ll get back to you as soon ass possible\r\n</p>\r\n\r\n");
            __builder.AddMarkupContent(2, "<h2>Create a new Issue</h2>\r\n");
            __builder.AddMarkupContent(3, @"<div class=""issue-grid mt-4 p-5""><div class=""col-10""><form class=""mt-3""><div class=""row""><div class=""mb-3""><input id=""firstname"" class=""form-control"" type=""text"" placeholder=""Firstname...""></div>
                <div class=""mb-3""><input id=""lastname"" class=""form-control"" type=""text"" placeholder=""Lastname...""></div>
                <div class=""mb-3""><input id=""email"" class=""form-control"" type=""email"" placeholder=""Email...""></div>
                <div class=""mb-3""><textarea class=""form-control"" id=""exampleFormControlTextarea1"" rows=""4"" placeholder=""Description...""></textarea></div></div>
            <div><button class=""btn btn-outline-light"">Submit</button></div></form></div></div>");
#nullable restore
#line 40 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
 if (issues == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "<p>No issues found</p>");
#nullable restore
#line 43 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "table");
            __builder.AddAttribute(6, "class", "table");
            __builder.AddMarkupContent(7, "<tr><th>#</th>\r\n            <th>Created Date</th>\r\n            <th>Customer</th>\r\n            <th>Service Worker</th>\r\n            <th>Issue Status</th></tr>");
#nullable restore
#line 55 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
         foreach (var issue in issues)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "tr");
            __builder.OpenElement(9, "td");
            __builder.AddContent(10, 
#nullable restore
#line 58 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
                     issue.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.OpenElement(12, "td");
            __builder.AddContent(13, 
#nullable restore
#line 59 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
                     issue.IssueDate

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 60 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
                     issue.Customer.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 61 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
                     issue.ServiceWorker.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 62 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
                     issue.IssueStatus

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 64 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 67 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 70 "C:\Users\Linne\source\repos\WepApiAssignment\BlazorApp1\Pages\Issues.razor"
       
    private IEnumerable<IssueViewModel> issues;

    protected override async Task OnInitializedAsync()
    {
        issues = await Http.GetFromJsonAsync<IEnumerable<IssueViewModel>>("https://localhost:44336/api/issues");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
