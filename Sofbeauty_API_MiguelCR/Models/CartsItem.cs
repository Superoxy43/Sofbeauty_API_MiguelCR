using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class CartsItem
{
    public int CartsItemId { get; set; }

    public int CartsId { get; set; }

    public int ProductsId { get; set; }

    public int Quantity { get; set; }

    public virtual ShoppingCart? Carts { get; set; } = null!;

    public virtual Product? Products { get; set; } = null!;
}
