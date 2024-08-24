using System;
using System.Collections.Generic;

namespace Sofbeauty_API_MiguelCR.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string LoginPassword { get; set; } = null!;

    public int UserRolId { get; set; }

    public virtual UserRole? UserRol { get; set; } = null!;
}
