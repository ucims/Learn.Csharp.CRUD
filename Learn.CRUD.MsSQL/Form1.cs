using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn.CRUD.MsSQL
{
    public partial class Form1 : Form
    {
        Pelajar pelajar;
        Gateway gateway;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            MasukanData();
        }

        private void MasukanData()
        {
            Pelajar pelajar = new Pelajar();
            pelajar.Roll = textBoxRoll.Text;
            pelajar.Math = Convert.ToDecimal(textBoxMath.Text);
            pelajar.English = Convert.ToDecimal(textBoxEnglish.Text);
            pelajar.Science = Convert.ToDecimal(textBoxScience.Text);
            Gateway gateway = new Gateway();
            gateway.SaveData(pelajar);
            MessageBox.Show("Saved");
            ResetField();
        }

        private void ResetField()
        {
            textBoxEnglish.Text = "";
            textBoxScience.Text = "";
            textBoxMath.Text = "";
            textBoxRoll.Text = "";
        }

        private void buttonLihat_Click(object sender, EventArgs e)
        {
            pelajar = new Pelajar();
            gateway = new Gateway();

            pelajar = gateway.Get(textBoxRoll.Text);

            textBoxEnglish.Text = pelajar.English.ToString();
            textBoxScience.Text = pelajar.Science.ToString();
            textBoxMath.Text = pelajar.Math.ToString();
        }
    }
}
