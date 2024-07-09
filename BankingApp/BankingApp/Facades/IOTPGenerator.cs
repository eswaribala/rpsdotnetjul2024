using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Facades
{
    public interface IOTPGenerator<T> where T : struct
    {
        public int GenerateOTP(T min, T max);
    }
}
