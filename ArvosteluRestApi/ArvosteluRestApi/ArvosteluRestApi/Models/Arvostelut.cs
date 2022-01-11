using System;
using System.Collections.Generic;

#nullable disable

namespace ArvosteluRestApi.Models
{
    public partial class Arvostelut
    {
        public int ArviointiId { get; set; }
        public int Arvosana { get; set; }
        public int TuoteId { get; set; }

        public virtual Tuotteet Tuote { get; set; }
    }
}
