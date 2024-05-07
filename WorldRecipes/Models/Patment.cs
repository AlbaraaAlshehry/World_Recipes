using System;
using System.Collections.Generic;

namespace WorldRecipes.Models;

public partial class Patment
{
    public decimal Id { get; set; }

    public decimal? CardNumber { get; set; }

    public decimal? Ccv { get; set; }

    public DateTime? ExDate { get; set; }
}
