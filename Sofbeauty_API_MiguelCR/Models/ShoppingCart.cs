using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class ShoppingCart
{
    public int CartsId { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<CartsItem> CartsItems { get; set; } = new List<CartsItem>();
}
