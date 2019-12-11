using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Learn.CRUD.PostgreSQL
{
   
    public partial class Form1 : Form
    {
        private string Id = "";
        private int jmlRow = 0;
        char gender;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ResetField()
        {
            this.Id = string.Empty;

            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxAddress.Text = "";
            textBoxSearch.Text = "";
            radioButtonLK.Checked = false;
            radioButtonPR.Checked = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData(null);
        }

        private void loadData(string keyword)
        {
            ClassCrud.sql = "SELECT id, firstname, lastname, address, CONCAT(firstname, '', lastname) as fullname, gender from tbl_biodata " +
                "WHERE CONCAT(CAST(id as varchar), ' ', firstname, ' ' , lastname) LIKE @keyword::varchar " +
                "OR TRIM(gender) LIKE @keyword::varchar ORDER By id asc"; 
            //ClassCrud.sql = "Select * from tbl_biodata";
            string keyWordStr = string.Format("%{0}%", keyword);
            ClassCrud.command = new NpgsqlCommand(ClassCrud.sql, ClassCrud.npgsqlConnection);
            ClassCrud.command.Parameters.Clear();
            ClassCrud.command.Parameters.AddWithValue("keyword", keyWordStr);
            DataTable dataTable = new DataTable();
            dataTable = ClassCrud.PerformCrud(ClassCrud.command);
            if(dataTable.Rows.Count > 0)
            {
                jmlRow = Convert.ToInt32(dataTable.Rows.Count.ToString());
            }
            else
            {
                jmlRow = 0;
            }

            toolStripStatusLabel1.Text = "Number of rows " + jmlRow;
            DataGridView dataGridView = dataGridView1;
            dataGridView.MultiSelect = false;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.DataSource = dataTable;

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "First Name";
            dataGridView.Columns[2].HeaderText = "Last Name";
            dataGridView.Columns[3].HeaderText = "Address";
            dataGridView.Columns[4].HeaderText = "Fulll Name";

            dataGridView.Columns[0].Width = 25;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;

            buttonInsert.Enabled = true;
        }

        private void execute(string psql_, string param)
        {
            ClassCrud.command = new NpgsqlCommand(psql_, ClassCrud.npgsqlConnection);
            addParameter(param);
            ClassCrud.PerformCrud(ClassCrud.command);
        }

        private void addParameter(string str)
        {
            bool isChecked = radioButtonLK.Checked;
            if (isChecked)
                gender = 'L';
            else
                gender = 'P';

            ClassCrud.command.Parameters.Clear();
            ClassCrud.command.Parameters.AddWithValue("firstName", textBoxFirstName.Text);
            ClassCrud.command.Parameters.AddWithValue("lastName", textBoxLastName.Text);
            ClassCrud.command.Parameters.AddWithValue("address", textBoxAddress.Text);
            ClassCrud.command.Parameters.AddWithValue("gender", gender);
            if(str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.Id))
            {
                ClassCrud.command.Parameters.AddWithValue("Id", this.Id);
            }

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxFirstName.Text) ||string.IsNullOrEmpty(textBoxLastName.Text))
            {
                MessageBox.Show("Field tidak boleh kosong, kaya hati yang ngoding wkwkwkwkwkwkwkwkwkwkwk", "Insert data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; ;
            }

            ClassCrud.sql = "INSERT INTO tbl_biodata (firstname, lastname, address, gender) VALUES (@FirstName, @LastName, @Address, @Gender)";
            try
            {
                execute(ClassCrud.sql, "Insert");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data berhasil disimpan, cie ga kaya hati dia yang tau kemana", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           loadData(null);
            ResetField();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridView dataGridView = dataGridView1;
                this.Id = Convert.ToString(dataGridView.CurrentRow.Cells[0].Value);
                buttonInsert.Enabled = false;
                buttonDelete.Text = "Delete (" + this.Id + ")";
                buttonUpdate.Text = "Update (" + this.Id + ")";

                textBoxFirstName.Text = Convert.ToString(dataGridView.CurrentRow.Cells[1].Value);
                textBoxLastName.Text = Convert.ToString(dataGridView.CurrentRow.Cells[2].Value);
                textBoxAddress.Text = Convert.ToString(dataGridView.CurrentRow.Cells[3].Value);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Select item from table"," Data kosong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if(string.IsNullOrEmpty(this.Id))
            {
                MessageBox.Show("Field tidak boleh kosong, kaya hati yang ngoding wkwkwkwkwkwkwkwkwkwkwk", "Insert data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ClassCrud.sql = "UPDATE tbl_biodata SET firstname = @firstname, lastname = @lastname, address = @address, gender = @gender WHERE id = @id::integer";
            execute(ClassCrud.sql, "Update");
            MessageBox.Show("Update Success", "Update data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData("");
            ResetField();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Select item from table", " Data kosong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrEmpty(this.Id))
            {
                MessageBox.Show("Field tidak boleh kosong, kaya hati yang ngoding wkwkwkwkwkwkwkwkwkwkwk", "Insert data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if(MessageBox.Show("Apakah anda ingin menghapus semua kenangan yang ada agar tidak galu mengingat masa lalau","Delete Kenangan Permanen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ClassCrud.sql = "DELETE FROM tbl_biodata WHERE id = @id::integer";
                execute(ClassCrud.sql, "Update");
                MessageBox.Show("Delete Success", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData("");
                ResetField();
            }
            else
            {
                MessageBox.Show("Move on Gagal", "Delete data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxSearch.Text.Trim()))
            {
                loadData("");
            }
            else
            {
                loadData(textBoxSearch.Text.Trim());
            }
        }

        private void textBoxFirstName_Click(object sender, EventArgs e)
        {
        }
    }

   
}
