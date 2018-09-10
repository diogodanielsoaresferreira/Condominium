using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Transacao
    {
        private int _ID;
        private DateTime _dt;
        private double _bal;
        

        public Transacao(DateTime dt, double balanco, int ID=-1, string Entidade = "", string tipo="")
        {
            if(ID!=-1)
                this.ID = ID;
            this.Date = dt;
            this.Balanco = balanco;

            if (!string.IsNullOrEmpty(Entidade))
                this.Entidade = Entidade;

            if(!string.IsNullOrEmpty(tipo))
                this.Tipo = tipo;
            
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("ID");
                _ID = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
            }
        }

        public string dataString
        {
            get
            {
                return Date.ToString("dd/MM/yy");
            }
        }

        public double Balanco
        {
            get
            {
                return _bal;
            }
            set
            {
                _bal = value;
            }
        }

        public double simBal
        {
            get
            {
                return -_bal;
            }
        }

        public string Tipo { get; set; }

        public string Entidade { get; set; }

        public static List<Transacao> get_Transactions(int IDPredio, DateTime final, DateTime initial)
        {
            List<Transacao> Ts = new List<Transacao>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getBuildingTransactions(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime dt = DateTime.Parse(reader["Data"].ToString());
                double Balanco = double.Parse(reader["Balanco"].ToString());
                Ts.Add(new Transacao(dt, Balanco));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return Ts;
        }

        public static double get_Sum_Transactions(int IDPredio, DateTime final, DateTime initial)
        {
            double co = 0;

            SqlCommand cmd = new SqlCommand(@"SELECT dbo.getSumTransactions(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);

            object o = cmd.ExecuteScalar();
            if (o != DBNull.Value)
                co = Convert.ToDouble(o);

            Database_Connection.cn.Close();
            return co;
        }

        public static double get_Sum_Receita(int IDPredio, DateTime final, DateTime initial)
        {
            double co = 0;

            SqlCommand cmd = new SqlCommand(@"SELECT dbo.getSumReceita(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);

            object o = cmd.ExecuteScalar();
            if (o != DBNull.Value)
                co = Convert.ToDouble(o);

            Database_Connection.cn.Close();
            return co;
        }

        public static double get_Sum_Despesa(int IDPredio, DateTime final, DateTime initial)
        {
            double co = 0;

            SqlCommand cmd = new SqlCommand(@"SELECT dbo.getSumDespesa(@ID_Predio, @InitialDate, @FinalDate);", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@InitialDate", initial);
            cmd.Parameters.AddWithValue("@FinalDate", final);

            object o = cmd.ExecuteScalar();
            if (o != DBNull.Value)
                co = Convert.ToDouble(o);

            Database_Connection.cn.Close();
            return co;
        }

    }
}
