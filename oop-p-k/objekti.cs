using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        protected List<Let> Rezervacije { get; set; }
        public korisnik(string ime, string prezime, string email, string lozinka, string brojTelefona, string brojPasosa)
        {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Lozinka = lozinka;
            BrojTelefona = brojTelefona;
            BrojPasosa = brojPasosa;
            Rezervacije = new List<Let>();
        }
        public bool ProveraLozinke(string unosLozinke)
        {
            return unosLozinke == Lozinka;
        }
        public void PromeniLozinku(string novaLozinka)
        {
            Lozinka = novaLozinka;
        }
    }
    public class Avion
    {

    }
    public abstract class Let
    {
        protected string Polaziste { get; set; }
        protected string Odrediste { get; set; }
        protected DateTime VremePolaska { get; set; }
        protected DateTime VremeDolaska { get; set; }
        protected string BrojLeta { get; set; }
        protected double BrojMesta { get; set; }
        protected string Kompanija { get; set; }
        public Let(string polaziste, string odrediste, DateTime vremePolaska, DateTime vremeDolaska, string brojLeta, double brojMesta, string kompanija)
        {
            Polaziste = polaziste;
            Odrediste = odrediste;
            VremePolaska = vremePolaska;
            VremeDolaska = vremeDolaska;
            BrojLeta = brojLeta;
            BrojMesta = brojMesta;
            Kompanija = kompanija;
        }
        public abstract double IzracunajTrajanjeLeta();
        public abstract double IzracunajCenuKarte();
        public abstract void RezervisiKartu(string imePutnika);
        public abstract void OtkaziRezervaciju(string imePutnika);
        public abstract void IzmeniLet(string novoPolaziste, string novoOdrediste, DateTime novoVremePolaska, DateTime novoVremeDolaska);

    }
    public class objekti
    {
        public static Dictionary<int, admin> Admini = new Dictionary<int, admin>();
        public static Dictionary<int, korisnik> Korisnici = new Dictionary<int, korisnik>();
        public static Dictionary<int, Avion> Avioni = new Dictionary<int, Avion>();
        public static Dictionary<int, Let> Letovi = new Dictionary<int, Let>();
    }
}
