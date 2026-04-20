using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigitalniKutak.Model.ENUMs;

namespace DigitalniKutak.Model
{
    public class Takmicenje
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime DatumOdrzavanja { get; set; }
        public bool PoOdeljenju { get; set; }
        public CompeitionCategory Kategorija { get; set; }
        public string KreatorId { get; set; }
        public Korisnik Kreator { get; set; } = null!;
        public bool DozvoliNaziveEkipa { get; set; }
        public int MaxBrojClanova { get; set; }
        //public ICollection<Ekipa> PrijavljeneEkipe { get; set; } = new List<Ekipa>();
    }
}
