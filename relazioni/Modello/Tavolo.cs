using System.Collections.Generic;

namespace Relazioni.Modello {
    public class Tavolo {
        public int Id { get; set; }
        public Orologio Orologio {get; set;}
        public List<Mossa> Mosse { get; set; }
    }
}