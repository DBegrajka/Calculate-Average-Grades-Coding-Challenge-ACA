using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
    class ClassGradeData
    {
        private string className;
        private double classAverageGrade;
        private int gradedStudents;
        private List<string> studentsWithZeroMarks;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        public double ClassAverageGrade
        {
            get { return classAverageGrade; }
            set { classAverageGrade = value; }
        }
        public int GradedStudents
        {
            get { return gradedStudents; }
            set { gradedStudents = value; }
        }
        public List<string> StudentsWithZeroMarks
        {
            get { return studentsWithZeroMarks; }
            set { studentsWithZeroMarks = value; }
        }
    }
}
