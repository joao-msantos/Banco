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
        public static void IncluirContaDB(SqlConnection sqlConn, string nome, double saldo)
        {
            string sql = "INSERT INTO contas (nome, saldo) VALUES (@nome @saldo)";
            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.Add(new SqlParameter("@nome", nome));
            cmd.Parameters.Add(new SqlParameter("@saldo", nome));
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Conta inserida");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
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

        public static void AlterarContaDB(SqlConnection sqlConn, Conta conta)
        {
            string sql = "UPDATE contas SET saldo = @saldo WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.Add(new SqlParameter("@id", conta.Id));
            cmd.Parameters.Add(new SqlParameter("@saldo", conta.Saldo));

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Conta alterada");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExcluirContasDB(SqlConnection sqlConn, Conta conta)
        {
            string sql = "DELETE FROM contas WHERE id = @id";

            SqlCommand cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.Add(new SqlParameter("@id", conta.Id));

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Conta Excluída");
            }   
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<Conta> ConsultarContasDB(SqlConnection sqlConn)
        {
            string slq = "SELECT * FROM contas";
            SqlCommand cmd = new SqlCommand(slq, sqlConn);
            List<Conta> contas = new List<Conta>();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr["id"].ToString());
                    string nome = dr["nome"].ToString();
                    double saldo = double.Parse(dr["saldo"].ToString());
                    contas.Add(new Conta(id, nome, saldo));
                }
                dr.Close();
            }


            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return contas;
        }
    }
}
