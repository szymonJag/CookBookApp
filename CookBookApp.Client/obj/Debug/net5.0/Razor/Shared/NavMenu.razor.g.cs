#pragma checksum "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1692666f128511c8a46e6e6aec046eacc26a2e06"
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
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-qon8db8zzs");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-qon8db8zzs>CookBookApp.Client</a>\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-qon8db8zzs");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-qon8db8zzs></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n\n");
            __builder.OpenComponent<CookBookApp.Client.Shared.AuthorizeView>(10);
            __builder.AddAttribute(11, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", 
#nullable restore
#line 12 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                     NavMenuCssClass

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                                                ToggleNavMenu

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "b-qon8db8zzs");
                __builder2.OpenElement(16, "ul");
                __builder2.AddAttribute(17, "class", "nav flex-column");
                __builder2.AddAttribute(18, "b-qon8db8zzs");
                __builder2.OpenElement(19, "li");
                __builder2.AddAttribute(20, "class", "nav-item px-3");
                __builder2.AddAttribute(21, "b-qon8db8zzs");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(22);
                __builder2.AddAttribute(23, "class", "nav-link");
                __builder2.AddAttribute(24, "href", "");
                __builder2.AddAttribute(25, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 15 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                                                             NavLinkMatch.All

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(27, "<span class=\"oi oi-home\" aria-hidden=\"true\" b-qon8db8zzs></span> Strona główna\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
#nullable restore
#line 19 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                 if (AuthenticationService.User != null)
                {
                    if (AuthenticationService.User.Role == "admin")
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(28, "li");
                __builder2.AddAttribute(29, "class", "nav-item px-3");
                __builder2.AddAttribute(30, "b-qon8db8zzs");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(31);
                __builder2.AddAttribute(32, "class", "nav-link");
                __builder2.AddAttribute(33, "href", "adminpanel");
                __builder2.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(35, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-qon8db8zzs>Panel administratora</span>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
#nullable restore
#line 27 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
      }

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(36, "li");
                __builder2.AddAttribute(37, "class", "nav-item px-3");
                __builder2.AddAttribute(38, "b-qon8db8zzs");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(39);
                __builder2.AddAttribute(40, "class", "nav-link");
                __builder2.AddAttribute(41, "href", "userpanel");
                __builder2.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(43, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-qon8db8zzs>Panel użytkownika</span>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
#nullable restore
#line 33 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
}

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(44, "Unauthorized", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(45, "div");
                __builder2.AddAttribute(46, "class", 
#nullable restore
#line 40 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                     NavMenuCssClass

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                                                ToggleNavMenu

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(48, "b-qon8db8zzs");
                __builder2.OpenElement(49, "ul");
                __builder2.AddAttribute(50, "class", "nav flex-column");
                __builder2.AddAttribute(51, "b-qon8db8zzs");
                __builder2.OpenElement(52, "li");
                __builder2.AddAttribute(53, "class", "nav-item px-3");
                __builder2.AddAttribute(54, "b-qon8db8zzs");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(55);
                __builder2.AddAttribute(56, "class", "nav-link");
                __builder2.AddAttribute(57, "href", "");
                __builder2.AddAttribute(58, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 43 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
                                                             NavLinkMatch.All

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(60, "<span class=\"oi oi-home\" aria-hidden=\"true\" b-qon8db8zzs></span> Strona główna\n                    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Users\48510\Documents\GitHub\CookBook\CookBookApp\CookBookApp.Client\Shared\NavMenu.razor"
        private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    } 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthenticationService { get; set; }
    }
}
#pragma warning restore 1591
