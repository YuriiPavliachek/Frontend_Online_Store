using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using SimpleFrontendApp.Pages;

public class StaticPagesTests
{
    [Fact]
    public void IndexPage_ShouldRender()
    {
        using var ctx = new TestContext();

        ctx.Services.AddSingleton<CartService>();

        var component = ctx.RenderComponent<SimpleFrontendApp.Pages.Index>();

        Assert.NotNull(component);
    }
}