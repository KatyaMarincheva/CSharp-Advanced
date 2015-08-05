namespace _13.LINQToExcel
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string StudentType { get; set; }
        public int ExamResult { get; set; }
        public int HomeworkSent { get; set; }
        public int HomeworkEvaluated { get; set; }
        public double Teamwork { get; set; }
        public int Attendances { get; set; }
        public double Bonus { get; set; }

        public double result;

        public Student(int iD, string firstName, string lastName, string email, string gender, string studentType, int examResult, int homeworkSent, int homeworkEvaluated, double teamwork, int attendances, double bonus)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            ExamResult = examResult;
            HomeworkSent = homeworkSent;
            Gender = gender;
            StudentType = studentType;
            Email = email;
            HomeworkEvaluated = homeworkEvaluated;
            Teamwork = teamwork;
            Attendances = attendances;
            Bonus = bonus;
        }

        public void CalculateResult()
        {
            this.result = (ExamResult + HomeworkSent + HomeworkEvaluated + Teamwork + Attendances + Bonus) / 5;
        }

    }
}
