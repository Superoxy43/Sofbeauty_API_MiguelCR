using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrdersId { get; set; }

    public int ProductsId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string DeliveryMethod { get; set; } = null!;

    public virtual Order Orders { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;
}
