namespace Domain
{
    public class ClanoviEkipe
    {
        public Guid EkipaId { get; set; }
        public Ekipa Ekipa { get; set; } = null!;
        public string Id { get; set; }
        public Korisnik Korisnik { get; set; } = null!;
        public bool JeKreator { get; set; }
    }
}