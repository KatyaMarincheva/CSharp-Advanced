/* Problem 2.	Students by Group
Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Students_Directory;

public class StudentsByGroupNumber
{
    static void Main()
    {
        // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
        StudentsDirectory database = new StudentsDirectory();

        // running LINQ query
        var studentsByGroupQuery =
            from student in database.Students
            orderby student.FirstName
            group student by student.GroupNumber
            into studentGroup
            where studentGroup.Key == 2
            select studentGroup;

        // printing
        PrintStudentInfoByGroup(studentsByGroupQuery);
    }

    public static void PrintStudentInfoByGroup<T>(IEnumerable<IGrouping<T, Student>> studentsQuery)
    {
        foreach (var group in studentsQuery)
        {
            Console.WriteLine("Group: {0}", @group.Key);
            foreach (var student in @group)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks));
            }
        }
    }
}

