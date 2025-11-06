using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kayitsiralama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source =arama.accdb");
        //KAYİT ARA DÜĞMESİ
        private void button1_Click(object sender, EventArgs e)
        {
            string deger = "%";
            if (textBox1.Text != "")
            {
                deger = "%" + textBox1.Text + "%";
            }

            OleDbCommand komut = new OleDbCommand("SELECT * FROM Tablo1 WHERE ADRES LIKE @adr", bag);
            komut.Parameters.AddWithValue("@adr", deger);

            bag.Open();
            OleDbDataReader oku = komut.ExecuteReader();
            DataTable tablo = new DataTable();
            tablo.Load(oku);
            oku.Close();
            bag.Close();

            dataGridView1.DataSource = tablo;
        }

    }
}
