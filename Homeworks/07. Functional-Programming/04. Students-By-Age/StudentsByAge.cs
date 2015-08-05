/* Problem 4.	Students by Age
Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. The query should return only the first name, last name and age.
 */

using System;
using System.Linq;
using Students_Directory;

class StudentsByAge
{
    static void Main()
    {
        // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
        StudentsDirectory database = new StudentsDirectory();

        // running LINQ query
        var studentsByAgeQuery =
            from student in database.Students
            where student.Age >= 18 && student.Age <= 24
            select new {student.FirstName, student.LastName, student.Age}; // limiting the query to names and age

        // printing
        foreach (var student in studentsByAgeQuery)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}",
                                student.FirstName, student.LastName, student.Age);
        }
    }
}

