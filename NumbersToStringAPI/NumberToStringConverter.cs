using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumbersToStringAPI
{
    public static class NumberToStringConverter
    {
        /*
        private static string Convert(string input_str)
        {

            input_str = input_str.Replace(',', '.');

            double number = -1;

            if (double.TryParse(input_str, out number))
                return Convert(number);
            else
                return "Error";
        }
        */

        public static string Convert(double inputNumber)
        {
            if (inputNumber < 0 || inputNumber > 999999.99)
                return "ERROR: number outside scope";
            else
                return Process(inputNumber);
        }


        /* EDGE-Cases 0.[xy] [x].00, [x].0
         * EDGE-Cases 1.[xy] [x].01,
         * Hundred and Thousand sometimes need "AND"
         * REMEMBER: Edgecases 00000.01
         * Edgecase: more than 1 delimiter (Not solved)
         */

        private static string Process(double number_original)
        {
            //if you multiply with 100 you risk a floating point error (ex. 2.05 = 204.9999997)
            //if you multiply with 10 twice, it negates the risk because of the intermidiate step.
            double number = number_original * 10 * 10;

            int m = 1;
            int size = 8;
            int firstNumberIndex = 9;
            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = (int)(number / (1 * Math.Pow(10, size - i - m)));
                if (numbers[i] != 0 && firstNumberIndex == 9)
                    firstNumberIndex = i;
                number = number % (1 * Math.Pow(10, size - i - m));
            }

            // 0,1,2 and 3,4,5 and 6,7 are together
            // 1,4,6 needs the ten check

            string output = "";

            if (firstNumberIndex < 3)
                output += Pro(new int[] { numbers[0], numbers[1], numbers[2] }) + "THOUSAND ";

            if (number_original < 2.00 && number_original > 0.99)
                output += "ONE DOLLAR AND ";
            else if (number_original < 1.00)
                output += "ZERO DOLLARS AND ";
            else
                output += Pro(new int[] { numbers[3], numbers[4], numbers[5] }) + "DOLLARS AND ";

            if (numbers[6] == 0 && numbers[7] == 0)
                output += "ZERO CENTS";
            else if (numbers[6] == 0 && numbers[7] == 1)
                output += "ONE CENT";
            else
                output += Pro(new int[] { 0, numbers[6], numbers[7] }) + "CENTS";

            return output;
        }

        private static string Pro(int[] ns)
        {
            if (ns.Length != 3)
                return "Error";

            string output = "";
            if (ns[0] != 0)
            {
                output += ConvertNumberToText(ns[0], false) + "HUNDRED ";
                if (ns[1] == 0 && ns[2] == 0)
                    return output;
                else
                    output += "AND ";
            }
            if (ns[1] == 1)
                output += ConvertNumberToText(ns[1] * 10 + ns[2], true);
            else
            {
                if (ns[1] != 0)
                    output += ConvertNumberToText(ns[1], true);
                if (ns[2] != 0)
                    output += ConvertNumberToText(ns[2], false);
            }
            return output;
        }

        private static string ConvertNumberToText(int number, bool isTens)
        {
            if (isTens)
            {
                switch (number)
                {
                    case 1:
                        return "TEN ";
                    case 2:
                        return "TWENTY ";
                    case 3:
                        return "THIRTY ";
                    case 4:
                        return "FOURTY ";
                    case 5:
                        return "FIFTY ";
                    case 6:
                        return "SIXTY ";
                    case 7:
                        return "SEVENTY ";
                    case 8:
                        return "EIGHTY ";
                    case 9:
                        return "NINETY ";
                    case 10:
                        return "TEN ";
                    case 11:
                        return "ELEVEN ";
                    case 12:
                        return "TWELVE ";
                    case 13:
                        return "THIRTEEN ";
                    case 14:
                        return "FOURTEEN ";
                    case 15:
                        return "FIFTEEN ";
                    case 16:
                        return "SIXTEEN ";
                    case 17:
                        return "SEVENTEEN ";
                    case 18:
                        return "EIGHTEEN ";
                    case 19:
                        return "NINETEEN ";

                    default:
                        return "";
                }
            }
            else
            {
                switch (number)
                {
                    //case 0:
                    //return "ZERO";
                    case 1:
                        return "ONE ";
                    case 2:
                        return "TWO ";
                    case 3:
                        return "THREE ";
                    case 4:
                        return "FOUR ";
                    case 5:
                        return "FIVE ";
                    case 6:
                        return "SIX ";
                    case 7:
                        return "SEVEN ";
                    case 8:
                        return "EIGHT ";
                    case 9:
                        return "NINE ";

                    default:
                        return "";
                }
            }
        }
    }
}
