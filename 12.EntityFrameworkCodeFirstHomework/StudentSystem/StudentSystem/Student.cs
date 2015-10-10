namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
            this.Homeworks = new List<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Course> Courses { get; set; }

        public virtual List<Homework> Homeworks { get; set; }

    }
}
