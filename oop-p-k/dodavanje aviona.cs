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
    public partial class dodavanje_aviona : Form
    {
        public dodavanje_aviona()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            comboBox1.DataSource = new List<Aerodrom>(aerodromi.aerod);
            comboBox1.DisplayMember = "Grad";
            comboBox1.ValueMember = "Naziv";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string markamodel = textBox1.Text;
            int kapacitet = (int)numericUpDown1.Value;
            bool dostupan = checkBox1.Checked;
            Aerodrom mestoskladistenja = (Aerodrom)comboBox1.SelectedItem;
            double potrosnja;
            if (string.IsNullOrEmpty(markamodel) || comboBox1.SelectedIndex==-1
                               || !double.TryParse(textBox4.Text, out potrosnja))
            {
                MessageBox.Show("Popunite sva polja ispravno!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objekti.Avioni.Add(objekti.Avioni.Count, new Avion(markamodel, kapacitet, 0.0, dostupan, mestoskladistenja, potrosnja));
            json.Sacuvaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
            Admin a = new Admin();
            this.Close();
            a.ShowDialog();
        }
    }
}
