using SsisUnit;
using SsisUnitBase.Enums;
using SsisUnit.Packages;
using SsisUnit.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ssisUnitLearning.API
{
    [TestClass]
    public class Test_15_Users_Dataset
    {
        [TestMethod]
        public void SQL_MERGE_Users_Empty_table()
        {
            // a new test suite
            SsisTestSuite ts = new SsisTestSuite();

            // the package to test; three times .., because test dll is in .\bin\Development
            PackageRef p = new PackageRef(
                "15_Users_Dataset",
                @"..\..\..\Assets\ispac\ssisUnitLearning.ispac",
                "15_Users_Dataset.dtsx",
                PackageStorageType.FileSystem
            );

            // the connection for the datasets
            ConnectionRef c = new ConnectionRef(
                "ssisUnitLearningDB",
                @"Provider=SQLNCLI11.1;Data Source=.\SQL2017;Integrated Security=SSPI;Initial Catalog=ssisUnitLearningDB;Auto Translate=False",
                ConnectionRef.ConnectionTypeEnum.ConnectionString
            );

            // let the test suite know about the ConnectionRef and the PackageRef
            ts.ConnectionList.Add(c.ReferenceName, c);
            ts.PackageList.Add(p.Name, p);

            // expected and actual datasets
            Dataset expected = new Dataset(ts, "Empty table test: expected dataset", c, false, @"SELECT *
FROM(
    VALUES
        (CAST('Name 1' AS VARCHAR(50)), CAST('Login 1' AS CHAR(12)), CAST(1 AS BIT), CAST(1 AS INT), CAST(2 AS TINYINT), CAST(0 AS BIT)),
        (CAST('Name 2' AS VARCHAR(50)), CAST('Login 2' AS CHAR(12)), CAST(1 AS BIT), CAST(2 AS INT), CAST(2 AS TINYINT), CAST(0 AS BIT)),
        (CAST('Name 3' AS VARCHAR(50)), CAST('Login 3' AS CHAR(12)), CAST(0 AS BIT), CAST(3 AS INT), CAST(2 AS TINYINT), CAST(0 AS BIT))
)x(Name, Login, IsActive, Id, SourceSystemId, IsDeleted)
ORDER BY Id; ");

            Dataset actual = new Dataset(ts, "Empty table test: actual dataset", c, false, @"SELECT
    Name,
    Login,
    IsActive,
    SourceId,
    SourceSystemId,
    IsDeleted
FROM dbo.Users
 ORDER BY SourceId;");

            // add the datasets to the test suite
            ts.Datasets.Add(expected.Name, expected);
            ts.Datasets.Add(actual.Name, actual);

            // the test
            Test t = new Test(ts, "SQL MERGE Users: Empty table", "15_Users_Dataset", null, "{FB549B65-6F0D-4794-BA8E-3FF975A6AE0B}");
            ts.Tests.Add(t.Name, t);

            // test setup
            SqlCommand s1 = new SqlCommand(ts, "ssisUnitLearningDB", false, @"WITH stgUsers AS (
SELECT *
FROM (
    VALUES
        ('Name 1', 'Login 1', 1, 1, 2, -1),
        ('Name 2', 'Login 2', 1, 2, 2, -1),
        ('Name 3', 'Login 3', 0, 3, 2, -1)
)x (Name, Login, IsActive, Id, SourceSystemId, InsertedAuditId)
)
INSERT INTO stg.Users (
    Name, Login, IsActive, Id, SourceSystemId, InsertedAuditId
)
SELECT
    Name, Login, IsActive, Id, SourceSystemId, InsertedAuditId
FROM stgUsers
;");

            // add the setup to the test
            t.TestSetup.Commands.Add(s1);

            // test asserts and asserts' commands
            SsisAssert a1 = new SsisAssert(ts, t, "Assert: Added 3 records", 3, false);
            a1.Command = new SqlCommand(ts, "ssisUnitLearningDB", true, "SELECT COUNT(*) FROM dbo.Users;");

            SsisAssert a2 = new SsisAssert(ts, t, "Assert: dbo.Users has expected records", true, false);
            a2.Command = new DataCompareCommand(ts, "", expected, actual);

            // add the asserts to the test
            t.Asserts.Add(a1.Name, a1);
            t.Asserts.Add(a2.Name, a2);

            // test teardown
            SqlCommand t1 = new SqlCommand(ts, "ssisUnitLearningDb", false, "TRUNCATE TABLE stg.Users;");
            SqlCommand t2 = new SqlCommand(ts, "ssisUnitLearningDb", false, "TRUNCATE TABLE dbo.Users;");

            // add the teardown commands to the test
            // add the setup to the test
            t.TestTeardown.Commands.Add(t1);
            t.TestTeardown.Commands.Add(t2);

            // execute the test suite
            ts.Execute();

            // verify if everything is OK; we expect 3 asserts to pass
            Assert.AreEqual(3, ts.Statistics.GetStatistic(StatisticEnum.AssertPassedCount));

            // show me the XML version of the test - only in debug mode (internal method)
            //System.Console.Write(ts.PersistToXml);
        }

    }
}
