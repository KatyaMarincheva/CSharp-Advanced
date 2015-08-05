/* Problem 10.	Students Enrolled in 2014
Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Students_Directory;
using _03.Students_By_First_And_Last_Name;

namespace _10.Students_Enrolled_In_2014
{
    static class StudentsEnrolledIn2014
    {
        static void Main()
        {
            // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
            StudentsDirectory database = new StudentsDirectory();

            // running LINQ query
            var studentsEnrolledIn2014 = database.Students.EnrolledIn2014();

            // printing - by invoking the PrintStudentsInfo() method from the StudentsByFirstAndLastName project
            StudentsByFirstAndLastName.PrintStudentsInfo(studentsEnrolledIn2014);
        }

        public static List<Student> EnrolledIn2014(this List<Student> database)
        {
            // regex
            string pattern = @"(?<=\d{4})(14)";
            Regex rgx = new Regex(pattern);

            // query
            var studentsEnrolledIn2014 =
                from student in database
                where rgx.IsMatch(student.FacultyNumber.ToString())
                select student;

            return studentsEnrolledIn2014.ToList();
        }
    }
}
