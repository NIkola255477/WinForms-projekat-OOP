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
    public partial class Korisnik : Form
    {
        public Korisnik()
        {
            InitializeComponent();
        }
        public static bool letovi = false;
        public static bool rezerevacije = false;
        public void Ucitajrezervacije()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objekti.TrenutniKorisnik.Rezervacije;
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
            rezerevacije = true;
        }
        public void UcitajLetove()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = objekti.Letovi;
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
            letovi = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            UcitajLetove();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!letovi)
            {
                MessageBox.Show("Prvo ucitajte letove!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate selektovati let koji zelite da obrisete!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Let selektovaniLet = dataGridView1.SelectedRows[0].DataBoundItem as Let;

            if (selektovaniLet == null)
            {
                MessageBox.Show("Greska pri izboru leta!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var flight = objekti.Letovi.FirstOrDefault(x => x == selektovaniLet);
            if (flight == null)
            {
                MessageBox.Show("Let nije pronađen!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objekti.TrenutniKorisnik.DodajRezervaciju(flight);
            flight.RezervisiKartu(objekti.TrenutniKorisnik);
            json.Sacuvaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
        }

        private void Korisnik_Load(object sender, EventArgs e)
        {
            UcitajLetove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!rezerevacije)
            {
                MessageBox.Show("Prvo ucitajte letove!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate selektovati let koji zelite da obrisete!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Let selektovaniLet = dataGridView1.SelectedRows[0].DataBoundItem as Let;

            if (selektovaniLet == null)
            {
                MessageBox.Show("Greska pri izboru leta!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var flight = objekti.Letovi.FirstOrDefault(x => x == selektovaniLet);
            if (flight == null)
            {
                MessageBox.Show("Let nije pronađen!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objekti.TrenutniKorisnik.OtkaziRezervaciju(flight);
            flight.OtkaziRezervaciju(objekti.TrenutniKorisnik);
            json.Sacuvaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
            Ucitajrezervacije();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ucitajrezervacije();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            doadavanjeLeta d = new doadavanjeLeta();

            d.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objekti.TrenutniKorisnik = null;
            objekti.TrenutniAdmin = null;
            objekti.UlogovanAdmin = false;
            this.Hide();
            Form1 forma1 = new Form1();
            forma1.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
