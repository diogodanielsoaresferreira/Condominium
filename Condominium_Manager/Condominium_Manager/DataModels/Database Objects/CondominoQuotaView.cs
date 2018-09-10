using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class CondominoQuotaView
    {
        public Condomino c { get; set; }
        public Fracao f { get; set; }
        public bool pay { get; set; }
        public DateTime compra { get; set; }

        public CondominoQuotaView(Fracao f, Condomino c, bool pay, DateTime compra)
        {
            this.c = c;
            this.pay = pay;
            this.f = f;
            this.compra = compra;
        }

        public static List<CondominoQuotaView> get_All_Current_Condominos(int IDPredio)
        {
            DateTime dtstart = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);
            DateTime dtend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 30);

            List<CondominoQuotaView> condominos = new List<CondominoQuotaView>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getCurrentCondominosQuotasAndFracoes(@ID_Predio, @dtstart, @dtend);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@dtstart", dtstart);
            cmd.Parameters.AddWithValue("@dtend", dtend);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Fracao F = new Fracao();
                DateTime compra;

                compra = DateTime.Parse(reader["Data_Compra"].ToString());

                // These values can't be null 
                F.ID = int.Parse(reader["ID"].ToString());
                F.Area = double.Parse(reader["Area"].ToString());
                F.Tipo = reader["Tipo"].ToString();
                F.IDPredio = int.Parse(reader["ID_Predio"].ToString());
                F.Piso = int.Parse(reader["Piso"].ToString());

                // These values can be null
                if (reader["Zona"] != DBNull.Value)
                    F.Zona = reader["Zona"].ToString();

                if (reader["Quota"] != DBNull.Value)
                    F.Quota = double.Parse(reader["Quota"].ToString());

                Condomino c = new Condomino();

                // These values can't be null 
                c.Nome = reader["Nome"].ToString();
                c.CC = reader["CC"].ToString();
                c.NIF = reader["NIF"].ToString();

                // These values can be null
                if (reader["E_mail"] != DBNull.Value)
                    c.Email = reader["E_mail"].ToString();

                bool payed = !string.IsNullOrEmpty(reader["Mes"].ToString());
                

                condominos.Add(new CondominoQuotaView(F, c, payed, compra));


            }
            reader.Close();
            Database_Connection.cn.Close();
            return condominos;
        }

    }
}
