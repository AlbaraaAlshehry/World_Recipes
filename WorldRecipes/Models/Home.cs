using System;
using System.Collections.Generic;

namespace WorldRecipes.Models;

public partial class Home
{
    public decimal Id { get; set; }

    public string? HeroImage { get; set; }

    public string? HomeParagraph { get; set; }

    public string? RecipesImage { get; set; }

    public string? AboutImage { get; set; }

    public string? AboutParagraph { get; set; }
}
