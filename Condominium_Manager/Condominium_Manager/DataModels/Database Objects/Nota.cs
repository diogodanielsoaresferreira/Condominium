using Condominium_Manager.DataModels;
using System;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Nota : Evento
    {
        public Nota(int id_predio, DateTime data, string titulo, string Descricao = "", int id=0) : base(id_predio, data, titulo, Descricao, id)
        {
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertNota", cn);
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

            finally
            {
                cn.Close();
            }
        }
    }
}
