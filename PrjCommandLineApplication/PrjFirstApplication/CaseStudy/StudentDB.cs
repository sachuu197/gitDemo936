using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
   public class StudentDB
    {
        //Property
       internal int id { get; set; }
       internal string? Name { get; set; }
        internal DateTime dateofbirth { get; set; }
       //internal  int[] Phone = new int[10];
       internal string Phone { get; set; }
        static string collegename = "VIIT";


       internal StudentDB(int id, string Name, DateTime dateofbirth,string ph) 
        {
            this.id = id;
            this.Name = Name;
            this.dateofbirth = dateofbirth;
            Phone = ph;
        }
    }

    class EnrollmentException : ApplicationException
    {
        public EnrollmentException(string msg):base(msg)
        {

        }
    }
   public class Course
    {
            internal int id { get; set; }
            internal string CName { get; set; }
            internal int Duration { get; set; }

            internal double Fees { get; set; }

            internal Course(int id, string name, int duration, double fees)
            {
                this.id = id;
                this.CName = name;
                this.Duration = duration;
                this.Fees = fees;
            }
            internal virtual void calculateMonthlyFee()
            {
                Fees = Fees / 12;
            }
    }

  class DegreeCourse : Course
      {
        enum Level
        {
            Bachelors, Masters
        }
        bool isPlacementAvailable { get; set; }
        int level { get; set; }
          internal DegreeCourse(int id, string name, int duration, double fees, bool i,string level) : base(id, name, duration, fees)
            {
                this.isPlacementAvailable = i;
            this.level = (int)Enum.Parse(typeof(Level), level);
            }
            internal override void calculateMonthlyFee()
            {
                double charge=0.0;
                if(isPlacementAvailable)
                {
                    charge = 0.1 * Fees;
                }
                Fees = Fees + charge;
            }
    }
    class DiplomaCourse : Course
    {
        enum Type
        {
            professional,academic
        }
        int type { get; set; }
          internal  DiplomaCourse(int id, string name, int duration, double fees, string type) : base(id, name, duration, fees)
            {
                this.type = (int)Enum.Parse(typeof(Type), type);
            }
            internal override void calculateMonthlyFee()
            {
                double charge;
                if (type==0)
                {
                    charge = 0.1 * Fees;
                }
                else
                {
                    charge = 0.05 * Fees;
                }
                Fees = Fees + charge;
            }
    }
    class Info
    {
       internal void DisplayStudent(StudentDB stu)
        {
            Console.WriteLine("id:{0} || Name:{1} || Date Of Birth:{2} ", stu.id, stu.Name,(stu.dateofbirth).ToString("yyyy-mm-dd"),stu.Phone);
        }
        internal void DisplayCourseinfo(Course c)
        {
            Console.WriteLine("id:{0} || CourseName:{1} || Duration:{2} Fees:{3}", c.id, c.CName, c.Duration, c.Fees);
        }
        internal void DisplayEnroll(Enroll er)
        {
            Console.WriteLine("id:{0} || StudentName:{1} || CourseName:{2} || Date Of Birth:{3}|| Duration:{4} Fees:{5}", er.student.id, er.student.Name, er.course.CName, er.student.dateofbirth, er.course.Duration, er.course.Fees);
        }
    }

   public class Enroll
    {
        internal StudentDB student { get; set; }
        internal Course course { get; set; }
        internal DateTime enrollmentDate { get; set; }

        public Enroll(StudentDB student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
        /* List<Enroll> E = new List<Enroll>();   //

         public Enroll(StudentDB student,Course course,DateTime enrollmentDate)
         {
             //this.student = student;
             //this.course = course;
             // this.enrollmentDate = enrollmentDate;
             Enroll e1 = new Enroll(student, course, enrollmentDate);
             int exceeds = E.Where(enroll => enroll.course.CName == e1.course.CName).Count(); 

             int sameCourse = E.Where(enroll => enroll.course.CName == e1.course.CName && enroll.student.Name == e1.student.Name).Count();

             if (sameCourse == 1)
             {
                 throw new EnrollmentException("Student has allready Enrolled for this Course!");
             }
             else if (exceeds >= 4)
             {
                 throw new EnrollmentException("There are more than 4 Students in this Course!");
             }
             else
                 E.Add(e1);
         }
         public List<Enroll> listOfEnrollments()
         {
             return E;
         }
       */
    }


    interface AppEngine
    {
             public void introduce(Course course); 
            public void register(StudentDB student);
           public List<StudentDB> listOfStudents();
             public void enroll(StudentDB student, Course course);
             public List<Enroll> listOfEnrollments();
    }
   public class InMemoryAppEngine:AppEngine
    {
      public List<StudentDB> S = new List<StudentDB>();
      public  List<Course> C = new List<Course>();
        public   List<Enroll> E = new List<Enroll>();
        public InMemoryAppEngine()
        { }

        public void enroll(StudentDB student,Course course)
        {
            Enroll e = new Enroll(student, course, DateTime.Now);
            E.Add(e);
        }
        public void introduce(Course course)
        {
            C.Add(course);
        }
        public void register(StudentDB student)
        {
            S.Add(student);
        }
        public List<StudentDB> listOfStudents()
        {
            return S;
        }
        public List<Enroll> listOfEnrollments()
        {
            return E;
        }
    }
    class PersistentAppEngine: AppEngine
    {
        public List<StudentDB> S = new List<StudentDB>();
        public List<Course> C = new List<Course>();
        public List<Enroll> E = new List<Enroll>();

        public void register(StudentDB student)
        {
            //string SName,Phone,Email;
           // Student s=null;
            SqlConnection con = null;
            SqlCommand cmd = null; //sql commond ADO.net le mahit nai mhanun

            try
            {//3. Windows Authentication
                con = new SqlConnection(
                    "Data Source = DESKTOP-E8Q152A; Initial catalog = Case_Study; Integrated Security = true");
                //4
                con.Open();
           

                cmd = new SqlCommand("insert into student (id,studentName,dateOfBirth,Phone) values (@id,@name,@phone,@email)", con);
                cmd.Parameters.AddWithValue("@id", student.id);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@phone", student.dateofbirth);
                cmd.Parameters.AddWithValue("@email", student.Phone);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Registered!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
         }
        public void introduce(Course course)
        {
            SqlConnection con = null;
            SqlCommand cmd = null; //sql commond ADO.net le mahit nai mhanun

            try
            {//3. Windows Authentication
                con = new SqlConnection(
                    "Data Source = DESKTOP-E8Q152A; Initial catalog = Case_Study; Integrated Security = true");
                //4
                con.Open();


                cmd = new SqlCommand("insert into course (id,CName,Duration,Fees) values (@id,@name,@duration,@fees)", con);
                cmd.Parameters.AddWithValue("@id", course.id);
                cmd.Parameters.AddWithValue("@name", course.CName);
                cmd.Parameters.AddWithValue("@duration", course.Duration);
                cmd.Parameters.AddWithValue("@fees", course.Fees);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Introduce to the new Course!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
       
        public List<StudentDB> listOfStudents()
        {
            SqlConnection con = null;
            SqlCommand cmd = null; //sql commond ADO.net le mahit nai mhanun
            StudentDB s1 = null;

            try
            {//3. Windows Authentication
                con = new SqlConnection(
                    "Data Source = DESKTOP-E8Q152A; Initial catalog = Case_Study; Integrated Security = true");
                //4
                con.Open();
                SqlDataReader dr;

                cmd = new SqlCommand("select * from student", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    S.Add(new StudentDB((int)dr[0], (string)dr[1], (DateTime)dr[2], (string)dr[3]));
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            return S;
        }
        public void enroll(StudentDB student, Course course)
        {

        }
        public List<Enroll> listOfEnrollments()
        {
            return E;
        }
    }
    class  App
    {
       //internal  int[] a1 = {7,6,4,5,4,4,8};
        static void Main()
        {
             int id;
             string name;
             DateTime date1;
             StudentDB[] student = new StudentDB[2];
             ArrayList students = new ArrayList();
             // string ph;
             int[] phone = new int[20];
             int[] a1 = { 7, 6, 4, 5, 4, 4, 8 };
             int[] a2 = { 5, 2, 4, 5, 4, 4, 8 };
             int[] a3 = { 9, 5, 4, 5, 4, 4, 8 };
            
             StudentDB std1 = new StudentDB(1, "Sachin Ghuge", Convert.ToDateTime("2000-07-09"),"43543534");
             StudentDB std2 = new StudentDB(2, "Sahil Bhaware", Convert.ToDateTime("2003-09-09"),"5455534");
             StudentDB std3 = new StudentDB(4, "Om Jadhav", Convert.ToDateTime("2019-08-03"),"453535");
             Info i = new Info();
             i.DisplayStudent(std1);
             i.DisplayStudent(std2);
             i.DisplayStudent(std3);


            //s2
            StudentDB[] StudentArray = { (new StudentDB(4, "Sameer Ghode", Convert.ToDateTime("2010-07-09"), "4534543535")), ((new StudentDB(5, "Sushil Bhaware", Convert.ToDateTime("2013-10-09"), "45454545423"))) };
            for (int i1 = 0; i1 < 2; i1++)
            {
                i.DisplayStudent(StudentArray[i1]);
            }

            //S3
            for (int i1 = 0; i1 < 2; i1++)
            {
                Console.WriteLine("Enter the Id");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Name");
                name = Console.ReadLine();

                Console.WriteLine("Enter the Date Of Birth");
                date1 = Convert.ToDateTime(Console.ReadLine());

                // Console.WriteLine("Enter the Phone Number");
                //phone = Convert.ToInt32(Console.ReadLine());


                student[i1] = new StudentDB(id, name, date1, "5432523");
            }

            for (int i1 = 0; i1 < 2; i1++)
            {
                i.DisplayStudent(student[i1]);
            }

            //s4 --arraylist
            /*  for (int i1 = 0; i1 < 2; i1++)
              {
                  Console.WriteLine("Enter the Id");
                  id = Convert.ToInt32(Console.ReadLine());

                  Console.WriteLine("Enter the Name");
                  name = Console.ReadLine();

                  Console.WriteLine("Enter the Date Of Birth");
                  date1 = Convert.ToDateTime(Console.ReadLine());

                  // Console.WriteLine("Enter the Phone Number");
                  //phone = Console.ReadLine();


                  students[i1] = new StudentDB(id, name, date1, phone);
              }

              foreach(var m in students)
              {
                  i.DisplayStudent(m);
              }*/
            //Course Class and inheritence

            Course c1 = new Course(101, "Sumit", 45, 56600.0);
            Info i2 = new Info();
            i2.DisplayCourseinfo(c1);

            DegreeCourse Dg = new DegreeCourse(102, "Sahil", 49, 52650.0, true, "Bachelors");
            Console.WriteLine("Degree Course");
            Console.WriteLine("Fees before Updation :- {0}", Dg.Fees);
            Console.WriteLine("**************");
            Dg.calculateMonthlyFee();
            Console.WriteLine("Fees after Updation :- {0}", Dg.Fees);
            Console.WriteLine("Diploma Course");
            DiplomaCourse Dm = new DiplomaCourse(103, "Abhi", 56, 42650.0, "academic");
            Console.WriteLine("Fees before Updation :- {0}", Dm.Fees);
            Console.WriteLine("**************");
            Dm.calculateMonthlyFee();
            Console.WriteLine("Fees after Updation :- {0}", Dm.Fees);


            //After Enroll

            Enroll e2 = new Enroll(new StudentDB(6, "Rajan Bhaware", Convert.ToDateTime("2050-02-07"), "545635433"), new Course(106, "Java", 45, 88600.0), Convert.ToDateTime("2011-01-19"));

            InMemoryAppEngine implementInterface = new InMemoryAppEngine();
            implementInterface.introduce(new Course(105, "Sia", 35, 48600.0));
            implementInterface.register(new StudentDB(5, "Som Jadhav", Convert.ToDateTime("2010-01-09"), "545635433"));
            implementInterface.enroll(new StudentDB(5, "Som Jadhav", Convert.ToDateTime("2010-01-09"), "545635433"), new Course(105, "Sia", 35, 48600.0));
            List<StudentDB> stu = new List<StudentDB>();
            stu = implementInterface.listOfStudents();

            foreach (var r in stu)
            {
                Console.WriteLine(r.id + " " + r.Name + " " + r.dateofbirth);
            }
            List<Enroll> er = new List<Enroll>();
            er = implementInterface.listOfEnrollments();

            foreach (var r in er)
            {
                Console.WriteLine(r.student.Name + " " + r.course.id + " " + r.enrollmentDate);
            }
            //Calling from Info Class

            i.DisplayEnroll(e2);
            

            /* Create a user defined Exception called as EnrollmentException

        - Then modify the enroll method we wrote on Day 2 to throw the above exception:
        - In case if the Student tries to enroll for the same course again
        - In case if the no. of students for a course exceeds 50
*/

        }
    }
}
