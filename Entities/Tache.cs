using System;
using System.Collections.Generic;

namespace ProjetGestion.Entities;

public partial class Tache
{
    public int Id { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    public DateTime? DateDeb { get; set; }

    public DateTime? DateFin { get; set; }
}
