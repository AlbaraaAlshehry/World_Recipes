using System;
using System.Collections.Generic;

namespace WorldRecipes.Models;

public partial class Contact
{
    public decimal Id { get; set; }

    public string? Email { get; set; }

    public string? Text { get; set; }
}
