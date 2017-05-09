using System;

namespace Relazioni.Modello {
    public class Orologio {
        public int Id {get;set;}
        public Tavolo Tavolo {get;set;}
        public TimeSpan TempoResiduoBianco {get;set;}
        public TimeSpan TempoResiduoNero {get;set;}
    }
}