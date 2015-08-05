/* Problem 8.	Excellent Students
Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
 */

using System;
using System.Linq;
using Students_Directory;

namespace _08.Excellent_Students
{
    class ExcellentStudents
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var excellentStudents =
                from student in database.Students
                where student.Marks.Contains(6)
                select new { Fullname = string.Join(" ", student.FirstName, student.LastName), Marks = string.Join(", ", student.Marks) };

            // printing
            foreach (var student in excellentStudents)
            {
                Console.WriteLine("Name: {0}, Grades: {{{1}}}", student.Fullname, student.Marks);
            }
        }
    }
}
