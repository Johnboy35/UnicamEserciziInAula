namespace Relazioni.Modello {
    public class Mossa {
        public int Id { get; set; }
        public string Valore { get; set; }
        public Tavolo Tavolo { get; set; }
    }
}