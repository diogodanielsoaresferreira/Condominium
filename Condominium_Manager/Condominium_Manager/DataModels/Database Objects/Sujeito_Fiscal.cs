using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Sujeito_Fiscal
    {

        public Sujeito_Fiscal(string NIF, string Nome, string E_mail="", string morada="")
        {
            this.NIF = NIF;
            this.nome = Nome;

            if (!string.IsNullOrEmpty(E_mail))
                this.E_mail = E_mail;

            if (!string.IsNullOrEmpty(morada))
                this.morada = morada;
        }

        private string _nif;
        private string _nome;
        private string _email;
        private string _morada;

        public string NIF
        {
            get
            {
                return _nif;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length != 9)
                {
                    throw new ArgumentOutOfRangeException("NIF");
                }
                _nif = value;
            }
        }

        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                    throw new ArgumentOutOfRangeException("Nome");
                _nome = value;
            }
        }

        public string E_mail
        {
            get
            {
                return _email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 50)
                    throw new ArgumentOutOfRangeException("E-mail");
                _email = value;
            }
        }

        public string morada
        {
            get
            {
                return _morada;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 100)
                    throw new ArgumentOutOfRangeException("Morada");
                _morada = value;
            }
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertSujeitoFiscal", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NIF", NIF);
            cmd.Parameters.AddWithValue("@Nome", nome);

            // These attributes can be null
            if (!string.IsNullOrEmpty(E_mail))
            {
                cmd.Parameters.AddWithValue("@e_mail", E_mail);
            }
            else
                cmd.Parameters.AddWithValue("@e_mail", null);

            if (!string.IsNullOrEmpty(morada))
            {
                cmd.Parameters.AddWithValue("@Morada", morada);
            }
            else
                cmd.Parameters.AddWithValue("@Morada", null);
            
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

        public static List<Sujeito_Fiscal> get_All_SujFiscal()
        {
            List<Sujeito_Fiscal> sjs = new List<Sujeito_Fiscal>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllSujeitosFiscais();", Database_Connection.cn);

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                string NIF = reader["NIF"].ToString();
                string Nome = reader["Nome"].ToString();
                string e_mail = "";
                string morada = "";

                if(DBNull.Value != reader["e_mail"])
                {
                    e_mail = reader["e_mail"].ToString();
                }

                if(DBNull.Value != reader["Morada"])
                {
                    morada = reader["Morada"].ToString();
                }

                sjs.Add(new Sujeito_Fiscal(NIF, Nome, e_mail, morada));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return sjs;
        }

    }
}
