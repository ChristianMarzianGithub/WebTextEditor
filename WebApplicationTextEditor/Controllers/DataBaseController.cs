using System;
using System.Data.SqlClient;

namespace WebApplicationTextEditor.Controllers
{
    public class DataBaseController
    {
        private SqlConnection getConnection()
        {
            return new SqlConnection("User ID=Innosoft;Initial Catalog=lagerDB;Data Source=LPE846-17\\SQLEXPRESS;Password=dispo");
        }

        public SqlDataReader executeQuery(String command)
        {
            SqlConnection con = getConnection();            
            con.Open();
            SqlCommand comm = con.CreateCommand();
            comm.CommandText = command;            
            return comm.ExecuteReader();
        }

        public void executeNonQuery(String command)
        {
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand comm = con.CreateCommand();
            comm.CommandText = command;
            comm.ExecuteNonQuery();
        }
    }
}