using BankingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
#nullable disable
namespace BankingApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public List<T> CustomerList { get; set; }

        public Repository() { 
          this.CustomerList = new List<T>();    
        }
        public T AddCustomer(T customer)
        {
            
            CustomerList.Add(customer);
            return customer;
            
        }

        public bool DeleteCustomer(long accountNo)
        {
            bool status = false;
            var name = typeof(T).Name;
            Console.WriteLine(name);
            T obj = null;
            if (name == "Individual")
            {

                obj = CustomerList.OfType<Individual>().FirstOrDefault(x => x.AccountNo == accountNo) as T;
               
            }
            else
            {
                obj= CustomerList.OfType<Corporate>().FirstOrDefault(x => x.AccountNo == accountNo) as T;
            }
            CustomerList.Remove(obj);
            status = true;
            return status;
        }

        public IEnumerable<T> GetAllCustomers()
        {
            return CustomerList;
        }

        public T GetCustomerById(long accountNo)
        {
            var name = typeof(T).Name;
            Console.WriteLine(name);
            if (name == "Individual") {

             return CustomerList.OfType<Individual>()
                    .FirstOrDefault(x => x.AccountNo == accountNo) as T;
            
            } else
            {
                return CustomerList.OfType<Corporate>().
                    FirstOrDefault(x => x.AccountNo == accountNo) as T;
            }
           

        }

        public T UpdateCustomer(string email, long accountNo)
        {
            throw new NotImplementedException();
        }
    }
}
