/* Problem 11.	* Students by Groups
Add a GroupName property to Student. Write a program that extracts all students grouped by 
 * GroupName and then prints them on the console. 
 * Print all group names along with the students in each group. Use the "group by into" LINQ operator.
 */

using System.Data.Common;
using System.Linq;

namespace _11.Students_By_Group_Name
{
    class StudentsByGroupName
    {
        static void Main()
        {
            GroupsDirectory database = new GroupsDirectory();

            // running LINQ query
            var studentsByGroupNameQuery =
                from student in database.StudentsWithGroups
                group student by student.GroupName
                into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            // printing - by invoking the PrintStudentInfoByGroup() method from the StudentsByGroup project
            StudentsByGroupNumber.PrintStudentInfoByGroup(studentsByGroupNameQuery);
        }
    }
}
