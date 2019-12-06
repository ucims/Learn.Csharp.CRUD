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

            string query = @"INSERT INTO Mahasiswa VALUES(" + pelajar.Roll + "," + pelajar.English + "," + pelajar.Math + "," + pelajar.Science + ")";
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
                pelajar.English = Convert.ToDecimal(sqlDataReader["Id"].ToString());
                pelajar.Math = Convert.ToDecimal(sqlDataReader["Id"].ToString());
                pelajar.Science = Convert.ToDecimal(sqlDataReader["Id"].ToString());

            }
            return pelajar;

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
