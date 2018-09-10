using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Pagamentos_Quota : Transacao
    {
        public Pagamentos_Quota(DateTime dt, double balanco, Fracao f, DateTime mes, int ID=-1) : base(dt, balanco, ID, "", "Quota "+mes.ToString("MM/yy"))
        {
            this.f = f;
            this.mes = mes;
            
        }
        
        private Fracao _f;
        private DateTime _mes;
        

        public Fracao f
        {
            get
            {
                return _f;
            }
            set
            {
                _f = value;
            }
        }

        public DateTime mes
        {
            get
            {
                return _mes;
            }
            set
            {
                _mes = value;
            }
        }

        public static List<Pagamentos_Quota> get_Quotas(int IDPredio, DateTime final, DateTime initial)
        {
            List<Pagamentos_Quota> Ts = new List<Pagamentos_Quota>();
            List<Fracao> fr = new List<Fracao>();

            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getQuotasOfBuilding(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Fracao F = new Fracao();

                // These values can't be null 
                F.ID = int.Parse(reader["ID_Fracao"].ToString());
                F.Area = double.Parse(reader["Area"].ToString());
                F.Tipo = reader["Tipo"].ToString();
                F.Zona = reader["Zona"].ToString();
                F.IDPredio = int.Parse(reader["ID_Predio"].ToString());
                F.Piso = int.Parse(reader["Piso"].ToString());

                // These values can be null
                if (reader["Zona"] != DBNull.Value)
                    F.Zona = reader["Zona"].ToString();

                if (reader["Quota"] != DBNull.Value)
                    F.Quota = double.Parse(reader["Quota"].ToString());
                

                DateTime dt = DateTime.Parse(reader["Data"].ToString());
                double Balanco = double.Parse(reader["Balanco"].ToString());
                int id = int.Parse(reader["PID"].ToString());
                DateTime mes = DateTime.Parse(reader["Mes"].ToString());

                fr.Add(F);
                Ts.Add(new Pagamentos_Quota(dt, Balanco, F, mes, id));
            }


            reader.Close();
            Database_Connection.cn.Close();
            
            for(int i=0; i<Ts.Count; i++)
            {
                if(fr[i].CurrentCondomino!=null)
                    Ts[i].Entidade = fr[i].CurrentCondomino.Nome;
            }

            return Ts;
        }
        

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertPagamentoQuota", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Mes", mes);
            cmd.Parameters.AddWithValue("@Data", Date);
            cmd.Parameters.AddWithValue("@Balanco", Balanco);
            cmd.Parameters.AddWithValue("@ID_Fracao", f.ID);

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

        public static int numberQuotasAtrasadas(int PredioID)
        {
            List<Pagamentos_Quota> Ts = new List<Pagamentos_Quota>();
            List<Fracao> fr = new List<Fracao>();

            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getQuotasAtrasadasOfBuilding(@ID_Predio, @Initial_Month, @End_Month);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", PredioID);
            cmd.Parameters.AddWithValue("@Initial_Month", new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1));
            cmd.Parameters.AddWithValue("@End_Month", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
            SqlDataReader reader = cmd.ExecuteReader();

            int on_day = 0;
            int all_quotes = 0;

            while (reader.Read())
            {
                on_day = int.Parse(reader["QUOTES_ON_DAY"].ToString());
                all_quotes = int.Parse(reader["ALL_QUOTES"].ToString());
            }


            reader.Close();
            Database_Connection.cn.Close();
            
            return all_quotes-on_day;
        }
    }
}
