using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Individual:Customer
    {
        public Gender Gender {  get; set; } 
        public DateTime? DOB { get; set; }  
    }
}
