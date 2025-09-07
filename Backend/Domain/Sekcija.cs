namespace Domain
{
    public class Sekcija
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime TerminOdrzavanja { get; set; }
        public Guid ProfesorId { get; set; }
    }
}