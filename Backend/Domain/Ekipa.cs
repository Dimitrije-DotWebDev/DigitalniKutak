namespace Domain
{
    public class Ekipa
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; } = null!;
        public Guid TakmicenjeId { get; set; }
        public Takmicenje Takmicenje { get; set; } = null!;
        public ICollection<ClanoviEkipe> Clanovi { get; set; } = new List<ClanoviEkipe>();
    }
}