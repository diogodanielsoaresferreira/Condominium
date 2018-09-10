using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Outros_Pagamentos : Transacao
    {

        public Outros_Pagamentos(DateTime dt, double balanco, Predio p, Sujeito_Fiscal sf, string desc="", int ID = -1) : base(dt, balanco, ID, sf.nome, desc)
        {
            this.p = p;
            this.sf = sf;
            
            if(!string.IsNullOrEmpty(desc))
                this.descricao = desc;
        }

       
        private string _desc;
        private Predio _p;
        private Sujeito_Fiscal _sf;

        

        public Predio p
        {
            get
            {
                return _p;
            }
            set
            {
                _p = value;
            }
        }

        public string descricao
        {
            get
            {
                return _desc;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 100)
                    throw new ArgumentOutOfRangeException("Descricao");
                _desc = value;
            }
        }

        public Sujeito_Fiscal sf
        {
            get
            {
                return _sf;
            }
            set
            {
                _sf = value;
            }
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertOutrosPagamentos", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@Data", Date);
            cmd.Parameters.AddWithValue("@suj_fiscal_nif", sf.NIF);
            cmd.Parameters.AddWithValue("@Balanco", Balanco);
            cmd.Parameters.AddWithValue("@ID_Predio",p.ID);

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
                ID = (int)cmd.Parameters["@new_id"].Value;
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

        public static List<Outros_Pagamentos> get_OutrosPagamentos(Predio P, DateTime final, DateTime initial)
        {
            List<Outros_Pagamentos> Ts = new List<Outros_Pagamentos>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getOutrosPagamentos(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", P.ID);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string NIF = reader["NIF"].ToString();
                string nome = reader["Nome"].ToString();
                string e_mail = "";
                string morada = "";
                if(reader["E_mail"] != DBNull.Value)
                    e_mail = reader["E_mail"].ToString();
                if(reader["Morada"] != DBNull.Value)
                    morada = reader["Morada"].ToString();

                Sujeito_Fiscal suj = new Sujeito_Fiscal(NIF, nome, e_mail, morada);

                int ID = int.Parse(reader["OID"].ToString());
                DateTime dt = DateTime.Parse(reader["Data"].ToString());
                double Balanco = double.Parse(reader["Balanco"].ToString());
                string desc = reader["descricao"].ToString();
                Ts.Add(new Outros_Pagamentos(dt, Balanco, P, suj, desc, ID));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return Ts;
        }

    }
}
