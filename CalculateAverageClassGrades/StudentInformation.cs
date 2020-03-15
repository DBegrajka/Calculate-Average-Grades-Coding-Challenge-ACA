using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
    public class StudentInformation
    {
        private string studentName;
        private int studentGrade;
        public string StudentName{ get { return studentName; } set { studentName = value; } }        
        public int StudentGrade{ get { return studentGrade; } set { studentGrade = value; } }

        public StudentInformation(string studentName, int studentGrade)
        {
            this.studentName = studentName;
            this.studentGrade = studentGrade;
        }
        public bool isGradeZero()
        {
            return studentGrade == 0;
        }
    }
}
