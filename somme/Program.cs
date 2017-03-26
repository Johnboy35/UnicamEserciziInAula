using System;

namespace somme
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inizializziamo la variabile che conterrà il risultato
            int risultato = 0;
            while (true) //Avendo scritto while(true) il ciclo while girerà all'infinito, dato che l'espressione true è costante e non potrà mai diventare false. L'unico modo di uscire dal ciclo sarà usando l'istruzione break (vedi riga 18)
            {
                Console.WriteLine("Per favore, inserisci un numero e premi INVIO oppure scrivi stop e premi INVIO per uscire dal programma");
                string decisione = Console.ReadLine(); //Raccogliamo l'input dell'utente
                if (decisione == "stop")
                {
                    Console.WriteLine(risultato);
                    break; //esce dal ciclo while, l'esecuzione riprenderà dalla riga 27
                }
                else
                {
                    int variabileParse = int.Parse(decisione); //converto l'input dell'utente da stringa a numero intero
                    risultato += variabileParse; //incremento il risultato con il numero intero digitato dall'utente
                    Console.WriteLine(risultato);
                }
            }
            //Qui sono fuori dal ciclo while
        }
    }
}
