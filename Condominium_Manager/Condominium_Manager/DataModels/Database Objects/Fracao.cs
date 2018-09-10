using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Condominium_Manager
{

    [Serializable()]
    public class Fracao
    {
        private int _ID;
        private int _Piso = -1;
        private string _Zona;
        private double _Quota = -1;
        private double _Area = -1;
        private string _Tipo;
        private int _IDPredio;
        private List<Photo> _photos = new List<Photo>();
        private bool condomino_set = false;
        private Condomino _CurrentCondomino;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public int Piso
        {
            get { return _Piso; }
            set
            {
                _Piso = value;
            }
        }

        public string Zona
        {
            get { return _Zona; }
            set { _Zona = value; }
        }

        public double Quota
        {
            get { return _Quota; }
            set
            {
                if (value < 0 && value != -1)
                    throw new ArgumentOutOfRangeException("Quota");
                _Quota = value;
            }
        }

        public double Area
        {
            get { return _Area; }
            set
            {
                if (value < 0 && value != -1)
                    throw new ArgumentOutOfRangeException("Area");
                _Area = value;
            }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public int IDPredio
        {
            get { return _IDPredio; }
            set { _IDPredio = value; }
        }

        public Condomino CurrentCondomino
        {
            get
            {
                if (!condomino_set)
                {
                    condomino_set = true;
                    _CurrentCondomino = getCurrentCondomino();
                }
                return _CurrentCondomino;
            }
            set
            {
                _CurrentCondomino = value;
            }
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
            return _IDPredio + "/" + _Piso + "/" + _Zona;
        }

        public Fracao() : base()
        {
        }

        public Fracao(int Piso, string Zona, double Quota, double Area, string Tipo, int PredioID) : base()
        {
            this.Piso = Piso;
            this.Zona = Zona;
            this.Quota = Quota;
            this.Area = Area;
            this.Tipo = Tipo;
            this.IDPredio = PredioID;

        }

        public Condomino getCurrentCondomino()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getCurrentCondomino(@ID);", Database_Connection.cn);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = cmd.ExecuteReader();

            Condomino C = null;

            while (reader.Read())
            {
                string CC = reader["CC"].ToString();
                string Nome = reader["Nome"].ToString();
                string e_mail = reader["e_mail"].ToString();
                string NIF = reader["NIF"].ToString();
                C = new Condomino(CC, Nome, NIF, e_mail);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return C;
        }

        public static List<Fracao> getFracoesOfCondomino(Condomino c, Predio p)
        {
            List<Fracao> fracoes = new List<Fracao>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getFractionsOfCondomino(@CC, @ID_Predio);", Database_Connection.cn);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", c.CC);
            cmd.Parameters.AddWithValue("@ID_Predio", p.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                Fracao F = new Fracao();

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

                fracoes.Add(F);
            }

            reader.Close();
            Database_Connection.cn.Close();
            return fracoes;
        }

        public List<Compra> getAllCompras()
        {
            List<Compra> Compras = new List<Compra>();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM getAllComprasOfFraction(@ID) ORDER BY DATA_COMPRA;", Database_Connection.cn);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                string CC = reader["CC"].ToString();
                string Nome = reader["Nome"].ToString();
                string e_mail = reader["e_mail"].ToString();
                string NIF = reader["NIF"].ToString();
                int ID = int.Parse(reader["ID"].ToString());
                Condomino c = new Condomino(CC, Nome, NIF, e_mail);
                DateTime compra = DateTime.Parse(reader["Data_Compra"].ToString());
                DateTime venda;
                if(DBNull.Value != reader["Data_venda"])
                {
                    venda = DateTime.Parse(reader["Data_venda"].ToString());
                    Compras.Add(new Compra(ID, this, c, compra, venda));
                }
                else
                    Compras.Add(new Compra(ID, this, c, compra));

            }

            reader.Close();
            Database_Connection.cn.Close();
            return Compras;
        }

        public bool Update()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_updateFracao", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear(); 
            cmd.Parameters.AddWithValue("@Area", Area); 
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio); 
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Piso", Piso);
            
            if (!string.IsNullOrEmpty(Zona))
            {
                cmd.Parameters.AddWithValue("@Zona", Zona);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Zona", null);
            }
            if (Quota != -1)
            {
                cmd.Parameters.AddWithValue("@Quota", Quota);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Quota", null);
            }
            
            try 
            { 
                cmd.ExecuteNonQuery(); 
            } 
            catch (Exception ex) 
            { 
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message); 
            } 
            finally 
            {  
                cn.Close(); 
            }
            delete_all_photos();
            save_photos();

            return true;
        }

        private void delete_all_photos()
        {
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_deletePhotosOfFraction", Database_Connection.cn);
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

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertFracao", cn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@Piso", Piso);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);

            // These attributes can be null 

            if (!string.IsNullOrEmpty(Zona))
            {
                cmd.Parameters.AddWithValue("@Zona", Zona);
            }
            else
                cmd.Parameters.AddWithValue("@Zona", null);

            if (Quota != -1)
            {
                cmd.Parameters.AddWithValue("@Quota", Quota);
            }
            else
                cmd.Parameters.AddWithValue("@Quota", null);


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

            save_photos();
        }

        private void save_photos()
        {


            foreach (Photo p in Photos)
            {
                string path = p.save("Fracao", ID);

                SqlConnection cn = Database_Connection.cn;
                SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_savePhotoOfFracao", cn);
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
            
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_deleteFraction", Database_Connection.cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 
 
            cmd.Parameters.Clear(); 
            cmd.Parameters.AddWithValue("@ID", ID);
 
            try 
            { 
                cmd.ExecuteNonQuery(); 
            } 
            catch (Exception ex) 
            { 
                throw new Exception("Failed to delete contact in database. \n ERROR MESSAGE: \n" + ex.Message); 
            } 
            finally 
            { 
                Database_Connection.cn.Close(); 
            }
            
        }

        public List<string> getImages()
        {
            List<string> p = new List<string>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM getImagesFromFraction(@ID);", Database_Connection.cn);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);

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

        public DateTime getBuyDate()
        {
            DateTime dt = DateTime.MinValue;
            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getCompraDate(@ID_Fracao);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Fracao", ID);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dt = DateTime.Parse(reader["date"].ToString());
            }

            reader.Close();
            Database_Connection.cn.Close();
            return dt;
        }
        

        public DateTime getLastQuota()
        {
            DateTime dt = DateTime.MinValue;
            SqlCommand cmd = new SqlCommand(@" SELECT * FROM getLastQuota(@ID_Fracao); ", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Fracao", ID);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dt = DateTime.Parse(reader["mes"].ToString());
            }
            reader.Close();
            Database_Connection.cn.Close();
            return dt;
        }
        

        public static List<Fracao> get_All_Fractions(int IDPredio)
        { 
            List<Fracao> fractions = new List<Fracao>(); 
             
            SqlCommand cmd = new SqlCommand("SELECT * FROM getAllFractionsFromPredio(@ID_Predio);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            SqlDataReader reader = cmd.ExecuteReader();
             
            while (reader.Read()) 
            { 
                Fracao F = new Fracao(); 
 
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
                
                fractions.Add(F); 
            } 
             
            reader.Close(); 
            Database_Connection.cn.Close(); 
            return fractions;
        }

        public static int count_Fractions_ByType(int IDPredio, string type)
        {
            int co = 0;

            SqlCommand cmd = new SqlCommand("SELECT dbo.countFractionByType(@ID_Predio, @Tipo);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID_Predio", IDPredio);
            cmd.Parameters.AddWithValue("@Tipo", type);

            co = (int)cmd.ExecuteScalar();

            Database_Connection.cn.Close();
            return co;
        }

        public static Fracao getFracaoByID(int ID)
        {

            SqlCommand cmd = new SqlCommand("Select * FROM getFractionByID(@ID);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = cmd.ExecuteReader();
            Fracao F = new Fracao();

            while (reader.Read())
            {
                
                // These values can't be null 
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
                
            }

            reader.Close();
            Database_Connection.cn.Close();
            return F;
        }

        public List<Photo> getImagesPhotos()
        {
            List<Photo> p = new List<Photo>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM getImagesFromFraction(@ID);", Database_Connection.cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string path = reader["Localizacao_ficheiro"].ToString();
                string name = System.IO.Path.GetFileName(path);
                if (new FileInfo(path).Length == 0)
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