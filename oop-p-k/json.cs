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

        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static void SacuvajA(List<admin> Admini)
        {
            string jsonStr = JsonConvert.SerializeObject(Admini, settings);
            File.WriteAllText(FileAdmin, jsonStr);
        }
        public static void SacuvajK(List<korisnik> korisnici)
        {
            string jsonStr = JsonConvert.SerializeObject(korisnici, settings);
            File.WriteAllText(FileKorisnici, jsonStr);
        }
        public static void SacuvajL(List<Let> Letovi)
        {
            string jsonStr = JsonConvert.SerializeObject(Letovi, settings);
            File.WriteAllText(FileLetovi, jsonStr);
        }
        public static void SacuvajAv(List<Avion> Avioni)
        {
            string jsonStr = JsonConvert.SerializeObject(Avioni, settings);
            File.WriteAllText(FileAvioni, jsonStr);
        }
        public static void Sacuvaj(List<admin> Admini, List<korisnik> korisnici
                       , List<Let> Letovi, List<Avion> Avioni)
        {
            SacuvajA(Admini);
            SacuvajK(korisnici);
            SacuvajL(Letovi);
            SacuvajAv(Avioni);
        }
        public static void Ucitaj(List<admin> Admini, List<korisnik> korisnici
            , List<Let> Letovi, List<Avion> Avioni)
        {
            if (!File.Exists(FileLetovi) || !File.Exists(FileAvioni) || !File.Exists(FileAdmin) || !File.Exists(FileKorisnici))
            {
                return;
            }
            string jsonl = File.ReadAllText(FileLetovi);
            string jsona = File.ReadAllText(FileAvioni);
            string jsonad = File.ReadAllText(FileAdmin);
            string jsonk = File.ReadAllText(FileKorisnici);

            var loadedKorisnici = JsonConvert.DeserializeObject<List<korisnik>>(jsonk, settings);
            var loadedAdmini = JsonConvert.DeserializeObject<List<admin>>(jsonad, settings);
            var loadedAvioni = JsonConvert.DeserializeObject<List<Avion>>(jsona, settings);
            var loadedLetovi = JsonConvert.DeserializeObject<List<Let>>(jsonl, settings);

            if (loadedKorisnici != null)
            {
                korisnici.Clear();
                foreach (var item in loadedKorisnici)
                    korisnici.Add(item);
            }
            if (loadedAdmini != null)
            {
                Admini.Clear();
                foreach (var item in loadedAdmini)
                    Admini.Add(item);
            }
            if (loadedAvioni != null)
            {
                Avioni.Clear();
                foreach (var item in loadedAvioni)
                    Avioni.Add(item);
            }
            if (loadedLetovi != null)
            {
                Letovi.Clear();
                foreach (var item in loadedLetovi)
                    Letovi.Add(item);
            }
        }
    }
}
