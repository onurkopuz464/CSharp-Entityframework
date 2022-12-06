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
    public partial class FRM_Urun : Form
    {
        public FRM_Urun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void listele_buton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,
                                            x.DURUM
                                        }).ToList();


        }

        private void ekle_buton_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = urun_text.Text;
            t.MARKA = marka_text.Text;
            t.STOK = short.Parse(stok_text.Text);
            t.FIYAT = decimal.Parse(fiyat_text.Text);
            t.DURUM = true;
            t.KATEGORI = int.Parse(kategori_combo.SelectedValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");
        }

        private void sil_buton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(ıd_text.Text);
            var urunıd = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urunıd);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");


        }

        private void guncelle_buton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(ıd_text.Text);
            var t = db.TBLURUN.Find(x);
            t.URUNAD = urun_text.Text;
            t.MARKA = marka_text.Text;
            t.STOK = short.Parse(stok_text.Text);
            t.FIYAT = decimal.Parse(fiyat_text.Text);
            t.DURUM = true;
            t.KATEGORI = int.Parse(kategori_combo.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FRM_Urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ıd,
                                   x.AD
                               }
                               ).ToList();
            kategori_combo.ValueMember = "ıd"; //  back te tutulan value numarası 
            kategori_combo.DisplayMember = "AD"; // gösterilen deger
            kategori_combo.DataSource = kategoriler; // source
        }
    }
}
