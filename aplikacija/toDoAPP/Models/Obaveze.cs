using System;
using System.Collections.Generic;

#nullable disable

namespace toDoAPP.Models
{
    public partial class Obaveze
    {
        public int? ObavezaId { get; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatIzvrsenja { get; set; }
        public string Kategorija { get; set; }
        
    }
}
