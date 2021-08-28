using EdukeyLearning.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdukeyLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kurs _kurs = new Kurs();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSil.Enabled = false;
            Yukle();
            

        }

        private void Yukle(string ara = "")
        {
            if (ara=="")
            {
               dtgList.DataSource = _kurs.Get();
            }
            else
            {
                dtgList.DataSource = _kurs.Get(ara);
            }
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text=="Güncelle")

            {
                _kurs.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);
                _kurs.Ad = txtAd.Text;
                _kurs.Detay = txtDetay.Text;
                _kurs.Sure = txtSure.Text;
                _kurs.Egitmen = txtEgitmen.Text;

                _kurs.Guncelle(_kurs);
                Yukle();

                MessageBox.Show("Kaydınız Başarıyla Güncellenmiştir!");
            }
            else
            {
                _kurs.Ad = txtAd.Text;
                _kurs.Detay = txtDetay.Text;
                _kurs.Sure = txtSure.Text;
                _kurs.Egitmen = txtEgitmen.Text;

                _kurs.Kaydet(_kurs);

                Yukle();

                MessageBox.Show("Kaydınız Başarıyla Eklenmiştir!");
            }
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgList.ClearSelection();
            btnKaydet.Text = "Güncelle";
            btnSil.Enabled = true;


            txtAd.Text = dtgList.CurrentRow.Cells[1].Value.ToString();
            txtDetay.Text = dtgList.CurrentRow.Cells[2].Value.ToString();
            txtSure.Text = dtgList.CurrentRow.Cells[3].Value.ToString();
            txtEgitmen.Text = dtgList.CurrentRow.Cells[4].Value.ToString();

            


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _kurs.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);
            _kurs.Sil(_kurs);
            Yukle();
            MessageBox.Show("Kayıt Silindi!");
            btnKaydet.Text = "Kaydet";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            txtAd.Text = txtDetay.Text = txtSure.Text = txtEgitmen.Text = "";
            btnSil.Enabled = true;
            btnKaydet.Text = "Kaydet";
            dtgList.ClearSelection();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            Yukle(txtArama.Text);
        }
    }
}
