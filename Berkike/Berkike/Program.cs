using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace Berkike
{
    class Program
    {
        int adoszam;
        string utca;
        string hazszam;
        char adosav;
        int negyzetmeter;
        static int atelek = 0, btelek = 0, ctelek = 0;
        static int atelekado = 0, btelekado = 0, ctelekado = 0;
        
        
        public Program(string line)
        {
            string[] elemek = line.Split(' ');
            if (elemek.Length == 5)
            {
                adoszam = int.Parse(elemek[0]);
                utca = elemek[1];
                hazszam = elemek[2];
                adosav = char.Parse(elemek[3]);
                negyzetmeter = int.Parse(elemek[4]);

            }
        }

        static void FileOlvasas(string location, List<Program> adatlista) 
        {   
            
            //1. task
            if (File.Exists(location))
            {
                try
                {



                    using (StreamReader reader = new StreamReader(location))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Program ujAdat = new Program(line);
                            adatlista.Add(ujAdat);
                        }
                    }

                    int ListaHossza = adatlista.Count;
                    Console.WriteLine($"2. feladat. We found {ListaHossza} House in the file");
                }
                
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
                System.Environment.Exit(0);
            }
            
        }

        static void AdoszamKereso(int adoszam, List<Program> adatlista) 
        {
            //2. task
            for (int i = 0; i < adatlista.Count; i++)
            {
                if (adatlista[i].adoszam == adoszam) 
                {
                    Console.WriteLine($"{adatlista[i].utca} utca {adatlista[i].hazszam}");
                }
            }
        }

        static void Adozas(List<Program> adatlista)
        {
            //5. task
            Console.WriteLine("5. feladat.");
            foreach (var adat in adatlista)
            {
                if (adat.adosav == 'A')
                {
                    atelek += 1;
                    if (10000 < 800 * adat.negyzetmeter)
                    {
                        atelekado += 800 * adat.negyzetmeter;
                    }
                }
                else if (adat.adosav == 'B')
                {
                    btelek += 1;
                    if (10000 < 600 * adat.negyzetmeter) 
                    {
                        btelekado += 600 * adat.negyzetmeter;
                    }
                }
                else if (adat.adosav == 'C')
                {
                    ctelek += 1;
                    if (10000 < 100 * adat.negyzetmeter)
                    {
                        ctelekado += 100 * adat.negyzetmeter;
                    }
                }
            }
            Console.WriteLine($"We found {atelek} tax for 'A' category: {atelekado} Ft");
            Console.WriteLine($"We found {btelek} tax for 'B' category: {btelekado} Ft");
            Console.WriteLine($"We found {ctelek} tax for 'C' category: {ctelekado} Ft");
        }

        static void TobbSavosutcak(List<Program> adatlista)
        {
            Dictionary<string, HashSet<char>> utcaAdosavok = new Dictionary<string, HashSet<char>>();
            Console.WriteLine("6. feladat.");
            foreach (var adat in adatlista)
            {
                if (!utcaAdosavok.ContainsKey(adat.utca))
                {
                    utcaAdosavok[adat.utca] = new HashSet<char>();
                }
                utcaAdosavok[adat.utca].Add(adat.adosav);
            }
            
            Console.WriteLine("Utcák, amelyeknél több adósáv előfordul:");
            foreach (var utca in utcaAdosavok)
            {
                if (utca.Value.Count > 1)
                {
                    Console.WriteLine(utca.Key);
                }
            }
            
        }

        static void FileIras(List<Program> adatlista)
        {
            string pathName = @"C:\Users\marod\Desktop\txts\fileiras.txt";
            
            
            using (StreamWriter sw = new StreamWriter(pathName))
            {
                foreach (var adat in adatlista)
                {
                    
                    
                    
                    if (adat.adosav == 'A')
                    {
                        if (10000 < 800 * adat.negyzetmeter)
                        {
                            atelekado = 800 * adat.negyzetmeter;
                            
                        }
                        sw.WriteLine($"{adat.adoszam} {atelekado}");
                    }
                    else if (adat.adosav == 'B')
                    {
                        if (10000 < 600 * adat.negyzetmeter) 
                        {
                            btelekado = 600 * adat.negyzetmeter;
                            
                        }
                        sw.WriteLine($"{adat.adoszam} {btelekado}");
                    }
                    else if (adat.adosav == 'C')
                    {
                        if (10000 < 100 * adat.negyzetmeter)
                        {
                             ctelekado = 100 * adat.negyzetmeter;
                            
                        }
                        sw.WriteLine($"{adat.adoszam} {ctelekado}");
                    }
                }
            }
        }

        static void Main(String[] args)
        {
            string location = @"C:\Users\marod\Desktop\c-adoszamize-main\c-adoszamize-main\Berkike\utca.txt";

            List<Program> adatlista = new List<Program>();
            List<Program> UTCAK = new List<Program>();
            
            
            FileOlvasas(location, adatlista); 
                
            Console.Write("3. feladat. Enter the Tax Number: ");        // 3. task
            int adoszam = Int32.Parse(Console.ReadLine());              //
                
            AdoszamKereso(adoszam, adatlista);
            Adozas(adatlista);
            TobbSavosutcak(adatlista);   
            FileIras(adatlista);    
        }
    }
}
