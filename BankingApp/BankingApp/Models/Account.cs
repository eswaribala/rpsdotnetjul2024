using BankingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Account<T> where T : new()
    {
        public static int Count;
        public long RunningTotal {  get; set; }
        public DateOnly OpeningDate { get; set; }

        public static T GetAccountInstance()
        {
            Count++;
            if (Count == 1)
                return new T();
            else
                throw new SingletonException("Cannot create more than one object");
        }
    }
}
