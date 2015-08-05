using System;
using System.Collections.Generic;
using Students_Directory;

namespace _11.Students_By_Group_Name
{
    // new class StudentWithGroup inherits from class Student and extends it with a new GroupName property
    class StudentWithGroup : Student
    {
        public StudentWithGroup(Student student, string groupName)
            : base(student.FirstName, student.LastName, student.Age, student.FacultyNumber, student.Phone, student.Email, student.Marks, student.GroupNumber)
        {
            this.GroupName = groupName;
        }

        public StudentWithGroup(Student student)
            : base(student.FirstName, student.LastName, student.Age, student.FacultyNumber, student.Phone, student.Email, student.Marks, student.GroupNumber)
        {

        }

        public string GroupName { get; set; }
    }
}
