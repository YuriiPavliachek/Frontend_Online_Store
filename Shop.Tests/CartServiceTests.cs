using Xunit;

public class CartServiceTests
{
    [Fact]
    public void AddToCart_AddsProduct()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Name = "Ariel", Price = 100 };

        cart.AddToCart(product);

        Assert.Single(cart.Items);
    }

    [Fact]
    public void AddToCart_IncreasesQuantity_WhenSameProduct()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Name = "Ariel", Price = 100 };

        cart.AddToCart(product);
        cart.AddToCart(product);

        Assert.Equal(2, cart.Items[0].Quantity);
    }

    [Fact]
    public void RemoveFromCart_RemovesItem()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Name = "Ariel", Price = 100 };

        cart.AddToCart(product);
        cart.RemoveFromCart(product);

        Assert.Empty(cart.Items);
    }
    [Fact]
    public void GetTotal_WithMultipleQuantities()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Name = "A", Price = 100 };

        cart.AddToCart(product);
        cart.AddToCart(product);

        Assert.Equal(200, cart.GetTotal());
    }
    [Fact]
    public void CartItem_DefaultQuantity_IsOne()
    {
        var item = new CartItem
        {
            Product = new Product { Id = 1, Price = 100 },
            Quantity = 1
        };

        Assert.Equal(1, item.Quantity);
    }
    [Fact]
    public void AddToCart_IncreasesQuantity()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Name = "A", Price = 100 };

        cart.AddToCart(product);
        cart.AddToCart(product);

        Assert.Equal(2, cart.Items[0].Quantity);
    }

    [Fact]
    public void AddToCart_AddsDifferentProducts()
    {
        var cart = new CartService();

        cart.AddToCart(new Product { Id = 1, Price = 100 });
        cart.AddToCart(new Product { Id = 2, Price = 50 });

        Assert.Equal(2, cart.Items.Count);
    }
    [Fact]
    public void GetTotal_ReturnsCorrectSum()
    {
        var cart = new CartService();

        cart.AddToCart(new Product { Id = 1, Price = 100 });
        cart.AddToCart(new Product { Id = 2, Price = 50 });

        Assert.Equal(150, cart.GetTotal());
    }

    [Fact]
    public void GetTotal_WithQuantity()
    {
        var cart = new CartService();
        var product = new Product { Id = 1, Price = 100 };

        cart.AddToCart(product);
        cart.AddToCart(product);

        Assert.Equal(200, cart.GetTotal());
    }
}