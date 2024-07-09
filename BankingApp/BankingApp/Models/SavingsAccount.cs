using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class SavingsAccount
    {
        public SavingsAccount() { }
        public SavingsAccount(float ir)
        {
            this.InterestRate = ir; 
        }

        public float InterestRate {  get; set; }

    }
}
