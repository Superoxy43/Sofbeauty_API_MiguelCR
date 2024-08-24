using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class CustomerContact
{
    public int ContactsId { get; set; }

    public int CustomersId { get; set; }

    public string Adress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PreferredContact { get; set; } = null!;

    public virtual Customer Customers { get; set; } = null!;
}
