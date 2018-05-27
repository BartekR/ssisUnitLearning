<Query Kind="Statements" />

// use this code in Linqpad (http://linqpad.net) using C# Statement(s)

// the data from SQL Server
System.Data.DataTable expectedDataTable;

// the metadata
System.Data.DataTable metadata = new System.Data.DataTable("metadata");

metadata.Columns.Add("ColumnName", typeof(System.String));
metadata.Columns.Add("Value", typeof(System.String));
metadata.Columns.Add("Type", typeof(System.String));
metadata.Columns.Add("Length", typeof(System.Int32));
metadata.Columns.Add("MaxLength", typeof(System.Int32));

// to connect to the database I follow the sisUnit source code and ue the parts of it, ike usig factoryInvariantName from the helper methods
string factoryInvariantName = "System.Data.OleDb";
var dbFactory = System.Data.Common.DbProviderFactories.GetFactory(factoryInvariantName);

System.Data.Common.DbConnection conn = dbFactory.CreateConnection();

// I connect from host to the SQL Server on the VM using port forwarding, so I use sa user and the password, not the SSPI security
conn.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=ssisUnitLearningDB;Provider=SQLNCLI11.1;User ID=sa;Password=123qwe!@#;Auto Translate=False;";

System.Data.Common.DbCommand dbCommand = dbFactory.CreateCommand();

dbCommand.Connection = conn;

//It's enough to get one row for the metadata
dbCommand.CommandText = "SELECT TOP 1 * FROM dbo.Users;";

dbCommand.Connection.Open();

// there I used the ssisUnit RetrieveDataTable() fragment from DataTable.cs
using (IDataReader expectedReader = dbCommand.ExecuteReader())
{
    var ds = new DataSet();

    ds.Load(expectedReader, LoadOption.OverwriteChanges, new[] { "Results" });
    expectedDataTable = ds.Tables[0];
}

// the Dump() method is exposed by Linqpad
expectedDataTable.Dump();

//System.Diagnostics.Debug.Print(expectedDataTable.Rows.Count.ToString());

// iterate the DataTable rows to get the metadata
foreach (DataRow row in expectedDataTable.Rows)
{
	for(int x = 0; x < expectedDataTable.Columns.Count; x++)
	{
		metadata.Rows.Add(new object[] {
			expectedDataTable.Columns[x].ColumnName.ToString(), 
			row[x].ToString(),
			row[x].GetType().ToString(),
			row[x].GetType().ToString() == "System.String" ? row[x].ToString().Length : -1,
			expectedDataTable.Columns[x].MaxLength
		});
		metadata.AcceptChanges();
	}
}

// again, using Linqpad's Dump()
metadata.Dump();

//System.Diagnostics.Debug.Print(expectedDataTable.ToString());