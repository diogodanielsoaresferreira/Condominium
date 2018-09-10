using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Condomino
    {

        private string _CC;
        private string _NIF;
        private string _Nome;
        private string _Email;

        public string CC
        {
            get
            {
                return _CC;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 8)
                    throw new ArgumentOutOfRangeException("CC");
                _CC = value;
            }
        }

        public string NIF
        {
            get
            {
                return _NIF;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 9)
                {
                    throw new ArgumentOutOfRangeException("NIF");
                }
                _NIF = value;
            }
        }

        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Nome");
                }
                _Nome = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length > 50)
                        throw new ArgumentOutOfRangeException("Email");
                    _Email = value;
                }
            }
        }

        public Condomino()
        {
        }

        public Condomino(string CC, string Nome, string NIF, string Email="")
        {
            this.CC = CC;
            this.Nome = Nome;
            this.NIF = NIF;
            this.Email = Email;
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertCondomino", cn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", CC);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@NIF", NIF);

            
            if (string.IsNullOrEmpty(Email))
            {
                cmd.Parameters.AddWithValue("@e_mail", Email);
            }


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static List<Condomino> get_All_Condominos(int IDPredio)
        {
            List<Condomino> condominos = new List<Condomino>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllCondominos(@ID_Predio);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Condomino c = new Condomino();

                // These values can't be null 
                c.Nome = reader["Nome"].ToString();
                c.CC = reader["CC"].ToString();
                c.NIF = reader["NIF"].ToString();

                // These values can be null
                if (reader["E_mail"] != DBNull.Value)
                    c.Email = reader["E_mail"].ToString();

                condominos.Add(c);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return condominos;
        }

        /// <summary>
        /// Get all Current Condonimos of a Building
        /// </summary>
        /// <param name="IDPredio"></param>
        /// <returns></returns>
        public static List<Condomino> get_All_Current_Condominos(int IDPredio)
        {
            List<Condomino> condominos = new List<Condomino>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllCurrentCondominosFromBuilding(@ID_Predio);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Condomino c = new Condomino();

                // These values can't be null 
                c.Nome = reader["Nome"].ToString();
                c.CC = reader["CC"].ToString();
                c.NIF = reader["NIF"].ToString();
                
                // These values can be null
                if (reader["E_mail"] != DBNull.Value)
                    c.Email = reader["E_mail"].ToString();

                condominos.Add(c);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return condominos;
        }
        

        public static List<Condomino> get_Condominos(int IDPredio)
        {
            List<Condomino> condominos = new List<Condomino>();

            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getAllCondominos(@ID_Predio);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Condomino c = new Condomino();

                // These values can't be null 
                c.Nome = reader["Nome"].ToString();
                c.CC = reader["CC"].ToString();
                c.NIF = reader["NIF"].ToString();

                // These values can be null
                if (reader["E_mail"] != DBNull.Value)
                    c.Email = reader["E_mail"].ToString();

                condominos.Add(c);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return condominos;
        }

        public static int get_Number_Current_Condominos(int IDPredio)
        {
            int number_c = 0;
            SqlCommand cmd = new SqlCommand(@"SELECT dbo.getNumberOfCurrentCondominos(@ID_Predio);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);

            number_c = (int)cmd.ExecuteScalar();

            Database_Connection.cn.Close();
            return number_c;
        }
    }
}
