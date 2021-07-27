using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOne
{
    class Employee
    {
        //Property
        int Eid { get; set; }
        string? Empname { get; set; }
        string? Location { get; set; }
        int Salary { get; set; }
        int Did { get; }    //Read Only Property

        Employee()
        {
            Did = 101;
        }
        Employee(int Eid, string Empname, string Location, int Sal)
        {
            this.Eid = Eid;
            this.Empname = Empname;
            this.Location = Location;
            Salary = Sal;
        }

        void DisplayEmployee(Employee emp)
        {
            Console.WriteLine("Eid:{0} || EmpName:{1} || Location:{2} || Salary:{3} || Did:{4}", Eid, Empname, Location, Salary, emp.Did);
        }


        static void Main()
        {
            int Eid, Esalary;
            string ELocation, Empname;
            Employee employee = new Employee();

            Console.WriteLine("Enter the Eid");
            Eid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the EmpName");
            Empname = Console.ReadLine();

            Console.WriteLine("Enter the Location");
            ELocation = Console.ReadLine();

            Console.WriteLine("Enter the Salary");
            Esalary = Convert.ToInt32(Console.ReadLine());

            Employee employee1 = new Employee(Eid, Empname, ELocation, Esalary);
            employee1.DisplayEmployee(employee);
        }
    }
}

