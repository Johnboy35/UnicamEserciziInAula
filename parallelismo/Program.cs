using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace parallelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Numero di core: {Environment.ProcessorCount}");
            /*Enumerable.Range(0, 10000000).Select(i => random.NextDouble()).ToArray();*/
            Random random = new Random();
            double[] numeriCasuali = new double[1000000];
            for (int i = 0; i < numeriCasuali.Length; i++) {
                numeriCasuali[i] = random.NextDouble();
            }
            
            Task taskSequenziale = Task.Run(() => {
                EsecuzioneSequenziale(numeriCasuali);
            });
            Task taskParallelo = Task.Run(() => {
                EsecuzioneParallela(numeriCasuali);
            });

            Task.WaitAll(taskSequenziale, taskParallelo);
            Console.WriteLine("Entrambe le esecuzioni sono terminate");
            Console.ReadLine();
        }

        private static void EsecuzioneSequenziale(double[] numeriCasuali)
        {
            Console.WriteLine("Sequenziale");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double somma = numeriCasuali.Sum();
            stopwatch.Stop();
            Console.WriteLine($"Il risultato era: {somma}, ci sono voluti: {stopwatch.ElapsedMilliseconds}");
        }

        private static void EsecuzioneParallela(double[] numeriCasuali)
        {
            Console.WriteLine("Parallela");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /*double somma = numeriCasuali
            .AsParallel()
            .WithDegreeOfParallelism(4)
            .Sum(i => {
                for (int j = 0; j<10000000; j++) {
                }
                return i;
            }
            );*/
            double somma = 0;
            object l = new Object();
            var parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 3;
            Parallel.For(0, numeriCasuali.Length, parallelOptions, (i, parallelLoopState) => {
                    double numero = numeriCasuali[i];
                    lock (l) {                        
                        somma += numero;
                    }
            });

            stopwatch.Stop();
            Console.WriteLine($"Il risultato era: {somma}, ci sono voluti: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
