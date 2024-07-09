using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace BankingApp.Models
{
    //step1
    public delegate void MoneyDeposited(long depositedAmount);
    public class Transaction
    {
        //step2
        public event MoneyDeposited MoneyDepositedEvent;
        public long Amount { get; set; }
        protected DateTime TimeStamp { get; set; }  
        public string Sender { get; set; }
        protected string Receiver { get; set; }

        //step4 raise event
        public void RaiseEvent(long amount)
        {
            //raise the event
            MoneyDepositedEvent(amount);
        }
        //step3 invocation method
        public void Deposit(long amount)
        {
            Amount = amount;
            
            Console.WriteLine($"Amount Deposited...{this.Amount}");
        }
    }
}
