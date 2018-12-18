using NUnit.Framework;
using System;
using System.IO;

namespace NUnitHomeworkP1MMorozyouk
{
    [SetUpFixture]
    public class SetupClass
    {
        string testDirPath;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var testMethodName = TestContext.CurrentContext.Test.ClassName;
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"TEST {dateTime}");
            Directory.CreateDirectory(path);
            testDirPath = path;
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            var sourcePath = testDirPath;
            var destinationPath = Path.Combine("C:\\TestResults", Path.GetFileName(testDirPath));

            Directory.CreateDirectory(destinationPath);
        }
    }
}
