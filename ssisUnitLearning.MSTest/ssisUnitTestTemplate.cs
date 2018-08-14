// the code uses parts of work by Ravi Palihena
// https://github.com/rarpal/SampleSSISUnit
// and source code of TestRunnerUI


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SsisUnit;
using SsisUnitBase.EventArgs;

namespace ssisUnitLearningMSTest
{
    [TestClass]
	public class TestUnit_01_OnlyParametersAndVariables
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
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
        } // end TestMethod

        [TestMethod]
        public void Test_SEQCSomecontainer()
        {
            test = testSuite.Tests["SEQC Some container"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_05_SQLTask_LocalCM
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\05_SQLTask_LocalCM.ssisUnit");
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
        public void Test_SQLLoadnamesofthefiles()
        {
            test = testSuite.Tests["SQL Load names of the files"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_FELCLoadfilenames()
        {
            test = testSuite.Tests["FELC Load file names"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_10_ProjectCM
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\10_ProjectCM.ssisUnit");
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
        public void Test_SQLSELECT1()
        {
            test = testSuite.Tests["SQL SELECT 1"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_SQLGetSourceSystemId_PackageScope_()
        {
            test = testSuite.Tests["SQL Get SourceSystemId (Package Scope)"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_SQLGetSourceSystemId_ContainerScope_()
        {
            test = testSuite.Tests["SQL Get SourceSystemId (Container Scope)"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_11_TruncateTable
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\11_TruncateTable.ssisUnit");
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
        public void Test_SQLCountrecordsaftertruncate()
        {
            test = testSuite.Tests["SQL Count records after truncate"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_SQLCountrecordsbeforetruncate()
        {
            test = testSuite.Tests["SQL Count records before truncate"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_SQLTRUNCATETABLETruncateSample()
        {
            test = testSuite.Tests["SQL TRUNCATE TABLE TruncateSample"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_11_TruncateTable_NoTruncationTest
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\11_TruncateTable_NoTruncationTest.ssisUnit");
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
        public void Test_SQLCountrecordsaftertruncate()
        {
            test = testSuite.Tests["SQL Count records after truncate"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_SQLCountrecordsbeforetruncate()
        {
            test = testSuite.Tests["SQL Count records before truncate"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_15_Users_Dataset
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\15_Users_Dataset.ssisUnit");
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
        public void Test_SQLMERGEUsers_Emptytable()
        {
            test = testSuite.Tests["SQL MERGE Users: Empty table"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_15_Users_Dataset_Persisted
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\15_Users_Dataset_Persisted.ssisUnit");
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
        public void Test_SQLMERGEUsers_Emptytable()
        {
            test = testSuite.Tests["SQL MERGE Users: Empty table"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\20_DataFlow.ssisUnit");
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
        public void Test_DFTLoadUsers()
        {
            test = testSuite.Tests["DFT LoadUsers"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_30_Expressions
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\30_Expressions.ssisUnit");
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
        public void Test_Calculatedefaultdates()
        {
            test = testSuite.Tests["Calculate default dates"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_60_Loops
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\60_Loops.ssisUnit");
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
        public void Test_FLCEvaluateexpression()
        {
            test = testSuite.Tests["FLC Evaluate expression"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

        [TestMethod]
        public void Test_EXPRAdd6()
        {
            test = testSuite.Tests["EXPR Add 6"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_Empty
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\Empty.ssisUnit");
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
	}   // end Test

    [TestClass]
	public class TestUnit_MSDB_Loop
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\MSDB_Loop.ssisUnit");
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
        public void Test_Test1()
        {
            test = testSuite.Tests["Test1"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_PackageStore_Loop
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\PackageStore_Loop.ssisUnit");
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
        public void Test_Test1()
        {
            test = testSuite.Tests["Test1"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    [TestClass]
	public class TestUnit_SSISCatalog_Dataset
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
            //System.Console.WriteLine(System.Environment.CurrentDirectory);
			testSuite = new SsisTestSuite(@"..\..\..\Tests\SSISCatalog_Dataset.ssisUnit");
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
        public void Test_SQLMERGEUsers_Emptytable()
        {
            test = testSuite.Tests["SQL MERGE Users: Empty table"];
            context = testSuite.CreateContext();

            testSuite.AssertCompleted += TestSuiteAssertCompleted;
            isTestPassed = true;

            bool rs = test.Execute(context);

            testSuite.AssertCompleted -= TestSuiteAssertCompleted;

            Assert.AreEqual<bool>(true, isTestPassed, System.String.Join(";", messages));
        } // end TestMethod

	}   // end Test

    
}   // end namespace

