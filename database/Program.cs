using System;
using System.Linq;
using Database.Modello;
using Database.Servizi;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estraggo i nomi dal database");
            //EstraiINomi();
            EstraiNomiConEntityFramework();
            Console.ReadLine();
        }

        public static async void EstraiNomi() {
            string stringaDiConnessione = @"Data Source=..\..\..\Database.db";

            using (var connessione = new SqliteConnection(stringaDiConnessione)) {
                await connessione.OpenAsync();
                using (var comando = connessione.CreateCommand()) {
                    comando.CommandText = "SELECT Nome, Cognome FROM Persone";
                    using (var reader = await comando.ExecuteReaderAsync()) {
                        while(reader.Read()) {
                            Console.WriteLine($"{reader["Nome"]} {reader["Cognome"]}");
                        }
                    }
                }
            }
        }

        public static async void EstraiNomiConEntityFramework() {
            using (var contesto = new MioDbContext()) {
                var query = contesto
                .Persone
                .Where(p => p.Nome.StartsWith("M"))
                .OrderBy(p => p.Cognome);

                var persone = await query.ToListAsync();
                foreach (var persona in persone) {
                    Console.WriteLine(persona);
                }
            }
        }
    }
}
