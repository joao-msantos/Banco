using Banco.Models;
using static Banco.CRUD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Banco.ConexaoDB;
using static Banco.CRUD;

namespace Banco {
    public class Program {
        public static void Main(string[] args) {

            SqlConnection sqlConn = AbrirConexao();

            if(sqlConn == null)
            {
                Console.WriteLine("Erro conexão com o banco.");
                return;
            }

            ExibirConta(sqlConn);
            FecharConexao(sqlConn);
        }
    }
}