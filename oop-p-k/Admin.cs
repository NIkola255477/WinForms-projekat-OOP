using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_p_k
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public static bool avioni = false;
        public static bool korisnici = false;
        public static bool aerodrom = false;
        public static bool letovi = false;
        private void button2_Click(object sender, EventArgs e)
        {
            UcitajK();
        }
        public void UcitajK()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objekti.Korisnici.Values.ToList();
            //string ime, string prezime, string email, string lozinka, string brojTelefona, string brojPasosa, string username
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["username"].DisplayIndex = 0;
                dataGridView1.Columns["ime"].DisplayIndex = 1;
                dataGridView1.Columns["prezime"].DisplayIndex = 2;
                dataGridView1.Columns["email"].DisplayIndex = 3;
                dataGridView1.Columns["lozinka"].DisplayIndex = 4;
                dataGridView1.Columns["brojTelefona"].DisplayIndex = 5;
                dataGridView1.Columns["brojPasosa"].DisplayIndex = 6;
            }
            dataGridView1.AutoResizeColumns();
            korisnici = true;
            aerodrom = false;
            avioni = false;
            letovi = false;
        }
        public void UcitajAvione()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objekti.Avioni.Values.ToList();
            //string markaModel, int kapacitet, double maksimalnaDuzinaLeta, bool dostupan, string mestoSkladistenja, double potrosnjaGorivapoH
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["markaModel"].DisplayIndex = 0;
                dataGridView1.Columns["kapacitet"].DisplayIndex = 1;
                dataGridView1.Columns["maksimalnaDuzinaLeta"].DisplayIndex = 2;
                dataGridView1.Columns["dostupan"].DisplayIndex = 3;
                dataGridView1.Columns["mestoSkladistenja"].DisplayIndex = 4;
                dataGridView1.Columns["potrosnjaGorivapoH"].DisplayIndex = 5;
            }
            dataGridView1.AutoResizeColumns();
            korisnici = false;
            aerodrom = false;
            avioni = true;
            letovi = false;
        }
        public void UcitajLetove()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objekti.Letovi.Values.ToList();
            //Aerodrom polaziste, Aerodrom odrediste, DateTime vremePolaska, DateTime vremeDolaska, string brojLeta, double brojMesta, string kompanija
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["polaziste"].DisplayIndex = 0;
                dataGridView1.Columns["odrediste"].DisplayIndex = 1;
                dataGridView1.Columns["vremePolaska"].DisplayIndex = 2;
                dataGridView1.Columns["vremeDolaska"].DisplayIndex = 3;
                dataGridView1.Columns["brojLeta"].DisplayIndex = 4;
                dataGridView1.Columns["brojMesta"].DisplayIndex = 5;
                dataGridView1.Columns["kompanija"].DisplayIndex = 6;
            }
            dataGridView1.AutoResizeColumns();
            korisnici = false;
            aerodrom = false;
            avioni = false;
            letovi = true;
        }
        public void UcitajAerodrome()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = aerodromi.aerod.ToList();
            //string naziv, string grad, string drzava, string laditude, string longitude
            if(dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["naziv"].DisplayIndex = 0;
                dataGridView1.Columns["grad"].DisplayIndex = 1;
                dataGridView1.Columns["drzava"].DisplayIndex = 2;
                dataGridView1.Columns["latitude"].DisplayIndex = 3;
                dataGridView1.Columns["longitude"].DisplayIndex = 4;
            }
            dataGridView1.AutoResizeColumns();
            korisnici = false;
            aerodrom = true;
            avioni = false;
            letovi = false;
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            UcitajLetove();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcitajAerodrome();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UcitajLetove();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UcitajAvione();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (letovi)
            {
                
            }
        }
    }
}
