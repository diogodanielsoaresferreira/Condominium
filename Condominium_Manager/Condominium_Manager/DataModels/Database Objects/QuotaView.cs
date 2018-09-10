using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class QuotaView
    {
        public string Nome { get; set; }
        public int Piso { get; set; }
        public string Zona { get; set; }
        public string Tipo { get; set; }
        public double Quota { get; set; }
        public int Fracao_Id { get; set; }
        public DateTime DateCompra { get; set; }
        public DateTime DateVenda { get; set; }
        public bool Janeiro { get; set; }
        public bool Fevereiro { get; set; }
        public bool Marco { get; set; }
        public bool Abril { get; set; }
        public bool Maio { get; set; }
        public bool Junho { get; set; }
        public bool Julho { get; set; }
        public bool Agosto { get; set; }
        public bool Setembro { get; set; }
        public bool Outubro { get; set; }
        public bool Novembro { get; set; }
        public bool Dezembro { get; set; }

        public QuotaView(string Nome, int Fracao_Id, int Piso, string Zona, string tipo, double quota, bool Janeiro = false, bool Fevereiro = false, bool Marco = false, bool Abril = false, bool Maio = false, bool Junho = false, bool Julho = false, bool Agosto = false, bool Setembro = false, bool Outubro = false, bool Novembro = false, bool Dezembro = false)
        {
            this.Nome = Nome;
            this.Piso = Piso;
            this.Zona = Zona;
            this.Tipo = tipo;
            this.Quota = quota;
            this.Fracao_Id = Fracao_Id;
            this.DateCompra = DateTime.MinValue;
            this.DateVenda = DateTime.MaxValue;

            this.Janeiro = Janeiro;
            this.Fevereiro = Fevereiro;
            this.Marco = Marco;
            this.Abril = Abril;
            this.Maio = Maio;
            this.Junho = Junho;
            this.Julho = Julho;
            this.Agosto = Agosto;
            this.Setembro = Setembro;
            this.Outubro = Outubro;
            this.Novembro = Novembro;
            this.Dezembro = Dezembro;
        }

        public static List<QuotaView> getAllQuotas(Predio p, int year)
        {
            List<QuotaView> Qvs = new List<QuotaView>();

            DateTime dtstart = new DateTime(year, 1, 1);
            DateTime dtend = new DateTime(year, 12, 31);

          
            
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllQuotasWithinYear(@Predio_ID, @dtstart, @dtend);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Predio_ID", p.ID);
            cmd.Parameters.AddWithValue("@dtstart", dtstart);
            cmd.Parameters.AddWithValue("@dtend", dtend);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Check if it already exists. If not, create one.
                QuotaView search = Qvs.Find(Qv => Qv.Fracao_Id == int.Parse(reader["ID"].ToString()));
                if (search == null)
                {
                    Fracao F = new Fracao();
                    F.ID = int.Parse(reader["ID"].ToString());
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
                    search = new QuotaView("", F.ID, F.Piso, F.Zona, F.Tipo, F.Quota);

                    if (reader["Data_Compra"] != DBNull.Value)
                        search.DateCompra = DateTime.Parse(reader["Data_Compra"].ToString());

                    if (reader["Data_Venda"] != DBNull.Value)
                        search.DateVenda = DateTime.Parse(reader["Data_Venda"].ToString());

                }

                /* Set the month as payed */
                if (DBNull.Value != reader["Mes"])
                {
                    if (DateTime.Parse(reader["Mes"].ToString()).Month == 1)
                    {
                        search.Janeiro = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 2)
                    {
                        search.Fevereiro = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 3)
                    {
                        search.Marco = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 4)
                    {
                        search.Abril = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 5)
                    {
                        search.Maio = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 6)
                    {
                        search.Junho = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 7)
                    {
                        search.Julho = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 8)
                    {
                        search.Agosto = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 9)
                    {
                        search.Setembro = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 10)
                    {
                        search.Outubro = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 11)
                    {
                        search.Novembro = true;
                    }
                    else if (DateTime.Parse(reader["Mes"].ToString()).Month == 12)
                    {
                        search.Dezembro = true;
                    }

                }

                // Set Condomin to fraction if it exists.
                if (reader["Nome"] != DBNull.Value)
                {
                    if (!search.Nome.Contains(reader["Nome"].ToString()))
                        if (search.Nome == "")
                            search.Nome = reader["Nome"].ToString();
                        else
                            search.Nome += "/" + reader["Nome"].ToString();
                }

                if (Qvs.Find(Qv => Qv.Fracao_Id == int.Parse(reader["ID"].ToString())) == null)
                    Qvs.Add(search);
            }
            


            reader.Close();
            Database_Connection.cn.Close();

            return Qvs;
        }
        

    }
}
