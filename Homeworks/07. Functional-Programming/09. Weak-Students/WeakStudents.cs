/* Problem 9.	Weak Students
Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.
 */

using System.Collections.Generic;
using System.Linq;
using Students_Directory;
using _03.Students_By_First_And_Last_Name;

namespace _09.Weak_Students
{
    public static class WeakStudents
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var weekStudentsList = database.Students.WeakStudentsList();

            // printing - by invoking the PrintStudentsInfo() method from the StudentsByFirstAndLastName project
            StudentsByFirstAndLastName.PrintStudentsInfo(weekStudentsList);
        }

        public static List<Student> WeakStudentsList(this List<Student> students)
        {
            var weakStudent =
            from student in students
            where (student.Marks.Count(x => x == 2) == 2)
            select student;

            return weakStudent.ToList();
        }
    }
}
