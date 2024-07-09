using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Facades
{
    internal class OTPGenerator<T> : IOTPGenerator<T> where T : struct
    {
        public int GenerateOTP(T min, T max)
        {
            return new Random().Next(Convert.ToInt32(min), 
                Convert.ToInt32(max));
        }
    }
}
