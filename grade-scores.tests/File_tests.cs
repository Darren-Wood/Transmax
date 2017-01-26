using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace grade_scores.tests
{
    [TestClass]
    public class File_tests
    {
        [TestMethod]
        [DeploymentItem("student.txt",".")]
        public void TestFile()
        {
            File target = new File("student.txt");
            String actual = target.GetFileContents();
            String expected =
        @"Stephanie,Wood,90
Darren,Wood,90
Rebekah,Wood,50
Judi,Bowring,90
Geoff,Bowring,99
John,Wood,75
Val,Wood,75
Janelle,Wood,75
Josh,Herron,80
Tom,Herron,75
Olivia,Herron,75
Melanie,Bowring,89";
        Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("studentEmpty.txt",".")]
        public void GetEmptyFile()
        {
            File target = new File("studentEmpty.txt");
            String actual = target.GetFileContents();
            String expected = "";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("student.txt", ".")]
        public void WritingToFile()
        {
            String fileName = "student.txt";
            String fileNameWithSuffix = "student-graded.txt";
            File target = new File(fileName);
            String expected = "Writing to file was a success";
            bool success = target.WriteToFile(expected);
            File target2 = new File(fileNameWithSuffix);
            String actual = target2.GetFileContents();
            Assert.AreEqual(expected, actual);
        }
        [ExpectedException(typeof(FileNotFoundException))]
        [TestMethod]
        public void FileDoesNotExist()
        {
            String fileNameThatDoesNotExist = "wrongFile.txt";
            File target = new File(fileNameThatDoesNotExist);
            target.GetFileContents();
        }
    }
}
