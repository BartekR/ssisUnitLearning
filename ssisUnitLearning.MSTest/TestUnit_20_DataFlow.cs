using SsisUnit;
using SsisUnitBase.EventArgs;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ssisUnitLearningMSTest
{
    [TestClass]
    public class TestUnit_20_DataFlow
    {
        private static SsisTestSuite testSuite;

        private SsisUnitBase.TestResult testResult;
        private Test test;
        private Context context;

        private bool isTestPassed;

        private List<string> messages = new List<string>();

        [ClassInitialize]
        public static void Init(TestContext tc)
        {
            testSuite = new SsisTestSuite(@"C:\Users\Administrator\source\repos\ssisUnitLearning\Tests\20_DataFlow.ssisUnit");
        }

        private void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if (e.AssertName != null)
            {
                testResult = e.TestExecResult;
                isTestPassed = isTestPassed & e.TestExecResult.TestPassed;
                if(e.TestExecResult.TestPassed == false)
                {
                    messages.Add(e.AssertName + " failed");
                }
            }
        }

        [TestMethod]
        public void DFT_LoadUsers()
        {
            //testSuite = new SsisTestSuite(@"C:\Users\Administrator\source\repos\ssisUnitLearning\Tests\01_OnlyParametersAndVariables.ssisUnit");
            test = testSuite.Tests["DFT LoadUsers"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        }
    }
}
