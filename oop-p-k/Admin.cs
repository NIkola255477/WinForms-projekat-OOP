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
                dataGridView1.Columns["Ime"].DisplayIndex = 1;
                dataGridView1.Columns["Prezime"].DisplayIndex = 2;
                dataGridView1.Columns["Email"].DisplayIndex = 3;
                dataGridView1.Columns["Lozinka"].DisplayIndex = 4;
                dataGridView1.Columns["BrojTelefona"].DisplayIndex = 5;
                dataGridView1.Columns["BrojPasosa"].DisplayIndex = 6;
                dataGridView1.Columns["Username"].DisplayIndex = 0;
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
                dataGridView1.Columns["MarkaModel"].DisplayIndex = 0;
                dataGridView1.Columns["Kapacitet"].DisplayIndex = 1;
                dataGridView1.Columns["MaksimalnaDuzinaLeta"].DisplayIndex = 2;
                dataGridView1.Columns["Dostupan"].DisplayIndex = 3;
                dataGridView1.Columns["MestoSkladistenja"].DisplayIndex = 4;
                dataGridView1.Columns["PotrosnjaGorivapoH"].DisplayIndex = 5;
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
                dataGridView1.Columns["laditude"].DisplayIndex = 3;
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

            DialogResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovaj let?",
                                         "Potvrda brisanja",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (rezultat == DialogResult.Yes)
            {
                int kljucZaBrisanje = objekti.Letovi.FirstOrDefault(x => x.Value == selektovaniLet).Key;
                
                if (objekti.Letovi.Remove(kljucZaBrisanje))
                {
                    MessageBox.Show("Let je uspesno obrisan!", "Uspeh",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajLetove();
                }
                else
                {
                    MessageBox.Show("Greska pri brisanju leta!", "Greska",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objekti.TrenutniKorisnik = null;
            objekti.TrenutniAdmin = null;
            objekti.UlogovanAdmin = false;
            Form1 forma1 = new Form1();
            forma1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
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

                int kljucZaBrisanje = objekti.Letovi.FirstOrDefault(x => x.Value == selektovaniLet).Key;

                if (objekti.Letovi.Remove(kljucZaBrisanje))
                {
                    MessageBox.Show("Let je uspesno obrisan!", "Uspeh",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajLetove();
                }
                else
                {
                    MessageBox.Show("Greska pri brisanju leta!", "Greska",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            doadavanjeLeta dodavanjeLeta = new doadavanjeLeta();
            dodavanjeLeta.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dodavanje_aviona dodavanje_Aviona = new dodavanje_aviona();
            dodavanje_Aviona.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            doadavanjeLeta dodavanjeLeta = new doadavanjeLeta();
            dodavanjeLeta.ShowDialog();
            this.Close();
        }
    }
}
