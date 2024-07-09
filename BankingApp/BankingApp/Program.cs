// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using BankingApp.Facades;
using BankingApp.Models;
using BankingApp.Repositories;

namespace BankingApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //apply generic
            IRepository<Individual> individualRepository = new Repository<Individual>();
            individualRepository.AddCustomer(new Individual
            {
                AccountNo = new Random().Next(1, 100000),
                Name = new FullName
                {
                    FirstName = "Parameswari",
                    LastName = "Bala",
                    MiddleName = ""
                },
                Email = "Param@gmail.com",
                DOB = new DateTime(1970, 12, 2),
                Gender = Gender.Female,
                PhoneNumber = 123456789,
                AddressList = null
            });

            //corporate
            IRepository<Corporate> corporateRepository = new Repository<Corporate>();
            corporateRepository.AddCustomer(new Corporate
            {
                AccountNo = new Random().Next(1, 100000),
                Name = new FullName
                {
                    FirstName = "Siemens",
                    LastName = "Technologies",
                    MiddleName = ""
                },
                Email = "sample@siemens.com",
                CompanyType = CompanyType.PRIVATE,
                PhoneNumber = 123456789,
                AddressList = null
            });

            //Get Individual Details

            IEnumerator<Individual> individualList = individualRepository
                .GetAllCustomers().GetEnumerator();
            long accountNo = 0;
            while (individualList.MoveNext())
            {
                accountNo = individualList.Current.AccountNo;
                Console.WriteLine(individualList.Current.AccountNo);

            }

            Individual individualObject = individualRepository.GetCustomerById(accountNo);
            Console.WriteLine($"Individual Name{individualObject.Name.FirstName}");

            //Generic Constraint
            //where<T>:class allows only ref type
            //IRepository<int> repository = new Repository<int>();

            //where<T>:struct allows only value type
            IOTPGenerator<int> oTPGenerator = new OTPGenerator<int>();
            Console.WriteLine("Generated OTP is" + oTPGenerator.GenerateOTP(1000, 9999));

            //Where <T>:new()
            //parameterless constructor
            Account<SavingsAccount>.GetAccountInstance();
            //Account<SavingsAccount>.GetAccountInstance();

            //check covariance
            // ITransactionRepository<Transaction> transactionRepository = new TransactionRepository<DirectDebit>();
            // transactionRepository.Message();
            //contravariance
            ITransactionRepository<DirectDebit> transactionRepository1 = new TransactionRepository<Transaction>();
            transactionRepository1.Message();

            //Delegate
            PasswordValidator.TestDelegate();

            //Func Delegate
            Func<Individual, Customer> func = new Func<Individual, Customer>
                (individualRepository.AddCustomer);
            Console.WriteLine($"Customer Account No={func.Invoke(new Individual
            {
                AccountNo = new Random().Next(1, 100000),
                Name = new FullName
                {
                    FirstName = "Vignesh",
                    LastName = "Bala",
                    MiddleName = ""
                },
                Email = "viki@gmail.com",
                DOB = new DateTime(1995, 12, 7),
                Gender = Gender.Male,
                PhoneNumber = 123456799,
                AddressList = null
            }).AccountNo}");

            Action<long> action = new Action<long>(new Transaction().Deposit);
            action.Invoke(new Random().Next());

            Predicate<long> predicate = new Predicate<long>(individualRepository.DeleteCustomer);
            predicate.Invoke(accountNo);

           
            


            //Tuple
            Tuple<Individual, Account<SavingsAccount>, Transaction> tuple = new 
                Tuple<Individual, Account<SavingsAccount>, 
                Transaction>(individualObject,new Account<SavingsAccount>
                {
                    OpeningDate=new DateOnly(2024,1,1),
                    RunningTotal=new Random().Next()

                }, new Transaction
                {
                 Amount=new Random().Next(),
                 Sender="Parameswari"
                });
            //tuple.Item1.AccountNo,


            //Event Handling

            Transaction transactionObj = new Transaction();
            //Event should be associated to some method;
            transactionObj.MoneyDepositedEvent += transactionObj.Deposit;
            transactionObj.RaiseEvent(50000);



            Console.ReadKey();

        }
    }


}
