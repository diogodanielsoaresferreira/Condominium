using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Item
    {
        private string _nome;
        private Orcamento _orc;
        private double _balanco;

        public Item(string Nome, Orcamento orc, double balanco){
            this.Nome = Nome;
            this.orc = orc;
            this.Balanco = balanco;
        }

        public string Nome
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

        public Orcamento orc
        {
            get
            {
                return _orc;
            }
            set
            {
                _orc = value;
            }
        }

        public double Balanco
        {
            get
            {
                return _balanco;
            }
            set
            {
                _balanco = value;
            }
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertItem", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Balanco", Balanco);
            cmd.Parameters.AddWithValue("@Orcamento_ID", orc.ID);

            try
            {
                // Save the inserted id
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            cn.Close();
        }
    }
}
