using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Aviso : Evento
    {
        public Aviso(int id_predio, DateTime data, string titulo, string Descricao = "", int id=0) : base(id_predio, data, titulo, Descricao, id)
        {
            get_Condominos();
        }

        public List<Condomino> condominos { get; set; }

        public void add_Condomino(Condomino c)
        {
            condominos.Add(c);
        }

        /// <summary>
        /// Get Condominos currently associated with the alert
        /// </summary>
        private void get_Condominos()
        {
            condominos = new List<Condomino>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getCondominosOnAlert(@ID);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string cc = reader["CC"].ToString();
                string nome = reader["Nome"].ToString();
                string nif = reader["NIF"].ToString();
                string email = "";
                if(reader["E_mail"] != DBNull.Value)
                    email = reader["E_mail"].ToString();

                condominos.Add(new Condomino(cc, nome, nif, email));
            }
            reader.Close();
            Database_Connection.cn.Close();
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertAviso", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", id_predio);
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Titulo", titulo);

            if (!string.IsNullOrEmpty(descricao))
            {
                cmd.Parameters.AddWithValue("@Descricao", descricao);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Descricao", null);
            }

            SqlParameter pm = new SqlParameter("@new_id", System.Data.SqlDbType.Int);
            pm.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(pm);
            

            try
            {
                // Save the inserted id 
                cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["@new_id"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            

            
            foreach (Condomino c in condominos)
            {

                cmd = new SqlCommand("CONDOMINIUM.p_InsertCondominoAviso", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Aviso", id);
                cmd.Parameters.AddWithValue("@CC", c.CC);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }
            }
            
            Database_Connection.cn.Close();
        }
    }
}
