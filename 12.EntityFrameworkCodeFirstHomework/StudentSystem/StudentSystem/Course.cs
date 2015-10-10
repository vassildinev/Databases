namespace StudentSystem
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
            this.Homeworks = new List<Homework>();
        }

        [Key]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Homework> Homeworks { get; set; }
    }
}
