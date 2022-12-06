using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource= kategoriler;


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = textBox1.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD = textBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");


        }
    }
}
