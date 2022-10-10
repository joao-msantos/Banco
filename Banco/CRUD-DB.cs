using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Banco.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class CRUD_DB
    {
        public static Conta ConsultarContaDB(SqlConnection sqlConn, int num)
        {
            string slq = "SELECT * FROM contas WHERE id = @id";
            SqlCommand cmd = new SqlCommand(slq, sqlConn);
            cmd.Parameters.Add(new SqlParameter("@id", num));
            Conta conta = null;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int id = int.Parse(dr["id"].ToString());
                    string nome = dr["nome"].ToString();
                    double saldo = double.Parse(dr["saldo"].ToString());
                    
                    conta = new Conta(id, nome, saldo);
                }
                dr.Close();
            }


            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);  
            }
            
            return conta;
        }
    }
}
