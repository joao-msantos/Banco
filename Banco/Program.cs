using Banco.Models;
using static Banco.CRUD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Banco.ConexaoDB;


namespace Banco {
    public class Program {
        public static void Main(string[] args) {

            SqlConnection sqlConn = AbrirConexao();

            if(sqlConn == null)
            {
                Console.WriteLine("Erro conexão com o banco.");
                return;
            }
            ExibirContas(sqlConn);
            ExcluirConta(sqlConn);
            ExibirContas(sqlConn);
            FecharConexao(sqlConn);
        }
    }
}