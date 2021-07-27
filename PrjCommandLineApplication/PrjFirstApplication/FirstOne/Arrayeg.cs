using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOne
{
    class Arrayeg
    {
        string[] fruits = new string[3];
        int[] mark = { 65, 76, 87 };

        internal void GetFruits()
        {
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine("enter the fruits");
                fruits[i] = Console.ReadLine();
            }

            foreach (var ch in fruits)
            {
                Console.WriteLine("FruitName:{0}", ch);
            }
        }

        class StringEg
        {
            internal void StringFunction()
            {
                string FirstName = "Sai";
                string Name = "Sachin Ghuge";

                Console.WriteLine("To UPPER :{0}", FirstName.ToUpper());
                Console.WriteLine("To LOWER :{0}", FirstName.ToLower());
                Console.WriteLine("Length :{0}", Name.Length);

                bool isContains = Name.Contains("in");
                Console.WriteLine("Contains IN :{0}", isContains);
                Console.WriteLine("Substring :{0}", Name.Substring(3,5));
            }
        }




        static void Main()
        {
            //Arrayeg A1 = new Arrayeg();
           // A1.GetFruits();
            StringEg S1 = new StringEg();
            S1.StringFunction();
        }
    }
}
