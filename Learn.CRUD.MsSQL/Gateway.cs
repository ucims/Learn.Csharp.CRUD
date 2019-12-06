using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.CRUD.MsSQL
{
    public class Gateway
    {
        Pelajar pelajar;
        public bool SaveData(Pelajar pelajar)
        {
            //string conn = "Data Source=DESKTOP-V5VOD86\\SQLEXPRESS;Initial Catalog=Universitas;Integrated Security=True";
            //SqlConnection sqlConnection = new SqlConnection(conn);
            //sqlConnection.Open();

            msConn().Open();

            string query = @"INSERT INTO Mahasiswa VALUES(" + pelajar.Roll + "," + pelajar.English + "," + pelajar.Bahasa + "," + pelajar.Science + ")";
            SqlCommand command = new SqlCommand(query, msConn());
            command.ExecuteNonQuery();
            //sqlConnection.Close();
            msConn().Close();
            return true;
        }

        public Pelajar Get(string roll)
        {
            pelajar = new Pelajar();
            string conn = "Data Source=DESKTOP-V5VOD86\\SQLEXPRESS;Initial Catalog=Universitas;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();

            string query = @"SELECT * FROM Mahasiswa WHERE Roll = " + roll.Trim();
            SqlCommand command = new SqlCommand(query,sqlConnection);

            SqlDataReader sqlDataReader = command.ExecuteReader();
            while(sqlDataReader.Read())
            {
                pelajar.Id = Convert.ToInt32(sqlDataReader["Id"].ToString());
                pelajar.Roll = sqlDataReader["Roll"].ToString();
                pelajar.English = Convert.ToDecimal(sqlDataReader["English"].ToString());
                pelajar.Bahasa = Convert.ToDecimal(sqlDataReader["Bahasa"].ToString());
                pelajar.Science = Convert.ToDecimal(sqlDataReader["Science"].ToString());
            }
            return pelajar;

        }

        public bool Update(Pelajar pelajar)
        {
            //pelajar = new Pelajar();
            string conn = "Data Source=DESKTOP-V5VOD86\\SQLEXPRESS;Initial Catalog=Universitas;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();

            string query = @"UPDATE Mahasiswa SET Bahasa = " + pelajar.English + ",English = " + pelajar.Bahasa + ", Science = " + pelajar.Science + "WHERE Roll = " + pelajar.Roll;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public bool Delete(Pelajar pelajar)
        {
            string conn = "Data Source=DESKTOP-V5VOD86\\SQLEXPRESS;Initial Catalog=Universitas;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();

            string query = @"DELETE FROM Mahasiswa WHERE Roll = " + pelajar.Roll;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        private SqlConnection msConn()
        {
            string conn = "Data Source=DESKTOP-V5VOD86\\SQLEXPRESS;Initial Catalog=Universitas;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(conn);
            //sqlConnection.Open();

            return sqlConnection;
        }

       
                
    }
}
