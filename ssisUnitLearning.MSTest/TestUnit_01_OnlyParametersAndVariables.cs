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

namespace ssisUnitLearningMSTestExample
{
    [TestClass]
    public class TestUnit_01_OnlyParametersAndVariables
    {
        // testSuite has to be static or the error comes out:
        // An object reference is required for the non-static field, method, or property 'TestUnit_01_OnlyParametersAndVariables.testSuite'	ssisUnitLearning.MSTest C:\Users\Administrator\source\repos\ssisUnitLearning\ssisUnitLearning.MSTest\TestUnit_01_OnlyParametersAndVariables.cs
        private static SsisTestSuite testSuite;
        private SsisUnitBase.TestResult testResult;
        private Test test;
        private Context context;

        private bool isTestPassed;

        private List<string> messages = new List<string>();

        [ClassInitialize]
        // class has to be like in the error message
        // Message: Method ssisUnitLearningMSTest.TestUnit_01_OnlyParametersAndVariables.Init has wrong signature.
        // The method must be static, public, does not return a value and should take a single parameter of type TestContext.
        // Additionally, if you are using async-await in method then return-type must be Task.
        public static void Init(TestContext tc)
        {
            // ssisUnitLearningMSTest.dll is in subfolder bin\Debug and Tests folder is parallel, that's why ..\..\..
            testSuite = new SsisTestSuite(@"..\..\..\Tests\01_OnlyParametersAndVariables.ssisUnit");
        }

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
