namespace ProjetGestion.DTO
{
    public class TacheDTO

    {
        public int Id { get; set; }

        public string? Titre { get; set; }

        public string? Contenu { get; set; }

        public DateTime? DateDeb { get; set; }

        public DateTime? DateFin { get; set; }
    }

}
