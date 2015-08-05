using System;
using System.Collections.Generic;
using Students_Directory;

namespace _11.Students_By_Group_Name
{
    class GroupsDirectory
    {
        // creating the required List<StudentWithGroup> 
        public List<StudentWithGroup> StudentsWithGroups = CreateGroupsDirectory();

        public static List<StudentWithGroup> CreateGroupsDirectory()
        {
            var studentsWithGroups = new List<StudentWithGroup>();

            // using the intitial students databae, to create new studets with groups database
            StudentsDirectory database = new StudentsDirectory();
            foreach (var student in database.Students)
            {
                if (student.GroupNumber == 1)
                {
                    studentsWithGroups.Add(new StudentWithGroup(student, "C#"));
                }
                else if (student.GroupNumber == 2)
                {
                    studentsWithGroups.Add(new StudentWithGroup(student, "PHP"));
                }
                else if (student.GroupNumber == 3)
                {
                    studentsWithGroups.Add(new StudentWithGroup(student, "JS"));
                }
                else if (student.GroupNumber == 4)
                {
                    studentsWithGroups.Add(new StudentWithGroup(student, "Java"));
                }
                else
                {
                    studentsWithGroups.Add(new StudentWithGroup(student, "No group chosen"));
                }
            }

            return studentsWithGroups;
        }
    }
}
