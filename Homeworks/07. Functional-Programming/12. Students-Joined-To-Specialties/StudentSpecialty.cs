using System;

namespace _12.Students_Joined_To_Specialties
{
    class StudentSpecialty
    {
        public string Speciality { get; set; }

        public int FacultyNumber { get; set; }

        public StudentSpecialty(string studentSpeciality, int facultyNumber)
        {
            this.Speciality = studentSpeciality;
            this.FacultyNumber = facultyNumber;
        }
    }
}
