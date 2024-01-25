using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; } = new List<Course>();

        public Student(string name)
        {
            Id = new Random().Next(100000, 999999);
            Name = name;
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (Course course in RegisteredCourses)
            {
                totalHours += course.WeeklyHours;
            }
            return totalHours;
        }
    }

}