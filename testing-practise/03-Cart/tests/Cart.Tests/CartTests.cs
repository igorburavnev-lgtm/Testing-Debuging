using Practise;

namespace Cart.Tests;

public class CartTests
{
    private static List<CartItem> Items(params (string name, decimal price, int qty)[] rows)
    {
        var list = new List<CartItem>();
        foreach (var r in rows) list.Add(new CartItem(r.name, r.price, r.qty));
        return list;
    }

    [Fact]
    public void Subtotal_OneItemTwoPieces_MultipliesPriceByQuantity()
    {
        var cart = Items(("хлеб", 50m, 2));
        Assert.Equal(100m, Practise.Cart.Subtotal(cart));
    }

    [Fact]
    public void TotalQuantity_CountsPiecesNotLines()
    {
        var cart = Items(("хлеб", 50m, 2), ("молоко", 80m, 3));
        Assert.Equal(5, Practise.Cart.TotalQuantity(cart));
    }

    [Fact]
    public void ApplyDiscount_TenPercent_Returns900()
    {
        Assert.Equal(900m, Practise.Cart.ApplyDiscount(1000m, 10));
    }

    [Fact]
    public void ApplyDiscount_ZeroPercent_ReturnsSameSum()
    {
        Assert.Equal(1000m, Practise.Cart.ApplyDiscount(1000m, 0));
    }

    [Fact]
    public void ApplyDiscount_HundredPercent_ReturnsZero()
    {
        Assert.Equal(0m, Practise.Cart.ApplyDiscount(1000m, 100));
    }

    [Fact]
    public void ApplyDiscount_OutOfRange_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Practise.Cart.ApplyDiscount(1000m, 120));
    }

    [Fact]
    public void Shipping_AboveThreshold_IsFree()
    {
        Assert.Equal(0m, Practise.Cart.Shipping(2500m));
    }

    [Fact]
    public void Shipping_ExactlyAtThreshold_IsFree()
    {
        Assert.Equal(0m, Practise.Cart.Shipping(2000m));
    }

    [Fact]
    public void Shipping_OneRubleBelow_Is300()
    {
        Assert.Equal(300m, Practise.Cart.Shipping(1999m));
    }

    [Fact]
    public void Round2_ThirdDecimalBelowFive_Truncates()
    {
        Assert.Equal(10.00m, Practise.Cart.Round2(10.004m));
    }

    [Fact]
    public void Round2_ThirdDecimalIsFive_RoundsUp()
    {
        Assert.Equal(2.35m, Practise.Cart.Round2(2.345m));
    }

    [Fact]
    public void Round2_AnotherHalfUpCase()
    {
        Assert.Equal(2.36m, Practise.Cart.Round2(2.355m));
    }

    [Fact]
    public void Total_AboveThresholdWithDiscount_NoShipping()
    {
        var cart = Items(("хлеб", 2500m, 1));
        Assert.Equal(2250m, Practise.Cart.Total(cart, 10));
    }

    [Fact]
    public void Total_BelowThresholdWithDiscount_AddsShipping()
    {
        var cart = Items(("хлеб", 1000m, 1));
        Assert.Equal(1300m, Practise.Cart.Total(cart, 0));
    }

    [Fact]
    public void Cheapest_TwoItems_ReturnsCheaper()
    {
        var cart = Items(("а", 50m, 1), ("б", 30m, 1));
        CartItem cheapest = Practise.Cart.Cheapest(cart);
        Assert.Equal("б", cheapest.Name);
    }

    [Fact]
    public void Cheapest_EmptyCart_ThrowsInvalidOperation()
    {
        var cart = new List<CartItem>();
        Assert.Throws<InvalidOperationException>(() => Practise.Cart.Cheapest(cart));
    }
}