/* Problem 7.	Filter Students by Phone
Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.
 */

using System.Collections.Generic;
using System.Linq;
using Students_Directory;
using _03.Students_By_First_And_Last_Name;

namespace _07.Filter_Students_By_Phone
{
    static class FilterStudentsByPhone
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var studentsByPhoneQuery = database.Students.StudentsByPhoneQuery();

            // printing - by invoking the PrintStudentsInfo() method from the StudentsByFirstAndLastName project
            StudentsByFirstAndLastName.PrintStudentsInfo(studentsByPhoneQuery);
        }

        public static List<Student> StudentsByPhoneQuery(this List<Student> database)
        {
            var studentsByPhoneQuery =
                from student in database
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                select student;

            return studentsByPhoneQuery.ToList();
        }
    }
}
