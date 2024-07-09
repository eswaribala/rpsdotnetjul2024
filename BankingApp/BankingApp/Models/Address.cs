using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace BankingApp.Models
{
    public class Address
    {
        public long AddressId {  get; set; }
        public string DoorNo { get; set; }
        public string StreetName {  get; set; }
        public string City { get; set; }

        public Customer Customer { get; set; }

    }
}
