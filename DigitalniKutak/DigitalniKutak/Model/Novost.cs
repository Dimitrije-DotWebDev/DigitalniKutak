using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Model
{
    public partial class Novost
    {
        public Guid Id { get; set; }

        public string Naslov { get; set; } = null!;

        public string Sadrzaj { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public string SlikaPutanja { get; set; } = null!;

        public string FajlPutanja { get; set; } = null!;

        public int GrupaId { get; set; }
    }
}
