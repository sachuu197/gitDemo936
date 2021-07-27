using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class CaseStudy4
    {
        static void Main()
        {
            List<StudentDB> sList = new List<StudentDB>();      
            PersistentAppEngine p = new PersistentAppEngine();
            StudentDB stdt = new StudentDB(27, "Abhi Joshi", Convert.ToDateTime("2010-09-29"), "54554545");
            Course course = new Course(24, "DS", 39, 4567.8f);
             p.register(stdt);
            p.introduce(course);
           sList = p.listOfStudents();
            foreach(StudentDB stu in sList)
            {
                Console.WriteLine("Student Id :{0} || Student Name :{1} || Student DOB :{2}", stu.id, stu.Name, stu.dateofbirth);
            }
        }
    }
}
