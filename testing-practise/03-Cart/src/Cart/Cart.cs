namespace Practise;

public record CartItem(string Name, decimal Price, int Quantity);

public static class Cart
{
    public static decimal Subtotal(List<CartItem> items)
    {
        decimal sum = 0;
        foreach (var item in items) sum += item.Price * item.Quantity;
        return sum;
    }

    public static decimal ApplyDiscount(decimal sum, int percent)
    {
        if (percent < 0 || percent > 100)
            throw new ArgumentOutOfRangeException(nameof(percent));
        return sum * (1 - percent / 100m);
    }

    public static decimal Shipping(decimal sum)
    {
        return sum >= 2000m ? 0m : 300m;
    }

    public static decimal Round2(decimal sum)
    {
        return Math.Round(sum, 2, MidpointRounding.AwayFromZero);
    }

    public static decimal Total(List<CartItem> items, int discountPercent)
    {
        decimal sum = Subtotal(items);
        decimal discounted = ApplyDiscount(sum, discountPercent);
        return Round2(discounted + Shipping(discounted));
    }

    public static CartItem Cheapest(List<CartItem> items)
    {
        if (items.Count == 0) throw new InvalidOperationException("корзина пуста");
        CartItem best = items[0];
        foreach (var item in items)
            if (item.Price < best.Price) best = item;
        return best;
    }

    public static int TotalQuantity(List<CartItem> items)
    {
        int count = 0;
        foreach (var item in items) count += item.Quantity;
        return count;
    }
}