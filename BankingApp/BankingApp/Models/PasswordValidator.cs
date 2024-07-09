using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingApp.Models
{   //step 1
    public delegate bool Validate(string password); 
    public class PasswordValidator
    {

        public bool CheckPasswordLength(string password)
        {
            return password.Length > 5;
        }
        public bool CheckPasswordPattern(string password)
        {
            String pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$";

            return Regex.IsMatch(password, pattern);
        }


        public static void TestDelegate()
        {
            
            PasswordValidator passwordValidator = new PasswordValidator();
            //step 2
            Validate validate = new Validate(passwordValidator.CheckPasswordLength);
            validate += new Validate(passwordValidator.CheckPasswordPattern);

            //step3
            foreach (Validate validator in validate.GetInvocationList())
            {
                Console.WriteLine($"{validator.Method.Name}, {validator("Test@123")}");

            }
            Console.ReadKey();

        }
    }
    
}
