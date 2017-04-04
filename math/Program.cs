using System;

namespace UnicamMath
{
    class Program
    {
        //Di Riccardo Cannella
        //https://github.com/riccardocannella/UnicamMath/blob/master/Program.cs

        private static double ChiediCatetoAllUtente(string messaggio) {
            while (true)
            {
                Console.Write(messaggio);
                string catetoTestuale = Console.ReadLine();
                
                if (double.TryParse(catetoTestuale, out double cateto))
                    return cateto;
                else
                {
                    Console.WriteLine("Non hai digitato un numero corretto, riprova.\n");
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Questo programma calcola l'ipotenusa e gli angoli interni fornendo la lunghezza di due cateti");
            double ipotenusa = 0;
            double angolo1 = 90;
            double angolo2 = 0;
            double angolo3 = 0;
            double cateto1 = ChiediCatetoAllUtente("Per favore inserisci il primo cateto: ");
            double cateto2 = ChiediCatetoAllUtente("Per favore inserisci il secondo cateto: ");
            
            
            // Teorema di Pitagora per trovare l'ipotenusa
            ipotenusa = Math.Sqrt(Math.Pow(cateto1, 2.0) + Math.Pow(cateto2, 2.0));
            // Per trovare il secondo angolo uso l'arcotangente 
            angolo2 = Math.Atan((cateto2 / cateto1)) * (180 / Math.PI);
            angolo3 = 90 - angolo2;
            Console.WriteLine($"L'ipotenusa misura {ipotenusa.ToString("F2")}");
            Console.WriteLine($"I tre angoli interni misurano {angolo1.ToString("F2")} gradi, {angolo2.ToString("F2")} gradi e {angolo3.ToString("F2")} gradi.");
            Console.ReadKey();
        }
    }
}
