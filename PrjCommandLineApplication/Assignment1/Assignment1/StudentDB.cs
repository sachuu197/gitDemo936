using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class StudentDB
    {
        String Stu_Name { get; set; }
        int Stu_Age { get; set; }
        string[] Marks { get; set; }
        int Score { get; set; }
        enum feedbackdesc
        {
            Poor,
            Good,
            VeryGood,
            Excellent,
        }
        int Grade, feedback;
        StudentDB(String Stu_Name, int Stu_Age)
        {
            this.Stu_Name = Stu_Name;
            this.Stu_Age = Stu_Age;
        }
        void EnterMarks()
        {
            int no_of_subj;

            Console.WriteLine("Enter number of subjects");
            no_of_subj = Convert.ToInt32(Console.ReadLine());
            if (no_of_subj < 5)
            {
                Console.WriteLine("Subjects cannot be less than 5");
                Console.WriteLine("Enter number of subjects");
                no_of_subj = Convert.ToInt32(Console.ReadLine());
            }
            string[] Marks = new string[no_of_subj];
            for (int j = 0; j < no_of_subj; j++)
            {
                Console.WriteLine("Enter marks {0}", j + 1);
                Marks[j] = Console.ReadLine();
            }
            this.Marks = Marks;
        }
        void CalculateGrade()
        {
            int TotalGrade = 0, Grade;

            for (int i = 0; i < Marks.Length; i++)
            {
                TotalGrade = TotalGrade + Convert.ToInt32(Marks[i]);
            }
            Grade = TotalGrade / Marks.Length;
            if (Grade > 90 && Grade <= 100) feedback = (int)feedbackdesc.Excellent;
            else if (Grade > 75 && Grade <= 90) feedback = (int)feedbackdesc.VeryGood;
            else if (Grade > 40 && Grade <= 75) feedback = (int)feedbackdesc.Good;
            else feedback = (int)feedbackdesc.Poor;

            this.Grade = Grade;
        }

        void DisplayResultMethod()
        {
            Console.WriteLine("Student Name: {0} || Grade: {1} || Feedback: {2}", Stu_Name, Grade, (feedbackdesc)feedback);
        }

        static void Main()
        {
            int Stu_Age, no_of_students;
            String Stu_Name;

            Console.WriteLine("Enter number of students");
            no_of_students = Convert.ToInt32(Console.ReadLine());

            StudentDB[] studentdb = new StudentDB[no_of_students];

            for (int i = 0; i < no_of_students; i++)
            {
                Console.WriteLine("Enter student name");
                Stu_Name = Console.ReadLine();
                Console.WriteLine("Enter student age");
                Stu_Age = Convert.ToInt32(Console.ReadLine());

                studentdb[i] = new StudentDB(Stu_Name, Stu_Age);
                studentdb[i].EnterMarks();
            }

            for (int i = 0; i < no_of_students; i++)
            {
                studentdb[i].CalculateGrade();
                studentdb[i].DisplayResultMethod();
            }
        }
    }
}
