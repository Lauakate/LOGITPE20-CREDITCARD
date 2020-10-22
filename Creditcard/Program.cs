using System;

namespace Creditcard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your ID code:");
            string UserID = Console.ReadLine();

            if (ValidateIK(UserID))
            {

                if (GetAge(UserID))
                {
                    Console.WriteLine("Enter your credit card number:");
                    string CreditCard = Console.ReadLine();

                    if (Validate(CreditCard))
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect credit card format");
                    }

                    Console.WriteLine("Enter your CVV code:");
                    string CVV = Console.ReadLine();

                    if (ValidateCVV(CVV))
                    {
                        if (ValidateCVV(CVV))
                        {
                            Console.WriteLine("Correct CVV format");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect CVV format");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong format");
            }
        }
        public static bool ValidateIK(string idCode)
        {
            if (idCode.Length == 11)
            {
                try
                {
                    long.Parse(idCode);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public static bool GetAge(string idCode)
        {
            int FirstNum = Int32.Parse(idCode[0].ToString());

            int YearOfBirth = GetYear(idCode);

            DateTime now = DateTime.Now;
            int YearNow = Int32.Parse(now.Year.ToString());
            int Age = YearNow - YearOfBirth;

            if (Age <= 18)
            {
                Console.WriteLine("You are not authorized to use a credit card yet");
                return false;
            }
            else if (Age >= 18 && FirstNum == 1 || FirstNum == 3 || FirstNum == 5)
            {
                Console.WriteLine("Hello, Sir");

                return true;
            }
            else if (Age >= 18 && FirstNum == 2 || FirstNum == 4 || FirstNum == 6)
            {
                Console.WriteLine("Hello, Madam");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetYear(string idCode)
        {

            string YearFromCode = idCode.Substring(1, 2);
            string Year;

            if (int.Parse(idCode[0].ToString()) > 4)
            {
                Year = "20" + YearFromCode;
            }
            else
            {
                Year = "19" + YearFromCode;
            }

            int YearParsed = Int32.Parse(Year);

            return YearParsed;
        }
        public static bool Validate(string CCVali)
        {


            if (CCVali.Length == 16)
            {
                try
                {
                    long.Parse(CCVali);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }

            }
            else
            {
                return false;
            }



        }
        public static bool ValidateCVV(string CCVVali)
        {
            if (CCVVali.Length == 3)
            {
                try
                {
                    long.Parse(CCVVali);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wrong format: {e}");
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public static bool CCV(string idCode)
        {
            int CCVali = Int32.Parse(idCode[0].ToString());
            if (CCVali == 51 || CCVali == 52 || CCVali == 53 || CCVali == 54 || CCVali == 55)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Your card has been declined");
                return false;
            }
        }
        public static bool CVV(string idCode)
        {
            int CCVVali = Int32.Parse(idCode[0].ToString());
            if (CCVVali == 3)
            {
                Console.WriteLine("Your card has been accepted");
                return true;
            }
            else 
            {
                Console.WriteLine("Your card has been declined");
                return false;
            }
        }
    }
}