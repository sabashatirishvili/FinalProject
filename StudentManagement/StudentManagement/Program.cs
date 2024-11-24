
using System.Text;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public char Grade { get; set; }

        public Student(string name, int id, char grade) {
            Name = name;
            ID = id;
            Grade = grade;
        }

    }

    public class StudentManager
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
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
                students.Append($"{student.Name} | {student.ID} | {student.Grade}");
            }

            return students.ToString();
        }

        public Student FindByID(int id)
        {
            return Students.Find(student => student.ID == id);
        }

        public void UpdateGrade(int id, char grade) {
            FindByID(id).Grade = grade;
        }
    }
}
