using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace oop_p_k
{
    public class admin
    {
        protected string Username { get; set; }
        protected string Password { get; set; }
        public admin(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public bool ProveraLozinke(string unosLozinke)
        {
            return unosLozinke == Password;
        }
        public bool ProveraUsera(string unosUsera)
        {
            return unosUsera == Username;
        }
        public void PromeniLozinku(string novaLozinka)
        {
            Password = novaLozinka;
        }
    }
    public class korisnik
    {
        protected string Ime { get; set; }
        protected string Prezime { get; set; }
        protected string Email { get; set; }
        protected string Lozinka { get; set; }
        protected string BrojTelefona { get; set; }
        protected string BrojPasosa { get; set; }
        protected string Username { get; set; }
        protected List<Let> Rezervacije { get; set; }
        public korisnik(string ime, string prezime, string email, string lozinka, string brojTelefona, string brojPasosa, string username)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Lozinka = lozinka;
            BrojTelefona = brojTelefona;
            BrojPasosa = brojPasosa;
            Rezervacije = new List<Let>();
            Username = username;
        }
        public bool ProveraLozinke(string unosLozinke)
        {
            return unosLozinke == Lozinka;
        }
        public bool ProveraUsera(string unosUsera)
        {
            return unosUsera == Username;
        }
        public void PromeniLozinku(string novaLozinka)
        {
            Lozinka = novaLozinka;
        }
    }
    public class Aerodrom
    {
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Laditude { get; set; }
        public string Longitude { get; set; }
        public Aerodrom(string naziv, string grad, string drzava, string laditude, string longitude)
        {
            Naziv = naziv;
            Grad = grad;
            Drzava = drzava;
            Laditude = laditude;
            Longitude = longitude;
        }
    }
    public class Avion
    {
        private string MarkaModel { get; set; }
        private int Kapacitet { get; set; }
        private double MaksimalnaDuzinaLeta { get; set; }
        private bool Dostupan { get; set; }
        private string MestoSkladistenja { get; set; }
        private double PotrosnjaGorivapoH { get; set; }
        public Avion(string markaModel, int kapacitet, double maksimalnaDuzinaLeta, bool dostupan, string mestoSkladistenja, double potrosnjaGorivapoH)
        {
            MarkaModel = markaModel;
            Kapacitet = kapacitet;
            MaksimalnaDuzinaLeta = maksimalnaDuzinaLeta;
            Dostupan = dostupan;
            MestoSkladistenja = mestoSkladistenja;
            PotrosnjaGorivapoH = potrosnjaGorivapoH;
        }
        public void PromeniDostupnost(bool novaDostupnost)
        {
            Dostupan = novaDostupnost;
        }
        public bool ProveraDostupnosti()
        {
            return Dostupan;
        }
        public double IzracunajMaksimalnuUdaljenost()
        {
            return MaksimalnaDuzinaLeta;
        }
    }
    public abstract class Let
    {
        protected Aerodrom Polaziste { get; set; }
        protected Aerodrom Odrediste { get; set; }
        protected DateTime VremePolaska { get; set; }
        protected DateTime VremeDolaska { get; set; }
        protected string BrojLeta { get; set; }
        protected double BrojMesta { get; set; }
        protected string Kompanija { get; set; }
        protected List<korisnik> Rezervacije { get; set; }
        public Let(Aerodrom polaziste, Aerodrom odrediste, DateTime vremePolaska, DateTime vremeDolaska, string brojLeta, double brojMesta, string kompanija)
        {
            Polaziste = polaziste;
            Odrediste = odrediste;
            VremePolaska = vremePolaska;
            VremeDolaska = vremeDolaska;
            BrojLeta = brojLeta;
            BrojMesta = brojMesta;
            Kompanija = kompanija;
            Rezervacije = new List<korisnik>();
        }
        public abstract double IzracunajTrajanjeLeta();
        public abstract double IzracunajUdaljenostLeta();
        public abstract double IzracunajCenuKarte();
        public abstract void RezervisiKartu(korisnik k);
        public abstract void OtkaziRezervaciju(korisnik k);
        public abstract void IzmeniLet(Aerodrom novoPolaziste, Aerodrom novoOdrediste, DateTime novoVremePolaska, DateTime novoVremeDolaska);
    }
    public class ObicanLet : Let
    {
        private double cenaPoKilometru = 0.15;
        private double faktor = 1.2;
        public ObicanLet(Aerodrom polaziste, Aerodrom odrediste, DateTime vremePolaska, DateTime vremeDolaska, string brojLeta, double brojMesta, string kompanija)
            : base(polaziste, odrediste, vremePolaska, vremeDolaska, brojLeta, brojMesta, kompanija) { }
        public override double IzracunajCenuKarte()
        {
           double km = objekti.RacunanjeUdaljenostiAerodromaNaZemlji(Polaziste.Laditude, Polaziste.Longitude, Odrediste.Laditude, Odrediste.Longitude);
           return cenaPoKilometru * km*faktor;
        }
        public override double IzracunajTrajanjeLeta()
        {
            TimeSpan trajanje = VremeDolaska - VremePolaska;
            return trajanje.TotalHours;
        }
        public override double IzracunajUdaljenostLeta()
        {
            return objekti.RacunanjeUdaljenostiAerodromaNaZemlji(Polaziste.Laditude, Polaziste.Longitude, Odrediste.Laditude, Odrediste.Longitude);
        }
        public override void RezervisiKartu(korisnik k)
        {
            Rezervacije.Add(k);
        }
        public override void OtkaziRezervaciju(korisnik k)
        {
            Rezervacije.Remove(k);
        }
        public override void IzmeniLet(Aerodrom novoPolaziste, Aerodrom novoOdrediste, DateTime novoVremePolaska, DateTime novoVremeDolaska)
        {
            Polaziste = novoPolaziste;
            Odrediste = novoOdrediste;
            VremePolaska = novoVremePolaska;
            VremeDolaska = novoVremeDolaska;
        }
    }
    public class Charter : Let
    {
        private double fiksni = 5000;
        private double profit = 1.2;
        private double varTroskovi = 20;
        public Charter(Aerodrom polaziste, Aerodrom odrediste, DateTime vremePolaska, DateTime vremeDolaska, string brojLeta, double brojMesta, string kompanija)
        :base(polaziste,odrediste,vremePolaska,vremeDolaska,brojLeta,brojMesta,kompanija){ }
        public override double IzracunajTrajanjeLeta()
        {
            return (VremeDolaska - VremePolaska).TotalHours;
        }
        public override double IzracunajUdaljenostLeta()
        {
            return objekti.RacunanjeUdaljenostiAerodromaNaZemlji(Polaziste.Laditude, Polaziste.Longitude, Odrediste.Laditude, Odrediste.Longitude);
        }
        public override double IzracunajCenuKarte()
        {
            double km = objekti.RacunanjeUdaljenostiAerodromaNaZemlji(Polaziste.Laditude, Polaziste.Longitude, Odrediste.Laditude, Odrediste.Longitude);
            double ukupniTroskovi = fiksni + (varTroskovi * km);
            return (ukupniTroskovi / BrojMesta) * profit;
        }
        public override void RezervisiKartu(korisnik k)
        {
            Rezervacije.Add(k);
        }
        public override void OtkaziRezervaciju(korisnik k)
        {
            Rezervacije.Remove(k);
        }
        public override void IzmeniLet(Aerodrom novoPolaziste, Aerodrom novoOdrediste, DateTime novoVremePolaska, DateTime novoVremeDolaska)
        {
            Polaziste = novoPolaziste;
            Odrediste = novoOdrediste;
            VremePolaska = novoVremePolaska;
            VremeDolaska = novoVremeDolaska;
        }
    }
    public class objekti
    {
        public static Dictionary<int, admin> Admini = new Dictionary<int, admin>();
        public static Dictionary<int, korisnik> Korisnici = new Dictionary<int, korisnik>();
        public static Dictionary<int, Avion> Avioni = new Dictionary<int, Avion>();
        public static Dictionary<int, Let> Letovi = new Dictionary<int, Let>();
        public const double cenaGoriva = 100;
        public static double RacunanjeUdaljenostiAerodromaNaZemlji(
    string lat1s, string lon1s,
    string lat2s, string lon2s)
        {
            if (string.IsNullOrWhiteSpace(lat1s) || string.IsNullOrWhiteSpace(lon1s) ||
                string.IsNullOrWhiteSpace(lat2s) || string.IsNullOrWhiteSpace(lon2s))
                return 0;

            double lat1 = ParseCoordinate(lat1s, true);
            double lon1 = ParseCoordinate(lon1s, false);
            double lat2 = ParseCoordinate(lat2s, true);
            double lon2 = ParseCoordinate(lon2s, false);

            return Haversine(lat1, lon1, lat2, lon2);
        }

        private static double ParseCoordinate(string input, bool isLatitude)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            input = input.Trim().ToUpper();

            int sign = 1;

            if (input.EndsWith("S") || input.Contains("S")) sign = -1;
            if (input.EndsWith("W") || input.Contains("W")) sign = -1;

            // uklanjamo N / S / E / W
            input = input.Replace("N", "").Replace("S", "")
                         .Replace("E", "").Replace("W", "");

            input = input.Trim();

            // zameni decimalni zarez u tacku
            input = input.Replace(',', '.');

            double value;
            if (!double.TryParse(input, System.Globalization.NumberStyles.Float,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out value))
                return 0;

            if (isLatitude && (value < -90 || value > 90)) return 0;
            if (!isLatitude && (value < -180 || value > 180)) return 0;

            return sign * value;
        }

        private static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371.0;

            double dLat = ToRad(lat2 - lat1);
            double dLon = ToRad(lon2 - lon1);

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private static double ToRad(double deg)
        {
            return deg * (Math.PI / 180.0);
        }
    }
}
