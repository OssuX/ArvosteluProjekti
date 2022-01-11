using System;
using System.Collections.Generic;

#nullable disable

namespace ArvosteluRestApi.Models
{
    public partial class Tuotteet
    {
        public Tuotteet()
        {
            Arvosteluts = new HashSet<Arvostelut>();
        }

        public int TuoteId { get; set; }
        public string Nimi { get; set; }
        public decimal? Hinta { get; set; }

        public virtual ICollection<Arvostelut> Arvosteluts { get; set; }
    }
}
