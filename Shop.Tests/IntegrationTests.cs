using Xunit;

public class IntegrationTests
{
    [Fact]
    public void FullCartScenario_WorksCorrectly()
    {
        // Імітуємо роботу магазину
        var cart = new CartService();

        var product1 = new Product { Id = 1, Name = "Ariel", Price = 100 };
        var product2 = new Product { Id = 2, Name = "Fairy", Price = 50 };

        // Користувач додає товари
        cart.AddToCart(product1);
        cart.AddToCart(product2);
        cart.AddToCart(product1); // ще раз той самий

        // Перевіряємо кількість
        Assert.Equal(2, cart.Items.First(x => x.Product.Id == 1).Quantity);
        Assert.Equal(1, cart.Items.First(x => x.Product.Id == 2).Quantity);

        // Перевіряємо суму
        Assert.Equal(250, cart.GetTotal());

        // Видаляємо товар
        cart.RemoveFromCart(product2);

        // Перевірка після видалення
        Assert.Single(cart.Items);
        Assert.Equal(200, cart.GetTotal());
    }
}