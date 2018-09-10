using Condominium_Manager.DataModels;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media;

namespace Condominium_Manager
{

    [Serializable()]
    public class Predio
    {
        private int _ID;
        private string _Nome;
        private string _Morada;
        private string _Cidade;
        private string _Codigo_Postal;
        private double _Latitude;
        private double _Longitude;
        private double _Area;
        private List<Photo> _photos = new List<Photo>();

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public string Nome
        {
            get { return _Nome; }
            set
            {
                if (value == null | string.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome do prédio não pode ser vazio");
                }
                _Nome = value;
            }
        }

        public string Morada
        {
            get { return _Morada; }
            set { _Morada = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string Codigo_Postal
        {
            get { return _Codigo_Postal; }
            set {
                if (value.Length != 8)
                    throw new ArgumentOutOfRangeException("Codigo_Postal");
                _Codigo_Postal = value;
            }
        }

        public double Latitude
        {
            get { return _Latitude; }
            set {
                if (value < -90 || value > 90)
                    throw new ArgumentOutOfRangeException("Latitude");
                _Latitude = value;
            }
        }

        public double Longitude
        {
            get { return _Longitude; }
            set {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException("Longitude");
                _Longitude = value;
            }
        }

        public double Area
        {
            get { return _Area; }
            set {
                if(value<0 && value!=-1)
                    throw new ArgumentOutOfRangeException("Area");
                _Area = value;
            }
        }

        public Location Location
        {
            get { return new Location(Latitude, Longitude); }
        }

        public List<Photo> Photos
        {
            get
            {
                return _photos;
            }
            set
            {
                _photos = value;
            }
        }

        public override string ToString()
        {
            return _Nome;
        }

        public Predio() : base()
        {
        }

        public Predio(string Nome, double Latitude, double Longitude, string Morada="", string Cidade="", string Codigo_Postal="",  double Area=-1) : base()
        {
            this.Nome = Nome;

            this.Latitude = Latitude;
            this.Longitude = Longitude;

            if (!string.IsNullOrEmpty(Morada))
                this.Morada = Morada;

            if (!string.IsNullOrEmpty(Cidade))
                this.Cidade = Cidade;

            if (!string.IsNullOrEmpty(Codigo_Postal))
                this.Codigo_Postal = Codigo_Postal;
           
            this.Area = Area;
            
        }

        public Predio(string Nome) : base()
        {
            this.Nome = Nome;
        }
        
        public bool Update()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_updatePredio", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Latitude", Latitude);
            cmd.Parameters.AddWithValue("@Longitude", Longitude);
            cmd.Parameters.AddWithValue("@ID", ID);

            // These attributes can be null
            if (!string.IsNullOrEmpty(Morada))
            {
                cmd.Parameters.AddWithValue("@Morada", Morada);
            }
            else
                cmd.Parameters.AddWithValue("@Morada", null);

            if (!string.IsNullOrEmpty(Cidade))
            {
                cmd.Parameters.AddWithValue("@Cidade", Cidade);
            }
            else
                cmd.Parameters.AddWithValue("@Cidade", null);

            if (!string.IsNullOrEmpty(Codigo_Postal))
            {
                cmd.Parameters.AddWithValue("@Codigo_Postal", Codigo_Postal);
            }
            else
                cmd.Parameters.AddWithValue("@Codigo_Postal", null);

            if (Area != -1)
            {
                cmd.Parameters.AddWithValue("@Area", Area);
            }
            else
                cmd.Parameters.AddWithValue("@Area", null);
            

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to connect to database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            delete_all_photos();
            save_photos();

            return true;
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertPredio", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Latitude", Latitude);
            cmd.Parameters.AddWithValue("@Longitude", Longitude);

            // These attributes can be null
            if (!string.IsNullOrEmpty(Morada)) {
                cmd.Parameters.AddWithValue("@Morada", Morada);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Morada", null);
            }
            if (!string.IsNullOrEmpty(Cidade))
            {
                cmd.Parameters.AddWithValue("@Cidade", Cidade);
            }
            else
                cmd.Parameters.AddWithValue("@Cidade", null);
            if (string.IsNullOrEmpty(Codigo_Postal))
            {
                cmd.Parameters.AddWithValue("@Codigo_Postal", Codigo_Postal);
            }
            else
                cmd.Parameters.AddWithValue("@Codigo_Postal", null);
            if (Area != -1)
            {
                cmd.Parameters.AddWithValue("@Area", Area);
            }
            else
                cmd.Parameters.AddWithValue("@Area", null);

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

            // Save all photos from the building
            save_photos();
        }

        private void delete_all_photos()
        {
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_deletePhotosPredio", Database_Connection.cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Connection = Database_Connection.cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to connect to database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                Database_Connection.cn.Close();
            }
        }

        private void save_photos()
        {
            
            foreach (Photo p in Photos)
            {
                string path = p.save("Predio", ID);

                SqlConnection cn = Database_Connection.cn;
                SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertPhotosPredio", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Localizacao_Ficheiro", path);
                
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to connect to database. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            
        }

        public void Delete()
        {

            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_deletePredio", Database_Connection.cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to connect to database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                Database_Connection.cn.Close();
            }
        }

        public static List<Predio> get_All_Buildings()
        {
            List<Predio> p = new List<Predio>();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM getAllBuildings();", Database_Connection.cn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Predio P = new Predio();

                // These four values can't be null
                P.ID = Int32.Parse(reader["ID"].ToString());
                P.Nome = reader["Nome"].ToString();
                P.Latitude = double.Parse(reader["Latitude"].ToString());
                P.Longitude = double.Parse(reader["Longitude"].ToString());

                // These four attributes can be null
                if(reader["Morada"] != DBNull.Value)
                    P.Morada = reader["Morada"].ToString();
                if (reader["Area"] != DBNull.Value)
                    P.Area = double.Parse(reader["Area"].ToString());
                if (reader["Cidade"] != DBNull.Value)
                    P.Cidade = reader["Cidade"].ToString();
                if (reader["Codigo_Postal"] != DBNull.Value)
                    P.Codigo_Postal = reader["Codigo_Postal"].ToString();

                p.Add(P);
            }
            
            reader.Close();
            Database_Connection.cn.Close();
            return p;
        }
        
        public List<string> getImages()
        {
            List<string> p = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM getImagesFromPredio(@ID_PREDIO);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_PREDIO", ID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string path = reader["Localizacao_ficheiro"].ToString();
                
                p.Add(path);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return p;
        }

        public List<Photo> getImagesPhotos()
        {
            List<Photo> p = new List<Photo>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM getImagesFromPredio(@ID_PREDIO);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_PREDIO", ID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string path = reader["Localizacao_ficheiro"].ToString();
                string name = System.IO.Path.GetFileName(path);
                if (new FileInfo(path).Length==0)
                    p.Add(new Photo(name, 0, path));
                else
                    p.Add(new Photo(name, new FileInfo(path).Length / 100, path));
            }

            reader.Close();
            Database_Connection.cn.Close();
            return p;
        }

    }
}

