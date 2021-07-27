using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOne
{
    class Practice
    {
        void Types()
        {
            string name;
            int age;
            Console.WriteLine("Enter the name");
            name = Console.ReadLine();
            Console.WriteLine("Enter the age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name:{0} && Age{1}", name, age);
        }
        void TypeConversion()
        {
            int num = 100;
            float petrol = num;
            double diesel = petrol;
            Console.WriteLine("num:{0} && petrol:{1}", num, petrol);
        }
        void BoxingandUnboxing()
        {
            int num = 100;
            Object obj = num;
            //double diesel = petrol;
            Console.WriteLine("Object:{0} ", obj);
            int sal = (int)obj;
            Console.WriteLine("Sal:{0} ", sal);
        }
        void Nullable()
        {
            int? age = null;
            Console.WriteLine("Age:{0} ",age);
        }
        static void Main()
        {
            Practice datatypes = new Practice();
            // datatypes.Types();
            // datatypes.TypeConversion();
            datatypes.BoxingandUnboxing();
            //datatypes.Nullable();

        }
    }
}
