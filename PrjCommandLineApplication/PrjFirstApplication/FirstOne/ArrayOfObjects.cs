using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOne
{
    class ArrayOfObjects
    {  //Property

        //Static Keyword
       static string OrganizationName = "LTI"; //(Only one copy of varible is created for all employee objects instead of having to each and every objects)
        int Eid { get; set; }
        string? Empname { get; set; }
        string? Location { get; set; }
        int Salary { get; set; }
        int Did { get; }    //Read Only Property

        ArrayOfObjects()
        {
            Did = 101;
        }
        ArrayOfObjects(int Eid, string Empname, string Location, int Sal)
        {
            this.Eid = Eid;
            this.Empname = Empname;
            this.Location = Location;
            Salary = Sal;
        }

        void DisplayEmployee(ArrayOfObjects emp)
        {
            Console.WriteLine("Eid:{0} || EmpName:{1} || Location:{2} || Salary:{3} || Did:{4} || Oragnization:{5}", Eid, Empname, Location, Salary, emp.Did, OrganizationName);
        }


        static void Main()
        {
            ArrayOfObjects[] ArrayObj = new ArrayOfObjects[2];
            int Eid, Esalary;
            string ELocation, Empname;
            ArrayOfObjects employee = new ArrayOfObjects();
            for(int i=0;i<2;i++)
            { 
                Console.WriteLine("Enter the Eid");
                Eid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the EmpName");
                Empname = Console.ReadLine();

                Console.WriteLine("Enter the Location");
                ELocation = Console.ReadLine();

                Console.WriteLine("Enter the Salary");
                Esalary = Convert.ToInt32(Console.ReadLine());
                ArrayObj[i] = new ArrayOfObjects(Eid, Empname, ELocation, Esalary);
            }
            for (int i = 0; i < 2; i++)
            {
                ArrayObj[i].DisplayEmployee(employee);
            }
                
            
        }
    }
}
