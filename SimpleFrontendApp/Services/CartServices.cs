public class CartService
{
    public List<CartItem> Items { get; private set; } = new List<CartItem>();

    public void AddToCart(Product product)
    {
        var item = Items.FirstOrDefault(x => x.Product.Id == product.Id);
        if (item != null)
        {
            item.Quantity++;
        }
        else
        {
            Items.Add(new CartItem { Product = product });
        }
    }

    public void RemoveFromCart(Product product)
    {
        var item = Items.FirstOrDefault(x => x.Product.Id == product.Id);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    public decimal GetTotal() => Items.Sum(x => x.Product.Price * x.Quantity);
}