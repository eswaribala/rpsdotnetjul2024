using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo.Models
{
    public static class NumToWord
    {
        public static string ConvertToText(this int num)
        {
            string result = "";

            switch (num)
            {
                case 0:

                    result = "ZERO";
                    break;
                case 1:

                    result = "ONE";
                    break;
                case 2:

                    result = "TWO";
                    break;
                case 3:

                    result = "THREE";
                    break;
                case 4:

                    result = "FOUR";
                    break;
                case 5:

                    result = "FIVE";
                    break;
                case 6:

                    result = "SIX";
                    break;
                case 7:

                    result = "SEVEN";
                    break;

                case 8:

                    result = "EIGHT";
                    break;
                case 9:

                    result = "NINE";
                    break;

            }
            return result;

        }


    }
}
