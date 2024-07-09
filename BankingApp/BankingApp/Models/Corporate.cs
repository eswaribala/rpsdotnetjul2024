using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Corporate:Customer
    {
        public CompanyType CompanyType { get; set; }
    }
}
