
using System.Text;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            while (true)
            {
                Console.WriteLine("add - Add a studnt \n" +
                    "all - All students\n" +
                    "find - Find a student by ID \n" +
                    "update - Update a student's grade (By ID)\n" +
                    "exit - Exit the program");

                var operation = Console.ReadLine();

                switch (operation)
                {
                    case "add":
                        Console.Clear();
                        Console.WriteLine("Enter a name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter a grade:");
                        bool gradeCheck = char.TryParse(Console.ReadLine(), out char grade);
                        if (gradeCheck) {
                            manager.AddStudent(name, grade);
                            Console.WriteLine("Student added");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "all":
                        Console.Clear();
                        var students = manager.AllStudents();
                        Console.WriteLine(students);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "find":
                        Console.Clear();
                        Console.WriteLine("Enter an ID:");
                        bool IdCheck = int.TryParse(Console.ReadLine(), out int id);
                        List<Student> result = manager.FindByID(id);
                        result.ForEach(student => Console.WriteLine($"{student.Name} | {student.ID} | {student.Grade}\n"));
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "update":
                        Console.Clear();
                        Console.WriteLine("Enter an ID:");
                        bool intCheck = int.TryParse(Console.ReadLine(), out int studentId);
                        Console.WriteLine("To what grade? (A, B, C, D, F)");
                        bool newGradeCheck = char.TryParse(Console.ReadLine(), out char newGrade);
                        if (newGradeCheck) {
                            manager.UpdateGrade(studentId, newGrade);
                        } else
                        {
                            Console.WriteLine("Invalid input");
                        }
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }


    public class Student
    {
        public string Name { get; set; }
        private static int IDHelper = 0;
        public int ID { get; set; }
        public char Grade { get; set; }

        public Student(string name, char grade) {
            IDHelper++;
            Name = name;
            ID = IDHelper;
            Grade = grade;
        }

    }

    public class StudentManager
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(string name, char grade)
        {
            char[] grades = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };

            if (grades.Contains(grade))
            {
                Students.Add(new Student(name, grade));
            } else
            {
                Console.WriteLine("Invalid Grade");
            }
        }

        public string AllStudents()
        {
            if (Students.Count == 0)
            {
                return "No Students";
            } 

            StringBuilder students = new StringBuilder();
            foreach (Student student in Students)
            {
                students.Append($"{student.Name} | {student.ID} | {student.Grade}\n");
            }

            return students.ToString();
        }

        public List<Student> FindByID(int id)
        {
            return Students.FindAll(student => student.ID.ToString().Contains(id.ToString()));
        }

        public void UpdateGrade(int id, char grade) {
            char[] grades = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            
            if (grades.Contains(grade))
            {
                Student student = Students.Find(student => student.ID == id);
                student.Grade = grade;
            } else
            {
                Console.WriteLine("Invalid Grade");
            }
            
        }
    }
}
