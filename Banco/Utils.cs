using Banco.Models;
using System;
using System.Collections.Generic;

namespace Banco {
    public static class Utils {

        public static int EntrarConta() {
            int num = 0;
            bool ok = false;

            do {
                try {
                    num = EntrarInteiro("Entre com o número da conta: ");
                    if (num > 0) {
                        ok = true;
                    }
                    else {
                        Console.WriteLine("Erro: número de conta inválido");
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: número inválaido");
                }
            } while (!ok);
            return num;
        }

        public static int EntrarInteiro(string msg) {
            int num = 0;
            bool ok = false;

            do {
                try {
                    Console.Write(msg);
                    num = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: número inválido");
                }
            } while (!ok);
            return num;
        }

        public static string EntrarNome() {
            string nome = "";
            string[] campos;
            bool ok = false;

            do {
                Console.Write("Entre com o nome: ");
                nome = Console.ReadLine();
                campos = nome.Split(' ');
                if (campos.Length < 2) {
                    Console.WriteLine("Erro: nome inválido");
                }
                else {
                    ok = true;
                }

            } while (!ok);
            return nome;
        }

        public static double EntrarReal(string msg) {
            double num = 0;
            bool ok = false;

            do {
                try {
                    Console.Write(msg);
                    num = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException) {
                    Console.WriteLine("Erro: número inválido");
                }
            } while (!ok);
            return num;
        }

        public static double EntrarRealPositivo(string msg) {
            double saldo = 0;
            bool ok = false;

            do {
                saldo = EntrarReal(msg);
                if (saldo < 0) {
                    Console.WriteLine("Erro: saldo inválido");
                }
                else {
                    ok = true;
                }
            } while (!ok);
            return saldo;
        }

        public static int PesquisarConta(List<Conta> contas, int num) {
            int achou = -1;

            for (int i = 0; i < contas.Count; i++) {
                if (contas[i].Id == num) {
                    achou = i;
                    break;
                }
            }
            return achou;
        }

        public static int EntrarOperacao(string msg) {
            bool ok = false;
            int oper;
            
            do {
                oper = EntrarInteiro(msg);
                if ((oper != 1) && (oper != 2)) {
                    Console.WriteLine("Erro: operação inválida");
                }
                else {
                    ok = true;
                }
            } while (!ok);
            return oper;
        }
        public static void AlterarSaldo(Conta conta) {

            int oper = EntrarOperacao("Digite [1]-Crédito ou [2]-Débito: ");
            double valor = EntrarRealPositivo("Entre com o valor: ");
            if (oper == 1) {
                conta.Saldo += valor;
            }
            else {
                conta.Saldo -= valor;
            }
        }
    }
}