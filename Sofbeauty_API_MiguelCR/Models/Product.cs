using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class Product
{
    public int ProductsId { get; set; }

    public string ProductsName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Type { get; set; }

    public decimal Price { get; set; }

    public string? Img { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<CartsItem> CartsItems { get; set; } = new List<CartsItem>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
