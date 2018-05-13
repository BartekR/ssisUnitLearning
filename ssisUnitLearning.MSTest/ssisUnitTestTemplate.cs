﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SsisUnit;
using SsisUnitBase.EventArgs;

namespace ssisUnitLearningMSTest2
{
    [TestClass]
	public class TestUnit_01_OnlyParametersAndVariables
    {
        private SsisTestSuite testSuite;
        private SsisUnitBase.TestResult testResult;
        private Test test;
        private Context context;

        private bool isTestPassed;

        private void TestSuiteAssertCompleted(object sender, AssertCompletedEventArgs e)
        {
            if(e.AssertName != null)
            {
                testResult = e.TestExecResult;
                isTestPassed = isTestPassed & e.TestExecResult.TestPassed;
            }
        }
	}
}