using Condominium_Manager.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Compra
    {
        public int ID;
        public Fracao f;
        public Condomino c { get; set; }
        public DateTime _Data_Compra { get; set; }
        public DateTime _Data_Venda { get; set; }

        public string Data_Compra
        {
            get
            {
                return _Data_Compra.ToString("dd/MM/yy");
            }
        }

        public string Data_Venda
        {
            get
            {
                return _Data_Venda.ToString("dd/MM/yy");
            }
        }

        public Compra(int ID, Fracao f, Condomino c, DateTime Data_Compra)
        {
            this.ID = ID;
            this.f = f;
            this.c = c;
            this._Data_Compra = Data_Compra;
            this._Data_Venda = DateTime.MaxValue;
        }

        public Compra(Fracao f, Condomino c, DateTime Data_Compra)
        {
            this.f = f;
            this.c = c;
            this._Data_Compra = Data_Compra;
            this._Data_Venda = DateTime.MaxValue;
        }

        public Compra(int ID, Fracao f, Condomino c, DateTime Data_Compra, DateTime Data_Venda)
        {
            this.ID = ID;
            this.f = f;
            this.c = c;
            this._Data_Compra = Data_Compra;
            this._Data_Venda = Data_Venda;
        }

        public Compra(Fracao f, Condomino c, DateTime Data_Compra, DateTime Data_Venda)
        {
            this.f = f;
            this.c = c;
            this._Data_Compra = Data_Compra;
            this._Data_Venda = Data_Venda;
        }

        public void save()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_insertCompra", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Fracao", f.ID);
            cmd.Parameters.AddWithValue("@CC_Condomino", c.CC);
            cmd.Parameters.AddWithValue("@Data_Compra", _Data_Compra);

            if (_Data_Venda != DateTime.MaxValue)
            {
                cmd.Parameters.AddWithValue("@Data_Venda", _Data_Venda);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Data_Venda", null);
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

        public void update()
        {
            SqlConnection cn = Database_Connection.cn;
            SqlCommand cmd = new SqlCommand("CONDOMINIUM.p_updateCompra", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Data_compra", _Data_Compra);
            cmd.Parameters.AddWithValue("@Data_venda", _Data_Venda);
            cmd.Parameters.AddWithValue("@ID_Fracao", f.ID);
            cmd.Parameters.AddWithValue("@CC", c.CC);
            cmd.Parameters.AddWithValue("@ID", ID);
            

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

            return;
        }
    }
}
