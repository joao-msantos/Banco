using Banco.Models;

namespace Banco
{
    internal class ConsultarContaDB : Conta
    {
        private object sqlConn;
        private int num;

        public ConsultarContaDB(object sqlConn, int num)
        {
            this.sqlConn = sqlConn;
            this.num = num;
        }
    }
}