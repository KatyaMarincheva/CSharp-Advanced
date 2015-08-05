/* Problem 12.	* Students Joined to Specialties
Create a class StudentSpecialty that holds specialty name and faculty number. 
 * Create a list of student specialties, where each specialty corresponds to a certain student (via the faculty number). 
 * Print all student names alphabetically along with their faculty number and specialty name. Use the "join" LINQ operator. 
 */

using System;
using System.Collections;
using System.Linq;
using _12.Students_Joined_To_Specialties;
using Students_Directory;

class StudentsJoinedToSpecialties
{
    static void Main()
    {
        StudentsDirectory database1 = new StudentsDirectory();
        SpecialtiesDirectory database2 = new SpecialtiesDirectory();

        // LINQ query
        var joinedData =
                from student in database1.Students
                orderby student.FirstName ascending, student.LastName ascending
                join speciality in database2.StudentSpecialties on student.FacultyNumber equals speciality.FacultyNumber
                select new { student.FirstName, student.LastName, student.FacultyNumber, speciality.Speciality };

        // lambda expression
        var joinedDataLinqExtMtd =
            database1.Students.OrderBy(st => st.FirstName)
                .ThenBy(st => st.LastName)
                .Join(database2.StudentSpecialties, st => st.FacultyNumber, sp => sp.FacultyNumber,
                    (student, speciality) =>
                        new { student.FirstName, student.LastName, student.FacultyNumber, speciality.Speciality });

        // printing
        Console.WriteLine("{0, -18} {1, -8} {2, -12}", "Name", "FacNum", "Specialty");
        foreach (var item in joinedData)
        {
            Console.WriteLine("{0, -18} {1, -8} {2, -12}", item.FirstName + " " + item.LastName, item.FacultyNumber, item.Speciality );
        }
    }
}

