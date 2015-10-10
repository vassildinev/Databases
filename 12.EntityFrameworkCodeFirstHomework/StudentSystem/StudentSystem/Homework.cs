namespace StudentSystem
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime DateSent { get; set; }

        public string CourseId { get; set; }

        public int StudentId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
