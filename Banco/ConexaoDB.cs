using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ConexaoDB
    {
        public static SqlConnection AbrirConexao(){
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BancoLP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            try{
                sqlConn.Open();
                Console.WriteLine("Banco conectado");  
                return sqlConn;

            }catch(SqlException ex){
                Console.WriteLine(ex.Message);  
            }
            return null;
            
        }

        public static void FecharConexao(SqlConnection sqlConn)
        {
            sqlConn.Close();
            Console.WriteLine("Banco desconectado");
        }
    }
}
