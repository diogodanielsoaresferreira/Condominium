using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Orcamento
    {

        private int _id;
        private string _titulo;
        private string _descricao;
        private DateTime inicial;
        private DateTime final;
        private Predio _p;
        private List<Item> _items = new List<Item>();

        public Orcamento(string titulo, DateTime inicial, DateTime final, Predio p, string Descricao="", int id=-1)
        {
            this.Titulo = titulo;
            this.inicial = inicial;
            this.final = final;
            this.p = p;

            if (!string.IsNullOrEmpty(Descricao))
                this.Descricao = Descricao;

            if (id != -1)
                this.ID = id;

        }

        public List<Item> items
        {
            get
            {
                if (_items.Count == 0)
                    get_Items();
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID");
                _id = value;
            }
        }

        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 25)
                    throw new ArgumentOutOfRangeException("Titulo");
                _titulo = value;
            }
        }

        public string Descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 100)
                    throw new ArgumentOutOfRangeException("Descricao");
                _descricao = value;
            }
        }

        public DateTime Initial_Date
        {
            get
            {
                return inicial;
            }
            set
            {
                if (value == null || (final!=null && value>final))
                    throw new ArgumentOutOfRangeException("Data Inicial");
                inicial = value;
            }
        }

        public DateTime Final_Date
        {
            get
            {
                return final;
            }
            set
            {
                if (value == null || (inicial != null && value < inicial))
                    throw new ArgumentOutOfRangeException("Data Final");
                final = value;
            }
        }

        public Predio p
        {
            get
            {
                return _p;
            }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException("Prédio");
                _p = value;
            }
        }

        public static List<Orcamento> get_Orcamentos(int IDPredio, DateTime final, DateTime initial, Predio p)
        {
            List<Orcamento> Orcamentos = new List<Orcamento>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getOrcamentoFromBuilding(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime dt_inicial = DateTime.Parse(reader["Data_Inicial"].ToString());
                DateTime dt_final = DateTime.Parse(reader["Data_Final"].ToString());
                string titulo = reader["Titulo"].ToString();
                string desc = "";
                if (DBNull.Value != reader["Descricao"])
                    desc = reader["Descricao"].ToString();
                int id = int.Parse(reader["ID"].ToString());

                Orcamentos.Add(new Orcamento(titulo, dt_inicial, dt_final, p, desc, id));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return Orcamentos;
        }

        private void get_Items()
        {
            _items = new List<Item>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getItemsFromOrcamento(@ID);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string Nome = reader["nome"].ToString();
                double Balanco = double.Parse(reader["balanco"].ToString());
                _items.Add(new Item(Nome, this, Balanco));
            }
            reader.Close();
            Database_Connection.cn.Close();
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertOrcamento", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            
            cmd.Parameters.AddWithValue("@ID_Predio", p.ID);
            cmd.Parameters.AddWithValue("@Data_Inicial", Initial_Date);
            cmd.Parameters.AddWithValue("@Data_Final", Final_Date);
            cmd.Parameters.AddWithValue("@Titulo", Titulo);

            if (!string.IsNullOrEmpty(Descricao))
            {
                cmd.Parameters.AddWithValue("@Descricao", Descricao);
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
                ID = (int)cmd.Parameters["@new_id"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            cn.Close();
        }

    }
}
