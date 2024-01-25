using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = selectedCourses.Sum(course => course.WeeklyHours);

            if (totalWeeklyHours > MaxWeeklyHours)
            {
                throw new Exception($"Cannot register for more than {MaxWeeklyHours} weekly hours.");
            }

            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Full time)";
        }
    }

}