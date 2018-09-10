using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Manutencao : Evento
    {
        public Manutencao(Predio p, DateTime data, string titulo, string Descricao = "", int id=0, string tipo="", Outros_Pagamentos op = null) : base(p.ID, data, titulo, Descricao, id)
        {
            this.p = p;
            this.tipo = tipo;
            this.op = op;
        }

        public Predio p { get; set; }
        private string _tipo;
        private Outros_Pagamentos _op;

        public string tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("tipo");
                }
                _tipo = value;
            }
        }

        public Outros_Pagamentos op
        {
            get
            {
                return _op;
            }
            set
            {
                _op = value;
            }
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertManutencao", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", p.ID);
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Titulo", titulo);

            // These attributes can be null 
            if (!string.IsNullOrEmpty(descricao))
            {
                cmd.Parameters.AddWithValue("@Descricao", descricao);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Descricao", null);
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                cmd.Parameters.AddWithValue("@tipo", tipo);
            }
            else
            {
                cmd.Parameters.AddWithValue("@tipo", null);
            }

            if (op!=null)
            {
                cmd.Parameters.AddWithValue("@Id_Outros_Pagamentos", op.ID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id_Outros_Pagamentos", null);
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

        public static List<Manutencao> get_Manutencoes(Predio p, DateTime final, DateTime initial)
        {
            List<Manutencao> Rs = new List<Manutencao>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllManutencoesAndPaymentsOfBuilding(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", p.ID);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Sujeito_Fiscal sj;
                Outros_Pagamentos op = null;

                if (DBNull.Value != reader["Id_Outros_Pagamentos"]){
                    string Morada = "";
                    string Email = "";

                    string NIF = reader["NIF"].ToString();
                    string Nome = reader["Nome"].ToString();

                    if (reader["Morada"] != DBNull.Value)
                        Morada = reader["Morada"].ToString();
                    if (reader["e_mail"] != DBNull.Value)
                        Email = reader["e_mail"].ToString();
                    sj = new Sujeito_Fiscal(NIF, Nome, Email, Morada);

                    int id_outros_pag = int.Parse(reader["Id_Outros_Pagamentos"].ToString());
                    DateTime OData = DateTime.Parse(reader["OData"].ToString());
                    double balanco = double.Parse(reader["Balanco"].ToString());

                    string ODescricao = "";
                    if (DBNull.Value != reader["ODescricao"])
                        ODescricao = reader["ODescricao"].ToString();

                    op = new Outros_Pagamentos(OData, balanco, p, sj, ODescricao, id_outros_pag);
                }

                DateTime dt = DateTime.Parse(reader["MData"].ToString());
                string titulo = reader["Titulo"].ToString();
                string desc = "";
                string tipo = "";


                if (DBNull.Value != reader["MDescricao"])
                    desc = reader["MDescricao"].ToString();

                if (DBNull.Value != reader["Tipo"])
                    tipo = reader["Tipo"].ToString();
                
                int id = int.Parse(reader["MID"].ToString());

                Rs.Add(new Manutencao(p, dt, titulo, desc, id, tipo, op));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return Rs;
        }

    }
}
