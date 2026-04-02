using Xunit;
using System.Diagnostics;

public class PerformanceTests
{
    [Fact]
    public void AddToCart_Performance_Test()
    {
        var cart = new CartService();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < 10000; i++)
        {
            cart.AddToCart(new Product
            {
                Id = i,
                Name = "Product " + i,
                Price = 10
            });
        }

        stopwatch.Stop();

        Assert.True(stopwatch.ElapsedMilliseconds < 2000,
            $"Занадто довго: {stopwatch.ElapsedMilliseconds} ms");
    }

    [Fact]
    public void GetTotal_Performance_Test()
    {
        var cart = new CartService();

        for (int i = 0; i < 5000; i++)
        {
            cart.AddToCart(new Product
            {
                Id = i,
                Price = 10
            });
        }

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var total = cart.GetTotal();

        stopwatch.Stop();

        Assert.Equal(50000, total);
        Assert.True(stopwatch.ElapsedMilliseconds < 1000,
            $"Повільно: {stopwatch.ElapsedMilliseconds} ms");
    }
}