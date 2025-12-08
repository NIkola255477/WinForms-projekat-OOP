using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_p_k
{
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rege = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string ime = textBox1.Text;
            string prezime = textBox2.Text;
            string email = textBox3.Text;
            string lozinka = textBox4.Text;
            string brojTelefona = textBox5.Text;
            string brojPasosa = textBox6.Text;
            string username = textBox7.Text;
            int brT, brP;
            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(lozinka) || string.IsNullOrEmpty(brojTelefona)
                || string.IsNullOrEmpty(brojPasosa) || string.IsNullOrEmpty(username)
                || !int.TryParse(brojTelefona,out brT) || !int.TryParse(brojPasosa,out brP)
                || !Regex.IsMatch(email, rege))
            {
                MessageBox.Show("Popunite sva polja!", "Greska",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(var k in objekti.Korisnici.Values)
            {
                if(k.ProveraUsera(username))
                {
                    MessageBox.Show("Korisnicko ime je zauzeto!", "Greska",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            objekti.Korisnici.Add(brT,new korisnik(ime, prezime, email, lozinka, brT, brojPasosa, username));
            json.SacuvajK(objekti.Korisnici);
            MessageBox.Show("Uspesno ste se registrovali!");
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
