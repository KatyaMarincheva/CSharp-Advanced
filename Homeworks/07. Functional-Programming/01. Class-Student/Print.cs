using System;
using System.Collections.Generic;

namespace Students_Directory
{
    public static class Print
    {
        public static void PrintStudentsInfo(this IEnumerable<Student> database)
        {
            foreach (var student in database)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}, Faculty Number: {3} " +
                                  "\n\tPhone: {4}, Email: {5} \n\tGrades: {{{6}}}, Group: {7}",
                    student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                    student.Phone, student.Email, string.Join(", ", student.Marks), student.GroupNumber);
            }
        }
    }
}
