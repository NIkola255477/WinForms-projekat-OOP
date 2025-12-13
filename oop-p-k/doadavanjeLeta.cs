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
    public partial class doadavanjeLeta : Form
    {
        public doadavanjeLeta()
        {
            InitializeComponent();
            label8.Enabled = false;
            label8.Visible = false;
            textBox4.Enabled = false;
            textBox4.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.ShowUpDown = true;
            comboBox1.DataSource = new List<Aerodrom>(aerodromi.aerod);
            comboBox1.DisplayMember = "Grad";
            comboBox1.ValueMember = "Naziv";
            comboBox2.DataSource = new List<Aerodrom>(aerodromi.aerod);
            comboBox2.DisplayMember = "Grad";
            comboBox2.ValueMember = "Naziv";
            if (objekti.UlogovanAdmin)
            {
                button1.Text = "Dodaj let";
            }
            else
            {
                button1.Text = "Rezervisi charter let";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
                               || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Popunite sva obavezna polja!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Morate izabrati polaziste i odrediste!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Aerodrom polaziste = (Aerodrom)comboBox1.SelectedItem;
            Aerodrom odrediste = (Aerodrom)comboBox2.SelectedItem;
            int brojMesta;
            if (!int.TryParse(textBox2.Text, out brojMesta) || brojMesta <= 0)
            {
                MessageBox.Show("Broj mesta mora biti pozitivan broj!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Vreme polaska mora biti pre vremena dolaska!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (objekti.UlogovanAdmin)
            {
                if (checkBox1.Checked)
                {
                    if (string.IsNullOrEmpty(textBox4.Text))
                    {
                        MessageBox.Show("Morate uneti specijalne zahteve za charter!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Let noviLet = new Charter(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox3.Text, textBox4.Text);
                    objekti.Letovi.Add(noviLet);
                }
                else
                {
                    Let noviLet = new ObicanLet(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox3.Text);
                    objekti.Letovi.Add(noviLet);
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (string.IsNullOrEmpty(textBox4.Text))
                    {
                        MessageBox.Show("Morate uneti specijalne zahteve za charter!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Let noviLet = new Charter(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox3.Text, textBox4.Text);
                    objekti.Letovi.Add(noviLet);
                    noviLet.RezervisiKartu(objekti.TrenutniKorisnik);
                }
                else
                {
                    MessageBox.Show("Morate checkirati da rezervisete charter!", "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            json.Sacuvaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
            MessageBox.Show("Let je uspesno napravljen!", "Uspeh",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (objekti.UlogovanAdmin)
            {
                this.Hide();
                Admin formAdmin = new Admin();
                formAdmin.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Korisnik formKorisnik = new Korisnik();
                formKorisnik.ShowDialog();
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label8.Enabled = true;
                label8.Visible = true;
                textBox4.Enabled = true;
                textBox4.Visible = true;
            }
            else
            {
                textBox4.Clear();
                label8.Enabled = false;
                label8.Visible = false;
                textBox4.Enabled = false;
                textBox4.Visible = false;
            }
        }

        private void doadavanjeLeta_Load(object sender, EventArgs e)
        {

        }
    }
}
