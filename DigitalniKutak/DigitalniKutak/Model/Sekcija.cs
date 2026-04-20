using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Model
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
