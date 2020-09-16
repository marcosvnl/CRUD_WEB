using CRUD_WEB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_WEB.Repositorio
{
    public class TimeRepositorio
    {
        // Metodo para chamar a conexão SQL
        private SqlConnection _con;
        private void Connection()
        {
            //Aqui também estava com um erro. A String era recuperada, mas não estava sendo utilizada
            // na conexão "_con"            
            _con = new SqlConnection();
            _con.ConnectionString = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
        }
        // Add Times
        public bool AdicionarTime(Times timeobj)
        {
            Connection();
            int i;
            // Chamar a PROCEDURE
            using (SqlCommand command = new SqlCommand("IncluirTime", _con))
            {
                //Passando os parametros da PROCEDURE IncluirTime
                // e adicionando valores
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Time", timeobj.Time);
                command.Parameters.AddWithValue("@Estado", timeobj.Estado);
                command.Parameters.AddWithValue("@Cores", timeobj.Cores);
                _con.Open();
                i = command.ExecuteNonQuery();

            }
            _con.Close();
            return i >= 1;
        }
        // Retorno de todos os times em uma lista
        public List<Times> ObterTimes()
        {
            Connection();
            List<Times> timesList = new List<Times>();
            using (SqlCommand command = new SqlCommand("ObterTimes", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();
                SqlDataReader reader = command.ExecuteReader();
                // Equanto estiver lendo reader
                while (reader.Read())
                {
                    Times time = new Times()
                    {
                        // Retorno das linhas declaradas na PROCEDURE ObterTimes 
                        TimeId = Convert.ToInt32(reader["TimeId"]),
                        Time = Convert.ToString(reader["Time"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        Cores = Convert.ToString(reader["Cores"]),
                    };
                    timesList.Add(time);
                }
                _con.Close();
                return timesList;
            }
        }
        //Atualizar times
        public bool AtualizarTime(Times timeobj)
        {
            Connection();
            int i;
            using (SqlCommand command = new SqlCommand("AtualizarTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@TimeId", timeobj.TimeId);
                command.Parameters.AddWithValue("@Time", timeobj.Time);
                command.Parameters.AddWithValue("@Estado", timeobj.Estado);
                command.Parameters.AddWithValue("@Cores", timeobj.Cores);
                _con.Open();
                i = command.ExecuteNonQuery();

            }
            _con.Close();
            return i >= 1;
        }
        public bool ExcluirTime(int id)
        {
            Connection();
            int i;

            using (SqlCommand command = new SqlCommand("ExcluirTimeId", _con))
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", id);
                _con.Open();
                i = command.ExecuteNonQuery();

            }
            _con.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
}