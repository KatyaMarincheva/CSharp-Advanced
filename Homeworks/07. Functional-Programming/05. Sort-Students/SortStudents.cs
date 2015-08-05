/* Problem 2.	Students by Group
Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Students_Directory;
using _03.Students_By_First_And_Last_Name;

static class StudentsByGroup
{
    static void Main()
    {
        // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
        StudentsDirectory database = new StudentsDirectory();

        // using lambda expressions
        var sortedStudents =
    database.Students.OrderByDescending(student => student.FirstName).ThenBy(student => student.LastName);

        // running LINQ query
        var studentsSortQuery = database.Students.StudentsSortQuery();
        
        // printing - by invoking the PrintStudentsInfo() method from the StudentsByFirstAndLastName project
        StudentsByFirstAndLastName.PrintStudentsInfo(sortedStudents);
        Console.WriteLine();
        StudentsByFirstAndLastName.PrintStudentsInfo(studentsSortQuery);
    }

    public static List<Student> StudentsSortQuery(this List<Student> database)
    {
        var studentsSortQuery =
            from student in database
            orderby student.FirstName descending,
            student.LastName descending
            select student;

        return studentsSortQuery.ToList();
    }
}

