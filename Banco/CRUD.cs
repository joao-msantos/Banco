using Banco.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Banco.Utils;
using static Banco.CRUD_DB;

namespace Banco {
    public class CRUD {
        public static void IncluirConta(SqlConnection sqlConn) {

            string nome = EntrarNome();
            double saldo = EntrarRealPositivo("Entre com o saldo: ");
            IncluirContaDB(sqlConn, nome, saldo);
        }

        public static void AlterarConta(SqlConnection sqlConn)
        {

            int num = EntrarConta();
            Conta conta = ConsultarContaDB(sqlConn, num);
            if (conta == null)
            {
                Console.WriteLine("Erro: conta não existe");
                return;
            }
            AlterarSaldo(conta);
            AlterarContaDB(sqlConn, conta);
        }

        public static void ExcluirConta(SqlConnection sqlConn) {

            int num = EntrarConta();
            Conta conta = ConsultarContaDB(sqlConn, num);

            if (conta == null) {
                Console.WriteLine("Erro: conta não existe");
                return;
            }
            if (conta.Saldo != 0) {
                Console.WriteLine("Erro: saldo diferente de zero");
                return;
            }

            ExcluirContasDB(sqlConn, conta);
        }
        public static void ExibirConta(SqlConnection sqlConn) {

            int num = EntrarConta();
            Conta conta = ConsultarContaDB(sqlConn, num);
            if(conta != null)
            {
                Console.WriteLine(conta);
            } else
            {
                Console.WriteLine("Erro: Conta não encontrada.");
            }
        }
        public static void ExibirContas(SqlConnection sqlConn)
        {
            List<Conta> contas = ConsultarContasDB(sqlConn);
            if (contas == null) 
            {
                Console.WriteLine("Banco vazio");
                return;
            }
            foreach(var conta in contas) {
                Console.WriteLine(conta);
            }
        }
    }
}
