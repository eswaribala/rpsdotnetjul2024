using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Repositories
{
    internal class TransactionRepository<T> : ITransactionRepository<T>
    {
        public void Message()
        {
            Console.WriteLine($"Transaction Type {typeof(T).Name}");
        }
    }
}
