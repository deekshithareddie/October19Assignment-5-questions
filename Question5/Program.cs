namespace DelegatesEx
{
    //question 5
    //creating delegate of boolean type with a parameter
    public delegate bool IsEligibleforScholarship(Student std);

    //class studnet with members variables and methods
    public class Student
    {
        public int RollNo;
        public string Name;
        public int Marks;
        public char SportsGreade;
        public Delegate IsEligibleforScholarship { get; set; }

         
        public static string GetEligibleStudents(List<Student> studenetsList, IsEligibleforScholarship isEligible)
        {
            string result = "";
            foreach (var item in studenetsList)
            {
                if (isEligible(item))
                {
                    if (result == "")
                    {
                        result += item.Name;
                    }
                    else
                    {
                        result += ", " + item.Name;
                    }
                }

            }
            return result;
        }

        //method to check eligibility
        public static bool ScholarshipEligibility(Student std)
        {
            if (std.SportsGreade == 'A' && std.Marks > 80)
            {
                return true;
            }
            return false;
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            List<Student> listStudents = new List<Student>();
            Student obj1 = new Student()
            {
                RollNo = 1,
                Name = "Raj",
                Marks = 75,
                SportsGreade = 'A'
            };
            Student obj2 = new Student()
            {
                RollNo = 2,
                Name = "Rahul",
                Marks = 82,
                SportsGreade = 'A'
            };
            Student obj3 = new Student()
            {
                RollNo = 3,
                Name = "Kiran",
                Marks = 89,
                SportsGreade = 'B'
            };
            Student obj4 = new Student()
            {
                RollNo = 4,
                Name = "Sunil",
                Marks = 86,
                SportsGreade = 'A'
            };
            listStudents.Add(obj1);
            listStudents.Add(obj2);
            listStudents.Add(obj3);
            listStudents.Add(obj4);
            IsEligibleforScholarship isEligiblefor = new IsEligibleforScholarship(Student.ScholarshipEligibility);
            var res = Student.GetEligibleStudents(listStudents, isEligiblefor);
            Console.WriteLine(res);


        }
    }
}