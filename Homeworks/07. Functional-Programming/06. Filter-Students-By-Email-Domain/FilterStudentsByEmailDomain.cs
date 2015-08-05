/* Problem 6.	Filter Students by Email Domain
Print all students that have email @abv.bg. Use LINQ.
*/

using System.Collections.Generic;
using System.Linq;
using Students_Directory;
using _03.Students_By_First_And_Last_Name;

namespace _06.Filter_Students_By_Email_Domain
{
    static class FilterStudentsByEmailDomain
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var studentsByEmailDomainQuery = database.Students.StudentsByEmailDomainQuery();

            // printing - by invoking the PrintStudentsInfo() method from the StudentsByFirstAndLastName project
            StudentsByFirstAndLastName.PrintStudentsInfo(studentsByEmailDomainQuery);
        }

        public static List<Student> StudentsByEmailDomainQuery(this List<Student> database)
        {
            var studentsByEmailDomainQuery =
                from student in database
                where student.Email.Substring(student.Email.Length - 6) == "abv.bg"
                select student;

            return studentsByEmailDomainQuery.ToList();
        }
    }
}
