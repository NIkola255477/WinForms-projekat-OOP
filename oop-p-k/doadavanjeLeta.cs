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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
                               || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Popunite sva obavezna polja!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Aerodrom polaziste = (Aerodrom)comboBox1.SelectedItem;
            Aerodrom odrediste = (Aerodrom)comboBox2.SelectedItem;
            if (!double.TryParse(textBox3.Text, out double brojMesta))
            {
                MessageBox.Show("Broj mesta mora biti broj!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Vreme polaska mora biti pre vremena dolaska!", "Greska",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int noviid;
            if(objekti.Letovi.Count == 0)
            {
                noviid = 0;
            }
            else
            {
                noviid = objekti.Letovi.Keys.Max() + 1;
            }
            if (objekti.UlogovanAdmin)
            {
                if (checkBox1.Checked)
                {
                    objekti.Letovi.Add(noviid, new Charter(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox2.Text, textBox4.Text));
                }
                else
                {
                    objekti.Letovi.Add(noviid, new ObicanLet(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox2.Text));
                }
            }
            else
            {
                if (checkBox1.Checked)
                {
                    objekti.Letovi.Add(noviid, new Charter(polaziste, odrediste,
                                           dateTimePicker1.Value, dateTimePicker2.Value,
                                           textBox1.Text, brojMesta, textBox2.Text, textBox4.Text));
                    objekti.Letovi[noviid].RezervisiKartu(objekti.TrenutniKorisnik);
                }
                else
                {
                    MessageBox.Show("morate checkirati da rezervisete charter","greska",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Let je uspesno napravljen!", "Uspeh",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            checkBox1.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            if (objekti.UlogovanAdmin)
            {
                Admin a = new Admin();
                this.Close();
                a.Show();
            }
            else
            {
                Korisnik k = new Korisnik();
                this.Close();
                k.Show();
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
    }
}
