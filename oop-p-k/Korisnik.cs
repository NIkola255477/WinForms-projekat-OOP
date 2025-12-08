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
        }
        private void button5_Click(object sender, EventArgs e)
        {
            UcitajLetove();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Korisnik_Load(object sender, EventArgs e)
        {
            UcitajLetove();
        }
    }
}
