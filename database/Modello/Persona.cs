namespace Database.Modello {
    public class Persona {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Cognome {get;set;}

        public override string ToString() {
            return $"{Nome} {Cognome} (Id: {Id})";
        }
    }
}