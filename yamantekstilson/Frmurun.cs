using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yamantekstilson
{
    public partial class Frmurun : Form
    {
        public Frmurun()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public Urun Urun { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtUrun)) return;
            if (!ErrorControl(nmFiyat)) return;

            if (!ErrorControl(nmStok)) return;



            Urun.Ad = txtUrun.Text;

            Urun.Fiyat = (double)nmFiyat.Value;
            Urun.Stok = (double)nmStok.Value;




            DialogResult = DialogResult.OK;
        }

        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "boş bırakalamaz veya hatalı giriş");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "boş bırakalamaz veya hatalı giriş");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            return true;

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            txtID.Text = Urun.ID.ToString();
            if (Güncelleme)
            {
                txtUrun.Text = Urun.Ad;

                nmFiyat.Value = (decimal)Urun.Fiyat;
                nmStok.Value = (decimal)Urun.Stok;




            }
        }

        private void txtDetay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
