using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LambdaDemo.Models
{
    public class Customer
    {

        public long AccountNo { get; set; }
        public FullName Name { get; set; }

        public string Email {  get; set; }  
        public string Password { get; set; }
        public long PhoneNumber { get; set; }

        public IEnumerable<Address> AddressList { get; set;}


    }
}
