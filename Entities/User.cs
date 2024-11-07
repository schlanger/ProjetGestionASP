using System;
using System.Collections.Generic;

namespace ProjetGestion.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }
}
