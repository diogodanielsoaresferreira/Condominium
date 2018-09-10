using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Condominium_Manager.DataModels
{
    class Database_Connection
    {
        private static SqlConnection _cn;
        public static SqlConnection cn {
            get
            {
                try
                {

                if (_cn == null)
                    _cn = new SqlConnection("Server=tcp:193.136.175.33\\SQLSERVER2012,8293;Database=p1g1;User Id=p1g1; Password = database; ");
                if (_cn.State != ConnectionState.Open)
                    _cn.Open();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Não foi possível ligar-se ao servidor com a base de dados.");
                    System.Environment.Exit(1);
                }
                return _cn;
            }
        }

        public Database_Connection()
        {

        }
        
    }
}
