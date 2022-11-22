using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonDemo {
    // TODO: Schreiben Sie Ihre Modelklassen, die das Dokument stundenplan.json abbilden können.
    public class Klasse {
        public string Id { get; set; } = null!;
        public List<Lehrer> Lehrer { get; set; } = null!;
    }

    public class Lehrer {
        public string Id { get; set; } = null!;
        public string Vorname { get; set; } = null!;
        public string Zuname { get; set; } = null!;
        public List<Gegenstaende> Gegenstaende { get; set; } = null!;
    }

    public class Gegenstaende {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }


    public class Program {
        static async Task Main() {
            // Wichtig: Bei Copy to Output Directory muss im Solution Explorer bei stundenplan.json
            //          die Option Copy Always gesetzt werden-
            using var filestream = new FileStream("stundenplan.json", FileMode.Open, FileAccess.Read);

            // Liest das Dokument in die Variable stdplan ein. Da es ein Array ist, wird hier auch
            // ein Array erstellt.
            Klasse[]? stdplan = await JsonSerializer.DeserializeAsync<Klasse[]>(filestream);
            Console.WriteLine($"Es wurden {stdplan?.Length} Klassen geladen.");

            if (stdplan is not null ) { 
                foreach ( Klasse k in stdplan ) {
                    Console.WriteLine( $"Klasse: {k.Id}" );
                }
            }

            // TODO: Geben Sie alle Lehrer (ID, Vorname, Zuname) der Schule aus.
            Console.WriteLine("\n-------------------------------- Lehrer --------------------------------");
            if ( stdplan is not null ) {
                foreach ( Klasse k in stdplan ) {
                    foreach ( Lehrer l in k.Lehrer ) {
                        Console.WriteLine($"Id: {l.Id}\nVorname: {l.Vorname}\nZuname: {l.Zuname}");
                    }
                }
            }

            // TODO: Geben Sie alle Gegenstände (ID, Name) der Schule aus.
            Console.WriteLine("\n----------------------------- Gegenstände -----------------------------");
            if (stdplan is not null) {
                foreach (Klasse k in stdplan) {
                    foreach (Lehrer l in k.Lehrer) {
                        foreach (Gegenstaende g in l.Gegenstaende) {
                            Console.WriteLine($"Id: {g.Id}\nName: {g.Name}");
                        }
                    }
                }
            }
        }


    }
}