/* Problem 3.	Students by First and Last Name
Print all students whose first name is before their last name alphabetically. Use a LINQ query.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Students_Directory;

namespace _03.Students_By_First_And_Last_Name
{
    public static class StudentsByFirstAndLastName
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var studentsByNames = database.Students.StudentsByNames();

            // printing
            PrintStudentsInfo(studentsByNames);
        }

        public static List<Student> StudentsByNames(this List<Student> database)
        {
            var studentsByNames =
                from student in database
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return studentsByNames.ToList();
        }

        public static void PrintStudentsInfo(IEnumerable<Student> studentsQuery)
        {
            foreach (var student in studentsQuery)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}, Group: {7}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);
            }
        }
    }
}


