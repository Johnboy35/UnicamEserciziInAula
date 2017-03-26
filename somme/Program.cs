using System;

namespace somme
{
    class Program
    {
        static void Main(string[] args)
        {
            int risultato = 0;
            while (true)
            {
                Console.WriteLine("Perfavore decidi cosa fare (scrivi stop per stoppare)");
                string decisione = Console.ReadLine();
                if (decisione == "stop")
                {
                    Console.WriteLine(risultato);
                    break;
                }
                else
                {
                    Console.WriteLine("Per favore scrivi un numero");
                    string primoNumero = Console.ReadLine();
                    int variabileParse = int.Parse(primoNumero);
                    risultato += variabileParse;
                    Console.WriteLine(risultato);
                }
            }


        }
    }
}
