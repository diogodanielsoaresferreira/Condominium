using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Condominium_Manager
{
    public class Evento
    {

        public Evento(int id_predio, DateTime data, string titulo, string Descricao="", int id=0)
        {
            this.id = id;
            this.id_predio = id_predio;
            this.data = data;
            this.titulo = titulo;
            if (descricao != "")
                this.descricao = Descricao;
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("id");
                _id = value;
            }
        }

        public string titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if(value==null || value== ""){
                    throw new ArgumentOutOfRangeException("titulo");
                }
                _titulo = value;
            }
        }

        public string descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                _descricao = value;
            }
        }

        public string dataString { get { return data.ToString("dd/MM/yy"); } }

        public DateTime data
        {
            get
            {
                return _data;
            }
            set
            {
                if (data==null)
                    throw new ArgumentOutOfRangeException("data");
                _data = value;
            }
        }
        public int id_predio
        {
            get
            {
                return _id_predio;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("id_predio");
                _id_predio = value;
            }
        }

        private int _id { get; set; }
        private string _titulo { get; set; }
        private string _descricao { get; set; }
        private DateTime _data { get; set; }
        private int _id_predio { get; set; }

        public static List<Evento> get_Next_Events(int IDPredio)
        {
            List<Evento> eventos = new List<Evento>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getNextEvents(@ID_Predio) ORDER BY Data;", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                int lid = int.Parse(reader["ID"].ToString());
                DateTime ldata = DateTime.Parse(reader["Data"].ToString());
                string ltitulo = reader["Titulo"].ToString();
                eventos.Add(new Evento(IDPredio, ldata, ltitulo, id:lid));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return eventos;
        }

        public static List<Evento> get_Day_Events(int IDPredio, DateTime day)
        {
            List<Evento> eventos = new List<Evento>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getDayEvents(@ID_Predio, @Date) ORDER BY Data;", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@Date", day.Date);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int lid = int.Parse(reader["ID"].ToString());
                DateTime ldata = DateTime.Parse(reader["Data"].ToString());
                string ltitulo = reader["Titulo"].ToString();
                eventos.Add(new Evento(IDPredio, ldata, ltitulo, id:lid));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return eventos;
        }

    }
}
