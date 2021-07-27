using System;

namespace Assignment3
{
    class Program
    {
       // internal 
        static void Main()
        {
            string str1;
            Console.WriteLine("Enter a String");
            str1 = Console.ReadLine();
            Console.WriteLine("Upper Case:{0}", str1.ToUpper());
            Console.WriteLine("Lower Case:{0}", str1.ToLower());
            Console.WriteLine("Upper Case:{0}", str1.Length);

        }
    }
}
