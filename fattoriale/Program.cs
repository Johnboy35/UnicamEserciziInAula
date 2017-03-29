using System;
using System.Numerics;

namespace UnicamFattoriale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stampo dei messaggi di cortesia per l'utente, così lo guido all'utilizzo del programma
            Console.WriteLine("Questo programma calcola il fattoriale di un numero intero");

            while (true)
            {
                Console.Write("Digita un numero intero e premi invio, oppure premi subito invio per uscire: ");

                //Console.ReadLine si mette in attesa che l'utente digiti qualcosa e prema invio.
                //Quando ha premuto invio, il testo che ha digitato lo assegno ad una variabile di tipo string.
                string testoDigitatoDallUtente = Console.ReadLine();

                //Se l'utente non ha digitato nulla, allora esco dal ciclo while (e quindi dal programma)
                if (string.IsNullOrEmpty(testoDigitatoDallUtente)) {
                    break;
                }

                //Se invece ha digitato qualcosa, uso TryParse che è più efficiente di un blocco try...catch
                //per fare il parsing degli interi e catturare l'eventuale eccezione che potrebbe verificarsi.
                bool esito = int.TryParse(testoDigitatoDallUtente, out int numero); //Scrivere out int numero è un modo per dichiarare la variabile somma che verrà valorizzata dal metodo TryParse

                //Verifichiamo qual è stato l'esito di int.TryParse
                if (!esito)
                {
                    Console.WriteLine("Non hai digitato un numero valido, riprova");
                    continue; //Se non ha digitato un numero, interrompo il ciclo e così esco
                }

                //Mi copio il numero digitato dall'utente, in modo che io possa stamparlo in fondo tale e quale, alla riga 46
                int numeroInserito = numero;

                //Uso BigInteger perché è adatto a contenere numeri interi arbitrariamente grandi
                BigInteger risultato = 1;
                while (numero >= 2)
                {
                    risultato *= numero;
                    numero--;
                }

                //Stampo il risultato
                Console.WriteLine($"Il fattoriale di {numeroInserito} e' {risultato}");
            }
        }
    }
}