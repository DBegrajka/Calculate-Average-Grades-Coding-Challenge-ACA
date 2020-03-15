using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
    class FileWriter
    {
        private StreamWriter writer;
        internal void writeOutputToFile(List<ClassGradeData> classesGradeData)
        {
            string FolderPath = ConfigurationManager.AppSettings["FolderPathOfOutputFileToWrite"];
            using (writer = new StreamWriter(FolderPath + "/Output Average Class Grades.txt"))
            {
                writer.WriteLine("American Credit Acceptance Coding Challenge Output ");
                writer.WriteLine();
                write_highestPerformingClass(classesGradeData);
                write_totalAverage(classesGradeData);
                writer.WriteLine("-> Ques: [5.c] For each class:");
                writer.WriteLine();
                foreach (ClassGradeData classGradeData in classesGradeData)
                {
                    write_classAverage(classGradeData);
                }
            }
        }
        private double UptoOneDecimalPoints(double averageGrade)
        {
            var AverageClassGrade = Convert.ToDouble(String.Format("{0:0.0}", averageGrade));
            return AverageClassGrade;
        }
        private void write_highestPerformingClass(List<ClassGradeData> classesGradeData)
        {
            List<ClassGradeData> sortedClass = AverageGradeCalculation.sortClasses(classesGradeData);
            writer.WriteLine("-> Ques: [5.a] The highest Performing Class:");
            writer.WriteLine("\t Name= {0}, Average Grade = {1}", sortedClass.First().ClassName, sortedClass.First().ClassAverageGrade);
            writer.WriteLine();
        }
        private void write_totalAverage(List<ClassGradeData> classesGradeData)
        {
            double averageScoreForAllStudents = UptoOneDecimalPoints(AverageGradeCalculation.averageForAllStudents(classesGradeData));
            writer.WriteLine("-> Ques: [5.b] The average score for all students regardless of class:");
            writer.WriteLine("\t Average Score = {0}", averageScoreForAllStudents);
            writer.WriteLine();
        }
        private void write_classAverage(ClassGradeData classGradeData)
        {
            writer.WriteLine("\t Name of the Class = {0} ", classGradeData.ClassName);
            writer.WriteLine();
            writer.WriteLine("\t i. Average score for the class = {0}", UptoOneDecimalPoints(classGradeData.ClassAverageGrade));
            writer.WriteLine("\t ii. Total number of students within the class = {0}", classGradeData.GradedStudents + classGradeData.StudentsWithZeroMarks.Count);
            writer.WriteLine("\t iii. The number of students used to calculate the class average = {0}", classGradeData.GradedStudents);
            if (classGradeData.StudentsWithZeroMarks.Count > 0)
            {
                writer.WriteLine("\t iv. The names of any students who were discarded from consideration:");
                foreach (string name in classGradeData.StudentsWithZeroMarks)
                {
                    writer.WriteLine("\t\t - {0}", name);
                    writer.WriteLine();
                }
            }
            else
            {
                writer.WriteLine("\t iv. All the students were considered");
                writer.WriteLine();
            }
        }
    }
}
