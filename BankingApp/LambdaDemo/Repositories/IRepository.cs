using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo.Repositories
{
    public interface IRepository<T> where T : class
    {
        T AddCustomer(T customer);
        T GetCustomerById(long accountNo);
        IEnumerable<T> GetAllCustomers();

        T UpdateCustomer(string email, long accountNo);

        bool DeleteCustomer(long  accountNo);
            

    }
}
