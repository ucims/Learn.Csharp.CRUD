using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;


namespace Learn.CRUD.PostgreSQL
{
    class ClassCrud
    {
        private static string getConnection()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string db = "Database=DB_Data_Diri;";
            string user = "Username=postgres;";
            string pass = "Password=maisenpai;";

            string conn = string.Format("{0}{1}{2}{3}{4}", host, port, db, user, pass);
            return conn;
        }

        public static NpgsqlConnection npgsqlConnection = new NpgsqlConnection(getConnection());
        public static NpgsqlCommand command = default(NpgsqlCommand);
        public static string sql = string.Empty;

        public static DataTable PerformCrud(NpgsqlCommand command)
        {
            NpgsqlDataAdapter dataAdapter = default(NpgsqlDataAdapter);
            DataTable dataTable = new DataTable();
            try
            {
                dataAdapter = new NpgsqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = null;
            }

            return dataTable;
        }
    }
}
