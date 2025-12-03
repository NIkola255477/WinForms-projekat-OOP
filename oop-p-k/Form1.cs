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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            json.Ucitaj(objekti.Admini, objekti.Korisnici, objekti.Letovi, objekti.Avioni);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Unesite korisnicko ime i lozinku!", "Greska",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var a in objekti.Admini.Values)
            {
                if (a.ProveraUsera(username) && a.ProveraLozinke(password))
                {
                    MessageBox.Show("Uspesno ste se prijavili kao admin!");
                    this.Hide();
                    Admin formAdmin = new Admin();
                    formAdmin.ShowDialog();
                    this.Close();
                    return;
                }
            }
            foreach (var korisnik in objekti.Korisnici.Values)
            {
                if (korisnik.ProveraLozinke(password) && korisnik.ProveraUsera(username))
                {
                    MessageBox.Show("Uspesno ste se prijavili kao korisnik!");
                    this.Hide();
                    Korisnik formKorisnik = new Korisnik();
                    formKorisnik.ShowDialog();
                    this.Close();
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign_up sign_Up = new sign_up();
            sign_Up.ShowDialog();
            this.Close();
        }
    }
}
