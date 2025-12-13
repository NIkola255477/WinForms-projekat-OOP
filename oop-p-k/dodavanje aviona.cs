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
            if (string.IsNullOrEmpty(markamodel) || comboBox1.SelectedIndex == -1
                               || string.IsNullOrEmpty(textBox4.Text)
                               || !double.TryParse(textBox4.Text, out potrosnja)
                               || kapacitet <= 0 || potrosnja <= 0)
            {
                MessageBox.Show("Popunite sva polja ispravno!", "Greska",
                                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objekti.Avioni.Add(new Avion(markamodel, kapacitet, 0.0, dostupan, mestoskladistenja, potrosnja));
            json.Sacuvaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
            this.Hide();
            Admin a = new Admin();
            a.ShowDialog();
            this.Close();
        }
    }
}
