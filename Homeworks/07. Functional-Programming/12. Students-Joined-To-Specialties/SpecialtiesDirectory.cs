using System.Collections.Generic;

namespace _12.Students_Joined_To_Specialties
{
    class SpecialtiesDirectory
    {
        public List<StudentSpecialty> StudentSpecialties = CreateSpeciltiesDirectory();

        public static List<StudentSpecialty> CreateSpeciltiesDirectory()
        {
            var specialitiesFacNums = new List<StudentSpecialty>
		    {
			    new StudentSpecialty("Web Developer",801231),
			    new StudentSpecialty("Web Developer",801242),
			    new StudentSpecialty("PHP Developer",801253),
			    new StudentSpecialty("PHP Developer",801214),
			    new StudentSpecialty("QA Engineer",801275),
			    new StudentSpecialty("QA Engineer",801214),
		    };

            return specialitiesFacNums;
        }
    }
}
