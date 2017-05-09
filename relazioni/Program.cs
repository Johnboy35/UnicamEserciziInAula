using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Relazioni.Modello;
using Relazioni.Servizi;

namespace relazioni
{
    class Program
    {
        static void Main(string[] args)
        {
            RecuperaPartita(1);
            //EseguiPartita();
            Console.ReadLine();
        }

        private static async void RecuperaPartita(int id)
        {
            using (DataBase db = new DataBase()) {
                Tavolo tavolo = await db
                .Tavoli
                .Include(t => t.Orologio)
                .Include(t => t.Mosse)
                .Where(t => t.Id == id)
                .SingleAsync();

                Console.WriteLine($"tempo bianco: {tavolo.Orologio.TempoResiduoBianco}");
                Console.WriteLine($"tempo nero: {tavolo.Orologio.TempoResiduoNero}");
                foreach (Mossa mossa in tavolo.Mosse) {
                    Console.WriteLine(mossa.Valore);
                }
            }
        }

        private static async void EseguiPartita()
        {
            using (DataBase db = new DataBase()) {

                await db.Database.EnsureCreatedAsync();

                Tavolo tavolo = new Tavolo();
                Orologio orologio = new Orologio();
                tavolo.Orologio = orologio;

                Mossa mossa1 = new Mossa();
                mossa1.Valore = "A2 A3";
                mossa1.Tavolo = tavolo;

                Mossa mossa2 = new Mossa();
                mossa2.Valore = "A1 H1";
                mossa2.Tavolo = tavolo;

                db.Add(mossa1);
                db.Add(mossa2);

                await db.SaveChangesAsync();
                Console.WriteLine("Dati inseriti");

            }
            
        }
    }
}
