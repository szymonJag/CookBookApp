#pragma checksum "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f169f1f8d2b13ac9e198c0aeb6bce573eea41b6"
// <auto-generated/>
#pragma warning disable 1591
namespace CookBookApp.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Services.LocalStorageService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Services.AuthenticationService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Services.UserService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\_Imports.razor"
using CookBookApp.Client.Services.ProductService;

#line default
#line hidden
#nullable disable
    public partial class TableTemplate<TItem> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "table-wrapper-scroll-y my-custom-scrollbar");
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table table-hover table-striped");
            __builder.OpenElement(4, "thead");
            __builder.OpenElement(5, "tr");
            __builder.AddContent(6, 
#nullable restore
#line 6 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
                 TableHeader

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.OpenElement(8, "tbody");
#nullable restore
#line 9 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
             if (Items != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
                 foreach (var item in Items)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(9, "tr");
            __builder.AddContent(10, 
#nullable restore
#line 13 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
                         RowTemplate(item)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 14 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(11, "<tr>Nic tu nie ma</tr>");
#nullable restore
#line 19 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\TableTemplate.razor"
       
    [Parameter]
    public RenderFragment TableHeader { get; set; }

    [Parameter]
    public RenderFragment<TItem> RowTemplate { get; set; }

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591