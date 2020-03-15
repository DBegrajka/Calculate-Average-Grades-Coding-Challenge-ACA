using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CalculateAverageClassGrades
{
    class FileReader
    {
        public List<ClassInformation> readFiles()
        {
            try
            {
                string folderPath= ConfigurationManager.AppSettings["FolderPathOfInputFilesToRead"];
                var filesToRead = Directory.EnumerateFiles(folderPath, "*.csv");
                char[] seperators = { ',', '\\', '.' };
                String[] readColumns;
                List<ClassInformation> classInformation = new List<ClassInformation>();
                foreach (string file in filesToRead)
                {
                    List<StudentInformation> studentInfo = new List<StudentInformation>();
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        streamReader.ReadLine();
                        while(streamReader.Peek() != -1)
                        {
                            readColumns = streamReader.ReadLine().Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                            int studentGrade;
                            if (Int32.TryParse(readColumns[1], out studentGrade))
                                studentInfo.Add(new StudentInformation(readColumns[0], studentGrade));                            
                            else
                                Console.WriteLine("Student grade of Wrong Format");                                                      
                        }
                    }
                    String[] className = file.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    classInformation.Add(new ClassInformation (className[1], studentInfo));
                }
                return classInformation;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception = {0}", exception.Message);
                return new List<ClassInformation>();
            }
        }
    }
}
