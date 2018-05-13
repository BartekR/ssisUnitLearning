// the code uses parts of work by Ravi Palihena
// https://github.com/rarpal/SampleSSISUnit
// and source code of TestRunnerUI

// if there are problems, disable DotNet Extensions for Text Explorer
// example: Unable to fetch source Information for test method: ssisUnitLearningMSTest.TestUnit_01_OnlyParametersAndVariables.Test_01_OnlyParametersAndVariables contained in project: ssisUnitLearningMSTest.
// that happened to me wih failing tests on SSDT 15.5.6
// upgrading to SSDT 15.6.5 solved the problem
// https://developercommunity.visualstudio.com/content/problem/158160/unable-to-fetch-source-information-for-test-method.html


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SsisUnit;
using SsisUnitBase.EventArgs;

namespace ssisUnitLearningMSTest
{
    [TestClass]
    public class TestUnit_01_OnlyParametersAndVariables
    {
        private SsisTestSuite testSuite;
        private SsisUnitBase.TestResult testResult;
        private Test test;
        private Context context;

        private bool isTestPassed;

        private List<string> messages = new List<string>();

        private void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if(e.AssertName != null)
            {
                testResult = e.TestExecResult;
                isTestPassed = isTestPassed & e.TestExecResult.TestPassed;
                if (e.TestExecResult.TestPassed == false)
                {
                    messages.Add(e.AssertName + " failed");
                }
            }
        }

        [TestMethod]
        public void Test_01_OnlyParametersAndVariables()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Administrator\source\repos\ssisUnitLearning\Tests\01_OnlyParametersAndVariables.ssisUnit");
            test = testSuite.Tests["01_OnlyParametersAndVariables"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        }

        [TestMethod]
        public void Test_01_OnlyParametersAndVariablesv3()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Administrator\source\repos\ssisUnitLearning\Tests\01_OnlyParametersAndVariables_v3.ssisUnit");
            test = testSuite.Tests["01_OnlyParametersAndVariables"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }

        [TestMethod]
        public void Test_SEQC_Some_container()
        {
            testSuite = new SsisTestSuite(@"C:\Users\Administrator\source\repos\ssisUnitLearning\Tests\01_OnlyParametersAndVariables.ssisUnit");
            test = testSuite.Tests["SEQC Some container"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;
        }
    }
}
