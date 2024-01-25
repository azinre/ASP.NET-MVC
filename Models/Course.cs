using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        private string code;
        private string title;
        private int weeklyHours;
        public string Code { get { return code; } }
        public string Title { get { return title; } }
        public int WeeklyHours { get { return weeklyHours; } set { weeklyHours = value; } }

        public Course(string code, string title)
        {
            this.code = code;
            this.title = title;
            weeklyHours = 0;
        }
    }
}