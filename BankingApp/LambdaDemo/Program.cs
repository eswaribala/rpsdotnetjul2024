// See https://aka.ms/new-console-template for more information

using LambdaDemo.Models;
using LambdaDemo.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;

namespace LambdaDemo
{
    public delegate bool CheckPasswordLength(string password);
    public delegate bool CheckPasswordPattern(string password);
    class Program
    {
        public static void Main(string[] args)
        {
            Individual individual = new Individual
            {
                AccountNo = new Random().Next(1, 10000),
                Name = new FullName
                {
                    FirstName = "Parameswari",
                    LastName = "Bala",
                    MiddleName = ""
                },
                Email = "Param@gmail.com",
                Password = "Test@123",
                Gender = Gender.Female,
                AddressList = null,
                DOB = null
            };
            IRepository<Individual> repository = new Repository<Individual>();
            Func<Individual, Customer> func = (obj) =>
            {
                return repository.AddCustomer(obj);
            };
            long accountNo = func.Invoke(individual).AccountNo;
           Console.WriteLine( $"Generated Account No={func.Invoke(individual).AccountNo}");
            //zero arguments
            Func<long> genData = ()=>new Random().NextInt64(0,100000);
            Console.WriteLine($"Generated Data={genData.Invoke()}");
            //implicit type
            var data = () => repository.GetCustomerById(accountNo);
            Console.WriteLine($"Result={data}");
           

            IRepository<Customer> repositoryInstance = new Repository<Customer>();
            //explicit param type
            Func<Customer,Customer> funcExplicit = (Customer obj) =>
            {
                return repositoryInstance.AddCustomer(obj);
            };
            funcExplicit.Invoke(individual);

            //lambda with default value
            var genResult = (int minValue = 0, int maxValue = 10000) =>
            new Random().Next(minValue, maxValue);
            genResult(5000, 5000000);
            genResult();

            //capture outer variables

            float roi = 0.07f;

            Func<int,int,float> interestCal=(p,m)=>p+(p*m*roi);

            Console.WriteLine($"Cumulative Value={interestCal(10000, 12)}");
            roi = 0.08f;
            Console.WriteLine($"Cumulative Value={interestCal(10000, 12)}");

            //instantiate existing delegate
            CheckPasswordLength checkPasswordLength = new 
                CheckPasswordLength(CheckPwdLength);
            checkPasswordLength("Test@123");

            //anonymous delegate with Lambda
            String pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$";
            /*
            CheckPasswordPattern checkPasswordPattern = delegate (string password)
            {
                return Regex.IsMatch(password, pattern);
            };
            */
            CheckPasswordPattern checkPasswordPattern = (password) =>
            {
                return Regex.IsMatch(password, pattern);
            };
            checkPasswordPattern("Test@123");


            //Extension Method
            int amount = new Random().Next(100,10000);
            
            IList<string> text = new List<string>();
            int quo, rem = 0;
            Console.WriteLine($"Amount={amount}");
            while (amount > 0)
            {
                quo = amount / 10;
                rem = amount % 10;
                text.Add(rem.ConvertToText());
                amount = quo;
            }
            
            foreach (string x in text)
                Console.Write($"{x}");
            

            Console.ReadKey();  
        }

        public static bool CheckPwdLength(string password)
        {
            return password.Length < 8;
        }

    }
}