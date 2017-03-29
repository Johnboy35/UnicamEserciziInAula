using System;

namespace UnicamCompleanno
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questo programma ti dice la tua eta' e il numero di giorni che restano al tuo compleanno");
            while (true)
            {
                Console.Write("Digita la tua data di nascita e premi invio, oppure premi invio per terminare: ");
                string testoDigitatoDallUtente = Console.ReadLine();

                if (string.IsNullOrEmpty(testoDigitatoDallUtente))
                {
                    //Se l'utente non ha digitato nulla, lo faccio uscire dal ciclo (e quindi dal programma)
                    break;
                }

                //Usiamo DateTime.TryParse che è più efficiente di un blocco try...catch nel catturare le eccezioni
                bool esito = DateTime.TryParse(testoDigitatoDallUtente, out DateTime dataDiNascita); //dichiaro la variabile dataDiNascita qui, è una nuova funzionalità di C# 7 uscito a marzo 2017
                if (!esito)
                {
                    Console.WriteLine("Non hai inserito una data valida, riprova");
                    continue; //Termino qui l'attuale iterazione del ciclo while e passo alla prossima
                }

                DateTime oggi = DateTime.Today;

                //Calcoliamo gli anni dell'utente con un metodo trovato su StackOverflow (vedi la definizione più in basso in questo file)
                int anniDiDifferenza = Years(dataDiNascita, oggi);
                Console.WriteLine($"Oggi hai {anniDiDifferenza} anni");

                //Creiamo la data del prossimo compleanno usando l'anno corrente, il mese e il giorno di nascita.
                DateTime dataProssimoCompleanno = new DateTime(oggi.Year, dataDiNascita.Month, dataDiNascita.Day);

                //Se si verifica che la data del prossimo compleanno è già trascorsa, vuol dire che l'utente ha già compiuto gli anni
                //e quindi aggiungiamo un anno alla data del prossimo compleanno
                if (dataProssimoCompleanno < oggi)
                {
                    dataProssimoCompleanno = dataProssimoCompleanno.AddYears(1);
                }

                TimeSpan differenzaTemporale = dataProssimoCompleanno - oggi;
                double differenzaInGiorni = differenzaTemporale.TotalDays;
                if (differenzaInGiorni == 0)
                {
                    Console.WriteLine("Tanti auguri!");
                }
                else
                {
                    Console.WriteLine($"Restano {differenzaInGiorni} giorni al tuo prossimo compleanno!");
                }
            }
            //qui sono fuori dal ciclo while
        }

        //Grazie, StackOverflow!
        //http://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp#answer-4127477
        static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
    }
}
