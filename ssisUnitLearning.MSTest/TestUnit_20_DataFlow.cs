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
            // ssisUnitLearningMSTest.dll is in subfolder bin\Debug and Tests folder is parallel, that's why ..\..\..
            testSuite = new SsisTestSuite(@"..\..\..\Tests\20_DataFlow.ssisUnit");
        }

        private void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if (e.AssertName != null)
            {
                testResult = e.TestExecResult;
                isTestPassed = isTestPassed & e.TestExecResult.TestPassed;
                if(e.TestExecResult.TestPassed == false)
                {
                    messages.Add(e.AssertName + " failed: " + e.TestExecResult.TestResultMsg);
                }
            }
        }

        [TestMethod]
        public void DFT_LoadUsers()
        {
            test = testSuite.Tests["DFT LoadUsers"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, rs, "Package did not execute");
            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        }
    }
}
