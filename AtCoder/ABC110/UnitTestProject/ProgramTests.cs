using ABC110D___Factorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass()]
public class ProgramTests
{

    //テストケース
    [TestMethod()]
    public void MainTest1() { TestInOut("TestCases/Input1.txt",  "TestCases/Output1.txt"); } //変更する
    [TestMethod()]
    public void MainTest2() { TestInOut("TestCases/Input2.txt", "TestCases/Output2.txt"); } //変更する
    [TestMethod()]
    public void MainTest3() { TestInOut("TestCases/Input3.txt", "TestCases/Output3.txt"); } //変更する
    //[TestMethod()]
    //public void MainTest4() { TestInOut("TestCases/Input4.txt", "TestCases/Output4.txt"); } //変更する
    //[TestMethod()]
    //public void MainTest5() { TestInOut("TestCases/Input5.txt", "TestCases/Output5.txt"); } //変更する

    public void TestInOut(string inputFileName, string outputFileName)
    {
        using (var input = new StreamReader(inputFileName))
        using (var output = new StringWriter())
        {
            Console.SetOut(output);
            Console.SetIn(input);
            Program.Main(new string[0]);

            Assert.AreEqual(File.ReadAllText(outputFileName), output.ToString());
        }
    }
}