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
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            MasukanData();
        }

        private void MasukanData()
        {
            Pelajar pelajar = new Pelajar();
            pelajar.Roll = textBoxRoll.Text;
            pelajar.Bahasa = Convert.ToDecimal(textBoxBahasa.Text);
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
            textBoxBahasa.Text = "";
            textBoxRoll.Text = "";
        }

        private void buttonLihat_Click(object sender, EventArgs e)
        {
            pelajar = new Pelajar();
            gateway = new Gateway();

            pelajar = gateway.Get(textBoxRoll.Text);

            textBoxEnglish.Text = pelajar.English.ToString();
            textBoxScience.Text = pelajar.Science.ToString();
            textBoxBahasa.Text = pelajar.Bahasa.ToString();

            buttonSimpan.Enabled = false;
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }
        // button update
        private void button1_Click(object sender, EventArgs e)
        {
            Pelajar pelajar = new Pelajar();
            Gateway gateway = new Gateway();

            pelajar.Roll = textBoxRoll.Text;
            pelajar.Bahasa = Convert.ToDecimal(textBoxBahasa.Text);
            pelajar.English = Convert.ToDecimal(textBoxEnglish.Text);
            pelajar.Science = Convert.ToDecimal(textBoxScience.Text);
            gateway.Update(pelajar);

            MessageBox.Show("Updated");

            ResetField();
        }
        // btn delete
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            pelajar = new Pelajar();
            gateway = new Gateway();
            pelajar.Roll = textBoxRoll.Text;
            gateway.Delete(pelajar);

            MessageBox.Show("Deleted");
            ResetField();
        }
    }
}
