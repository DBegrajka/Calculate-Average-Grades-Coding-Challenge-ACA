using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAverageClassGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            List<ClassInformation> classInformation =  fileReader.readFiles();
            if(classInformation.Count > 0)
            {
                List<ClassGradeData> classGradeData = new List<ClassGradeData>();
                foreach (ClassInformation classInfo in classInformation)
                {
                    classGradeData.Add(AverageGradeCalculation.calculateGradeData(classInfo));
                }                
                FileWriter filewrite = new FileWriter();
                filewrite.writeOutputToFile(classGradeData);
            }
            else
            {
                Console.WriteLine("Class data doesn't exist");
            }
        }
    }
}
