using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Reuniao : Evento
    {
        public List<Condomino> condominos
        {
            get
            {
                if (_condominos.Count == 0)
                    get_Condominos();
                return _condominos;
            }
            set
            {
                _condominos = value;
            }
        }

        private string _ata;
        public string ata {
            get {
                return _ata;
            }
            set {
                if (!string.IsNullOrEmpty(value) && value.Length>1000)
                {
                    throw new ArgumentOutOfRangeException("ata");
                }
                _ata = value;
            }
        }

        private List<Condomino> _condominos { get; set; } = new List<Condomino>();

        public Reuniao(int id_predio, DateTime data, string titulo, string Descricao = "", int id=0, string ata="") : base(id_predio, data, titulo, Descricao, id)
        {
            if (!string.IsNullOrEmpty(ata))
            {
                this.ata = ata;
            }
        }
        


        public void add_Condomino(Condomino c)
        {
            _condominos.Add(c);
        }

        public static List<Reuniao> get_Reunioes(int IDPredio, DateTime final, DateTime initial)
        {
            List<Reuniao> Rs = new List<Reuniao>();

            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getReunioesOfBuilding(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime dt = DateTime.Parse(reader["Data"].ToString());
                string titulo = reader["Titulo"].ToString();
                string desc = "";
                string ata = "";
                if (DBNull.Value != reader["Descricao"])
                    desc = reader["Descricao"].ToString();
                if (DBNull.Value != reader["Ata"])
                    ata = reader["Ata"].ToString();
                int id = int.Parse(reader["ID"].ToString());

                Rs.Add(new Reuniao(IDPredio, dt, titulo, desc, id, ata));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return Rs;
        }

        /// <summary>
        /// Get Condominos currently associated with the reunion
        /// </summary>
        private void get_Condominos()
        {
            _condominos = new List<Condomino>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getCondominosOnReunion(@ID);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string cc = reader["CC"].ToString();
                string nome = reader["Nome"].ToString();
                string nif = reader["NIF"].ToString();
                string email = "";
                if (reader["E_mail"] != DBNull.Value)
                    email = reader["E_mail"].ToString();

                _condominos.Add(new Condomino(cc, nome, nif, email));
            }
            reader.Close();
            Database_Connection.cn.Close();
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertReuniao", cn);
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
                cmd.Parameters.AddWithValue("@Descricao", null);

            if (!string.IsNullOrEmpty(ata))
            {
                cmd.Parameters.AddWithValue("@Ata", ata);
            }
            else
                cmd.Parameters.AddWithValue("@Ata", null);

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
                cmd = new SqlCommand("CONDOMINIUM.p_insertCondominoReuniao", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID_Reuniao", id);
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

            cn.Close();
        }
    }
}
