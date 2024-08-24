using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public int CustomersId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly OrdersDate { get; set; }

    public string DeliveryMethods { get; set; } = null!;

    public virtual Customer Customers { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
