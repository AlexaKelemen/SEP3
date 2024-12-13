using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using AngleSharp.Dom;
using BlazorApp1.Auth;
using BlazorApp1.Managers;
using BlazorApp1.Components.Pages;
using Bunit;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp1.Auth;
using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using Bunit.TestDoubles;
using Entities;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Xunit;
using Moq;

namespace Testing;


public class UnitTest1 : TestContext
{
    [Fact]
    public void Test1()
    {
        Services.AddSingleton<IManager>(new Manager());
        Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
        this.AddTestAuthorization();

        var cut = RenderComponent<EditUser>();


        // var button = cut.Find("button");
        var buttons = cut.FindAll("button");
        // buttons.GetElementById("card-button").Click();
        Assert.NotEmpty(buttons);

        // cut.MarkupMatches("isPopupVisible: False");
    }

}