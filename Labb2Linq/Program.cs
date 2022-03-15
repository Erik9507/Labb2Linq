using Labb2Linq.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Labb2Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            bool main = true;
            while (main)
            {
                Console.WriteLine("Välj nedan alternativ");
                Console.WriteLine("[1] Hämta alla lärare som undervisa matte");
                Console.WriteLine("[2] Hämta alla elever  med sina lärare.");
                Console.WriteLine("[3] Kolla om ämnen tabell Contains programmering1 eller inte.");
                Console.WriteLine("[4] Editera en Ämne från programmering2 till OOP");
                Console.WriteLine("[5] Uppdatera en student record om sina lärare är Anas till Reidar.");
                var keyInfo = Console.ReadKey(intercept: true);
                ConsoleKey menu = keyInfo.Key;
                switch (menu)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        allaLärareSomUndervisarMAtte();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        eleverMedLärare();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        inehållerKurs();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        editeraKursNamn();
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        uppdareaStudentRecord();
                        break;

                    default:
                        Console.WriteLine("Ogiltigt alternativ");
                        break;
                }
            }
            static void AddedObjects()
            {
                SkolaDbContext DB = new SkolaDbContext();

                //Klass sut20 = new Klass { klassNamn = "sut20" };
                //Klass sut21 = new Klass { klassNamn = "sut21" };
                //Klass sut22 = new Klass { klassNamn = "sut22" };
                //DB.Add(sut21);
                //DB.Add(sut22);

                //Lärare Tobias = new Lärare { förNamn = "Tobias", efterNamn = "Landen" };
                //Lärare Anas = new Lärare { förNamn = "Anas", efterNamn = "Qlok" };
                //Lärare Reidar = new Lärare { förNamn = "Reidar", efterNamn = "Nilsen" };
                //DB.Add(Tobias);
                //DB.Add(Anas);
                //DB.Add(Reidar);


                //Elev ErikNorell = new Elev { förNamn = "Erik", efterNamn = "Norell", _Klass = sut21 };
                //Elev LukasRose = new Elev { förNamn = "Lukas", efterNamn = "Rose", _Klass = sut21 };
                //Elev ViktorGunnarsson = new Elev { förNamn = "Viktor", efterNamn = "Gunnarsson", _Klass = sut21 };
                //Elev ErikRisholm = new Elev { förNamn = "Erik", efterNamn = "Risholm", _Klass = sut21 };
                //DB.Add(ErikNorell);
                //DB.Add(LukasRose);
                //DB.Add(ViktorGunnarsson);
                //DB.Add(ErikRisholm);

                //Kurs Prog1 = new Kurs { kursNamn = "Programmering 1", _Lärare = Anas, _Klass = sut21 };
                //Kurs AgilaMetoder = new Kurs { kursNamn = "Agila Metoder", _Lärare = Tobias, _Klass = sut21 };
                //Kurs AvanceradNet = new Kurs { kursNamn = "Avancerad .Net", _Lärare = Anas, _Klass = sut21 };
                //Kurs WebbUtv = new Kurs { kursNamn = "Webbutveckling", _Lärare = Reidar, _Klass = sut21 };
                //Kurs Matte2 = new Kurs { kursNamn = "Matte 2", _Lärare = Tobias, _Klass = sut21 };
                //DB.Add(Prog1);
                //DB.Add(AgilaMetoder);
                //DB.Add(AvanceradNet);
                //DB.Add(WebbUtv);
                //DB.Add(Matte2);
            }
            static void allaLärareSomUndervisarMAtte()
            {
                Console.Clear();
                Console.WriteLine("Hämta alla lärare som undervisa matte");
                Console.WriteLine();
                SkolaDbContext DB = new SkolaDbContext();
                var matchTeachers = from a in DB.Kurser
                                    join b in DB.Lärare
                                    on a._Lärare.Id equals b.Id
                                    where a.kursNamn == "Matte 2"
                                    select new
                                    {
                                        kursnamn = a.kursNamn,
                                        förnamn = b.förNamn,
                                        efternamn = b.efterNamn
                                    };

                foreach (var item in matchTeachers)
                {
                    Console.WriteLine($"{item.förnamn} {item.efternamn} undervisar {item.kursnamn}");
                }
                Console.ReadKey();
                Console.Clear();
            }
            static void eleverMedLärare()
            {
                Console.Clear();
                Console.WriteLine("Hämta alla elever  med sina lärare");
                SkolaDbContext DB = new SkolaDbContext();
                var teachersWstudents = (from a in DB.Elever
                                         join b in DB.Klasser on a._Klass.Id equals b.Id
                                         join c in DB.Kurser on b.Id equals c._Klass.Id
                                         join d in DB.Lärare on c._Lärare.Id equals d.Id
                                         select new
                                         {                                           
                                             elevFnamn = a.förNamn,
                                             elevEnamn = a.efterNamn,
                                             lärareFnamn = d.förNamn,
                                             lärareEnamn = d.efterNamn,
                                             kurs = c.kursNamn,

                                         }).Distinct();
                int i = 2;
                foreach (var item in teachersWstudents)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write($"Elev: {item.elevFnamn} {item.elevEnamn}");                 

                    Console.SetCursorPosition(25, i);
                    Console.WriteLine($"Lärare: { item.lärareFnamn} { item.lärareEnamn}");
                    Console.SetCursorPosition(55, i++);
                    Console.WriteLine($"Kurs: {item.kurs}");

                    
                }
                Console.ReadKey();
                Console.Clear();
            }
            static void inehållerKurs()
            {
                Console.Clear();
                Console.WriteLine("Kolla om ämnen tabell Contains programmering1 eller inte.");
                SkolaDbContext DB = new SkolaDbContext();
                string search = "Programmering 1";
                if (DB.Kurser.Select(x => x.kursNamn).ToList().Contains(search))
                {
                    Console.WriteLine(search + " finns som kurs");
                }
                else
                {
                    Console.WriteLine(search + " finns ej som kurs");
                }
                Console.ReadKey();
                Console.Clear();
            }
            static void editeraKursNamn()
            {
                Console.Clear();
                Console.WriteLine("Editera ett Ämne");
                Console.WriteLine();
                SkolaDbContext DB = new SkolaDbContext();
                bool edit = true;
                while (edit)
                {
                    Console.WriteLine("Ändra namn på en kurs. Vilken kurs vill du ändra namn på?");


                    string courseName = Console.ReadLine();
                    if (DB.Kurser.Select(s => s.kursNamn).ToList().Contains(courseName))
                    {
                        Console.WriteLine("Vad ska kursen heta istället?");

                        string courseName2 = Console.ReadLine();
                        var changeCourse = DB.Kurser.Where(s => s.kursNamn == courseName).FirstOrDefault();
                        changeCourse.kursNamn = courseName2;
                        DB.SaveChanges();
                        edit = false;

                    }
                    else
                    {
                        Console.WriteLine("Kursen finns inte....försök igen...");

                    }
                }
            }
            static void uppdareaStudentRecord()
            {
                Console.Clear();
                Console.WriteLine("Uppdatera en student record om sin lärare är Anas till Reidar.");
                Console.WriteLine();
                SkolaDbContext DB = new SkolaDbContext();

                if (DB.Kurser.Select(s => s._Lärare.förNamn).ToList().Contains("Anas"))
                {
                    var changeTeacher = DB.Lärare.Where(s => s.förNamn == "Reidar" && s.efterNamn == "Nilsen").FirstOrDefault();
                    changeTeacher.förNamn = "Anas";
                    changeTeacher.efterNamn = "Qlok";

                    var changeTeacher2 = DB.Lärare.Where(s => s.förNamn == "Anas" && s.efterNamn == "Qlok").FirstOrDefault();
                    changeTeacher2.förNamn = "Reidar";
                    changeTeacher2.efterNamn = "Nilsen";


                    Console.WriteLine(changeTeacher.förNamn + " och " + changeTeacher2.förNamn + " har nu bytt plats i databasen");
                    DB.SaveChanges();
                }
                
                else
                {
                    Console.WriteLine("Fel");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
