using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
    class ClassInformation
    {
        private List<StudentInformation> studentInfo;
        private string className;
        public List<StudentInformation> StudentInfo
        {
            get { return studentInfo; }
            set { studentInfo = value; }
        }
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public ClassInformation(string className, List<StudentInformation> studentInfo)
        {
            this.className = className;
            this.studentInfo = studentInfo;
        }
    }
}
