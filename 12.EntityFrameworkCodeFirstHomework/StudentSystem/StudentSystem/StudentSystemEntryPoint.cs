namespace StudentSystem
{
    using System;
    using System.Linq;

    public class StudentSystemEntryPoint
    {
        public static void Main()
        {
            using (var db = new StudentSystemContext())
            {
                //CreateSampleData(db);

                IQueryable query = from c in db.Courses
                                   select c.Name;

                foreach (var item in query)
                {
                    Console.WriteLine(item);
                }

            }
        }

        private static void CreateSampleData(StudentSystemContext db)
        {
            var student = new Student()
            {
                StudentId = 1,
                Name = "Georgi Ivanov",
                Number = 2000,
                DateOfBirth = new DateTime(1994, 01, 16)
            };

            var course = new Course()
            {
                Name = "HQC",
                Description = string.Empty,
                Materials = "SOLID, Design Patterns"
            };

            var homework = new Homework()
            {
                HomeworkId = 1,
                CourseId = "HQC",
                StudentId = 1,
                Course = course,
                Student = student,
                DateSent = new DateTime(2015, 10, 10)
            };

            student.Courses.Add(course);
            student.Homeworks.Add(homework);
            course.Students.Add(student);
            course.Homeworks.Add(homework);

            db.Courses.Add(course);
            db.Homeworks.Add(homework);
            db.Students.Add(student);
            db.SaveChanges();
        }
    }
}
