using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace FindBus.Models
{
    public class BDAcess
    {
        private MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["FindBus"].ToString());

        public DataTable ExecutaQuery(string query, List<MySqlParameter> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    if (parametros != null)
                        command.Parameters.Add(parametros);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                }
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public DataTable ExecutaQuery(string query)
        {
            return ExecutaQuery(query, parametros: null);
        }
        public int ExecutaQuery(string query, string campo)
        {
            MySqlDataReader dr;
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    con.Open();
                    command.CommandType = CommandType.Text;
                    dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        return Convert.ToInt32(dr[campo].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return 0;
        }
    }
}