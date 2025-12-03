using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace oop_p_k
{
    public class json
    {
        public static string FileAdmin = "admin.txt";
        public static string FileAvioni = "avioni.txt";
        public static string FileLetovi = "letovi.txt";
        public static string FileKorisnici = "korisnici.txt";
        public static void SacuvajA(Dictionary<int, admin> Admini)
        {
            string json = JsonConvert.SerializeObject(Admini, Formatting.Indented);
            File.WriteAllText(FileAdmin, json);
        }
        public static void SacuvajK(Dictionary<int, korisnik> korisnici)
        {
            string json = JsonConvert.SerializeObject(korisnici, Formatting.Indented);
            File.WriteAllText(FileKorisnici, json);
        }
        public static void SacuvajL(Dictionary<int, Let> Letovi)
        {
            string json = JsonConvert.SerializeObject(Letovi, Formatting.Indented);
            File.WriteAllText(FileLetovi, json);
        }
        public static void SacuvajAv(Dictionary<int, Avion> Avioni)
        {
            string json = JsonConvert.SerializeObject(Avioni, Formatting.Indented);
            File.WriteAllText(FileAvioni, json);
        }
        public static void Sacuvaj(Dictionary<int, admin> Admini, Dictionary<int, korisnik> korisnici
                       , Dictionary<int, Let> Letovi, Dictionary<int, Avion> Avioni)
        {
            SacuvajA(Admini);
            SacuvajK(korisnici);
            SacuvajL(Letovi);
            SacuvajAv(Avioni);
        }
        public static void Ucitaj(Dictionary<int,admin> Admini, Dictionary<int, korisnik> korisnici
            , Dictionary<int, Let> Letovi, Dictionary<int, Avion> Avioni)

        {
            if (!File.Exists(FileLetovi) || !File.Exists(FileAvioni) || !File.Exists(FileAdmin) || File.Exists(FileKorisnici))
            {
                return;
            }
            string jsonl = File.ReadAllText(FileLetovi);
            string jsona = File.ReadAllText(FileAvioni);
            string jsonad = File.ReadAllText(FileAdmin);
            string jsonk = File.ReadAllText(FileKorisnici);
            korisnici = JsonConvert.DeserializeObject<Dictionary<int, korisnik>>(jsonk);
            Admini = JsonConvert.DeserializeObject<Dictionary<int, admin>>(jsonad);
            Avioni = JsonConvert.DeserializeObject<Dictionary<int, Avion>>(jsona);
            Letovi = JsonConvert.DeserializeObject<Dictionary<int, Let>>(jsonl);
        }
    }
}
