using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
     class AverageGradeCalculation {
        public static ClassGradeData calculateGradeData(ClassInformation classInfo)
        {
            int sumOfAllGrades = 0;
            double averageClassMarks = 0.0;
            int gradedStudents;
            List<String> studentsWithZeroMarks = new List<string>();
            List<StudentInformation> studentsInfo = classInfo.StudentInfo;
            foreach(StudentInformation studentInfo in studentsInfo)
            {
                if (!(studentInfo.isGradeZero()))
                    sumOfAllGrades += studentInfo.StudentGrade;
                else
                    studentsWithZeroMarks.Add(studentInfo.StudentName);
            }
            gradedStudents = studentsInfo.Count - studentsWithZeroMarks.Count;
            averageClassMarks = (double)sumOfAllGrades / (double)gradedStudents;
            ClassGradeData classGradeData = new ClassGradeData();
            classGradeData.ClassName = classInfo.ClassName;
            classGradeData.StudentsWithZeroMarks = studentsWithZeroMarks;
            classGradeData.GradedStudents = gradedStudents;
            classGradeData.ClassAverageGrade = averageClassMarks;
            return classGradeData;
        }        
        public static List<ClassGradeData> sortClasses(List<ClassGradeData> classesGradeData)
        {
            classesGradeData.Sort((class1, class2) => class2.ClassAverageGrade.CompareTo(class1.ClassAverageGrade));
            return classesGradeData;
        }
        public static double averageForAllStudents(List<ClassGradeData> classesGradeData)
        {
            return (double)classesGradeData.Sum((class1 => class1.ClassAverageGrade)) / (double)classesGradeData.Count;            
        }
    }
}
