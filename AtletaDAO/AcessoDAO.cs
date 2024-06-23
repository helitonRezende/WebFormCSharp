using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AtletaDAO
{
    public class AcessoDAO
    {
        public class AcessoDB
        {
            // Conecta Banco //
            private static SqlConnection GetDbConnection()
            {
                // String no WebConfig //
                string conString = ConfigurationManager.ConnectionStrings["conexaoSQLServer"].ConnectionString;
                // Conecta //
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                return connection;
            }
            // Execução //
            public static void ExecuteNonQuery(string sql)
            {
                int i = -1;
                using (SqlConnection connection = GetDbConnection())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            // Pesquisa //
            public static DataTable GetDataTable(string sql)
            {
                using (SqlConnection connection = GetDbConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        connection.Close();
                        return table;
                    }
                }
            }
        }

    }
}